using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileContentExporter
{
    public partial class frmFileExporter : Form
    {
        #region P/Invoke + a size guard
        // Suspends RichTextBox repainting while we apply per-token colors,
        // so highlighting a large file doesn't flicker or crawl.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0x000B;

        // Skip highlighting past this size — plain text stays instant, coloring huge
        // output via thousands of Select() calls would not.
        private const int MaxHighlightChars = 400_000;
        // Info stored in each TreeNode.Tag so we can tell files apart from
        // folders without re-hitting the filesystem (and it survives even
        // for empty folders, unlike checking node.Nodes.Count == 0).
        private class FileSystemNodeInfo
        {
            public string FullPath;
            public bool IsDirectory;
        }

        private static readonly HashSet<string> ExcludedFolders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "bin", "obj", ".git", ".vs", "node_modules", "packages", ".idea"
        };

        private static readonly HashSet<string> BinaryExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".dll", ".exe", ".pdb", ".png", ".jpg", ".jpeg", ".gif", ".ico",
            ".bmp", ".zip", ".pfx", ".snk", ".cache", ".suo", ".resources"
        };

        private string _rootPath;
        private bool _isCheckingProgrammatically;
        private List<string> _recentPaths = new List<string>();
        private CheckedListBox clbExtensions;
        private GitIgnoreFilter _gitIgnore;
        private List<string> _filterPatterns = new List<string>(); // from txtFilter, e.g. *.cs;*.xaml
        private HashSet<string> _excludedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private ComboBox cmbRecentPaths;
        private TextBox txtFilter;
        private int _lastFindIndex = 0;
        #endregion

        public frmFileExporter()
        {
            InitializeComponent();
            ApplyDraculaTheme();
            SetupDragDrop();
            SetupRecentPathsAndFilter();
            SetupFindShortcut();
            RestoreSession();
            UpdateStatus();
        }
        private void SetupRecentPathsAndFilter()
        {
            // Recent paths dropdown, placed under the path textbox in pnlTop.
            cmbRecentPaths = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(12, 52),
                Width = 300,
                BackColor = DraculaTheme.Background,
                ForeColor = DraculaTheme.Foreground
            };
            cmbRecentPaths.SelectedIndexChanged += (s, e) =>
            {
                if (cmbRecentPaths.SelectedItem != null)
                {
                    txtPath.Text = cmbRecentPaths.SelectedItem.ToString();
                    btnLoadTree_Click(s, EventArgs.Empty);
                }
            };
            pnlTop.Controls.Add(cmbRecentPaths);

            // Filter box, placed in the tree toolbar.
            txtFilter = new TextBox
            {
                Dock = DockStyle.Right,
                Width = 160,
                BackColor = DraculaTheme.Background,
                ForeColor = DraculaTheme.Foreground,
                BorderStyle = BorderStyle.FixedSingle
            };
            // Simple placeholder behavior (no native PlaceholderText on .NET Framework TextBox).
            txtFilter.Text = "*.cs;*.xaml";
            txtFilter.ForeColor = DraculaTheme.Comment;
            txtFilter.Enter += (s, e) =>
            {
                if (txtFilter.Text == "*.cs;*.xaml")
                {
                    txtFilter.Text = "";
                    txtFilter.ForeColor = DraculaTheme.Foreground;
                }
            };
            txtFilter.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ApplyFilterAndReload();
                }
            };
            pnlTreeToolbar.Controls.Add(txtFilter);

            CreateExtensionChecklist();
        }

        private void ApplyFilterAndReload()
        {
            _filterPatterns = string.IsNullOrWhiteSpace(txtFilter.Text) || txtFilter.Text == "*.cs;*.xaml"
                ? new List<string>()
                : txtFilter.Text.Split(';').Where(p => !string.IsNullOrWhiteSpace(p)).ToList();

            if (string.IsNullOrEmpty(_rootPath)) return;

            Cursor = Cursors.WaitCursor;
            try { PopulateTree(_rootPath); }
            finally { Cursor = Cursors.Default; }
            RefreshExtensionChecklist();
        }

        private void RememberRecentPath(string path)
        {
            _recentPaths.Remove(path);
            _recentPaths.Insert(0, path);
            if (_recentPaths.Count > 8) _recentPaths.RemoveRange(8, _recentPaths.Count - 8);

            cmbRecentPaths.Items.Clear();
            cmbRecentPaths.Items.AddRange(_recentPaths.ToArray());
        }
        private void SetupDragDrop()
        {
            AllowDrop = true;
            DragEnter += (s, e) =>
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

            DragDrop += (s, e) =>
            {
                var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (paths == null || paths.Length == 0) return;

                string dropped = paths[0];
                txtPath.Text = File.Exists(dropped) ? Path.GetDirectoryName(dropped) : dropped;
                btnLoadTree_Click(s, EventArgs.Empty);
            };
        }
        private void RestoreSession()
        {
            AppSettings.Load();
            _recentPaths = new List<string>(AppSettings.RecentPaths);
            cmbRecentPaths.Items.AddRange(_recentPaths.ToArray());

            if (!string.IsNullOrEmpty(AppSettings.LastRootPath) && Directory.Exists(AppSettings.LastRootPath))
                txtPath.Text = AppSettings.LastRootPath; // populate only — user clicks Load Tree to restore
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var fileNodes = new List<TreeNode>();
            CollectCheckedFileNodes(treeViewFiles.Nodes, fileNodes);
            var checkedRelative = fileNodes
                .Select(n => GetRelativePath(((FileSystemNodeInfo)n.Tag).FullPath))
                .ToList();

            AppSettings.Save(_rootPath, _recentPaths, checkedRelative);
        }
        // ---------- Theming ----------

        private void ApplyDraculaTheme()
        {
            BackColor = DraculaTheme.Background;

            // Top bar
            pnlTop.BackColor = DraculaTheme.CurrentLine;
            lblPath.ForeColor = DraculaTheme.Foreground;
            chkExcludeCommon.ForeColor = DraculaTheme.Foreground;
            chkExcludeCommon.BackColor = Color.Transparent;

            txtPath.BackColor = DraculaTheme.Background;
            txtPath.ForeColor = DraculaTheme.Foreground;
            txtPath.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnBrowseFolder, DraculaTheme.Purple);
            StyleButton(btnBrowseFile, DraculaTheme.Purple);
            StyleButton(btnLoadTree, DraculaTheme.Green);

            // Tree panel
            pnlTreeToolbar.BackColor = DraculaTheme.CurrentLine;
            treeViewFiles.BackColor = DraculaTheme.Background;
            treeViewFiles.ForeColor = DraculaTheme.Foreground;
            treeViewFiles.LineColor = DraculaTheme.Comment;
            treeViewFiles.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnCheckAll, DraculaTheme.Green);
            StyleButton(btnUncheckAll, DraculaTheme.Red);

            // Output panel
            pnlOutputToolbar.BackColor = DraculaTheme.CurrentLine;
            txtOutput.BackColor = DraculaTheme.Background;
            txtOutput.ForeColor = DraculaTheme.Foreground;
            txtOutput.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnGenerate, DraculaTheme.Purple);
            StyleButton(btnCopyAll, DraculaTheme.Cyan);
            StyleButton(btnSaveOutput, DraculaTheme.Cyan);
            StyleButton(btnClearOutput, DraculaTheme.Red);
            chkSyntaxHighlighting.ForeColor = DraculaTheme.Foreground;
            chkSyntaxHighlighting.BackColor = Color.Transparent;

            // Splitter + status bar
            splitContainerMain.BackColor = DraculaTheme.Comment;
            statusStrip1.BackColor = DraculaTheme.CurrentLine;
            toolStripStatusLabel1.ForeColor = DraculaTheme.Foreground;
        }

        private void StyleButton(Button btn, Color accent)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = DraculaTheme.CurrentLine;
            btn.ForeColor = DraculaTheme.Foreground;
            btn.FlatAppearance.BorderColor = accent;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(DraculaTheme.CurrentLine, 0.2f);
            btn.FlatAppearance.MouseDownBackColor = accent;
        }

        // ---------- Path selection ----------

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the root folder to explore.";
                dlg.ShowNewFolderButton = false;
                if (!string.IsNullOrEmpty(txtPath.Text) && Directory.Exists(txtPath.Text))
                    dlg.SelectedPath = txtPath.Text;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtPath.Text = dlg.SelectedPath;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a .sln or .csproj file";
                dlg.Filter = "Solution/Project Files (*.sln;*.csproj;*.vbproj)|*.sln;*.csproj;*.vbproj|All Files (*.*)|*.*";
                dlg.CheckFileExists = true;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtPath.Text = Path.GetDirectoryName(dlg.FileName);
            }
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLoadTree_Click(sender, EventArgs.Empty);
            }
        }

        // ---------- Tree loading ----------

        private void btnLoadTree_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Enter or browse to a folder path first.", "Path Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Allow pasting a .sln/.csproj path directly — resolve to its containing folder.
            if (File.Exists(path))
                path = Path.GetDirectoryName(path);

            path = (path ?? string.Empty).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                MessageBox.Show("The specified folder does not exist:\n" + path, "Invalid Path",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtPath.Text = path;
            _rootPath = path;
            _gitIgnore = GitIgnoreFilter.LoadFrom(path);

            Cursor = Cursors.WaitCursor;
            try
            {
                PopulateTree(path);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            RefreshExtensionChecklist();
            RememberRecentPath(path);
            txtOutput.Clear();
            UpdateStatus();
            RestoreCheckedState(treeViewFiles.Nodes, AppSettings.LastCheckedRelativePaths);
        }
        private void RestoreCheckedState(TreeNodeCollection nodes, List<string> relativePaths)
        {
            if (relativePaths == null || relativePaths.Count == 0) return;
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is FileSystemNodeInfo info && !info.IsDirectory &&
                    relativePaths.Contains(GetRelativePath(info.FullPath)))
                    node.Checked = true;
                RestoreCheckedState(node.Nodes, relativePaths);
            }
        }
        private void SetupFindShortcut()
        {
            txtOutput.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.F)
                {
                    e.SuppressKeyPress = true;
                    ShowFindBox();
                }
            };
        }
        private void ShowFindBox()
        {
            string term = Microsoft.VisualBasic.Interaction.InputBox(
                "Find:", "Find in Output", "");
            if (string.IsNullOrEmpty(term)) return;

            int index = txtOutput.Find(term, _lastFindIndex, RichTextBoxFinds.None);
            if (index == -1 && _lastFindIndex > 0)
                index = txtOutput.Find(term, 0, RichTextBoxFinds.None); // wrap around

            if (index >= 0)
            {
                txtOutput.Select(index, term.Length);
                txtOutput.ScrollToCaret();
                _lastFindIndex = index + term.Length;
            }
            else
            {
                MessageBox.Show("Not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _lastFindIndex = 0;
            }
        }
        // Called from SetupRecentPathsAndFilter() at startup — see below.
        private void CreateExtensionChecklist()
        {
            clbExtensions = new CheckedListBox
            {
                Dock = DockStyle.Bottom,
                Height = 90,
                CheckOnClick = true,
                BackColor = DraculaTheme.Background,
                ForeColor = DraculaTheme.Foreground,
                BorderStyle = BorderStyle.FixedSingle
            };
            clbExtensions.ItemCheck += (s, e) =>
            {
                // ItemCheck fires before the change is applied — defer the rebuild.
                BeginInvoke((Action)(() =>
                {
                    _excludedExtensions = clbExtensions.CheckedItems.Cast<string>()
                        .Select(x => true).Any() // placeholder guard, real logic below
                        ? _excludedExtensions : _excludedExtensions;

                    _excludedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    for (int i = 0; i < clbExtensions.Items.Count; i++)
                        if (!clbExtensions.GetItemChecked(i))
                            _excludedExtensions.Add((string)clbExtensions.Items[i]);

                    if (!string.IsNullOrEmpty(_rootPath))
                    {
                        Cursor = Cursors.WaitCursor;
                        try { PopulateTree(_rootPath); }
                        finally { Cursor = Cursors.Default; }
                    }
                }));
            };
            splitContainerMain.Panel1.Controls.Add(clbExtensions);
        }

        private void RefreshExtensionChecklist()
        {
            var extensions = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            CollectExtensions(treeViewFiles.Nodes, extensions);

            clbExtensions.Items.Clear();
            foreach (var ext in extensions)
                clbExtensions.Items.Add(string.IsNullOrEmpty(ext) ? "(none)" : ext, !_excludedExtensions.Contains(ext));
        }

        private void CollectExtensions(TreeNodeCollection nodes, SortedSet<string> result)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is FileSystemNodeInfo info && !info.IsDirectory)
                    result.Add(Path.GetExtension(info.FullPath));
                CollectExtensions(node.Nodes, result);
            }
        }

        private void PopulateTree(string rootPath)
        {
            treeViewFiles.Nodes.Clear();
            treeViewFiles.BeginUpdate();
            try
            {
                string rootName = Path.GetFileName(rootPath);
                if (string.IsNullOrEmpty(rootName))
                    rootName = rootPath; // e.g. a drive root like "C:\"

                var rootNode = new TreeNode(rootName)
                {
                    Tag = new FileSystemNodeInfo { FullPath = rootPath, IsDirectory = true }
                };

                BuildTree(rootNode, rootPath);

                treeViewFiles.Nodes.Add(rootNode);
                rootNode.Expand();
            }
            finally
            {
                treeViewFiles.EndUpdate();
            }
        }

        private void BuildTree(TreeNode parentNode, string path)
        {
            IEnumerable<string> directories;
            IEnumerable<string> files;

            try
            {
                directories = Directory.GetDirectories(path).OrderBy(d => d, StringComparer.OrdinalIgnoreCase);
                files = Directory.GetFiles(path).OrderBy(f => f, StringComparer.OrdinalIgnoreCase);
            }
            catch
            {
                return;
            }

            foreach (var dir in directories)
            {
                string name = Path.GetFileName(dir);
                if (chkExcludeCommon.Checked && ExcludedFolders.Contains(name))
                    continue;
                if (_gitIgnore != null && _gitIgnore.IsIgnored(name, isDirectory: true))
                    continue;

                var dirNode = new TreeNode(name)
                {
                    Tag = new FileSystemNodeInfo { FullPath = dir, IsDirectory = true }
                };
                BuildTree(dirNode, dir);
                parentNode.Nodes.Add(dirNode);
            }

            foreach (var file in files)
            {
                string name = Path.GetFileName(file);
                if (_gitIgnore != null && _gitIgnore.IsIgnored(name, isDirectory: false))
                    continue;
                if (_excludedExtensions.Contains(Path.GetExtension(name)))
                    continue;
                if (!MatchesFilterPatterns(name))
                    continue;

                var fileNode = new TreeNode(name)
                {
                    Tag = new FileSystemNodeInfo { FullPath = file, IsDirectory = false }
                };
                parentNode.Nodes.Add(fileNode);
            }
        }

        // Wildcard filter box support — "*.cs;*.xaml" style, matched against the file name only.
        private bool MatchesFilterPatterns(string fileName)
        {
            if (_filterPatterns.Count == 0) return true;
            foreach (var pattern in _filterPatterns)
            {
                string regexText = "^" + Regex.Escape(pattern.Trim())
                    .Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
                if (Regex.IsMatch(fileName, regexText, RegexOptions.IgnoreCase))
                    return true;
            }
            return false;
        }

        // ---------- Checkbox cascade ----------

        private void treeViewFiles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (_isCheckingProgrammatically)
                return;

            _isCheckingProgrammatically = true;
            try
            {
                SetAllCheckedRecursive(e.Node.Nodes, e.Node.Checked);
            }
            finally
            {
                _isCheckingProgrammatically = false;
            }

            UpdateStatus();
        }

        private void SetAllCheckedRecursive(TreeNodeCollection nodes, bool isChecked)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = isChecked;
                SetAllCheckedRecursive(node.Nodes, isChecked);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e) => SetAllChecked(true);
        private void btnUncheckAll_Click(object sender, EventArgs e) => SetAllChecked(false);

        private void SetAllChecked(bool isChecked)
        {
            _isCheckingProgrammatically = true;
            try
            {
                SetAllCheckedRecursive(treeViewFiles.Nodes, isChecked);
            }
            finally
            {
                _isCheckingProgrammatically = false;
            }
            UpdateStatus();
        }

        // ---------- Output generation ----------

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_rootPath))
            {
                MessageBox.Show("Load a folder first.", "No Folder Loaded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fileNodes = new List<TreeNode>();
            CollectCheckedFileNodes(treeViewFiles.Nodes, fileNodes);

            if (fileNodes.Count == 0)
            {
                MessageBox.Show("No files are checked. Tick the checkbox next to one or more files in the tree.",
                    "No Files Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var files = new List<(string RelativePath, string Code, SyntaxHighlighter.Language Lang)>();
            long totalChars = 0;

            foreach (var node in fileNodes)
            {
                var info = (FileSystemNodeInfo)node.Tag;
                string code = ReadFileSafely(info.FullPath);
                totalChars += code.Length;
                files.Add((GetRelativePath(info.FullPath), code, SyntaxHighlighter.GetLanguage(Path.GetExtension(info.FullPath))));
            }

            bool applyHighlight = chkSyntaxHighlighting.Checked && totalChars <= MaxHighlightChars;
            Font regularFont = txtOutput.Font;
            Font boldFont = new Font(regularFont, FontStyle.Bold);

            string finalTextForCountsOnly = string.Empty;
            txtOutput.Clear();
            SendMessage(txtOutput.Handle, WM_SETREDRAW, false, IntPtr.Zero);
            try
            {
                foreach (var f in files)
                {
                    // Header — bold, cyan
                    txtOutput.SelectionStart = txtOutput.TextLength;
                    txtOutput.SelectionLength = 0;
                    txtOutput.SelectionColor = DraculaTheme.Cyan;
                    txtOutput.SelectionFont = boldFont;
                    txtOutput.AppendText("`" + f.RelativePath + ":`\n");

                    // Body — highlighted or plain, always via append (offsets never drift)
                    if (applyHighlight)
                        SyntaxHighlighter.AppendHighlighted(txtOutput, f.Code, f.Lang, DraculaTheme.Foreground, regularFont);
                    else
                    {
                        txtOutput.SelectionStart = txtOutput.TextLength;
                        txtOutput.SelectionLength = 0;
                        txtOutput.SelectionColor = DraculaTheme.Foreground;
                        txtOutput.SelectionFont = regularFont;
                        txtOutput.AppendText(f.Code);
                    }

                    txtOutput.SelectionStart = txtOutput.TextLength;
                    txtOutput.SelectionLength = 0;
                    txtOutput.SelectionColor = DraculaTheme.Foreground;
                    txtOutput.SelectionFont = regularFont;
                    txtOutput.AppendText("\n\n");
                }
                finalTextForCountsOnly = txtOutput.Text;
                txtOutput.Select(0, 0);
            }
            finally
            {
                SendMessage(txtOutput.Handle, WM_SETREDRAW, true, IntPtr.Zero);
                txtOutput.Invalidate();
            }

            int lineCount = txtOutput.Lines.Length;
            int charCount = txtOutput.TextLength;
            int wordCount = finalTextForCountsOnly.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;

            toolStripStatusLabel1.Text = $"Root: {_rootPath}    |    {fileNodes.Count} file(s)    |    " +
                $"{lineCount:N0} lines, {charCount:N0} chars, ~{wordCount:N0} tokens" +
                (chkSyntaxHighlighting.Checked && !applyHighlight ? "  (too large — plain text shown)" : "");
        }

        private void CollectCheckedFileNodes(TreeNodeCollection nodes, List<TreeNode> result)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is FileSystemNodeInfo info && !info.IsDirectory && node.Checked)
                    result.Add(node);

                CollectCheckedFileNodes(node.Nodes, result);
            }
        }

        private string GetRelativePath(string fullPath)
        {
            if (fullPath.StartsWith(_rootPath, StringComparison.OrdinalIgnoreCase))
                return fullPath.Substring(_rootPath.Length).Replace('/', '\\');

            return fullPath; // fallback, shouldn't normally happen
        }

        private string ReadFileSafely(string path)
        {
            string ext = Path.GetExtension(path);
            if (BinaryExtensions.Contains(ext))
                return "[Binary file - content not displayed]";

            try
            {
                // Normalize to \n only — RichTextBox silently collapses \r\n pairs
                // internally, which shifts every Select(start, length) offset computed
                // after the first line break. Keeping everything on \n avoids that.
                string text = File.ReadAllText(path);
                return text.Replace("\r\n", "\n").Replace("\r", "\n");
            }
            catch (Exception ex)
            {
                return $"[Error reading file: {ex.Message}]";
            }
        }

        // ---------- Output helpers ----------

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOutput.Text))
                return;

            try
            {
                Clipboard.SetText(txtOutput.Text);
                toolStripStatusLabel1.Text = "Output copied to clipboard.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not copy to clipboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOutput.Text))
                return;

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Markdown File (*.md)|*.md|Text File (*.txt)|*.txt|All Files (*.*)|*.*";
                dlg.FileName = "export.md";

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(dlg.FileName, txtOutput.Text);
                        toolStripStatusLabel1.Text = "Output saved to " + dlg.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not save file: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ---------- Status bar ----------

        private void UpdateStatus()
        {
            int fileCount = CountCheckedFiles(treeViewFiles.Nodes);
            toolStripStatusLabel1.Text = string.IsNullOrEmpty(_rootPath)
                ? "No folder loaded."
                : $"Root: {_rootPath}    |    Checked files: {fileCount}";
        }

        private int CountCheckedFiles(TreeNodeCollection nodes)
        {
            int count = 0;
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is FileSystemNodeInfo info && !info.IsDirectory && node.Checked)
                    count++;

                count += CountCheckedFiles(node.Nodes);
            }
            return count;
        }
    }
    #region Helper Classes
    public static class DraculaTheme
    {
        public static readonly Color Background = ColorTranslator.FromHtml("#282a36");
        public static readonly Color CurrentLine = ColorTranslator.FromHtml("#44475a");
        public static readonly Color Foreground = ColorTranslator.FromHtml("#f8f8f2");
        public static readonly Color Comment = ColorTranslator.FromHtml("#6272a4");
        public static readonly Color Cyan = ColorTranslator.FromHtml("#8be9fd");
        public static readonly Color Green = ColorTranslator.FromHtml("#50fa7b");
        public static readonly Color Orange = ColorTranslator.FromHtml("#ffb86c");
        public static readonly Color Pink = ColorTranslator.FromHtml("#ff79c6");
        public static readonly Color Purple = ColorTranslator.FromHtml("#bd93f9");
        public static readonly Color Red = ColorTranslator.FromHtml("#ff5555");
        public static readonly Color Yellow = ColorTranslator.FromHtml("#f1fa8c");
    }

    public static class SyntaxHighlighter
    {
        public enum Language { PlainText, CSharp, VbNet, JavaScript, Css, Xml, Html }

        private static readonly string[] CSharpKeywords =
        {
            "abstract","as","async","await","base","bool","break","byte","case","catch","char",
            "checked","class","const","continue","decimal","default","delegate","do","double",
            "else","enum","event","explicit","extern","false","finally","fixed","float","for",
            "foreach","get","goto","if","implicit","in","int","interface","internal","is","lock",
            "long","namespace","new","null","object","operator","out","override","params",
            "private","protected","public","readonly","ref","return","sealed","set","short",
            "sizeof","stackalloc","static","string","struct","switch","this","throw","true",
            "try","typeof","uint","ulong","unchecked","unsafe","ushort","using","var","virtual",
            "void","volatile","while"
        };

        private static readonly string[] VbKeywords =
        {
            "AddHandler","AddressOf","Alias","And","AndAlso","As","Boolean","ByRef","Byte","ByVal",
            "Call","Case","Catch","CBool","CByte","CChar","CDate","CDec","CDbl","Char","CInt","Class",
            "CLng","CObj","Const","Continue","CSByte","CShort","CSng","CStr","CType","CUInt","CULng",
            "CUShort","Date","Decimal","Declare","Default","Delegate","Dim","DirectCast","Do","Double",
            "Each","Else","ElseIf","End","Enum","Erase","Error","Event","Exit","False","Finally","For",
            "Friend","Function","Get","GetType","Global","GoSub","GoTo","Handles","If","Implements",
            "Imports","In","Inherits","Integer","Interface","Is","IsNot","Let","Lib","Like","Long",
            "Loop","Me","Mod","Module","MustInherit","MustOverride","MyBase","MyClass","Namespace",
            "Narrowing","New","Next","Not","Nothing","NotInheritable","NotOverridable","Object","Of",
            "On","Operator","Option","Optional","Or","OrElse","Overloads","Overridable","Overrides",
            "ParamArray","Partial","Private","Property","Protected","Public","RaiseEvent","ReadOnly",
            "ReDim","REM","RemoveHandler","Resume","Return","SByte","Select","Set","Shadows","Shared",
            "Short","Single","Static","Step","Stop","String","Structure","Sub","SyncLock","Then",
            "Throw","To","True","Try","TryCast","TypeOf","UInteger","ULong","UShort","Using",
            "Variant","Wend","When","While","Widening","With","WithEvents","WriteOnly","Xor"
        };

        private static readonly string[] JsKeywords =
        {
            "break","case","catch","class","const","continue","debugger","default","delete","do",
            "else","export","extends","finally","for","function","if","import","in","instanceof",
            "let","new","return","super","switch","this","throw","try","typeof","var","void","while",
            "with","yield","async","await","static","get","set","of","true","false","null","undefined"
        };

        public static readonly Color KeywordColor = DraculaTheme.Pink;
        public static readonly Color StringColor = DraculaTheme.Yellow;
        public static readonly Color CommentColor = DraculaTheme.Comment;
        public static readonly Color NumberColor = DraculaTheme.Purple;
        public static readonly Color TagColor = DraculaTheme.Pink;
        public static readonly Color AttributeColor = DraculaTheme.Green;
        public static readonly Color MethodColor = DraculaTheme.Green;   // Foo() calls / definitions
        public static readonly Color TypeColor = DraculaTheme.Cyan;      // PascalCase identifiers
        public static readonly Color PreprocColor = DraculaTheme.Orange; // #region, #if, #define
        public static readonly Color DefaultColor = DraculaTheme.Foreground;

        public static Language GetLanguage(string extension)
        {
            switch ((extension ?? string.Empty).ToLowerInvariant())
            {
                case ".cs": return Language.CSharp;
                case ".vb": return Language.VbNet;
                case ".js": case ".jsx": case ".ts": case ".tsx": return Language.JavaScript;
                case ".css": return Language.Css;
                case ".xml": case ".xaml": case ".csproj": case ".config": case ".resx": return Language.Xml;
                case ".html": case ".htm": return Language.Html;
                default: return Language.PlainText;
            }
        }

        /// <summary>
        /// Appends 'code' to rtb, coloring each token as it's written. Never computes
        /// offsets against a separately-built string, so it can't drift out of sync
        /// with whatever WinForms does internally to line endings.
        /// </summary>
        public static void AppendHighlighted(RichTextBox rtb, string code, Language language, Color defaultColor, Font baseFont)
        {
            if (string.IsNullOrEmpty(code)) return;

            if (language == Language.PlainText)
            {
                AppendColored(rtb, code, defaultColor, baseFont);
                return;
            }

            Regex pattern = BuildPattern(language, out string[] keywords);
            if (pattern == null)
            {
                AppendColored(rtb, code, defaultColor, baseFont);
                return;
            }

            var keywordSet = keywords != null ? new HashSet<string>(keywords, StringComparer.Ordinal) : null;

            int lastIndex = 0;
            foreach (Match m in pattern.Matches(code))
            {
                if (m.Index > lastIndex)
                    AppendColored(rtb, code.Substring(lastIndex, m.Index - lastIndex), defaultColor, baseFont);

                Color color;
                if (m.Groups["comment"].Success) color = CommentColor;
                else if (m.Groups["preproc"].Success) color = PreprocColor;
                else if (m.Groups["string"].Success) color = StringColor;
                else if (m.Groups["number"].Success) color = NumberColor;
                else if (m.Groups["tag"].Success) color = TagColor;
                else if (m.Groups["attr"].Success) color = AttributeColor;
                else if (m.Groups["word"].Success)
                {
                    string word = m.Value;
                    if (keywordSet != null && keywordSet.Contains(word))
                        color = KeywordColor;
                    else if (IsFollowedByOpenParen(code, m.Index + m.Length))
                        color = MethodColor;          // Foo(...) — call or declaration
                    else if (char.IsUpper(word[0]))
                        color = TypeColor;            // PascalCase — class/type name
                    else
                        color = defaultColor;
                }
                else
                    color = defaultColor;

                AppendColored(rtb, m.Value, color, baseFont);
                lastIndex = m.Index + m.Length;
            }

            if (lastIndex < code.Length)
                AppendColored(rtb, code.Substring(lastIndex), defaultColor, baseFont);
        }

        private static void AppendColored(RichTextBox rtb, string text, Color color, Font font)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = color;
            rtb.SelectionFont = font;
            rtb.AppendText(text);
        }
        private static bool IsFollowedByOpenParen(string code, int index)
        {
            int i = index;
            while (i < code.Length && (code[i] == ' ' || code[i] == '\t')) i++;
            return i < code.Length && code[i] == '(';
        }

        private static Regex BuildPattern(Language language, out string[] keywords)
        {
            keywords = null;
            switch (language)
            {
                case Language.CSharp:
                    keywords = CSharpKeywords;
                    return new Regex(
                        @"(?<preproc>^[ \t]*#\w+.*?$)" +
                        @"|(?<comment>//.*?$|/\*.*?\*/)" +
                        @"|(?<string>@""(?:[^""]|"""")*""|""(?:\\.|[^""\\])*"")" +
                        @"|(?<number>\b0[xX][0-9a-fA-F]+\b|\b\d+(\.\d+)?[fFdDmMuUlL]?\b)" +
                        @"|(?<word>\b[A-Za-z_]\w*\b)",
                        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled);

                case Language.VbNet:
                    keywords = VbKeywords;
                    return new Regex(
                        @"(?<comment>'.*?$)" +
                        @"|(?<string>""(?:[^""]|"""")*"")" +
                        @"|(?<number>&[Hh][0-9A-Fa-f]+|\b\d+(\.\d+)?\b)" +
                        @"|(?<word>\b[A-Za-z_]\w*\b)",
                        RegexOptions.Multiline | RegexOptions.Compiled);

                case Language.JavaScript:
                    keywords = JsKeywords;
                    return new Regex(
                        @"(?<comment>//.*?$|/\*.*?\*/)" +
                        @"|(?<string>`(?:\\.|[^`\\])*`|""(?:\\.|[^""\\])*""|'(?:\\.|[^'\\])*')" +
                        @"|(?<number>\b0[xX][0-9a-fA-F]+\b|\b\d+(\.\d+)?\b)" +
                        @"|(?<word>\b[A-Za-z_]\w*\b)",
                        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled);

                case Language.Css:
                    return new Regex(
                        @"(?<comment>/\*.*?\*/)" +
                        @"|(?<string>""(?:\\.|[^""\\])*""|'(?:\\.|[^'\\])*')" +
                        @"|(?<tag>[.#]?[A-Za-z-]+(?=\s*[{,:]))" +
                        @"|(?<number>\b\d+(\.\d+)?(px|em|rem|%|vh|vw|s|ms)?\b)",
                        RegexOptions.Singleline | RegexOptions.Compiled);

                case Language.Xml:
                case Language.Html:
                    return new Regex(
                        @"(?<comment><!--.*?-->)" +
                        @"|(?<tag></?[A-Za-z][\w:-]*)" +
                        @"|(?<attr>\b[A-Za-z-]+(?==))" +
                        @"|(?<string>""[^""]*""|'[^']*')",
                        RegexOptions.Singleline | RegexOptions.Compiled);

                default:
                    return null;
            }
        }
    }
    /// <summary>
    /// RichTextBox that raises ScrolledOrChanged on scroll/resize/font/text changes,
    /// since RichTextBox has no built-in Scroll event to hook a line-number gutter to.
    /// </summary>
    public class NumberedRichTextBox : RichTextBox
    {
        public event EventHandler ScrolledOrChanged;

        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x20A;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL)
                ScrolledOrChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            ScrolledOrChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Left-hand gutter that paints line numbers aligned to the attached
    /// RichTextBox's currently visible lines, VS Code / Notepad++ style.
    /// </summary>
    public class LineNumberPanel : Panel
    {
        private readonly NumberedRichTextBox _rtb;

        public LineNumberPanel(NumberedRichTextBox rtb)
        {
            _rtb = rtb;
            DoubleBuffered = true;
            BackColor = DraculaTheme.CurrentLine;
            Width = 48;
            Dock = DockStyle.Left;

            _rtb.ScrolledOrChanged += (s, e) => Invalidate();
            _rtb.TextChanged += (s, e) => { UpdateWidth(); Invalidate(); };
            _rtb.Resize += (s, e) => Invalidate();
            _rtb.FontChanged += (s, e) => Invalidate();
        }

        private void UpdateWidth()
        {
            int totalLines = Math.Max(1, _rtb.Lines.Length);
            int digits = totalLines.ToString().Length;
            int newWidth = Math.Max(40, digits * 9 + 20);
            if (Width != newWidth) Width = newWidth;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_rtb.TextLength == 0) return;

            int firstCharIndex = _rtb.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = _rtb.GetLineFromCharIndex(firstCharIndex);
            int totalLines = _rtb.Lines.Length;

            using (var font = new Font(_rtb.Font, FontStyle.Regular))
            using (var brush = new SolidBrush(DraculaTheme.Comment))
            {
                var format = new StringFormat { Alignment = StringAlignment.Far };
                for (int line = firstLine; line < totalLines; line++)
                {
                    int charIndex = _rtb.GetFirstCharIndexFromLine(line);
                    if (charIndex < 0) break;

                    Point pos = _rtb.GetPositionFromCharIndex(charIndex);
                    if (pos.Y > Height) break;

                    e.Graphics.DrawString((line + 1).ToString(), font, brush,
                        new RectangleF(0, pos.Y, Width - 6, font.Height + 2), format);
                }
            }
        }
    }
    /// <summary>
    /// Tiny pipe-delimited settings store under %AppData% — no project Settings.settings
    /// file needed. Line 1: last root path. Line 2: recent paths (|-joined, newest first).
    /// Line 3: last session's checked relative file paths (|-joined).
    /// </summary>
    public static class AppSettings
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "FileContentExporter", "settings.txt");

        public static string LastRootPath { get; private set; } = string.Empty;
        public static List<string> RecentPaths { get; private set; } = new List<string>();
        public static List<string> LastCheckedRelativePaths { get; private set; } = new List<string>();

        public static void Load()
        {
            try
            {
                if (!File.Exists(FilePath)) return;
                var lines = File.ReadAllLines(FilePath);
                if (lines.Length > 0) LastRootPath = lines[0];
                if (lines.Length > 1) RecentPaths = lines[1].Split('|').Where(s => s.Length > 0).ToList();
                if (lines.Length > 2) LastCheckedRelativePaths = lines[2].Split('|').Where(s => s.Length > 0).ToList();
            }
            catch { /* best-effort */ }
        }

        public static void Save(string rootPath, List<string> recentPaths, List<string> checkedRelativePaths)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                File.WriteAllLines(FilePath, new[]
                {
                    rootPath ?? string.Empty,
                    string.Join("|", recentPaths ?? new List<string>()),
                    string.Join("|", checkedRelativePaths ?? new List<string>())
                });
            }
            catch { /* best-effort */ }
        }
    }
    /// <summary>
    /// Minimal .gitignore support: blank lines and '#' comments skipped, '*' and '?'
    /// wildcards, trailing '/' means "directory only". Not a full gitignore spec
    /// (no negation, no '**'), but covers the common cases.
    /// </summary>
    public class GitIgnoreFilter
    {
        private readonly List<(Regex Pattern, bool DirOnly)> _rules = new List<(Regex, bool)>();

        public static GitIgnoreFilter LoadFrom(string rootPath)
        {
            var filter = new GitIgnoreFilter();
            string gitignorePath = Path.Combine(rootPath, ".gitignore");
            if (!File.Exists(gitignorePath)) return filter;

            foreach (var raw in File.ReadAllLines(gitignorePath))
            {
                string line = raw.Trim();
                if (line.Length == 0 || line.StartsWith("#")) continue;

                bool dirOnly = line.EndsWith("/");
                if (dirOnly) line = line.TrimEnd('/');

                string regexText = "^" + Regex.Escape(line)
                    .Replace(@"\*", ".*")
                    .Replace(@"\?", ".") + "$";

                filter._rules.Add((new Regex(regexText, RegexOptions.IgnoreCase), dirOnly));
            }
            return filter;
        }

        public bool IsIgnored(string name, bool isDirectory)
        {
            foreach (var (pattern, dirOnly) in _rules)
            {
                if (dirOnly && !isDirectory) continue;
                if (pattern.IsMatch(name)) return true;
            }
            return false;
        }
    }
    #endregion
}
