namespace FileClassificatorClient
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
            System.Windows.Forms.Button btnNewJobResetValues;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jobIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobProccessingElapsedTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeNowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDirsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countFilesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countResultsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceAllActiveJobs = new System.Windows.Forms.BindingSource(this.components);
            this.dsFilesClassification = new DMS.FC.DsFilesClassification();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnActiveJobsStartStopAutoUpdate = new System.Windows.Forms.Button();
            this.btnActiveJobKillJob = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbxResultsJobs = new System.Windows.Forms.ListBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
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
            this.bindingSourceJobResults = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.gbxResultsFilter = new System.Windows.Forms.GroupBox();
            this.cbxResulltsFilterOps = new System.Windows.Forms.ComboBox();
            this.cbxResultsFilterColName = new System.Windows.Forms.ComboBox();
            this.btnResultsFilterSet = new System.Windows.Forms.Button();
            this.tbxResultsFilter = new System.Windows.Forms.TextBox();
            this.rbtResultsFilterNo = new System.Windows.Forms.RadioButton();
            this.rbtResultsFilterYes = new System.Windows.Forms.RadioButton();
            this.btnLoadFinishedJobs = new System.Windows.Forms.Button();
            this.btnSaveAllFinishedJobs = new System.Windows.Forms.Button();
            this.btnResultsDelete = new System.Windows.Forms.Button();
            this.btnResultsRequery = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnRemotingLoadConfig = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewJobPush = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxNewJobFileType = new System.Windows.Forms.TextBox();
            this.tbxNewJobRegEx = new System.Windows.Forms.TextBox();
            this.tbxNewJobMinSize = new System.Windows.Forms.MaskedTextBox();
            this.tbxNewJobMaxSize = new System.Windows.Forms.MaskedTextBox();
            this.tbxNewJobDir = new System.Windows.Forms.TextBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.timerUpdateActiveJobsView = new System.Windows.Forms.Timer(this.components);
            this.dlgSaveFinishedJobs = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenFinishedJobs = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            btnNewJobResetValues = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAllActiveJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFilesClassification)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJobResults)).BeginInit();
            this.panel4.SuspendLayout();
            this.gbxResultsFilter.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Size = new System.Drawing.Size(867, 322);
            this.tabControl1.Controls.SetChildIndex(this.tabPage5, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage4, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(859, 296);
            // 
            // lbxLog
            // 
            this.lbxLog.ItemHeight = 13;
            this.lbxLog.Margin = new System.Windows.Forms.Padding(2);
            this.lbxLog.Size = new System.Drawing.Size(885, 212);
            // 
            // cbxLbxLogAnzeigeoptionen
            // 
            this.cbxLbxLogAnzeigeoptionen.Margin = new System.Windows.Forms.Padding(2);
            this.cbxLbxLogAnzeigeoptionen.Size = new System.Drawing.Size(119, 34);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(859, 296);
            this.tabPage2.Text = "Neuer Job";
            // 
            // btnNewJobResetValues
            // 
            btnNewJobResetValues.Location = new System.Drawing.Point(116, 12);
            btnNewJobResetValues.Margin = new System.Windows.Forms.Padding(2);
            btnNewJobResetValues.Name = "btnNewJobResetValues";
            btnNewJobResetValues.Size = new System.Drawing.Size(181, 24);
            btnNewJobResetValues.TabIndex = 1;
            btnNewJobResetValues.Text = "auf Standardwerte zurücksetzen";
            btnNewJobResetValues.UseVisualStyleBackColor = true;
            btnNewJobResetValues.Click += new System.EventHandler(this.btnNewJobResetValues_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(859, 296);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Aktive Jobs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jobIdDataGridViewTextBoxColumn,
            this.jobStateDataGridViewTextBoxColumn,
            this.jobProccessingElapsedTimeDataGridViewTextBoxColumn,
            this.dateTimeNowDataGridViewTextBoxColumn,
            this.countDirsDataGridViewTextBoxColumn,
            this.countFilesDataGridViewTextBoxColumn,
            this.countResultsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSourceAllActiveJobs;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(859, 244);
            this.dataGridView1.TabIndex = 1;
            // 
            // jobIdDataGridViewTextBoxColumn
            // 
            this.jobIdDataGridViewTextBoxColumn.DataPropertyName = "JobId";
            this.jobIdDataGridViewTextBoxColumn.HeaderText = "JobId";
            this.jobIdDataGridViewTextBoxColumn.Name = "jobIdDataGridViewTextBoxColumn";
            // 
            // jobStateDataGridViewTextBoxColumn
            // 
            this.jobStateDataGridViewTextBoxColumn.DataPropertyName = "JobState";
            this.jobStateDataGridViewTextBoxColumn.HeaderText = "JobState";
            this.jobStateDataGridViewTextBoxColumn.Name = "jobStateDataGridViewTextBoxColumn";
            // 
            // jobProccessingElapsedTimeDataGridViewTextBoxColumn
            // 
            this.jobProccessingElapsedTimeDataGridViewTextBoxColumn.DataPropertyName = "JobProccessingElapsedTime";
            this.jobProccessingElapsedTimeDataGridViewTextBoxColumn.HeaderText = "JobProccessingElapsedTime";
            this.jobProccessingElapsedTimeDataGridViewTextBoxColumn.Name = "jobProccessingElapsedTimeDataGridViewTextBoxColumn";
            // 
            // dateTimeNowDataGridViewTextBoxColumn
            // 
            this.dateTimeNowDataGridViewTextBoxColumn.DataPropertyName = "DateTimeNow";
            this.dateTimeNowDataGridViewTextBoxColumn.HeaderText = "DateTimeNow";
            this.dateTimeNowDataGridViewTextBoxColumn.Name = "dateTimeNowDataGridViewTextBoxColumn";
            // 
            // countDirsDataGridViewTextBoxColumn
            // 
            this.countDirsDataGridViewTextBoxColumn.DataPropertyName = "CountDirs";
            this.countDirsDataGridViewTextBoxColumn.HeaderText = "CountDirs";
            this.countDirsDataGridViewTextBoxColumn.Name = "countDirsDataGridViewTextBoxColumn";
            // 
            // countFilesDataGridViewTextBoxColumn
            // 
            this.countFilesDataGridViewTextBoxColumn.DataPropertyName = "CountFiles";
            this.countFilesDataGridViewTextBoxColumn.HeaderText = "CountFiles";
            this.countFilesDataGridViewTextBoxColumn.Name = "countFilesDataGridViewTextBoxColumn";
            // 
            // countResultsDataGridViewTextBoxColumn
            // 
            this.countResultsDataGridViewTextBoxColumn.DataPropertyName = "CountResults";
            this.countResultsDataGridViewTextBoxColumn.HeaderText = "CountResults";
            this.countResultsDataGridViewTextBoxColumn.Name = "countResultsDataGridViewTextBoxColumn";
            // 
            // bindingSourceAllActiveJobs
            // 
            this.bindingSourceAllActiveJobs.DataMember = "ActiveJobs";
            this.bindingSourceAllActiveJobs.DataSource = this.dsFilesClassification;
            // 
            // dsFilesClassification
            // 
            this.dsFilesClassification.DataSetName = "DsFilesClassification";
            this.dsFilesClassification.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnActiveJobsStartStopAutoUpdate);
            this.panel3.Controls.Add(this.btnActiveJobKillJob);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(859, 52);
            this.panel3.TabIndex = 0;
            // 
            // btnActiveJobsStartStopAutoUpdate
            // 
            this.btnActiveJobsStartStopAutoUpdate.BackColor = System.Drawing.Color.Red;
            this.btnActiveJobsStartStopAutoUpdate.Location = new System.Drawing.Point(6, 12);
            this.btnActiveJobsStartStopAutoUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnActiveJobsStartStopAutoUpdate.Name = "btnActiveJobsStartStopAutoUpdate";
            this.btnActiveJobsStartStopAutoUpdate.Size = new System.Drawing.Size(202, 29);
            this.btnActiveJobsStartStopAutoUpdate.TabIndex = 1;
            this.btnActiveJobsStartStopAutoUpdate.Text = "automat. Aktualisierung stoppen";
            this.btnActiveJobsStartStopAutoUpdate.UseVisualStyleBackColor = false;
            this.btnActiveJobsStartStopAutoUpdate.Click += new System.EventHandler(this.btnActiveJobsStartStopAutoUpdate_Click);
            // 
            // btnActiveJobKillJob
            // 
            this.btnActiveJobKillJob.BackColor = System.Drawing.Color.Red;
            this.btnActiveJobKillJob.Enabled = false;
            this.btnActiveJobKillJob.Location = new System.Drawing.Point(241, 12);
            this.btnActiveJobKillJob.Margin = new System.Windows.Forms.Padding(2);
            this.btnActiveJobKillJob.Name = "btnActiveJobKillJob";
            this.btnActiveJobKillJob.Size = new System.Drawing.Size(145, 29);
            this.btnActiveJobKillJob.TabIndex = 0;
            this.btnActiveJobKillJob.Text = "ausgewählten Job löschen";
            this.btnActiveJobKillJob.UseVisualStyleBackColor = false;
            this.btnActiveJobKillJob.Click += new System.EventHandler(this.btnActiveJobKillJob_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer1);
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(859, 296);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Resultate";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 64);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbxResultsJobs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(859, 232);
            this.splitContainer1.SplitterDistance = 92;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbxResultsJobs
            // 
            this.lbxResultsJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxResultsJobs.FormatString = "N0";
            this.lbxResultsJobs.FormattingEnabled = true;
            this.lbxResultsJobs.Location = new System.Drawing.Point(0, 0);
            this.lbxResultsJobs.Margin = new System.Windows.Forms.Padding(2);
            this.lbxResultsJobs.Name = "lbxResultsJobs";
            this.lbxResultsJobs.Size = new System.Drawing.Size(92, 232);
            this.lbxResultsJobs.TabIndex = 0;
            this.lbxResultsJobs.SelectedIndexChanged += new System.EventHandler(this.lbxResultsJobs_SelectedIndexChanged);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView2.DataSource = this.bindingSourceJobResults;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(764, 232);
            this.dataGridView2.TabIndex = 0;
            // 
            // depthDataGridViewTextBoxColumn
            // 
            this.depthDataGridViewTextBoxColumn.DataPropertyName = "depth";
            this.depthDataGridViewTextBoxColumn.HeaderText = "Tiefe";
            this.depthDataGridViewTextBoxColumn.Name = "depthDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "path";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = null;
            this.pathDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pathDataGridViewTextBoxColumn.HeaderText = "Verzeichnis";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // fileCountDataGridViewTextBoxColumn
            // 
            this.fileCountDataGridViewTextBoxColumn.DataPropertyName = "FileCount";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.fileCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fileCountDataGridViewTextBoxColumn.HeaderText = "#Files";
            this.fileCountDataGridViewTextBoxColumn.Name = "fileCountDataGridViewTextBoxColumn";
            // 
            // sumFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumFilesSize";
            this.sumFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Files";
            this.sumFilesSizeDataGridViewTextBoxColumn.Name = "sumFilesSizeDataGridViewTextBoxColumn";
            // 
            // archiveBitSetCountDataGridViewTextBoxColumn
            // 
            this.archiveBitSetCountDataGridViewTextBoxColumn.DataPropertyName = "ArchiveBitSetCount";
            this.archiveBitSetCountDataGridViewTextBoxColumn.HeaderText = "#Archive";
            this.archiveBitSetCountDataGridViewTextBoxColumn.Name = "archiveBitSetCountDataGridViewTextBoxColumn";
            // 
            // sumArchiveBitFileSizeDataGridViewTextBoxColumn
            // 
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.DataPropertyName = "SumArchiveBitFileSize";
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.HeaderText = "$ArchiveBit";
            this.sumArchiveBitFileSizeDataGridViewTextBoxColumn.Name = "sumArchiveBitFileSizeDataGridViewTextBoxColumn";
            // 
            // fotosCountDataGridViewTextBoxColumn
            // 
            this.fotosCountDataGridViewTextBoxColumn.DataPropertyName = "FotosCount";
            this.fotosCountDataGridViewTextBoxColumn.HeaderText = "#Fotos";
            this.fotosCountDataGridViewTextBoxColumn.Name = "fotosCountDataGridViewTextBoxColumn";
            // 
            // sumFotosSizeDataGridViewTextBoxColumn
            // 
            this.sumFotosSizeDataGridViewTextBoxColumn.DataPropertyName = "SumFotosSize";
            this.sumFotosSizeDataGridViewTextBoxColumn.HeaderText = "$FotosSize";
            this.sumFotosSizeDataGridViewTextBoxColumn.Name = "sumFotosSizeDataGridViewTextBoxColumn";
            // 
            // officeCountDataGridViewTextBoxColumn
            // 
            this.officeCountDataGridViewTextBoxColumn.DataPropertyName = "OfficeCount";
            this.officeCountDataGridViewTextBoxColumn.HeaderText = "#Office";
            this.officeCountDataGridViewTextBoxColumn.Name = "officeCountDataGridViewTextBoxColumn";
            // 
            // sumOfficeFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumOfficeFilesSize";
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Office";
            this.sumOfficeFilesSizeDataGridViewTextBoxColumn.Name = "sumOfficeFilesSizeDataGridViewTextBoxColumn";
            // 
            // sourceCodeCountDataGridViewTextBoxColumn
            // 
            this.sourceCodeCountDataGridViewTextBoxColumn.DataPropertyName = "SourceCodeCount";
            this.sourceCodeCountDataGridViewTextBoxColumn.HeaderText = "#SourceCode";
            this.sourceCodeCountDataGridViewTextBoxColumn.Name = "sourceCodeCountDataGridViewTextBoxColumn";
            // 
            // sumSourceCodeFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumSourceCodeFilesSize";
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.HeaderText = "$SourceCode";
            this.sumSourceCodeFilesSizeDataGridViewTextBoxColumn.Name = "sumSourceCodeFilesSizeDataGridViewTextBoxColumn";
            // 
            // videosCountDataGridViewTextBoxColumn
            // 
            this.videosCountDataGridViewTextBoxColumn.DataPropertyName = "VideosCount";
            this.videosCountDataGridViewTextBoxColumn.HeaderText = "#Videos";
            this.videosCountDataGridViewTextBoxColumn.Name = "videosCountDataGridViewTextBoxColumn";
            // 
            // sumVideosFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumVideosFilesSize";
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Videos";
            this.sumVideosFilesSizeDataGridViewTextBoxColumn.Name = "sumVideosFilesSizeDataGridViewTextBoxColumn";
            // 
            // webCountDataGridViewTextBoxColumn
            // 
            this.webCountDataGridViewTextBoxColumn.DataPropertyName = "WebCount";
            this.webCountDataGridViewTextBoxColumn.HeaderText = "#Web";
            this.webCountDataGridViewTextBoxColumn.Name = "webCountDataGridViewTextBoxColumn";
            // 
            // sumWebFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumWebFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumWebFilesSize";
            this.sumWebFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Web";
            this.sumWebFilesSizeDataGridViewTextBoxColumn.Name = "sumWebFilesSizeDataGridViewTextBoxColumn";
            // 
            // otherCountDataGridViewTextBoxColumn
            // 
            this.otherCountDataGridViewTextBoxColumn.DataPropertyName = "OtherCount";
            this.otherCountDataGridViewTextBoxColumn.HeaderText = "#Other";
            this.otherCountDataGridViewTextBoxColumn.Name = "otherCountDataGridViewTextBoxColumn";
            // 
            // sumOtherFilesSizeDataGridViewTextBoxColumn
            // 
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.DataPropertyName = "SumOtherFilesSize";
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.HeaderText = "$Other";
            this.sumOtherFilesSizeDataGridViewTextBoxColumn.Name = "sumOtherFilesSizeDataGridViewTextBoxColumn";
            // 
            // bindingSourceJobResults
            // 
            this.bindingSourceJobResults.DataMember = "ContentVec";
            this.bindingSourceJobResults.DataSource = this.dsFilesClassification;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gbxResultsFilter);
            this.panel4.Controls.Add(this.btnLoadFinishedJobs);
            this.panel4.Controls.Add(this.btnSaveAllFinishedJobs);
            this.panel4.Controls.Add(this.btnResultsDelete);
            this.panel4.Controls.Add(this.btnResultsRequery);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(859, 64);
            this.panel4.TabIndex = 0;
            // 
            // gbxResultsFilter
            // 
            this.gbxResultsFilter.Controls.Add(this.cbxResulltsFilterOps);
            this.gbxResultsFilter.Controls.Add(this.cbxResultsFilterColName);
            this.gbxResultsFilter.Controls.Add(this.btnResultsFilterSet);
            this.gbxResultsFilter.Controls.Add(this.tbxResultsFilter);
            this.gbxResultsFilter.Controls.Add(this.rbtResultsFilterNo);
            this.gbxResultsFilter.Controls.Add(this.rbtResultsFilterYes);
            this.gbxResultsFilter.Location = new System.Drawing.Point(199, 2);
            this.gbxResultsFilter.Margin = new System.Windows.Forms.Padding(2);
            this.gbxResultsFilter.Name = "gbxResultsFilter";
            this.gbxResultsFilter.Padding = new System.Windows.Forms.Padding(2);
            this.gbxResultsFilter.Size = new System.Drawing.Size(407, 44);
            this.gbxResultsFilter.TabIndex = 4;
            this.gbxResultsFilter.TabStop = false;
            this.gbxResultsFilter.Text = "Filter";
            // 
            // cbxResulltsFilterOps
            // 
            this.cbxResulltsFilterOps.Enabled = false;
            this.cbxResulltsFilterOps.FormattingEnabled = true;
            this.cbxResulltsFilterOps.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>"});
            this.cbxResulltsFilterOps.Location = new System.Drawing.Point(224, 15);
            this.cbxResulltsFilterOps.Margin = new System.Windows.Forms.Padding(2);
            this.cbxResulltsFilterOps.Name = "cbxResulltsFilterOps";
            this.cbxResulltsFilterOps.Size = new System.Drawing.Size(42, 21);
            this.cbxResulltsFilterOps.TabIndex = 5;
            // 
            // cbxResultsFilterColName
            // 
            this.cbxResultsFilterColName.Enabled = false;
            this.cbxResultsFilterColName.FormattingEnabled = true;
            this.cbxResultsFilterColName.Items.AddRange(new object[] {
            "FileCount",
            "FotosCount",
            "FotosSizeInBytes",
            "OfficeCount",
            "OfficeSizeInBytes",
            "OtherCount",
            "OtherSizeInBytes",
            "SizeInBytes",
            "SourceCodeCount",
            "SourceCodeSizeInBytes",
            "VideosCount",
            "VideosSizeInBytes",
            "WebCount",
            "WebCountSizeInBytes"});
            this.cbxResultsFilterColName.Location = new System.Drawing.Point(110, 15);
            this.cbxResultsFilterColName.Margin = new System.Windows.Forms.Padding(2);
            this.cbxResultsFilterColName.Name = "cbxResultsFilterColName";
            this.cbxResultsFilterColName.Size = new System.Drawing.Size(110, 21);
            this.cbxResultsFilterColName.TabIndex = 4;
            // 
            // btnResultsFilterSet
            // 
            this.btnResultsFilterSet.Enabled = false;
            this.btnResultsFilterSet.Location = new System.Drawing.Point(368, 11);
            this.btnResultsFilterSet.Margin = new System.Windows.Forms.Padding(2);
            this.btnResultsFilterSet.Name = "btnResultsFilterSet";
            this.btnResultsFilterSet.Size = new System.Drawing.Size(35, 24);
            this.btnResultsFilterSet.TabIndex = 3;
            this.btnResultsFilterSet.Text = "set";
            this.btnResultsFilterSet.UseVisualStyleBackColor = true;
            this.btnResultsFilterSet.Click += new System.EventHandler(this.btnResultsFilterSet_Click);
            // 
            // tbxResultsFilter
            // 
            this.tbxResultsFilter.Enabled = false;
            this.tbxResultsFilter.Location = new System.Drawing.Point(268, 15);
            this.tbxResultsFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbxResultsFilter.Name = "tbxResultsFilter";
            this.tbxResultsFilter.Size = new System.Drawing.Size(96, 20);
            this.tbxResultsFilter.TabIndex = 2;
            // 
            // rbtResultsFilterNo
            // 
            this.rbtResultsFilterNo.AutoSize = true;
            this.rbtResultsFilterNo.Checked = true;
            this.rbtResultsFilterNo.Location = new System.Drawing.Point(66, 15);
            this.rbtResultsFilterNo.Margin = new System.Windows.Forms.Padding(2);
            this.rbtResultsFilterNo.Name = "rbtResultsFilterNo";
            this.rbtResultsFilterNo.Size = new System.Drawing.Size(45, 17);
            this.rbtResultsFilterNo.TabIndex = 1;
            this.rbtResultsFilterNo.TabStop = true;
            this.rbtResultsFilterNo.Text = "nein";
            this.rbtResultsFilterNo.UseVisualStyleBackColor = true;
            this.rbtResultsFilterNo.CheckedChanged += new System.EventHandler(this.rbtResultsFilterNo_CheckedChanged);
            // 
            // rbtResultsFilterYes
            // 
            this.rbtResultsFilterYes.AutoSize = true;
            this.rbtResultsFilterYes.Location = new System.Drawing.Point(18, 15);
            this.rbtResultsFilterYes.Margin = new System.Windows.Forms.Padding(2);
            this.rbtResultsFilterYes.Name = "rbtResultsFilterYes";
            this.rbtResultsFilterYes.Size = new System.Drawing.Size(36, 17);
            this.rbtResultsFilterYes.TabIndex = 0;
            this.rbtResultsFilterYes.Text = "Ja";
            this.rbtResultsFilterYes.UseVisualStyleBackColor = true;
            this.rbtResultsFilterYes.CheckedChanged += new System.EventHandler(this.rbtResultsFilterYes_CheckedChanged);
            // 
            // btnLoadFinishedJobs
            // 
            this.btnLoadFinishedJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFinishedJobs.Location = new System.Drawing.Point(704, 14);
            this.btnLoadFinishedJobs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadFinishedJobs.Name = "btnLoadFinishedJobs";
            this.btnLoadFinishedJobs.Size = new System.Drawing.Size(149, 24);
            this.btnLoadFinishedJobs.TabIndex = 3;
            this.btnLoadFinishedJobs.Text = "Load: FileDialogPermission";
            this.btnLoadFinishedJobs.UseVisualStyleBackColor = true;
            this.btnLoadFinishedJobs.Click += new System.EventHandler(this.btnLoadFinishedJobs_Click);
            // 
            // btnSaveAllFinishedJobs
            // 
            this.btnSaveAllFinishedJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAllFinishedJobs.Location = new System.Drawing.Point(579, 14);
            this.btnSaveAllFinishedJobs.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveAllFinishedJobs.Name = "btnSaveAllFinishedJobs";
            this.btnSaveAllFinishedJobs.Size = new System.Drawing.Size(120, 24);
            this.btnSaveAllFinishedJobs.TabIndex = 2;
            this.btnSaveAllFinishedJobs.Text = "Save: XmlSerializer";
            this.btnSaveAllFinishedJobs.UseVisualStyleBackColor = true;
            this.btnSaveAllFinishedJobs.Click += new System.EventHandler(this.btnSaveAllFinishedJobs_Click);
            // 
            // btnResultsDelete
            // 
            this.btnResultsDelete.Location = new System.Drawing.Point(94, 14);
            this.btnResultsDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnResultsDelete.Name = "btnResultsDelete";
            this.btnResultsDelete.Size = new System.Drawing.Size(86, 24);
            this.btnResultsDelete.TabIndex = 1;
            this.btnResultsDelete.Text = "Delete";
            this.btnResultsDelete.UseVisualStyleBackColor = true;
            this.btnResultsDelete.Click += new System.EventHandler(this.btnResultsDelete_Click);
            // 
            // btnResultsRequery
            // 
            this.btnResultsRequery.BackColor = System.Drawing.SystemColors.Control;
            this.btnResultsRequery.Location = new System.Drawing.Point(6, 14);
            this.btnResultsRequery.Margin = new System.Windows.Forms.Padding(2);
            this.btnResultsRequery.Name = "btnResultsRequery";
            this.btnResultsRequery.Size = new System.Drawing.Size(76, 24);
            this.btnResultsRequery.TabIndex = 0;
            this.btnResultsRequery.Text = "Requery";
            this.btnResultsRequery.UseVisualStyleBackColor = false;
            this.btnResultsRequery.Click += new System.EventHandler(this.btnResultsRequery_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnRemotingLoadConfig);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(859, 296);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Remoting Konfiguration";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnRemotingLoadConfig
            // 
            this.btnRemotingLoadConfig.Location = new System.Drawing.Point(6, 11);
            this.btnRemotingLoadConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemotingLoadConfig.Name = "btnRemotingLoadConfig";
            this.btnRemotingLoadConfig.Size = new System.Drawing.Size(582, 28);
            this.btnRemotingLoadConfig.TabIndex = 0;
            this.btnRemotingLoadConfig.Text = "Remoting- Konfiguration aus App.Config laden";
            this.btnRemotingLoadConfig.UseVisualStyleBackColor = true;
            this.btnRemotingLoadConfig.Click += new System.EventHandler(this.btnRemotingLoadConfig_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(btnNewJobResetValues);
            this.panel2.Controls.Add(this.btnNewJobPush);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 50);
            this.panel2.TabIndex = 0;
            // 
            // btnNewJobPush
            // 
            this.btnNewJobPush.BackColor = System.Drawing.Color.LightGreen;
            this.btnNewJobPush.Location = new System.Drawing.Point(4, 12);
            this.btnNewJobPush.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewJobPush.Name = "btnNewJobPush";
            this.btnNewJobPush.Size = new System.Drawing.Size(88, 24);
            this.btnNewJobPush.TabIndex = 0;
            this.btnNewJobPush.Text = "Job starten";
            this.btnNewJobPush.UseVisualStyleBackColor = false;
            this.btnNewJobPush.Click += new System.EventHandler(this.btnNewJobPush_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxNewJobFileType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxNewJobRegEx, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxNewJobMinSize, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbxNewJobMaxSize, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxNewJobDir, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectDir, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 52);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 242);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "zu scannendes Verzeichnis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Filetyp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "reg. Ausdruck für Dateinamen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "File größer als";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "File kleiner als";
            // 
            // tbxNewJobFileType
            // 
            this.tbxNewJobFileType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewJobFileType.Location = new System.Drawing.Point(172, 30);
            this.tbxNewJobFileType.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNewJobFileType.Name = "tbxNewJobFileType";
            this.tbxNewJobFileType.Size = new System.Drawing.Size(645, 20);
            this.tbxNewJobFileType.TabIndex = 6;
            this.tbxNewJobFileType.Text = ".*";
            // 
            // tbxNewJobRegEx
            // 
            this.tbxNewJobRegEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewJobRegEx.Location = new System.Drawing.Point(172, 58);
            this.tbxNewJobRegEx.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNewJobRegEx.Name = "tbxNewJobRegEx";
            this.tbxNewJobRegEx.Size = new System.Drawing.Size(645, 20);
            this.tbxNewJobRegEx.TabIndex = 7;
            this.tbxNewJobRegEx.Text = ".*";
            // 
            // tbxNewJobMinSize
            // 
            this.tbxNewJobMinSize.Location = new System.Drawing.Point(172, 86);
            this.tbxNewJobMinSize.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNewJobMinSize.Mask = "999999999999";
            this.tbxNewJobMinSize.Name = "tbxNewJobMinSize";
            this.tbxNewJobMinSize.Size = new System.Drawing.Size(107, 20);
            this.tbxNewJobMinSize.TabIndex = 8;
            this.tbxNewJobMinSize.Text = "0";
            this.tbxNewJobMinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxNewJobMaxSize
            // 
            this.tbxNewJobMaxSize.Location = new System.Drawing.Point(172, 114);
            this.tbxNewJobMaxSize.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNewJobMaxSize.Mask = "999999999999";
            this.tbxNewJobMaxSize.Name = "tbxNewJobMaxSize";
            this.tbxNewJobMaxSize.Size = new System.Drawing.Size(108, 20);
            this.tbxNewJobMaxSize.TabIndex = 9;
            this.tbxNewJobMaxSize.Text = "922337203685";
            this.tbxNewJobMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxNewJobDir
            // 
            this.tbxNewJobDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewJobDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileClassificatorClient.Properties.Settings.Default, "DefaultFindFileDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbxNewJobDir.Location = new System.Drawing.Point(172, 2);
            this.tbxNewJobDir.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNewJobDir.Name = "tbxNewJobDir";
            this.tbxNewJobDir.Size = new System.Drawing.Size(645, 20);
            this.tbxNewJobDir.TabIndex = 11;
            this.tbxNewJobDir.Text = global::FileClassificatorClient.Properties.Settings.Default.DefaultFindFileDir;
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(821, 2);
            this.btnSelectDir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(25, 19);
            this.btnSelectDir.TabIndex = 12;
            this.btnSelectDir.Text = "...";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // timerUpdateActiveJobsView
            // 
            this.timerUpdateActiveJobsView.Interval = 500;
            this.timerUpdateActiveJobsView.Tick += new System.EventHandler(this.timerUpdateActiveJobsView_Tick);
            // 
            // dlgSaveFinishedJobs
            // 
            this.dlgSaveFinishedJobs.Filter = "XML-Dateien|*.xml";
            this.dlgSaveFinishedJobs.Title = "Fertiggestellte Jobs sichern in:";
            // 
            // dlgOpenFinishedJobs
            // 
            this.dlgOpenFinishedJobs.FileName = "openFileDialog1";
            this.dlgOpenFinishedJobs.Filter = "XML Dateien|*.xml";
            this.dlgOpenFinishedJobs.Title = "Öffnen sie eine Datei mit fertiggestellten Jobs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(867, 368);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "FileClassificator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAllActiveJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFilesClassification)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJobResults)).EndInit();
            this.panel4.ResumeLayout(false);
            this.gbxResultsFilter.ResumeLayout(false);
            this.gbxResultsFilter.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxNewJobFileType;
        private System.Windows.Forms.TextBox tbxNewJobRegEx;
        private System.Windows.Forms.MaskedTextBox tbxNewJobMinSize;
        private System.Windows.Forms.MaskedTextBox tbxNewJobMaxSize;
        private System.Windows.Forms.Button btnNewJobPush;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbxResultsJobs;
        private System.Windows.Forms.Panel panel4;
        private DMS.FC.DsFilesClassification dsFilesClassification;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnActiveJobKillJob;
        private System.Windows.Forms.Button btnResultsRequery;
        private System.Windows.Forms.Timer timerUpdateActiveJobsView;
        private System.Windows.Forms.Button btnActiveJobsStartStopAutoUpdate;
        private System.Windows.Forms.BindingSource bindingSourceAllActiveJobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobProccessingElapsedTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeNowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDirsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countFilesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countResultsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSourceJobResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn atimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeInBytesDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnResultsDelete;
        private System.Windows.Forms.Button btnSaveAllFinishedJobs;
        private System.Windows.Forms.SaveFileDialog dlgSaveFinishedJobs;
        private System.Windows.Forms.Button btnLoadFinishedJobs;
        private System.Windows.Forms.OpenFileDialog dlgOpenFinishedJobs;
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
        private System.Windows.Forms.Button btnRemotingLoadConfig;
        private System.Windows.Forms.TextBox tbxNewJobDir;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox gbxResultsFilter;
        private System.Windows.Forms.Button btnResultsFilterSet;
        private System.Windows.Forms.RadioButton rbtResultsFilterNo;
        private System.Windows.Forms.RadioButton rbtResultsFilterYes;
        private System.Windows.Forms.ComboBox cbxResultsFilterColName;
        private System.Windows.Forms.TextBox tbxResultsFilter;
        private System.Windows.Forms.ComboBox cbxResulltsFilterOps;
    }
}
