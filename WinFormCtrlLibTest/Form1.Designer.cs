namespace WinFormCtrlLibTest
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
            this.zeitraumBox1 = new WinFormCtrlLib.ZeitraumBox();
            this.lbxLogEvents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // zeitraumBox1
            // 
            this.zeitraumBox1.Bis = new System.DateTime(2012, 4, 26, 12, 20, 25, 268);
            this.zeitraumBox1.Location = new System.Drawing.Point(27, 28);
            this.zeitraumBox1.Name = "zeitraumBox1";
            this.zeitraumBox1.Size = new System.Drawing.Size(249, 74);
            this.zeitraumBox1.TabIndex = 0;
            this.zeitraumBox1.Von = new System.DateTime(2012, 4, 25, 12, 20, 25, 268);
            this.zeitraumBox1.ChangedEvent += new WinFormCtrlLib.ZeitraumBox.PropertyChangedEvent(this.zeitraumBox1_ChangedEvent);
            // 
            // lbxLogEvents
            // 
            this.lbxLogEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxLogEvents.FormattingEnabled = true;
            this.lbxLogEvents.Location = new System.Drawing.Point(27, 109);
            this.lbxLogEvents.Name = "lbxLogEvents";
            this.lbxLogEvents.Size = new System.Drawing.Size(249, 69);
            this.lbxLogEvents.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 187);
            this.Controls.Add(this.lbxLogEvents);
            this.Controls.Add(this.zeitraumBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormCtrlLib.ZeitraumBox zeitraumBox1;
        private System.Windows.Forms.ListBox lbxLogEvents;






    }
}

