namespace WinFormCtrlLib
{
    partial class ZeitraumBox
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
            this.lblVon = new System.Windows.Forms.Label();
            this.dateTimePickerVon = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBis = new System.Windows.Forms.DateTimePicker();
            this.lblBis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(4, 21);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(28, 13);
            this.lblVon.TabIndex = 0;
            this.lblVon.Text = "von:";
            // 
            // dateTimePickerVon
            // 
            this.dateTimePickerVon.Location = new System.Drawing.Point(38, 15);
            this.dateTimePickerVon.Name = "dateTimePickerVon";
            this.dateTimePickerVon.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVon.TabIndex = 2;
            this.dateTimePickerVon.ValueChanged += new System.EventHandler(this.dateTimePickerVon_ValueChanged);
            // 
            // dateTimePickerBis
            // 
            this.dateTimePickerBis.Location = new System.Drawing.Point(38, 41);
            this.dateTimePickerBis.Name = "dateTimePickerBis";
            this.dateTimePickerBis.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBis.TabIndex = 4;
            this.dateTimePickerBis.ValueChanged += new System.EventHandler(this.dateTimePickerBis_ValueChanged);
            // 
            // lblBis
            // 
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(4, 47);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(23, 13);
            this.lblBis.TabIndex = 3;
            this.lblBis.Text = "bis:";
            // 
            // ZeitraumBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePickerBis);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.dateTimePickerVon);
            this.Controls.Add(this.lblVon);
            this.Name = "ZeitraumBox";
            this.Size = new System.Drawing.Size(249, 74);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVon;
        private System.Windows.Forms.DateTimePicker dateTimePickerVon;
        private System.Windows.Forms.DateTimePicker dateTimePickerBis;
        private System.Windows.Forms.Label lblBis;
    }
}
