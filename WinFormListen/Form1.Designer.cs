namespace WinFormListen
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
            this.lbxMultiColPrimzahlen = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxMultiColVon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMultiColBis = new System.Windows.Forms.TextBox();
            this.btnMultiColStart = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.lbxMultiColPrimzahlen);
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Size = new System.Drawing.Size(592, 297);
            this.tabPage2.Text = "Mehrspaltige Listen";
            // 
            // lbxMultiColPrimzahlen
            // 
            this.lbxMultiColPrimzahlen.ColumnWidth = 60;
            this.lbxMultiColPrimzahlen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxMultiColPrimzahlen.FormattingEnabled = true;
            this.lbxMultiColPrimzahlen.Location = new System.Drawing.Point(3, 48);
            this.lbxMultiColPrimzahlen.MultiColumn = true;
            this.lbxMultiColPrimzahlen.Name = "lbxMultiColPrimzahlen";
            this.lbxMultiColPrimzahlen.Size = new System.Drawing.Size(586, 246);
            this.lbxMultiColPrimzahlen.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.tbxMultiColVon);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.tbxMultiColBis);
            this.flowLayoutPanel1.Controls.Add(this.btnMultiColStart);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(586, 45);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Primzahlen suchen von:";
            // 
            // tbxMultiColVon
            // 
            this.tbxMultiColVon.Location = new System.Drawing.Point(129, 3);
            this.tbxMultiColVon.Name = "tbxMultiColVon";
            this.tbxMultiColVon.Size = new System.Drawing.Size(100, 20);
            this.tbxMultiColVon.TabIndex = 1;
            this.tbxMultiColVon.Text = "2";
            this.tbxMultiColVon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Primzahlen suchen bis: ";
            // 
            // tbxMultiColBis
            // 
            this.tbxMultiColBis.Location = new System.Drawing.Point(359, 3);
            this.tbxMultiColBis.Name = "tbxMultiColBis";
            this.tbxMultiColBis.Size = new System.Drawing.Size(100, 20);
            this.tbxMultiColBis.TabIndex = 3;
            this.tbxMultiColBis.Text = "1000";
            this.tbxMultiColBis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnMultiColStart
            // 
            this.btnMultiColStart.Location = new System.Drawing.Point(465, 3);
            this.btnMultiColStart.Name = "btnMultiColStart";
            this.btnMultiColStart.Size = new System.Drawing.Size(116, 23);
            this.btnMultiColStart.TabIndex = 4;
            this.btnMultiColStart.Text = "Suche starten";
            this.btnMultiColStart.UseVisualStyleBackColor = true;
            this.btnMultiColStart.Click += new System.EventHandler(this.btnMultiColStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(600, 369);
            this.Name = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMultiColPrimzahlen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxMultiColVon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMultiColBis;
        private System.Windows.Forms.Button btnMultiColStart;
    }
}
