namespace babaros6ChartsTest
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbxTestLinearPlot = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLabel = new System.Windows.Forms.Button();
            this.btnTestLinearPlotGenerateLog = new System.Windows.Forms.Button();
            this.btnTestLinearPlotGenerateSinus = new System.Windows.Forms.Button();
            this.btnTestLinearPlotReset = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pbxLogarithmicPlot = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLabelLog = new System.Windows.Forms.Button();
            this.btnTestLogarithmicPlotLog = new System.Windows.Forms.Button();
            this.btnTestLogarithmicPlotReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTestLinearPlot)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogarithmicPlot)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.beendenToolStripMenuItem.Text = "beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(849, 521);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbxLog);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(841, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbxLog
            // 
            this.lbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 16;
            this.lbxLog.Location = new System.Drawing.Point(3, 44);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(835, 436);
            this.lbxLog.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 41);
            this.panel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pbxTestLinearPlot);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(841, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Test linear Plot";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pbxTestLinearPlot
            // 
            this.pbxTestLinearPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxTestLinearPlot.Location = new System.Drawing.Point(3, 53);
            this.pbxTestLinearPlot.Name = "pbxTestLinearPlot";
            this.pbxTestLinearPlot.Size = new System.Drawing.Size(835, 436);
            this.pbxTestLinearPlot.TabIndex = 1;
            this.pbxTestLinearPlot.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLabel);
            this.panel2.Controls.Add(this.btnTestLinearPlotGenerateLog);
            this.panel2.Controls.Add(this.btnTestLinearPlotGenerateSinus);
            this.panel2.Controls.Add(this.btnTestLinearPlotReset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 50);
            this.panel2.TabIndex = 0;
            // 
            // btnLabel
            // 
            this.btnLabel.Location = new System.Drawing.Point(356, 12);
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Size = new System.Drawing.Size(104, 23);
            this.btnLabel.TabIndex = 3;
            this.btnLabel.Text = "label";
            this.btnLabel.UseVisualStyleBackColor = true;
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnTestLinearPlotGenerateLog
            // 
            this.btnTestLinearPlotGenerateLog.Location = new System.Drawing.Point(229, 12);
            this.btnTestLinearPlotGenerateLog.Name = "btnTestLinearPlotGenerateLog";
            this.btnTestLinearPlotGenerateLog.Size = new System.Drawing.Size(103, 23);
            this.btnTestLinearPlotGenerateLog.TabIndex = 2;
            this.btnTestLinearPlotGenerateLog.Text = "log";
            this.btnTestLinearPlotGenerateLog.UseVisualStyleBackColor = true;
            this.btnTestLinearPlotGenerateLog.Click += new System.EventHandler(this.btnTestLinearPlotGenerateLog_Click);
            // 
            // btnTestLinearPlotGenerateSinus
            // 
            this.btnTestLinearPlotGenerateSinus.Location = new System.Drawing.Point(111, 11);
            this.btnTestLinearPlotGenerateSinus.Name = "btnTestLinearPlotGenerateSinus";
            this.btnTestLinearPlotGenerateSinus.Size = new System.Drawing.Size(96, 23);
            this.btnTestLinearPlotGenerateSinus.TabIndex = 1;
            this.btnTestLinearPlotGenerateSinus.Text = "Sin";
            this.btnTestLinearPlotGenerateSinus.UseVisualStyleBackColor = true;
            this.btnTestLinearPlotGenerateSinus.Click += new System.EventHandler(this.btnTestLinearPlotGenerateSinus_Click);
            // 
            // btnTestLinearPlotReset
            // 
            this.btnTestLinearPlotReset.Location = new System.Drawing.Point(8, 10);
            this.btnTestLinearPlotReset.Name = "btnTestLinearPlotReset";
            this.btnTestLinearPlotReset.Size = new System.Drawing.Size(86, 25);
            this.btnTestLinearPlotReset.TabIndex = 0;
            this.btnTestLinearPlotReset.Text = "Reset";
            this.btnTestLinearPlotReset.UseVisualStyleBackColor = true;
            this.btnTestLinearPlotReset.Click += new System.EventHandler(this.btnTestLinearPlotReset_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pbxLogarithmicPlot);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(841, 492);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test logarithmic Plot";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pbxLogarithmicPlot
            // 
            this.pbxLogarithmicPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxLogarithmicPlot.Location = new System.Drawing.Point(0, 44);
            this.pbxLogarithmicPlot.Name = "pbxLogarithmicPlot";
            this.pbxLogarithmicPlot.Size = new System.Drawing.Size(841, 448);
            this.pbxLogarithmicPlot.TabIndex = 1;
            this.pbxLogarithmicPlot.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLabelLog);
            this.panel3.Controls.Add(this.btnTestLogarithmicPlotLog);
            this.panel3.Controls.Add(this.btnTestLogarithmicPlotReset);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 44);
            this.panel3.TabIndex = 0;
            // 
            // btnLabelLog
            // 
            this.btnLabelLog.Location = new System.Drawing.Point(165, 3);
            this.btnLabelLog.Name = "btnLabelLog";
            this.btnLabelLog.Size = new System.Drawing.Size(113, 35);
            this.btnLabelLog.TabIndex = 2;
            this.btnLabelLog.Text = "LableLog";
            this.btnLabelLog.UseVisualStyleBackColor = true;
            this.btnLabelLog.Click += new System.EventHandler(this.btnLabelLog_Click);
            // 
            // btnTestLogarithmicPlotLog
            // 
            this.btnTestLogarithmicPlotLog.Location = new System.Drawing.Point(84, 3);
            this.btnTestLogarithmicPlotLog.Name = "btnTestLogarithmicPlotLog";
            this.btnTestLogarithmicPlotLog.Size = new System.Drawing.Size(75, 36);
            this.btnTestLogarithmicPlotLog.TabIndex = 1;
            this.btnTestLogarithmicPlotLog.Text = "log";
            this.btnTestLogarithmicPlotLog.UseVisualStyleBackColor = true;
            this.btnTestLogarithmicPlotLog.Click += new System.EventHandler(this.btnTestLogarithmicPlotLog_Click);
            // 
            // btnTestLogarithmicPlotReset
            // 
            this.btnTestLogarithmicPlotReset.Location = new System.Drawing.Point(3, 3);
            this.btnTestLogarithmicPlotReset.Name = "btnTestLogarithmicPlotReset";
            this.btnTestLogarithmicPlotReset.Size = new System.Drawing.Size(75, 36);
            this.btnTestLogarithmicPlotReset.TabIndex = 0;
            this.btnTestLogarithmicPlotReset.Text = "Reset";
            this.btnTestLogarithmicPlotReset.UseVisualStyleBackColor = true;
            this.btnTestLogarithmicPlotReset.Click += new System.EventHandler(this.btnTestLogarithmicPlotReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 569);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTestLinearPlot)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogarithmicPlot)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pbxTestLinearPlot;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTestLinearPlotReset;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pbxLogarithmicPlot;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTestLinearPlotGenerateLog;
        private System.Windows.Forms.Button btnTestLinearPlotGenerateSinus;
        private System.Windows.Forms.Button btnTestLogarithmicPlotReset;
        private System.Windows.Forms.Button btnTestLogarithmicPlotLog;
        private System.Windows.Forms.Button btnLabel;
        private System.Windows.Forms.Button btnLabelLog;
    }
}

