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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkExcludeCommon = new System.Windows.Forms.CheckBox();
            this.btnLoadTree = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.pnlTreeToolbar = new System.Windows.Forms.Panel();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.pnlOutputToolbar = new System.Windows.Forms.Panel();
            this.chkSyntaxHighlighting = new System.Windows.Forms.CheckBox();
            this.btnSaveOutput = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlTreeToolbar.SuspendLayout();
            this.pnlOutputToolbar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlTop.Controls.Add(this.chkExcludeCommon);
            this.pnlTop.Controls.Add(this.btnLoadTree);
            this.pnlTop.Controls.Add(this.btnBrowseFile);
            this.pnlTop.Controls.Add(this.btnBrowseFolder);
            this.pnlTop.Controls.Add(this.txtPath);
            this.pnlTop.Controls.Add(this.lblPath);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1120, 90);
            this.pnlTop.TabIndex = 0;
            // 
            // chkExcludeCommon
            // 
            this.chkExcludeCommon.AutoSize = true;
            this.chkExcludeCommon.BackColor = System.Drawing.Color.Transparent;
            this.chkExcludeCommon.Checked = true;
            this.chkExcludeCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeCommon.ForeColor = System.Drawing.Color.White;
            this.chkExcludeCommon.Location = new System.Drawing.Point(12, 60);
            this.chkExcludeCommon.Name = "chkExcludeCommon";
            this.chkExcludeCommon.Size = new System.Drawing.Size(447, 17);
            this.chkExcludeCommon.TabIndex = 5;
            this.chkExcludeCommon.Text = "Exclude common build/VCS folders (bin, obj, .git, .vs, node_modules, packages, .i" +
    "dea)";
            this.chkExcludeCommon.UseVisualStyleBackColor = false;
            // 
            // btnLoadTree
            // 
            this.btnLoadTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadTree.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadTree.FlatAppearance.BorderSize = 2;
            this.btnLoadTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.btnBrowseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBrowseFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowseFile.FlatAppearance.BorderSize = 2;
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.btnBrowseFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBrowseFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowseFolder.FlatAppearance.BorderSize = 2;
            this.btnBrowseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.lblPath.ForeColor = System.Drawing.Color.White;
            this.lblPath.Location = new System.Drawing.Point(12, 10);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(164, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Project / Solution / Folder Path:";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 90);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewFiles);
            this.splitContainerMain.Panel1.Controls.Add(this.pnlTreeToolbar);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.txtOutput);
            this.splitContainerMain.Panel2.Controls.Add(this.pnlOutputToolbar);
            this.splitContainerMain.Size = new System.Drawing.Size(1120, 613);
            this.splitContainerMain.SplitterDistance = 340;
            this.splitContainerMain.TabIndex = 1;
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewFiles.CheckBoxes = true;
            this.treeViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFiles.Font = new System.Drawing.Font("Roboto", 9F);
            this.treeViewFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeViewFiles.HideSelection = false;
            this.treeViewFiles.ItemHeight = 18;
            this.treeViewFiles.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.treeViewFiles.Location = new System.Drawing.Point(0, 38);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.ShowNodeToolTips = true;
            this.treeViewFiles.Size = new System.Drawing.Size(340, 575);
            this.treeViewFiles.TabIndex = 1;
            this.treeViewFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFiles_AfterCheck);
            // 
            // pnlTreeToolbar
            // 
            this.pnlTreeToolbar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTreeToolbar.Controls.Add(this.btnUncheckAll);
            this.pnlTreeToolbar.Controls.Add(this.btnCheckAll);
            this.pnlTreeToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTreeToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlTreeToolbar.Name = "pnlTreeToolbar";
            this.pnlTreeToolbar.Size = new System.Drawing.Size(340, 38);
            this.pnlTreeToolbar.TabIndex = 0;
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.AutoSize = true;
            this.btnUncheckAll.BackColor = System.Drawing.Color.LightPink;
            this.btnUncheckAll.FlatAppearance.BorderSize = 2;
            this.btnUncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheckAll.ForeColor = System.Drawing.Color.DarkRed;
            this.btnUncheckAll.Location = new System.Drawing.Point(104, 6);
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
            this.btnCheckAll.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCheckAll.FlatAppearance.BorderSize = 2;
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCheckAll.Location = new System.Drawing.Point(8, 6);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(90, 27);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.AcceptsTab = true;
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("JetBrains Mono", 10F);
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(0, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtOutput.Size = new System.Drawing.Size(776, 575);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // pnlOutputToolbar
            // 
            this.pnlOutputToolbar.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.chkSyntaxHighlighting.Checked = true;
            this.chkSyntaxHighlighting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSyntaxHighlighting.Location = new System.Drawing.Point(457, 12);
            this.chkSyntaxHighlighting.Name = "chkSyntaxHighlighting";
            this.chkSyntaxHighlighting.Size = new System.Drawing.Size(123, 17);
            this.chkSyntaxHighlighting.TabIndex = 3;
            this.chkSyntaxHighlighting.Text = "Syntax Highlighting";
            this.chkSyntaxHighlighting.UseVisualStyleBackColor = true;
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSaveOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSaveOutput.FlatAppearance.BorderSize = 2;
            this.btnSaveOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.btnClearOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClearOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnClearOutput.FlatAppearance.BorderSize = 2;
            this.btnClearOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.btnCopyAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCopyAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCopyAll.FlatAppearance.BorderSize = 2;
            this.btnCopyAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnGenerate.FlatAppearance.BorderSize = 2;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnGenerate.Location = new System.Drawing.Point(6, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 27);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate Output";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 703);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1120, 27);
            this.statusStrip1.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Poppins Medium", 9F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1105, 22);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "No folder loaded.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFileExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 730);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Roboto Medium", 8.25F);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "frmFileExporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Content Exporter";
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnSaveOutput;
        private System.Windows.Forms.CheckBox chkSyntaxHighlighting;
    }
}

