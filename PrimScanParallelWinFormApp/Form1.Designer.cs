namespace PrimScanParallelWinFormApp
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
            this.tabPageScann = new System.Windows.Forms.TabPage();
            this.lbxFertigePartitionen = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxBis = new System.Windows.Forms.TextBox();
            this.tbxVon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbxResultPart = new System.Windows.Forms.ComboBox();
            this.lbxResults = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageScann.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageScann);
            this.tabControl1.Size = new System.Drawing.Size(801, 392);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPageScann, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // lbxLog
            // 
            this.lbxLog.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbxLog.Size = new System.Drawing.Size(586, 199);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Size = new System.Drawing.Size(793, 366);
            this.tabPage2.Text = "Ergebnisse";
            this.tabPage2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            // 
            // tabPageScann
            // 
            this.tabPageScann.Controls.Add(this.lbxFertigePartitionen);
            this.tabPageScann.Controls.Add(this.panel2);
            this.tabPageScann.Location = new System.Drawing.Point(4, 22);
            this.tabPageScann.Name = "tabPageScann";
            this.tabPageScann.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScann.Size = new System.Drawing.Size(592, 297);
            this.tabPageScann.TabIndex = 1;
            this.tabPageScann.Text = "Primscanner";
            this.tabPageScann.UseVisualStyleBackColor = true;
            // 
            // lbxFertigePartitionen
            // 
            this.lbxFertigePartitionen.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbxFertigePartitionen.ColumnWidth = 200;
            this.lbxFertigePartitionen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFertigePartitionen.FormattingEnabled = true;
            this.lbxFertigePartitionen.Location = new System.Drawing.Point(3, 87);
            this.lbxFertigePartitionen.MultiColumn = true;
            this.lbxFertigePartitionen.Name = "lbxFertigePartitionen";
            this.lbxFertigePartitionen.Size = new System.Drawing.Size(586, 207);
            this.lbxFertigePartitionen.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnStartScan);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbxBis);
            this.panel2.Controls.Add(this.tbxVon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 84);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "von:";
            // 
            // btnStartScan
            // 
            this.btnStartScan.Location = new System.Drawing.Point(252, 39);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnStartScan.TabIndex = 4;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(126, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "bis:";
            // 
            // tbxBis
            // 
            this.tbxBis.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbxBis.Location = new System.Drawing.Point(129, 42);
            this.tbxBis.Name = "tbxBis";
            this.tbxBis.Size = new System.Drawing.Size(100, 20);
            this.tbxBis.TabIndex = 1;
            // 
            // tbxVon
            // 
            this.tbxVon.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbxVon.Location = new System.Drawing.Point(11, 42);
            this.tbxVon.Name = "tbxVon";
            this.tbxVon.Size = new System.Drawing.Size(100, 20);
            this.tbxVon.TabIndex = 0;
            this.tbxVon.Validating += new System.ComponentModel.CancelEventHandler(this.tbxVon_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "von";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbxResultPart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbxResults);
            this.splitContainer1.Size = new System.Drawing.Size(787, 360);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbxResultPart
            // 
            this.cbxResultPart.BackColor = System.Drawing.SystemColors.Control;
            this.cbxResultPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxResultPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbxResultPart.FormattingEnabled = true;
            this.cbxResultPart.Location = new System.Drawing.Point(0, 0);
            this.cbxResultPart.Name = "cbxResultPart";
            this.cbxResultPart.Size = new System.Drawing.Size(96, 360);
            this.cbxResultPart.TabIndex = 0;
            this.cbxResultPart.SelectedIndexChanged += new System.EventHandler(this.cbxResultPart_SelectedIndexChanged);
            // 
            // lbxResults
            // 
            this.lbxResults.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbxResults.ColumnWidth = 80;
            this.lbxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxResults.FormattingEnabled = true;
            this.lbxResults.Location = new System.Drawing.Point(0, 0);
            this.lbxResults.MultiColumn = true;
            this.lbxResults.Name = "lbxResults";
            this.lbxResults.Size = new System.Drawing.Size(687, 360);
            this.lbxResults.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(801, 438);
            this.Name = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageScann.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageScann;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxBis;
        private System.Windows.Forms.TextBox tbxVon;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.ListBox lbxFertigePartitionen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbxResultPart;
        private System.Windows.Forms.ListBox lbxResults;
    }
}
