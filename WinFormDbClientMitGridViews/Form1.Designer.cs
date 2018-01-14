namespace WinFormDbClientMitGridViews
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdMasterDetailLieferanten = new System.Windows.Forms.DataGridView();
            this.lfnrDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plzDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LieferantenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDbArtikel1 = new WinFormDbClientMitGridViews.DsDbArtikel();
            this.grdMAsterDetailProdukte = new System.Windows.Forms.DataGridView();
            this.ArtikelViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.ProdukteMaterDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLieferantenSave = new System.Windows.Forms.Button();
            this.btnRequeryLieferanten = new System.Windows.Forms.Button();
            this.grdLieferanten = new System.Windows.Forms.DataGridView();
            this.lfnrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plzDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lieferantenTableAdapter = new WinFormDbClientMitGridViews.DsDbArtikelTableAdapters.LieferantenTableAdapter();
            this.produkteTableAdapter = new WinFormDbClientMitGridViews.DsDbArtikelTableAdapters.ProdukteTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.artikelDetailsViewTableAdapter = new WinFormDbClientMitGridViews.DsDbArtikelTableAdapters.ArtikelDetailsViewTableAdapter();
            this.artnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProduktName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vorrat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMasterDetailLieferanten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LieferantenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDbArtikel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMAsterDetailProdukte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtikelViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdukteMaterDetailsBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLieferanten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Size = new System.Drawing.Size(592, 297);
            // 
            // lbxLog
            // 
            this.lbxLog.ItemHeight = 13;
            this.lbxLog.Size = new System.Drawing.Size(586, 199);
            // 
            // cbxLbxLogAnzeigeoptionen
            // 
            this.cbxLbxLogAnzeigeoptionen.Size = new System.Drawing.Size(119, 34);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdLieferanten);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Size = new System.Drawing.Size(592, 297);
            this.tabPage2.Text = "Lieferanten";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(592, 297);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Master Detail";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdMasterDetailLieferanten);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdMAsterDetailProdukte);
            this.splitContainer1.Size = new System.Drawing.Size(586, 245);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdMasterDetailLieferanten
            // 
            this.grdMasterDetailLieferanten.AutoGenerateColumns = false;
            this.grdMasterDetailLieferanten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMasterDetailLieferanten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lfnrDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.emailDataGridViewTextBoxColumn1,
            this.plzDataGridViewTextBoxColumn1});
            this.grdMasterDetailLieferanten.DataSource = this.LieferantenBindingSource;
            this.grdMasterDetailLieferanten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMasterDetailLieferanten.Location = new System.Drawing.Point(0, 0);
            this.grdMasterDetailLieferanten.Name = "grdMasterDetailLieferanten";
            this.grdMasterDetailLieferanten.Size = new System.Drawing.Size(586, 136);
            this.grdMasterDetailLieferanten.TabIndex = 0;
            // 
            // lfnrDataGridViewTextBoxColumn1
            // 
            this.lfnrDataGridViewTextBoxColumn1.DataPropertyName = "lfnr";
            this.lfnrDataGridViewTextBoxColumn1.HeaderText = "lfnr";
            this.lfnrDataGridViewTextBoxColumn1.Name = "lfnrDataGridViewTextBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // emailDataGridViewTextBoxColumn1
            // 
            this.emailDataGridViewTextBoxColumn1.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn1.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn1.Name = "emailDataGridViewTextBoxColumn1";
            // 
            // plzDataGridViewTextBoxColumn1
            // 
            this.plzDataGridViewTextBoxColumn1.DataPropertyName = "plz";
            this.plzDataGridViewTextBoxColumn1.HeaderText = "plz";
            this.plzDataGridViewTextBoxColumn1.Name = "plzDataGridViewTextBoxColumn1";
            // 
            // LieferantenBindingSource
            // 
            this.LieferantenBindingSource.DataMember = "Lieferanten";
            this.LieferantenBindingSource.DataSource = this.dsDbArtikel1;
            this.LieferantenBindingSource.CurrentChanged += new System.EventHandler(this.LieferantenBindingSource_CurrentChanged);
            this.LieferantenBindingSource.CurrentItemChanged += new System.EventHandler(this.LieferantenBindingSource_CurrentItemChanged);
            this.LieferantenBindingSource.PositionChanged += new System.EventHandler(this.LieferantenBindingSource_PositionChanged);
            // 
            // dsDbArtikel1
            // 
            this.dsDbArtikel1.DataSetName = "DsDbArtikel";
            this.dsDbArtikel1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grdMAsterDetailProdukte
            // 
            this.grdMAsterDetailProdukte.AllowUserToAddRows = false;
            this.grdMAsterDetailProdukte.AllowUserToDeleteRows = false;
            this.grdMAsterDetailProdukte.AutoGenerateColumns = false;
            this.grdMAsterDetailProdukte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMAsterDetailProdukte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artnr,
            this.ProduktName,
            this.preis,
            this.vorrat});
            this.grdMAsterDetailProdukte.DataSource = this.ArtikelViewBindingSource;
            this.grdMAsterDetailProdukte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMAsterDetailProdukte.Location = new System.Drawing.Point(0, 0);
            this.grdMAsterDetailProdukte.Name = "grdMAsterDetailProdukte";
            this.grdMAsterDetailProdukte.ReadOnly = true;
            this.grdMAsterDetailProdukte.Size = new System.Drawing.Size(586, 105);
            this.grdMAsterDetailProdukte.TabIndex = 0;
            // 
            // ArtikelViewBindingSource
            // 
            this.ArtikelViewBindingSource.DataMember = "ArtikelDetailsView";
            this.ArtikelViewBindingSource.DataSource = this.dsDbArtikel1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(586, 46);
            this.panel3.TabIndex = 0;
            // 
            // ProdukteMaterDetailsBindingSource
            // 
            this.ProdukteMaterDetailsBindingSource.DataMember = "Produkte";
            this.ProdukteMaterDetailsBindingSource.DataSource = this.dsDbArtikel1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLieferantenSave);
            this.panel2.Controls.Add(this.btnRequeryLieferanten);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 46);
            this.panel2.TabIndex = 0;
            // 
            // btnLieferantenSave
            // 
            this.btnLieferantenSave.Location = new System.Drawing.Point(101, 4);
            this.btnLieferantenSave.Name = "btnLieferantenSave";
            this.btnLieferantenSave.Size = new System.Drawing.Size(75, 23);
            this.btnLieferantenSave.TabIndex = 1;
            this.btnLieferantenSave.Text = "Save";
            this.btnLieferantenSave.UseVisualStyleBackColor = true;
            this.btnLieferantenSave.Click += new System.EventHandler(this.btnLieferantenSave_Click);
            // 
            // btnRequeryLieferanten
            // 
            this.btnRequeryLieferanten.Location = new System.Drawing.Point(6, 4);
            this.btnRequeryLieferanten.Name = "btnRequeryLieferanten";
            this.btnRequeryLieferanten.Size = new System.Drawing.Size(75, 23);
            this.btnRequeryLieferanten.TabIndex = 0;
            this.btnRequeryLieferanten.Text = "Requery";
            this.btnRequeryLieferanten.UseVisualStyleBackColor = true;
            this.btnRequeryLieferanten.Click += new System.EventHandler(this.btnRequeryLieferanten_Click);
            // 
            // grdLieferanten
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grdLieferanten.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLieferanten.AutoGenerateColumns = false;
            this.grdLieferanten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLieferanten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lfnrDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.plzDataGridViewTextBoxColumn});
            this.grdLieferanten.DataSource = this.LieferantenBindingSource;
            this.grdLieferanten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLieferanten.Location = new System.Drawing.Point(3, 49);
            this.grdLieferanten.Name = "grdLieferanten";
            this.grdLieferanten.Size = new System.Drawing.Size(586, 245);
            this.grdLieferanten.TabIndex = 1;
            // 
            // lfnrDataGridViewTextBoxColumn
            // 
            this.lfnrDataGridViewTextBoxColumn.DataPropertyName = "lfnr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.lfnrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.lfnrDataGridViewTextBoxColumn.HeaderText = "lfnr";
            this.lfnrDataGridViewTextBoxColumn.Name = "lfnrDataGridViewTextBoxColumn";
            this.lfnrDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // plzDataGridViewTextBoxColumn
            // 
            this.plzDataGridViewTextBoxColumn.DataPropertyName = "plz";
            this.plzDataGridViewTextBoxColumn.HeaderText = "plz";
            this.plzDataGridViewTextBoxColumn.Name = "plzDataGridViewTextBoxColumn";
            // 
            // lieferantenTableAdapter
            // 
            this.lieferantenTableAdapter.ClearBeforeFill = true;
            // 
            // produkteTableAdapter
            // 
            this.produkteTableAdapter.ClearBeforeFill = true;
            // 
            // artikelDetailsViewTableAdapter
            // 
            this.artikelDetailsViewTableAdapter.ClearBeforeFill = true;
            // 
            // artnr
            // 
            this.artnr.DataPropertyName = "artnr";
            this.artnr.HeaderText = "artnr";
            this.artnr.Name = "artnr";
            this.artnr.ReadOnly = true;
            // 
            // ProduktName
            // 
            this.ProduktName.DataPropertyName = "ProduktName";
            this.ProduktName.HeaderText = "ProduktName";
            this.ProduktName.Name = "ProduktName";
            this.ProduktName.ReadOnly = true;
            // 
            // preis
            // 
            this.preis.DataPropertyName = "preis";
            this.preis.HeaderText = "preis";
            this.preis.Name = "preis";
            this.preis.ReadOnly = true;
            // 
            // vorrat
            // 
            this.vorrat.DataPropertyName = "vorrat";
            this.vorrat.HeaderText = "vorrat";
            this.vorrat.Name = "vorrat";
            this.vorrat.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(600, 369);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMasterDetailLieferanten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LieferantenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDbArtikel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMAsterDetailProdukte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtikelViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdukteMaterDetailsBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLieferanten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grdLieferanten;
        private System.Windows.Forms.Panel panel2;
        private DsDbArtikel dsDbArtikel1;
        private System.Windows.Forms.BindingSource LieferantenBindingSource;
        private DsDbArtikelTableAdapters.LieferantenTableAdapter lieferantenTableAdapter;
        private System.Windows.Forms.Button btnRequeryLieferanten;
        private System.Windows.Forms.Button btnLieferantenSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn lfnrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plzDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdMasterDetailLieferanten;
        private System.Windows.Forms.DataGridViewTextBoxColumn lfnrDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn plzDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView grdMAsterDetailProdukte;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource ProdukteMaterDetailsBindingSource;
        private DsDbArtikelTableAdapters.ProdukteTableAdapter produkteTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource ArtikelViewBindingSource;
        private DsDbArtikelTableAdapters.ArtikelDetailsViewTableAdapter artikelDetailsViewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn artnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProduktName;
        private System.Windows.Forms.DataGridViewTextBoxColumn preis;
        private System.Windows.Forms.DataGridViewTextBoxColumn vorrat;
    }
}
