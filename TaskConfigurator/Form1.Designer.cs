namespace TaskConfigurator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbl_task_configuration_data = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.chkSingle = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbl_task_configuration_desc = new System.Windows.Forms.DataGridView();
            this.tbl_task_configuration_data_dropdown = new System.Windows.Forms.DataGridView();
            this.tbl_task_configuration_cntrl = new System.Windows.Forms.DataGridView();
            this.tbl_action_status_mapping_AIB = new System.Windows.Forms.DataGridView();
            this.cmsDropDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DropDownAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWicode = new System.Windows.Forms.TextBox();
            this.ddlSystem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlServer = new System.Windows.Forms.ComboBox();
            this.grpRead = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bg1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbl_task_configuration_main = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tbl_aib_task_order_attribute_mapping = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_data)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_desc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_data_dropdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_cntrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_action_status_mapping_AIB)).BeginInit();
            this.cmsDropDown.SuspendLayout();
            this.grpRead.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_main)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_aib_task_order_attribute_mapping)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_task_configuration_data
            // 
            this.tbl_task_configuration_data.AllowDrop = true;
            this.tbl_task_configuration_data.AllowUserToResizeRows = false;
            this.tbl_task_configuration_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_task_configuration_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_task_configuration_data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_task_configuration_data.Location = new System.Drawing.Point(3, 3);
            this.tbl_task_configuration_data.Name = "tbl_task_configuration_data";
            this.tbl_task_configuration_data.Size = new System.Drawing.Size(1203, 151);
            this.tbl_task_configuration_data.TabIndex = 2;
            this.tbl_task_configuration_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_task_configuration_data_CellClick);
            this.tbl_task_configuration_data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_task_configuration_data_CellValueChanged);
            this.tbl_task_configuration_data.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_task_configuration_data.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_task_configuration_data.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tbl_task_configuration_data_DataError);
            this.tbl_task_configuration_data.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tbl_task_configuration_data_RowsAdded);
            this.tbl_task_configuration_data.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.tbl_task_configuration_data_RowsRemoved);
            this.tbl_task_configuration_data.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            this.tbl_task_configuration_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbl_task_configuration_data_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLog);
            this.groupBox1.Controls.Add(this.chkSingle);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Location = new System.Drawing.Point(798, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 59);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Functionality";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(168, 17);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 7;
            this.btnLog.Text = "Show Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Visible = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // chkSingle
            // 
            this.chkSingle.AutoSize = true;
            this.chkSingle.Checked = true;
            this.chkSingle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSingle.Location = new System.Drawing.Point(270, 21);
            this.chkSingle.Name = "chkSingle";
            this.chkSingle.Size = new System.Drawing.Size(74, 17);
            this.chkSingle.TabIndex = 8;
            this.chkSingle.Text = "Single File";
            this.chkSingle.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(87, 17);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(6, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Reset All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(350, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbl_task_configuration_desc
            // 
            this.tbl_task_configuration_desc.AllowUserToAddRows = false;
            this.tbl_task_configuration_desc.AllowUserToDeleteRows = false;
            this.tbl_task_configuration_desc.AllowUserToResizeRows = false;
            this.tbl_task_configuration_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_task_configuration_desc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_task_configuration_desc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_task_configuration_desc.Location = new System.Drawing.Point(3, 3);
            this.tbl_task_configuration_desc.Name = "tbl_task_configuration_desc";
            this.tbl_task_configuration_desc.Size = new System.Drawing.Size(1203, 151);
            this.tbl_task_configuration_desc.TabIndex = 6;
            this.tbl_task_configuration_desc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_task_configuration_desc_CellValueChanged);
            this.tbl_task_configuration_desc.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_task_configuration_desc.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_task_configuration_desc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tbl_task_configuration_desc_DataError);
            this.tbl_task_configuration_desc.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tbl_task_configuration_desc_RowsAdded);
            this.tbl_task_configuration_desc.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            // 
            // tbl_task_configuration_data_dropdown
            // 
            this.tbl_task_configuration_data_dropdown.AllowUserToAddRows = false;
            this.tbl_task_configuration_data_dropdown.AllowUserToDeleteRows = false;
            this.tbl_task_configuration_data_dropdown.AllowUserToResizeRows = false;
            this.tbl_task_configuration_data_dropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_task_configuration_data_dropdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_task_configuration_data_dropdown.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_task_configuration_data_dropdown.Location = new System.Drawing.Point(3, 3);
            this.tbl_task_configuration_data_dropdown.Name = "tbl_task_configuration_data_dropdown";
            this.tbl_task_configuration_data_dropdown.Size = new System.Drawing.Size(1203, 151);
            this.tbl_task_configuration_data_dropdown.TabIndex = 7;
            this.tbl_task_configuration_data_dropdown.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tbl_task_configuration_data_dropdown_CellMouseDown);
            this.tbl_task_configuration_data_dropdown.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_task_configuration_data_dropdown.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_task_configuration_data_dropdown.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tbl_task_configuration_data_dropdown_DataError);
            this.tbl_task_configuration_data_dropdown.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tbl_task_configuration_data_dropdown_RowsAdded);
            this.tbl_task_configuration_data_dropdown.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            this.tbl_task_configuration_data_dropdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbl_task_configuration_data_dropdown_KeyDown);
            // 
            // tbl_task_configuration_cntrl
            // 
            this.tbl_task_configuration_cntrl.AllowUserToDeleteRows = false;
            this.tbl_task_configuration_cntrl.AllowUserToResizeRows = false;
            this.tbl_task_configuration_cntrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_task_configuration_cntrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_task_configuration_cntrl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_task_configuration_cntrl.Location = new System.Drawing.Point(3, 3);
            this.tbl_task_configuration_cntrl.Name = "tbl_task_configuration_cntrl";
            this.tbl_task_configuration_cntrl.Size = new System.Drawing.Size(1203, 151);
            this.tbl_task_configuration_cntrl.TabIndex = 8;
            this.tbl_task_configuration_cntrl.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_task_configuration_cntrl.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_task_configuration_cntrl.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tbl_task_configuration_cntrl_DataError);
            this.tbl_task_configuration_cntrl.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tbl_task_configuration_cntrl_RowsAdded);
            this.tbl_task_configuration_cntrl.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            this.tbl_task_configuration_cntrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbl_task_configuration_cntrl_KeyDown);
            // 
            // tbl_action_status_mapping_AIB
            // 
            this.tbl_action_status_mapping_AIB.AllowUserToResizeRows = false;
            this.tbl_action_status_mapping_AIB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_action_status_mapping_AIB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_action_status_mapping_AIB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_action_status_mapping_AIB.Location = new System.Drawing.Point(3, 3);
            this.tbl_action_status_mapping_AIB.Name = "tbl_action_status_mapping_AIB";
            this.tbl_action_status_mapping_AIB.Size = new System.Drawing.Size(1203, 151);
            this.tbl_action_status_mapping_AIB.TabIndex = 9;
            this.tbl_action_status_mapping_AIB.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_action_status_mapping_AIB.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_action_status_mapping_AIB.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tbl_action_status_mapping_AIB_DataError);
            this.tbl_action_status_mapping_AIB.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tbl_action_status_mapping_AIB_RowsAdded);
            this.tbl_action_status_mapping_AIB.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            this.tbl_action_status_mapping_AIB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbl_action_status_mapping_AIB_KeyDown);
            // 
            // cmsDropDown
            // 
            this.cmsDropDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropDownAddNew});
            this.cmsDropDown.Name = "cmsDropDown";
            this.cmsDropDown.Size = new System.Drawing.Size(157, 26);
            // 
            // DropDownAddNew
            // 
            this.DropDownAddNew.Name = "DropDownAddNew";
            this.DropDownAddNew.Size = new System.Drawing.Size(156, 22);
            this.DropDownAddNew.Text = "Insert New Row";
            this.DropDownAddNew.Click += new System.EventHandler(this.DropDownAddNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WiCode:";
            // 
            // txtWicode
            // 
            this.txtWicode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWicode.Location = new System.Drawing.Point(487, 21);
            this.txtWicode.Name = "txtWicode";
            this.txtWicode.Size = new System.Drawing.Size(115, 20);
            this.txtWicode.TabIndex = 1;
            // 
            // ddlSystem
            // 
            this.ddlSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSystem.FormattingEnabled = true;
            this.ddlSystem.Location = new System.Drawing.Point(309, 20);
            this.ddlSystem.Name = "ddlSystem";
            this.ddlSystem.Size = new System.Drawing.Size(121, 21);
            this.ddlSystem.TabIndex = 2;
            this.ddlSystem.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "System:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(608, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server:";
            // 
            // ddlServer
            // 
            this.ddlServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlServer.FormattingEnabled = true;
            this.ddlServer.Location = new System.Drawing.Point(147, 20);
            this.ddlServer.Name = "ddlServer";
            this.ddlServer.Size = new System.Drawing.Size(105, 21);
            this.ddlServer.TabIndex = 6;
            this.ddlServer.TabStop = false;
            this.ddlServer.SelectedIndexChanged += new System.EventHandler(this.ddlServer_SelectedIndexChanged);
            this.ddlServer.SelectedValueChanged += new System.EventHandler(this.ddlServer_SelectedValueChanged);
            // 
            // grpRead
            // 
            this.grpRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRead.Controls.Add(this.btnRefresh);
            this.grpRead.Controls.Add(this.label3);
            this.grpRead.Controls.Add(this.btnSearch);
            this.grpRead.Controls.Add(this.ddlServer);
            this.grpRead.Controls.Add(this.label2);
            this.grpRead.Controls.Add(this.ddlSystem);
            this.grpRead.Controls.Add(this.txtWicode);
            this.grpRead.Controls.Add(this.label1);
            this.grpRead.Location = new System.Drawing.Point(12, 12);
            this.grpRead.Name = "grpRead";
            this.grpRead.Size = new System.Drawing.Size(691, 59);
            this.grpRead.TabIndex = 3;
            this.grpRead.TabStop = false;
            this.grpRead.Text = "Read from db";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(19, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bg1
            // 
            this.bg1.WorkerReportsProgress = true;
            this.bg1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg1_DoWork);
            this.bg1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg1_ProgressChanged);
            this.bg1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(12, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1217, 180);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbl_task_configuration_desc);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1209, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Desc";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbl_task_configuration_data);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1209, 154);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbl_task_configuration_data_dropdown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1209, 154);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dropdown";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbl_task_configuration_cntrl);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1209, 154);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cntrl";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tbl_action_status_mapping_AIB);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1209, 154);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Response";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tbl_task_configuration_main);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1209, 154);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Main";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbl_task_configuration_main
            // 
            this.tbl_task_configuration_main.AllowUserToAddRows = false;
            this.tbl_task_configuration_main.AllowUserToResizeRows = false;
            this.tbl_task_configuration_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_task_configuration_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_task_configuration_main.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_task_configuration_main.Location = new System.Drawing.Point(3, 2);
            this.tbl_task_configuration_main.Name = "tbl_task_configuration_main";
            this.tbl_task_configuration_main.Size = new System.Drawing.Size(1203, 151);
            this.tbl_task_configuration_main.TabIndex = 10;
            this.tbl_task_configuration_main.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_task_configuration_main.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_task_configuration_main.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tbl_aib_task_order_attribute_mapping);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1209, 154);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Order";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tbl_aib_task_order_attribute_mapping
            // 
            this.tbl_aib_task_order_attribute_mapping.AllowUserToResizeRows = false;
            this.tbl_aib_task_order_attribute_mapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_aib_task_order_attribute_mapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tbl_aib_task_order_attribute_mapping.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tbl_aib_task_order_attribute_mapping.Location = new System.Drawing.Point(3, 2);
            this.tbl_aib_task_order_attribute_mapping.Name = "tbl_aib_task_order_attribute_mapping";
            this.tbl_aib_task_order_attribute_mapping.Size = new System.Drawing.Size(1203, 151);
            this.tbl_aib_task_order_attribute_mapping.TabIndex = 10;
            this.tbl_aib_task_order_attribute_mapping.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CommonColumnHeaderMouseDoubleClick);
            this.tbl_aib_task_order_attribute_mapping.CurrentCellDirtyStateChanged += new System.EventHandler(this.CommonCurrentCellDirtyStateChanged);
            this.tbl_aib_task_order_attribute_mapping.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CommonUserAddedRow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 290);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpRead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1257, 329);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_desc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_data_dropdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_cntrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_action_status_mapping_AIB)).EndInit();
            this.cmsDropDown.ResumeLayout(false);
            this.grpRead.ResumeLayout(false);
            this.grpRead.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_task_configuration_main)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_aib_task_order_attribute_mapping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_task_configuration_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView tbl_task_configuration_desc;
        private System.Windows.Forms.DataGridView tbl_task_configuration_data_dropdown;
        private System.Windows.Forms.DataGridView tbl_task_configuration_cntrl;
        private System.Windows.Forms.DataGridView tbl_action_status_mapping_AIB;
        private System.Windows.Forms.ContextMenuStrip cmsDropDown;
        private System.Windows.Forms.ToolStripMenuItem DropDownAddNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWicode;
        private System.Windows.Forms.ComboBox ddlSystem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlServer;
        private System.Windows.Forms.GroupBox grpRead;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox chkSingle;
        private System.Windows.Forms.Button btnRefresh;
        private System.ComponentModel.BackgroundWorker bg1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView tbl_task_configuration_main;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView tbl_aib_task_order_attribute_mapping;
    }
}

