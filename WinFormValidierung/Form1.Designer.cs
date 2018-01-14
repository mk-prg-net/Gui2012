namespace u3_Validating
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
            this.tbxA = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxB = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxRes = new System.Windows.Forms.TextBox();
            this.lblBValid = new System.Windows.Forms.Label();
            this.lblAValid = new System.Windows.Forms.Label();
            this.cbxOperatoren = new System.Windows.Forms.ComboBox();
            this.opItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCalc = new System.Windows.Forms.Button();
            this.lblFehler = new System.Windows.Forms.Label();
            this.btnOpUp = new System.Windows.Forms.Button();
            this.btnOpDown = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxA
            // 
            this.tbxA.Location = new System.Drawing.Point(53, 3);
            this.tbxA.Name = "tbxA";
            this.tbxA.Size = new System.Drawing.Size(94, 20);
            this.tbxA.TabIndex = 2;
            this.tbxA.Text = "0";
            this.tbxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxA.Validating += new System.ComponentModel.CancelEventHandler(this.tbxA_Validating);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.Controls.Add(this.tbxA, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxRes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBValid, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAValid, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxOperatoren, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCalc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFehler, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOpUp, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOpDown, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 119);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "A = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "B = ";
            // 
            // tbxB
            // 
            this.tbxB.Location = new System.Drawing.Point(53, 30);
            this.tbxB.Name = "tbxB";
            this.tbxB.Size = new System.Drawing.Size(94, 20);
            this.tbxB.TabIndex = 4;
            this.tbxB.Text = "0";
            this.tbxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxB.Validating += new System.ComponentModel.CancelEventHandler(this.tbxB_Validating);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 20);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxRes
            // 
            this.tbxRes.Location = new System.Drawing.Point(50, 54);
            this.tbxRes.Margin = new System.Windows.Forms.Padding(0);
            this.tbxRes.Name = "tbxRes";
            this.tbxRes.ReadOnly = true;
            this.tbxRes.Size = new System.Drawing.Size(100, 20);
            this.tbxRes.TabIndex = 7;
            this.tbxRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBValid
            // 
            this.lblBValid.AutoSize = true;
            this.lblBValid.ForeColor = System.Drawing.Color.Red;
            this.lblBValid.Location = new System.Drawing.Point(173, 27);
            this.lblBValid.Name = "lblBValid";
            this.lblBValid.Size = new System.Drawing.Size(0, 13);
            this.lblBValid.TabIndex = 9;
            // 
            // lblAValid
            // 
            this.lblAValid.AutoSize = true;
            this.lblAValid.ForeColor = System.Drawing.Color.Red;
            this.lblAValid.Location = new System.Drawing.Point(173, 0);
            this.lblAValid.Name = "lblAValid";
            this.lblAValid.Size = new System.Drawing.Size(0, 13);
            this.lblAValid.TabIndex = 8;
            // 
            // cbxOperatoren
            // 
            this.cbxOperatoren.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opItemsBindingSource, "Text", true));
            this.cbxOperatoren.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.opItemsBindingSource, "Operation", true));
            this.cbxOperatoren.DataSource = this.opItemsBindingSource;
            this.cbxOperatoren.DisplayMember = "Text";
            this.cbxOperatoren.FormattingEnabled = true;
            this.cbxOperatoren.Location = new System.Drawing.Point(173, 83);
            this.cbxOperatoren.Name = "cbxOperatoren";
            this.cbxOperatoren.Size = new System.Drawing.Size(53, 21);
            this.cbxOperatoren.TabIndex = 11;
            this.cbxOperatoren.ValueMember = "Operation";
            this.cbxOperatoren.TextUpdate += new System.EventHandler(this.cbxOperatoren_TextUpdate);
            this.cbxOperatoren.Validating += new System.ComponentModel.CancelEventHandler(this.cbxOperatoren_Validating);
            // 
            // opItemsBindingSource
            // 
            this.opItemsBindingSource.DataSource = typeof(u3_Validating.OpItems);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(3, 83);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(44, 23);
            this.btnCalc.TabIndex = 12;
            this.btnCalc.Text = "calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // lblFehler
            // 
            this.lblFehler.AutoSize = true;
            this.lblFehler.ForeColor = System.Drawing.Color.Red;
            this.lblFehler.Location = new System.Drawing.Point(276, 54);
            this.lblFehler.Name = "lblFehler";
            this.lblFehler.Size = new System.Drawing.Size(0, 13);
            this.lblFehler.TabIndex = 10;
            // 
            // btnOpUp
            // 
            this.btnOpUp.Location = new System.Drawing.Point(232, 83);
            this.btnOpUp.Name = "btnOpUp";
            this.btnOpUp.Size = new System.Drawing.Size(38, 23);
            this.btnOpUp.TabIndex = 13;
            this.btnOpUp.Text = "up";
            this.btnOpUp.UseVisualStyleBackColor = true;
            this.btnOpUp.Click += new System.EventHandler(this.btnOpUp_Click);
            // 
            // btnOpDown
            // 
            this.btnOpDown.Location = new System.Drawing.Point(276, 83);
            this.btnOpDown.Name = "btnOpDown";
            this.btnOpDown.Size = new System.Drawing.Size(75, 23);
            this.btnOpDown.TabIndex = 14;
            this.btnOpDown.Text = "down";
            this.btnOpDown.UseVisualStyleBackColor = true;
            this.btnOpDown.Click += new System.EventHandler(this.btnOpDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 119);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxB;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxRes;
        private System.Windows.Forms.Label lblBValid;
        private System.Windows.Forms.Label lblAValid;
        private System.Windows.Forms.Label lblFehler;
        private System.Windows.Forms.ComboBox cbxOperatoren;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.BindingSource opItemsBindingSource;
        private System.Windows.Forms.Button btnOpUp;
        private System.Windows.Forms.Button btnOpDown;
    }
}

