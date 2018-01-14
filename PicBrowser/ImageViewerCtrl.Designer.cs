namespace PicBrowser
{
    partial class ImageViewerCtrl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.tabCtrlImageAttributes = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.tabPageExif = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dsExif1 = new PicBrowser.DsExif();
            this.dsExif1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exifBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exifAtribDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.tabCtrlImageAttributes.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageExif.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsExif1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsExif1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exifBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbxImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabCtrlImageAttributes);
            this.splitContainer1.Size = new System.Drawing.Size(752, 605);
            this.splitContainer1.SplitterDistance = 388;
            this.splitContainer1.TabIndex = 0;
            // 
            // pbxImage
            // 
            this.pbxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxImage.Location = new System.Drawing.Point(0, 0);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(752, 388);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            // 
            // tabCtrlImageAttributes
            // 
            this.tabCtrlImageAttributes.Controls.Add(this.tabPageCommon);
            this.tabCtrlImageAttributes.Controls.Add(this.tabPageExif);
            this.tabCtrlImageAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlImageAttributes.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlImageAttributes.Name = "tabCtrlImageAttributes";
            this.tabCtrlImageAttributes.SelectedIndex = 0;
            this.tabCtrlImageAttributes.Size = new System.Drawing.Size(752, 213);
            this.tabCtrlImageAttributes.TabIndex = 0;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.tableLayoutPanel1);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 25);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(744, 184);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Allgemein";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // tabPageExif
            // 
            this.tabPageExif.Controls.Add(this.dataGridView1);
            this.tabPageExif.Location = new System.Drawing.Point(4, 25);
            this.tabPageExif.Name = "tabPageExif";
            this.tabPageExif.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExif.Size = new System.Drawing.Size(744, 184);
            this.tabPageExif.TabIndex = 1;
            this.tabPageExif.Text = "Exif";
            this.tabPageExif.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.95664F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.04336F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPath, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.48315F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.51685F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 178);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pfad";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(105, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(12, 17);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = ".";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.posDataGridViewTextBoxColumn,
            this.exifAtribDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.exifBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(738, 178);
            this.dataGridView1.TabIndex = 0;
            // 
            // dsExif1
            // 
            this.dsExif1.DataSetName = "DsExif";
            this.dsExif1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsExif1BindingSource
            // 
            this.dsExif1BindingSource.DataSource = this.dsExif1;
            this.dsExif1BindingSource.Position = 0;
            // 
            // exifBindingSource
            // 
            this.exifBindingSource.DataMember = "Exif";
            this.exifBindingSource.DataSource = this.dsExif1BindingSource;
            // 
            // posDataGridViewTextBoxColumn
            // 
            this.posDataGridViewTextBoxColumn.DataPropertyName = "pos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.posDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.posDataGridViewTextBoxColumn.HeaderText = "Pos";
            this.posDataGridViewTextBoxColumn.Name = "posDataGridViewTextBoxColumn";
            // 
            // exifAtribDataGridViewTextBoxColumn
            // 
            this.exifAtribDataGridViewTextBoxColumn.DataPropertyName = "ExifAtrib";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.exifAtribDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.exifAtribDataGridViewTextBoxColumn.HeaderText = "EXIF";
            this.exifAtribDataGridViewTextBoxColumn.Name = "exifAtribDataGridViewTextBoxColumn";
            this.exifAtribDataGridViewTextBoxColumn.Width = 250;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.valueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Wert";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // ImageViewerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImageViewerCtrl";
            this.Size = new System.Drawing.Size(752, 605);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.tabCtrlImageAttributes.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageExif.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsExif1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsExif1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exifBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.TabControl tabCtrlImageAttributes;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TabPage tabPageExif;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn posDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exifAtribDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource exifBindingSource;
        private System.Windows.Forms.BindingSource dsExif1BindingSource;
        public DsExif dsExif1;
    }
}
