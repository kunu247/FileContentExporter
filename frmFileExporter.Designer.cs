namespace FileContentExporter
{
    partial class frmFileExporter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileExporter));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkExcludeCommon = new System.Windows.Forms.CheckBox();
            this.btnLoadTree = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.cmbRecentPaths = new System.Windows.Forms.ComboBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.pnlTreeToolbar = new System.Windows.Forms.Panel();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.clbExtensions = new System.Windows.Forms.CheckedListBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.pnlOutputToolbar = new System.Windows.Forms.Panel();
            this.chkSyntaxHighlighting = new System.Windows.Forms.CheckBox();
            this.btnSaveOutput = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.statusStripMainApp = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer001 = new System.Windows.Forms.SplitContainer();
            this.splitContainer00101 = new System.Windows.Forms.SplitContainer();
            this.toolTipMainAppScreen = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlTreeToolbar.SuspendLayout();
            this.pnlOutputToolbar.SuspendLayout();
            this.statusStripMainApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer001)).BeginInit();
            this.splitContainer001.Panel1.SuspendLayout();
            this.splitContainer001.Panel2.SuspendLayout();
            this.splitContainer001.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer00101)).BeginInit();
            this.splitContainer00101.Panel1.SuspendLayout();
            this.splitContainer00101.Panel2.SuspendLayout();
            this.splitContainer00101.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnlTop.Controls.Add(this.chkExcludeCommon);
            this.pnlTop.Controls.Add(this.btnLoadTree);
            this.pnlTop.Controls.Add(this.btnBrowseFile);
            this.pnlTop.Controls.Add(this.btnBrowseFolder);
            this.pnlTop.Controls.Add(this.txtPath);
            this.pnlTop.Controls.Add(this.lblPath);
            this.pnlTop.Controls.Add(this.cmbRecentPaths);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1120, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // chkExcludeCommon
            // 
            this.chkExcludeCommon.AutoSize = true;
            this.chkExcludeCommon.BackColor = System.Drawing.Color.Transparent;
            this.chkExcludeCommon.Checked = true;
            this.chkExcludeCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeCommon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.chkExcludeCommon.Location = new System.Drawing.Point(12, 79);
            this.chkExcludeCommon.Name = "chkExcludeCommon";
            this.chkExcludeCommon.Size = new System.Drawing.Size(447, 17);
            this.chkExcludeCommon.TabIndex = 5;
            this.chkExcludeCommon.Text = "Exclude common build/VCS folders (bin, obj, .git, .vs, node_modules, packages, .idea)";
            this.toolTipMainAppScreen.SetToolTip(this.chkExcludeCommon, "ON - bin, obj, .git, .vs, node_modules, packages and .idea are hidden.\r\nClick to show them.");
            this.chkExcludeCommon.UseVisualStyleBackColor = false;
            this.chkExcludeCommon.CheckedChanged += new System.EventHandler(this.chkExcludeCommon_CheckedChanged);
            // 
            // btnLoadTree
            // 
            this.btnLoadTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnLoadTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadTree.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(250)))), ((int)(((byte)(123)))));
            this.btnLoadTree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(250)))), ((int)(((byte)(123)))));
            this.btnLoadTree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnLoadTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnLoadTree.Location = new System.Drawing.Point(1024, 26);
            this.btnLoadTree.Name = "btnLoadTree";
            this.btnLoadTree.Size = new System.Drawing.Size(84, 25);
            this.btnLoadTree.TabIndex = 4;
            this.btnLoadTree.Text = "Load Tree";
            this.btnLoadTree.UseVisualStyleBackColor = false;
            this.btnLoadTree.Click += new System.EventHandler(this.btnLoadTree_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnBrowseFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btnBrowseFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btnBrowseFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnBrowseFile.Location = new System.Drawing.Point(888, 26);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(130, 25);
            this.btnBrowseFile.TabIndex = 3;
            this.btnBrowseFile.Text = "Browse .sln/.csproj...";
            this.btnBrowseFile.UseVisualStyleBackColor = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnBrowseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btnBrowseFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btnBrowseFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnBrowseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnBrowseFolder.Location = new System.Drawing.Point(782, 26);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(100, 25);
            this.btnBrowseFolder.TabIndex = 2;
            this.btnBrowseFolder.Text = "Browse Folder...";
            this.btnBrowseFolder.UseVisualStyleBackColor = false;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.txtPath.Location = new System.Drawing.Point(12, 28);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(764, 21);
            this.txtPath.TabIndex = 1;
            this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.lblPath.Location = new System.Drawing.Point(12, 10);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(164, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Project / Solution / Folder Path:";
            // 
            // cmbRecentPaths
            // 
            this.cmbRecentPaths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.cmbRecentPaths.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbRecentPaths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecentPaths.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.cmbRecentPaths.FormattingEnabled = true;
            this.cmbRecentPaths.Location = new System.Drawing.Point(12, 52);
            this.cmbRecentPaths.Name = "cmbRecentPaths";
            this.cmbRecentPaths.Size = new System.Drawing.Size(764, 21);
            this.cmbRecentPaths.TabIndex = 6;
            this.toolTipMainAppScreen.SetToolTip(this.cmbRecentPaths, "Recent folders appear here after you load one.");
            this.cmbRecentPaths.SelectedIndexChanged += new System.EventHandler(this.cmbRecentPaths_SelectedIndexChanged);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 100);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer001);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.txtOutput);
            this.splitContainerMain.Panel2.Controls.Add(this.pnlOutputToolbar);
            this.splitContainerMain.Size = new System.Drawing.Size(1120, 603);
            this.splitContainerMain.SplitterDistance = 340;
            this.splitContainerMain.TabIndex = 1;
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.treeViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewFiles.CheckBoxes = true;
            this.treeViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFiles.Font = new System.Drawing.Font("Roboto", 9F);
            this.treeViewFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.treeViewFiles.HideSelection = false;
            this.treeViewFiles.ItemHeight = 18;
            this.treeViewFiles.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.treeViewFiles.Location = new System.Drawing.Point(0, 0);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.ShowNodeToolTips = true;
            this.treeViewFiles.Size = new System.Drawing.Size(340, 414);
            this.treeViewFiles.TabIndex = 1;
            this.treeViewFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFiles_AfterCheck);
            // 
            // pnlTreeToolbar
            // 
            this.pnlTreeToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnlTreeToolbar.Controls.Add(this.btnUncheckAll);
            this.pnlTreeToolbar.Controls.Add(this.btnCheckAll);
            this.pnlTreeToolbar.Controls.Add(this.txtFilter);
            this.pnlTreeToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTreeToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlTreeToolbar.Name = "pnlTreeToolbar";
            this.pnlTreeToolbar.Size = new System.Drawing.Size(340, 71);
            this.pnlTreeToolbar.TabIndex = 0;
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.AutoSize = true;
            this.btnUncheckAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnUncheckAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUncheckAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnUncheckAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnUncheckAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnUncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheckAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnUncheckAll.Location = new System.Drawing.Point(106, 35);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(90, 27);
            this.btnUncheckAll.TabIndex = 1;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = false;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.AutoSize = true;
            this.btnCheckAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnCheckAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(250)))), ((int)(((byte)(123)))));
            this.btnCheckAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(250)))), ((int)(((byte)(123)))));
            this.btnCheckAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnCheckAll.Location = new System.Drawing.Point(10, 35);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(90, 27);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.txtFilter.Location = new System.Drawing.Point(10, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(321, 21);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Text = "*.cs;*.xaml";
            this.toolTipMainAppScreen.SetToolTip(this.txtFilter, "No filter - every file is listed.\r\nType patterns such as *.cs;*.xaml and press Enter.");
            this.txtFilter.Enter += new System.EventHandler(this.txtFilter_Enter);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // clbExtensions
            // 
            this.clbExtensions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.clbExtensions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbExtensions.CheckOnClick = true;
            this.clbExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbExtensions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.clbExtensions.FormattingEnabled = true;
            this.clbExtensions.Location = new System.Drawing.Point(0, 0);
            this.clbExtensions.Name = "clbExtensions";
            this.clbExtensions.Size = new System.Drawing.Size(340, 110);
            this.clbExtensions.TabIndex = 2;
            this.toolTipMainAppScreen.SetToolTip(this.clbExtensions, "File extensions found in the loaded folder appear here.\r\nUntick one to hide those files.");
            this.clbExtensions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbExtensions_ItemCheck);
            // 
            // txtOutput
            // 
            this.txtOutput.AcceptsTab = true;
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("JetBrains Mono", 10F);
            this.txtOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.txtOutput.Location = new System.Drawing.Point(0, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtOutput.Size = new System.Drawing.Size(776, 565);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            this.txtOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutput_KeyDown);
            // 
            // pnlOutputToolbar
            // 
            this.pnlOutputToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnlOutputToolbar.Controls.Add(this.chkSyntaxHighlighting);
            this.pnlOutputToolbar.Controls.Add(this.btnSaveOutput);
            this.pnlOutputToolbar.Controls.Add(this.btnClearOutput);
            this.pnlOutputToolbar.Controls.Add(this.btnCopyAll);
            this.pnlOutputToolbar.Controls.Add(this.btnGenerate);
            this.pnlOutputToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutputToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlOutputToolbar.Name = "pnlOutputToolbar";
            this.pnlOutputToolbar.Size = new System.Drawing.Size(776, 38);
            this.pnlOutputToolbar.TabIndex = 0;
            // 
            // chkSyntaxHighlighting
            // 
            this.chkSyntaxHighlighting.AutoSize = true;
            this.chkSyntaxHighlighting.BackColor = System.Drawing.Color.Transparent;
            this.chkSyntaxHighlighting.Checked = true;
            this.chkSyntaxHighlighting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSyntaxHighlighting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSyntaxHighlighting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.chkSyntaxHighlighting.Location = new System.Drawing.Point(457, 11);
            this.chkSyntaxHighlighting.Name = "chkSyntaxHighlighting";
            this.chkSyntaxHighlighting.Size = new System.Drawing.Size(123, 17);
            this.chkSyntaxHighlighting.TabIndex = 3;
            this.chkSyntaxHighlighting.Text = "Syntax Highlighting";
            this.toolTipMainAppScreen.SetToolTip(this.chkSyntaxHighlighting, "ON - colors the output. Skipped automatically above 400,000 characters.\r\nApplies the next time you click Generate.");
            this.chkSyntaxHighlighting.UseVisualStyleBackColor = false;
            this.chkSyntaxHighlighting.CheckedChanged += new System.EventHandler(this.chkSyntaxHighlighting_CheckedChanged);
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnSaveOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btnSaveOutput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btnSaveOutput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnSaveOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnSaveOutput.Location = new System.Drawing.Point(344, 6);
            this.btnSaveOutput.Name = "btnSaveOutput";
            this.btnSaveOutput.Size = new System.Drawing.Size(107, 27);
            this.btnSaveOutput.TabIndex = 2;
            this.btnSaveOutput.Text = "Save Output...";
            this.btnSaveOutput.UseVisualStyleBackColor = false;
            this.btnSaveOutput.Click += new System.EventHandler(this.btnSaveOutput_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnClearOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnClearOutput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnClearOutput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnClearOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnClearOutput.Location = new System.Drawing.Point(258, 6);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(80, 27);
            this.btnClearOutput.TabIndex = 2;
            this.btnClearOutput.Text = "Clear";
            this.btnClearOutput.UseVisualStyleBackColor = false;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnCopyAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btnCopyAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btnCopyAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnCopyAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnCopyAll.Location = new System.Drawing.Point(142, 6);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(110, 27);
            this.btnCopyAll.TabIndex = 1;
            this.btnCopyAll.Text = "Copy All";
            this.btnCopyAll.UseVisualStyleBackColor = false;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btnGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(147)))), ((int)(((byte)(249)))));
            this.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(129)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.btnGenerate.Location = new System.Drawing.Point(6, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 27);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate Output";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.toolTipMainAppScreen.SetToolTip(this.btnGenerate, "Tick one or more files in the tree first.");
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // statusStripMainApp
            // 
            this.statusStripMainApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.statusStripMainApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripMainApp.Location = new System.Drawing.Point(0, 703);
            this.statusStripMainApp.Name = "statusStripMainApp";
            this.statusStripMainApp.Size = new System.Drawing.Size(1120, 27);
            this.statusStripMainApp.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Poppins Medium", 9F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1105, 22);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "No folder loaded.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer001
            // 
            this.splitContainer001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer001.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer001.IsSplitterFixed = true;
            this.splitContainer001.Location = new System.Drawing.Point(0, 0);
            this.splitContainer001.Name = "splitContainer001";
            this.splitContainer001.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer001.Panel1
            // 
            this.splitContainer001.Panel1.Controls.Add(this.pnlTreeToolbar);
            // 
            // splitContainer001.Panel2
            // 
            this.splitContainer001.Panel2.Controls.Add(this.splitContainer00101);
            this.splitContainer001.Size = new System.Drawing.Size(340, 603);
            this.splitContainer001.SplitterDistance = 71;
            this.splitContainer001.TabIndex = 0;
            // 
            // splitContainer00101
            // 
            this.splitContainer00101.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer00101.Location = new System.Drawing.Point(0, 0);
            this.splitContainer00101.Name = "splitContainer00101";
            this.splitContainer00101.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer00101.Panel1
            // 
            this.splitContainer00101.Panel1.Controls.Add(this.treeViewFiles);
            // 
            // splitContainer00101.Panel2
            // 
            this.splitContainer00101.Panel2.Controls.Add(this.clbExtensions);
            this.splitContainer00101.Size = new System.Drawing.Size(340, 528);
            this.splitContainer00101.SplitterDistance = 414;
            this.splitContainer00101.TabIndex = 0;
            // 
            // toolTipMainAppScreen
            // 
            this.toolTipMainAppScreen.AutoPopDelay = 10000;
            this.toolTipMainAppScreen.InitialDelay = 350;
            this.toolTipMainAppScreen.OwnerDraw = true;
            this.toolTipMainAppScreen.ReshowDelay = 100;
            this.toolTipMainAppScreen.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTipMainAppScreen_Draw);
            this.toolTipMainAppScreen.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipMainAppScreen_Popup);
            // 
            // frmFileExporter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1120, 730);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStripMainApp);
            this.Font = new System.Drawing.Font("Roboto Medium", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "frmFileExporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Content Exporter";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmFileExporter_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmFileExporter_DragEnter);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlTreeToolbar.ResumeLayout(false);
            this.pnlTreeToolbar.PerformLayout();
            this.pnlOutputToolbar.ResumeLayout(false);
            this.pnlOutputToolbar.PerformLayout();
            this.statusStripMainApp.ResumeLayout(false);
            this.statusStripMainApp.PerformLayout();
            this.splitContainer001.Panel1.ResumeLayout(false);
            this.splitContainer001.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer001)).EndInit();
            this.splitContainer001.ResumeLayout(false);
            this.splitContainer00101.Panel1.ResumeLayout(false);
            this.splitContainer00101.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer00101)).EndInit();
            this.splitContainer00101.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.CheckBox chkExcludeCommon;
        private System.Windows.Forms.Button btnLoadTree;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel pnlTreeToolbar;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.TreeView treeViewFiles;
        private System.Windows.Forms.Panel pnlOutputToolbar;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.StatusStrip statusStripMainApp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnSaveOutput;
        private System.Windows.Forms.CheckBox chkSyntaxHighlighting;
        private System.Windows.Forms.ComboBox cmbRecentPaths;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckedListBox clbExtensions;
        private System.Windows.Forms.SplitContainer splitContainer001;
        private System.Windows.Forms.SplitContainer splitContainer00101;
        private System.Windows.Forms.ToolTip toolTipMainAppScreen;
    }
}

