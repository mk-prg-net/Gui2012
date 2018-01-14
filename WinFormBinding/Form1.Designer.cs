namespace WinFormBinding
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxGreifer = new System.Windows.Forms.ListBox();
            this.greiferBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbxGreiferBaudraten = new System.Windows.Forms.ListBox();
            this.greiferBaudratenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greiferBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greiferBaudratenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.86997F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.13003F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbxGreifer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbxGreiferBaudraten, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 273);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Baudrate in Abhängigkeit vom Greifer wählen";
            // 
            // lbxGreifer
            // 
            this.lbxGreifer.DataSource = this.greiferBindingSource;
            this.lbxGreifer.DisplayMember = "Name";
            this.lbxGreifer.FormattingEnabled = true;
            this.lbxGreifer.Location = new System.Drawing.Point(175, 3);
            this.lbxGreifer.Name = "lbxGreifer";
            this.lbxGreifer.Size = new System.Drawing.Size(120, 95);
            this.lbxGreifer.TabIndex = 1;
            this.lbxGreifer.ValueMember = "ID";
            // 
            // greiferBindingSource
            // 
            this.greiferBindingSource.DataSource = typeof(WinFormBinding.Greifer);
            this.greiferBindingSource.CurrentItemChanged += new System.EventHandler(this.greiferBindingSource_CurrentItemChanged);
            // 
            // lbxGreiferBaudraten
            // 
            this.lbxGreiferBaudraten.DataSource = this.greiferBaudratenBindingSource;
            this.lbxGreiferBaudraten.DisplayMember = "Baudrate";
            this.lbxGreiferBaudraten.FormattingEnabled = true;
            this.lbxGreiferBaudraten.Location = new System.Drawing.Point(323, 3);
            this.lbxGreiferBaudraten.Name = "lbxGreiferBaudraten";
            this.lbxGreiferBaudraten.Size = new System.Drawing.Size(120, 95);
            this.lbxGreiferBaudraten.TabIndex = 2;
            this.lbxGreiferBaudraten.ValueMember = "Baudrate";
            // 
            // greiferBaudratenBindingSource
            // 
            this.greiferBaudratenBindingSource.DataSource = typeof(WinFormBinding.GreiferBaudraten);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greiferBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greiferBaudratenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxGreifer;
        private System.Windows.Forms.ListBox lbxGreiferBaudraten;
        private System.Windows.Forms.BindingSource greiferBindingSource;
        private System.Windows.Forms.BindingSource greiferBaudratenBindingSource;
    }
}

