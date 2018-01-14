namespace FileClassificatorClient
{
    partial class FormClassificatorClient
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
            this.MyDsFilesClassification = new FileClassificatorClient.DsFilesClassification();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClassifyNew = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvDir = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.depthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumFilesSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archiveBitSetCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fotosCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumFotosSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.officeCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceCodeCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videosCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumVideosFilesSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumWebFilesSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumOtherFilesSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentVecBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDsFilesClassification = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyDsFilesClassification)).BeginInit();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentVecBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDsFilesClassification)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Text = "Klassifikation";
            // 
            // MyDsFilesClassification
            // 
            this.MyDsFilesClassification.DataSetName = "DsFilesClassification";
            this.MyDsFilesClassification.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClassifyNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 40);
            this.panel2.TabIndex = 0;
            // 
            // btnClassifyNew
            // 
            this.btnClassifyNew.Location = new System.Drawing.Point(3, 3);
            this.btnClassifyNew.Name = "btnClassifyNew";
            this.btnClassifyNew.Size = new System.Drawing.Size(178, 34);
            this.btnClassifyNew.TabIndex = 0;
            this.btnClassifyNew.Text = "Neue Klassifizierung";
            this.btnClassifyNew.UseVisualStyleBackColor = true;
            this.btnClassifyNew.Click += new System.EventHandler(this.btnClassifyNew_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvDir);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(840, 359);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 1;
            // 
            // trvDir
            // 
            this.trvDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDir.Location = new System.Drawing.Point(0, 0);
            this.trvDir.Name = "trvDir";
            this.trvDir.Size = new System.Drawing.Size(295, 359);
            this.trvDir.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.depthDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.fileCountDataGridViewTextBoxColumn,
            this.sumFilesSizeDataGridViewTextBoxColumn,
            this.archiveBitSetCountDataGridViewTextBoxColumn,
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn,
            this.fotosCountDataGridViewTextBoxColumn,
            this.sumFotosSizeDataGridViewTextBoxColumn,
            this.officeCountDataGridViewTextBoxColumn,
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn,
            this.sourceCodeCountDataGridViewTextBoxColumn,
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn,
            this.videosCountDataGridViewTextBoxColumn,
            this.sumVideosFilesSizeDataGridViewTextBoxColumn,
            this.webCountDataGridViewTextBoxColumn,
            this.sumWebFilesSizeDataGridViewTextBoxColumn,
            this.otherCountDataGridViewTextBoxColumn,
            this.sumOtherFilesSizeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.contentVecBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(541, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // depthDataGridViewTextBoxColumn
            // 
            this.depthDataGridViewTextBoxColumn.DataPropertyName = "depth";
            this.depthDataGridViewTextBoxColumn.HeaderText = "Tiefe";
            this.depthDataGridViewTextBoxColumn.Name = "depthDataGridViewTextBoxColumn";
            this.depthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Dir";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileCountDataGridViewTextBoxColumn
            // 
            this.fileCountDataGridViewTextBoxColumn.DataPropertyName = "FileCount";
            this.fileCountDataGridViewTextBoxColumn.HeaderText = "#AllFiles";
            this.fileCountDataGridViewTextBoxColumn.Name = "fileCountDataGridViewTextBoxColumn";
            this.fileCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumFilesSize";
            this.sumFilesSizeDataGridViewTextBoxColumn.HeaderText = "$AllFiles";
            this.sumFilesSizeDataGridViewTextBoxColumn.Name = "sumFilesSizeDataGridViewTextBoxColumn";
            this.sumFilesSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // archiveBitSetCountDataGridViewTextBoxColumn
            // 
            this.archiveBitSetCountDataGridViewTextBoxColumn.DataPropertyName = "ArchiveBitSetCount";
            this.archiveBitSetCountDataGridViewTextBoxColumn.HeaderText = "#ArchiveBit";
            this.archiveBitSetCountDataGridViewTextBoxColumn.Name = "archiveBitSetCountDataGridViewTextBoxColumn";
            this.archiveBitSetCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumArchiveBitFileSizeDataGridViewTextBoxColumn
            // 
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.DataPropertyName = "SumArchiveBitFileSize";
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.HeaderText = "$ArchiveBit";
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.Name = "sumArchiveBitFileSizeDataGridViewTextBoxColumn";
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fotosCountDataGridViewTextBoxColumn
            // 
            this.fotosCountDataGridViewTextBoxColumn.DataPropertyName = "FotosCount";
            this.fotosCountDataGridViewTextBoxColumn.HeaderText = "#Fotos";
            this.fotosCountDataGridViewTextBoxColumn.Name = "fotosCountDataGridViewTextBoxColumn";
            this.fotosCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumFotosSizeDataGridViewTextBoxColumn
            // 
            this.sumFotosSizeDataGridViewTextBoxColumn.DataPropertyName = "SumFotosSize";
            this.sumFotosSizeDataGridViewTextBoxColumn.HeaderText = "$Fotos";
            this.sumFotosSizeDataGridViewTextBoxColumn.Name = "sumFotosSizeDataGridViewTextBoxColumn";
            this.sumFotosSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // officeCountDataGridViewTextBoxColumn
            // 
            this.officeCountDataGridViewTextBoxColumn.DataPropertyName = "OfficeCount";
            this.officeCountDataGridViewTextBoxColumn.HeaderText = "#Office";
            this.officeCountDataGridViewTextBoxColumn.Name = "officeCountDataGridViewTextBoxColumn";
            this.officeCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumOfficeFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumOfficeFilesSize";
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Office";
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.Name = "sumOfficeFilesSizeDataGridViewTextBoxColumn";
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceCodeCountDataGridViewTextBoxColumn
            // 
            this.sourceCodeCountDataGridViewTextBoxColumn.DataPropertyName = "SourceCodeCount";
            this.sourceCodeCountDataGridViewTextBoxColumn.HeaderText = "#SourceCode";
            this.sourceCodeCountDataGridViewTextBoxColumn.Name = "sourceCodeCountDataGridViewTextBoxColumn";
            this.sourceCodeCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumSourceCodeFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumSourceCodeFilesSize";
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.HeaderText = "$SourceCode";
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.Name = "sumSourceCodeFilesSizeDataGridViewTextBoxColumn";
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // videosCountDataGridViewTextBoxColumn
            // 
            this.videosCountDataGridViewTextBoxColumn.DataPropertyName = "VideosCount";
            this.videosCountDataGridViewTextBoxColumn.HeaderText = "#Videos";
            this.videosCountDataGridViewTextBoxColumn.Name = "videosCountDataGridViewTextBoxColumn";
            this.videosCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumVideosFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumVideosFilesSize";
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Videos";
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.Name = "sumVideosFilesSizeDataGridViewTextBoxColumn";
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // webCountDataGridViewTextBoxColumn
            // 
            this.webCountDataGridViewTextBoxColumn.DataPropertyName = "WebCount";
            this.webCountDataGridViewTextBoxColumn.HeaderText = "#Web";
            this.webCountDataGridViewTextBoxColumn.Name = "webCountDataGridViewTextBoxColumn";
            this.webCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumWebFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumWebFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumWebFilesSize";
            this.sumWebFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Web";
            this.sumWebFilesSizeDataGridViewTextBoxColumn.Name = "sumWebFilesSizeDataGridViewTextBoxColumn";
            this.sumWebFilesSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // otherCountDataGridViewTextBoxColumn
            // 
            this.otherCountDataGridViewTextBoxColumn.DataPropertyName = "OtherCount";
            this.otherCountDataGridViewTextBoxColumn.HeaderText = "#Other";
            this.otherCountDataGridViewTextBoxColumn.Name = "otherCountDataGridViewTextBoxColumn";
            this.otherCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumOtherFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumOtherFilesSize";
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Other";
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.Name = "sumOtherFilesSizeDataGridViewTextBoxColumn";
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contentVecBindingSource
            // 
            this.contentVecBindingSource.DataMember = "ContentVec";
            this.contentVecBindingSource.DataSource = this.bindingSourceDsFilesClassification;
            // 
            // bindingSourceDsFilesClassification
            // 
            this.bindingSourceDsFilesClassification.DataSource = this.MyDsFilesClassification;
            this.bindingSourceDsFilesClassification.Position = 0;
            // 
            // FormClassificatorClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(854, 483);
            this.Name = "FormClassificatorClient";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyDsFilesClassification)).EndInit();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentVecBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDsFilesClassification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trvDir;
        private System.Windows.Forms.BindingSource bindingSourceDsFilesClassification;
        private System.Windows.Forms.Button btnClassifyNew;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource contentVecBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn depthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumFilesSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn archiveBitSetCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumArchiveBitFileSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fotosCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumFotosSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn officeCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumOfficeFilesSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceCodeCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumSourceCodeFilesSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn videosCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumVideosFilesSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn webCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumWebFilesSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumOtherFilesSizeDataGridViewTextBoxColumn;
        private DsFilesClassification MyDsFilesClassification;
    }
}
