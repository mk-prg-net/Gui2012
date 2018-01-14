namespace PicBrowser
{
    partial class PicBrowserForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Knoten0", 0, 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicBrowserForm));
            this.folderBrowserDialogForScan = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTab2TreeNodeRefresh = new System.Windows.Forms.Button();
            this.btnReloadDirectory = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvPicDir = new System.Windows.Forms.TreeView();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.cbxViewerAsParallel = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Size = new System.Drawing.Size(811, 631);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(592, 297);
            // 
            // lbxLog
            // 
            this.lbxLog.ItemHeight = 13;
            this.lbxLog.Location = new System.Drawing.Point(4, 85);
            this.lbxLog.Margin = new System.Windows.Forms.Padding(4);
            this.lbxLog.Size = new System.Drawing.Size(584, 199);
            // 
            // cbxLbxLogAnzeigeoptionen
            // 
            this.cbxLbxLogAnzeigeoptionen.Margin = new System.Windows.Forms.Padding(2);
            this.cbxLbxLogAnzeigeoptionen.Size = new System.Drawing.Size(119, 34);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(803, 605);
            this.tabPage2.Text = "Viewer";
            // 
            // folderBrowserDialogForScan
            // 
            this.folderBrowserDialogForScan.ShowNewFolderButton = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxViewerAsParallel);
            this.panel2.Controls.Add(this.btnTab2TreeNodeRefresh);
            this.panel2.Controls.Add(this.btnReloadDirectory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 34);
            this.panel2.TabIndex = 0;
            // 
            // btnTab2TreeNodeRefresh
            // 
            this.btnTab2TreeNodeRefresh.Location = new System.Drawing.Point(155, 3);
            this.btnTab2TreeNodeRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnTab2TreeNodeRefresh.Name = "btnTab2TreeNodeRefresh";
            this.btnTab2TreeNodeRefresh.Size = new System.Drawing.Size(123, 23);
            this.btnTab2TreeNodeRefresh.TabIndex = 1;
            this.btnTab2TreeNodeRefresh.Text = "Knoten aktualisieren";
            this.btnTab2TreeNodeRefresh.UseVisualStyleBackColor = true;
            this.btnTab2TreeNodeRefresh.Click += new System.EventHandler(this.btnTab2TreeNodeRefresh_Click);
            // 
            // btnReloadDirectory
            // 
            this.btnReloadDirectory.Location = new System.Drawing.Point(5, 3);
            this.btnReloadDirectory.Name = "btnReloadDirectory";
            this.btnReloadDirectory.Size = new System.Drawing.Size(136, 23);
            this.btnReloadDirectory.TabIndex = 0;
            this.btnReloadDirectory.Text = "Verzeichnis neu laden";
            this.btnReloadDirectory.UseVisualStyleBackColor = true;
            this.btnReloadDirectory.Click += new System.EventHandler(this.btnReloadDirectory_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvPicDir);
            this.splitContainer1.Size = new System.Drawing.Size(795, 563);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 1;
            // 
            // trvPicDir
            // 
            this.trvPicDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvPicDir.ImageIndex = 0;
            this.trvPicDir.ImageList = this.imageListTreeView;
            this.trvPicDir.Location = new System.Drawing.Point(0, 0);
            this.trvPicDir.Name = "trvPicDir";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "Knoten0";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Knoten0";
            this.trvPicDir.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.trvPicDir.SelectedImageIndex = 0;
            this.trvPicDir.Size = new System.Drawing.Size(264, 563);
            this.trvPicDir.TabIndex = 0;
            this.trvPicDir.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.trvPicDir_AfterCollapse);
            this.trvPicDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvPicDir_BeforeExpand);
            this.trvPicDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvPicDir_AfterSelect);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "Folder_Back.ico");
            this.imageListTreeView.Images.SetKeyName(1, "folder_open.ico");
            this.imageListTreeView.Images.SetKeyName(2, "font.ico");
            this.imageListTreeView.Images.SetKeyName(3, "Image_File.ico");
            // 
            // cbxViewerAsParallel
            // 
            this.cbxViewerAsParallel.AutoSize = true;
            this.cbxViewerAsParallel.Location = new System.Drawing.Point(305, 8);
            this.cbxViewerAsParallel.Name = "cbxViewerAsParallel";
            this.cbxViewerAsParallel.Size = new System.Drawing.Size(109, 17);
            this.cbxViewerAsParallel.TabIndex = 2;
            this.cbxViewerAsParallel.Text = "Parallelcomputing";
            this.cbxViewerAsParallel.UseVisualStyleBackColor = true;
            // 
            // PicBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(811, 677);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PicBrowserForm";
            this.Text = "PicBrowser (c) Martin Korneffel, Stuttgart 2007";
            this.Load += new System.EventHandler(this.PicBrowserForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReloadDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogForScan;
        private System.Windows.Forms.TreeView trvPicDir;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.Button btnTab2TreeNodeRefresh;
        private System.Windows.Forms.CheckBox cbxViewerAsParallel;
    }
}
