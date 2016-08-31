namespace BACnetBrowser
{
    partial class DatabaseConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseConnectionForm));
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbPW = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblSecondsToUplaod = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_statusStripLabelErgebnis = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_StatusStripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_StatusStripLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ScrollUploadTime = new System.Windows.Forms.HScrollBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbMo = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSo = new System.Windows.Forms.CheckBox();
            this.cbSa = new System.Windows.Forms.CheckBox();
            this.cbFr = new System.Windows.Forms.CheckBox();
            this.cbDo = new System.Windows.Forms.CheckBox();
            this.cbMi = new System.Windows.Forms.CheckBox();
            this.cbDi = new System.Windows.Forms.CheckBox();
            this.btnTryConnection = new System.Windows.Forms.Button();
            this.btnSaveConnection = new System.Windows.Forms.Button();
            this.btnShowTableNames = new System.Windows.Forms.Button();
            this.chbVPN = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbConnectionName = new System.Windows.Forms.TextBox();
            this.panTryConnection = new System.Windows.Forms.Panel();
            this.btnShowTable = new System.Windows.Forms.Button();
            this.comBoxDatabases = new System.Windows.Forms.ComboBox();
            this.btnNewDatabase = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBoxConnectionType = new System.Windows.Forms.ComboBox();
            this.tabControlControlConnection = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panConnectionName = new System.Windows.Forms.Panel();
            this.panConnectionDetails = new System.Windows.Forms.Panel();
            this.tabPageSSH = new System.Windows.Forms.TabPage();
            this.cbSSLModeRequired = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dbSSLModePreferred = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.listViewUploadList = new System.Windows.Forms.ListView();
            this.columnHeaderConnections = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubscriber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.subscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsubscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewTableNames = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripCommands = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sELECTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goupBoxDateTimeUpload = new System.Windows.Forms.GroupBox();
            this.tLayPanWeekdays = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxConnectionsAndSubsriber = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewProvider = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItemAddSub = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItemRemoveSub = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.imagelist = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.statusStrip.SuspendLayout();
            this.panTryConnection.SuspendLayout();
            this.tabControlControlConnection.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.panConnectionName.SuspendLayout();
            this.panConnectionDetails.SuspendLayout();
            this.tabPageSSH.SuspendLayout();
            this.contextMenuStripSettings.SuspendLayout();
            this.contextMenuStripCommands.SuspendLayout();
            this.goupBoxDateTimeUpload.SuspendLayout();
            this.tLayPanWeekdays.SuspendLayout();
            this.groupBoxConnectionsAndSubsriber.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(110, 34);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(222, 20);
            this.tbServer.TabIndex = 3;
            // 
            // tbPW
            // 
            this.tbPW.Location = new System.Drawing.Point(110, 116);
            this.tbPW.Name = "tbPW";
            this.tbPW.Size = new System.Drawing.Size(222, 20);
            this.tbPW.TabIndex = 6;
            this.tbPW.UseSystemPasswordChar = true;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(110, 60);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(222, 20);
            this.tbServerPort.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(110, 86);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(222, 20);
            this.tbUsername.TabIndex = 5;
            // 
            // lblSecondsToUplaod
            // 
            this.lblSecondsToUplaod.AutoSize = true;
            this.lblSecondsToUplaod.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSecondsToUplaod.Location = new System.Drawing.Point(3, 59);
            this.lblSecondsToUplaod.Name = "lblSecondsToUplaod";
            this.lblSecondsToUplaod.Size = new System.Drawing.Size(104, 13);
            this.lblSecondsToUplaod.TabIndex = 18;
            this.lblSecondsToUplaod.Text = "Seconds - Timespan";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.m_statusStripLabelErgebnis});
            this.statusStrip.Location = new System.Drawing.Point(0, 388);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(760, 22);
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // m_statusStripLabelErgebnis
            // 
            this.m_statusStripLabelErgebnis.Name = "m_statusStripLabelErgebnis";
            this.m_statusStripLabelErgebnis.Size = new System.Drawing.Size(0, 17);
            // 
            // m_StatusStripLabel1
            // 
            this.m_StatusStripLabel1.Name = "m_StatusStripLabel1";
            this.m_StatusStripLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // m_StatusStripLabel2
            // 
            this.m_StatusStripLabel2.Name = "m_StatusStripLabel2";
            this.m_StatusStripLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // ScrollUploadTime
            // 
            this.ScrollUploadTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScrollUploadTime.Location = new System.Drawing.Point(3, 72);
            this.ScrollUploadTime.Maximum = 309;
            this.ScrollUploadTime.Minimum = 10;
            this.ScrollUploadTime.Name = "ScrollUploadTime";
            this.ScrollUploadTime.Size = new System.Drawing.Size(347, 19);
            this.ScrollUploadTime.TabIndex = 22;
            this.ScrollUploadTime.Value = 10;
            this.ScrollUploadTime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.ScrollUploadTime.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // cbMo
            // 
            this.cbMo.AutoSize = true;
            this.cbMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMo.Location = new System.Drawing.Point(3, 3);
            this.cbMo.Name = "cbMo";
            this.cbMo.Size = new System.Drawing.Size(43, 23);
            this.cbMo.TabIndex = 24;
            this.cbMo.Text = "Mo";
            this.cbMo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbMo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Days:";
            // 
            // cbSo
            // 
            this.cbSo.AutoSize = true;
            this.cbSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSo.Location = new System.Drawing.Point(297, 3);
            this.cbSo.Name = "cbSo";
            this.cbSo.Size = new System.Drawing.Size(47, 23);
            this.cbSo.TabIndex = 27;
            this.cbSo.Text = "So";
            this.cbSo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSo.UseVisualStyleBackColor = true;
            // 
            // cbSa
            // 
            this.cbSa.AutoSize = true;
            this.cbSa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSa.Location = new System.Drawing.Point(248, 3);
            this.cbSa.Name = "cbSa";
            this.cbSa.Size = new System.Drawing.Size(43, 23);
            this.cbSa.TabIndex = 28;
            this.cbSa.Text = "Sa";
            this.cbSa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSa.UseVisualStyleBackColor = true;
            // 
            // cbFr
            // 
            this.cbFr.AutoSize = true;
            this.cbFr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFr.Location = new System.Drawing.Point(199, 3);
            this.cbFr.Name = "cbFr";
            this.cbFr.Size = new System.Drawing.Size(43, 23);
            this.cbFr.TabIndex = 29;
            this.cbFr.Text = "Fr";
            this.cbFr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbFr.UseVisualStyleBackColor = true;
            // 
            // cbDo
            // 
            this.cbDo.AutoSize = true;
            this.cbDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDo.Location = new System.Drawing.Point(150, 3);
            this.cbDo.Name = "cbDo";
            this.cbDo.Size = new System.Drawing.Size(43, 23);
            this.cbDo.TabIndex = 30;
            this.cbDo.Text = "Do";
            this.cbDo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDo.UseVisualStyleBackColor = true;
            // 
            // cbMi
            // 
            this.cbMi.AutoSize = true;
            this.cbMi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMi.Location = new System.Drawing.Point(101, 3);
            this.cbMi.Name = "cbMi";
            this.cbMi.Size = new System.Drawing.Size(43, 23);
            this.cbMi.TabIndex = 31;
            this.cbMi.Text = "Mi";
            this.cbMi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbMi.UseVisualStyleBackColor = true;
            // 
            // cbDi
            // 
            this.cbDi.AutoSize = true;
            this.cbDi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDi.Location = new System.Drawing.Point(52, 3);
            this.cbDi.Name = "cbDi";
            this.cbDi.Size = new System.Drawing.Size(43, 23);
            this.cbDi.TabIndex = 32;
            this.cbDi.Text = "Di";
            this.cbDi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDi.UseVisualStyleBackColor = true;
            // 
            // btnTryConnection
            // 
            this.btnTryConnection.Location = new System.Drawing.Point(3, 43);
            this.btnTryConnection.Name = "btnTryConnection";
            this.btnTryConnection.Size = new System.Drawing.Size(109, 23);
            this.btnTryConnection.TabIndex = 34;
            this.btnTryConnection.Text = "Try Connection";
            this.btnTryConnection.UseVisualStyleBackColor = true;
            this.btnTryConnection.Click += new System.EventHandler(this.btnTryConnection_Click);
            // 
            // btnSaveConnection
            // 
            this.btnSaveConnection.Location = new System.Drawing.Point(4, 72);
            this.btnSaveConnection.Name = "btnSaveConnection";
            this.btnSaveConnection.Size = new System.Drawing.Size(108, 23);
            this.btnSaveConnection.TabIndex = 35;
            this.btnSaveConnection.Text = "Save Connection";
            this.btnSaveConnection.UseVisualStyleBackColor = true;
            this.btnSaveConnection.Visible = false;
            this.btnSaveConnection.Click += new System.EventHandler(this.btnSaveConnection_Click);
            // 
            // btnShowTableNames
            // 
            this.btnShowTableNames.Location = new System.Drawing.Point(118, 43);
            this.btnShowTableNames.Name = "btnShowTableNames";
            this.btnShowTableNames.Size = new System.Drawing.Size(167, 23);
            this.btnShowTableNames.TabIndex = 36;
            this.btnShowTableNames.Text = "Show ConnectionString";
            this.btnShowTableNames.UseVisualStyleBackColor = true;
            this.btnShowTableNames.Click += new System.EventHandler(this.btnShowTableNames_Click);
            // 
            // chbVPN
            // 
            this.chbVPN.AutoSize = true;
            this.chbVPN.Location = new System.Drawing.Point(357, 21);
            this.chbVPN.Name = "chbVPN";
            this.chbVPN.Size = new System.Drawing.Size(48, 17);
            this.chbVPN.TabIndex = 6;
            this.chbVPN.Text = "VPN";
            this.chbVPN.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Connectionname:";
            // 
            // tbConnectionName
            // 
            this.tbConnectionName.Location = new System.Drawing.Point(110, 13);
            this.tbConnectionName.Name = "tbConnectionName";
            this.tbConnectionName.Size = new System.Drawing.Size(135, 20);
            this.tbConnectionName.TabIndex = 2;
            // 
            // panTryConnection
            // 
            this.panTryConnection.Controls.Add(this.btnShowTable);
            this.panTryConnection.Controls.Add(this.comBoxDatabases);
            this.panTryConnection.Controls.Add(this.btnNewDatabase);
            this.panTryConnection.Controls.Add(this.label4);
            this.panTryConnection.Controls.Add(this.btnShowTableNames);
            this.panTryConnection.Controls.Add(this.btnSaveConnection);
            this.panTryConnection.Controls.Add(this.btnTryConnection);
            this.panTryConnection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTryConnection.Enabled = false;
            this.panTryConnection.Location = new System.Drawing.Point(3, 235);
            this.panTryConnection.Name = "panTryConnection";
            this.panTryConnection.Size = new System.Drawing.Size(350, 100);
            this.panTryConnection.TabIndex = 46;
            // 
            // btnShowTable
            // 
            this.btnShowTable.Location = new System.Drawing.Point(118, 72);
            this.btnShowTable.Name = "btnShowTable";
            this.btnShowTable.Size = new System.Drawing.Size(167, 23);
            this.btnShowTable.TabIndex = 55;
            this.btnShowTable.Text = "Show TableNames";
            this.btnShowTable.UseVisualStyleBackColor = true;
            this.btnShowTable.Visible = false;
            this.btnShowTable.Click += new System.EventHandler(this.button1_Click);
            // 
            // comBoxDatabases
            // 
            this.comBoxDatabases.Enabled = false;
            this.comBoxDatabases.FormattingEnabled = true;
            this.comBoxDatabases.Location = new System.Drawing.Point(110, 12);
            this.comBoxDatabases.Name = "comBoxDatabases";
            this.comBoxDatabases.Size = new System.Drawing.Size(175, 21);
            this.comBoxDatabases.TabIndex = 56;
            this.comBoxDatabases.SelectedIndexChanged += new System.EventHandler(this.comBoxDatabases_SelectedIndexChanged);
            // 
            // btnNewDatabase
            // 
            this.btnNewDatabase.Enabled = false;
            this.btnNewDatabase.Location = new System.Drawing.Point(290, 12);
            this.btnNewDatabase.Name = "btnNewDatabase";
            this.btnNewDatabase.Size = new System.Drawing.Size(42, 23);
            this.btnNewDatabase.TabIndex = 58;
            this.btnNewDatabase.Text = "New";
            this.btnNewDatabase.UseVisualStyleBackColor = true;
            this.btnNewDatabase.Click += new System.EventHandler(this.btnNewDatabase_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Database:";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(272, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "ConnectionType:";
            // 
            // cbBoxConnectionType
            // 
            this.cbBoxConnectionType.FormattingEnabled = true;
            this.cbBoxConnectionType.Items.AddRange(new object[] {
            "MySql",
            "PostgreSql",
            "MicrosoftSql",
            "OleDb",
            "OdeBc"});
            this.cbBoxConnectionType.Location = new System.Drawing.Point(110, 6);
            this.cbBoxConnectionType.Name = "cbBoxConnectionType";
            this.cbBoxConnectionType.Size = new System.Drawing.Size(222, 21);
            this.cbBoxConnectionType.TabIndex = 1;
            this.cbBoxConnectionType.SelectedIndexChanged += new System.EventHandler(this.cbBoxConnectionType_SelectedIndexChanged);
            // 
            // tabControlControlConnection
            // 
            this.tabControlControlConnection.Controls.Add(this.tabPageSettings);
            this.tabControlControlConnection.Controls.Add(this.tabPageSSH);
            this.tabControlControlConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlControlConnection.Location = new System.Drawing.Point(0, 0);
            this.tabControlControlConnection.Name = "tabControlControlConnection";
            this.tabControlControlConnection.SelectedIndex = 0;
            this.tabControlControlConnection.Size = new System.Drawing.Size(364, 364);
            this.tabControlControlConnection.TabIndex = 49;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panConnectionName);
            this.tabPageSettings.Controls.Add(this.panConnectionDetails);
            this.tabPageSettings.Controls.Add(this.btnCancel);
            this.tabPageSettings.Controls.Add(this.panTryConnection);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(356, 338);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panConnectionName
            // 
            this.panConnectionName.Controls.Add(this.label9);
            this.panConnectionName.Controls.Add(this.tbConnectionName);
            this.panConnectionName.Dock = System.Windows.Forms.DockStyle.Left;
            this.panConnectionName.Enabled = false;
            this.panConnectionName.Location = new System.Drawing.Point(3, 3);
            this.panConnectionName.Name = "panConnectionName";
            this.panConnectionName.Size = new System.Drawing.Size(251, 88);
            this.panConnectionName.TabIndex = 60;
            // 
            // panConnectionDetails
            // 
            this.panConnectionDetails.Controls.Add(this.label5);
            this.panConnectionDetails.Controls.Add(this.label6);
            this.panConnectionDetails.Controls.Add(this.tbUsername);
            this.panConnectionDetails.Controls.Add(this.label3);
            this.panConnectionDetails.Controls.Add(this.label2);
            this.panConnectionDetails.Controls.Add(this.label1);
            this.panConnectionDetails.Controls.Add(this.cbBoxConnectionType);
            this.panConnectionDetails.Controls.Add(this.tbServerPort);
            this.panConnectionDetails.Controls.Add(this.tbPW);
            this.panConnectionDetails.Controls.Add(this.tbServer);
            this.panConnectionDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panConnectionDetails.Enabled = false;
            this.panConnectionDetails.Location = new System.Drawing.Point(3, 91);
            this.panConnectionDetails.Name = "panConnectionDetails";
            this.panConnectionDetails.Size = new System.Drawing.Size(350, 144);
            this.panConnectionDetails.TabIndex = 59;
            // 
            // tabPageSSH
            // 
            this.tabPageSSH.Controls.Add(this.cbSSLModeRequired);
            this.tabPageSSH.Controls.Add(this.textBox1);
            this.tabPageSSH.Controls.Add(this.dbSSLModePreferred);
            this.tabPageSSH.Controls.Add(this.textBox2);
            this.tabPageSSH.Controls.Add(this.textBox3);
            this.tabPageSSH.Controls.Add(this.label8);
            this.tabPageSSH.Controls.Add(this.label12);
            this.tabPageSSH.Controls.Add(this.label13);
            this.tabPageSSH.Controls.Add(this.textBox4);
            this.tabPageSSH.Controls.Add(this.label14);
            this.tabPageSSH.Location = new System.Drawing.Point(4, 22);
            this.tabPageSSH.Name = "tabPageSSH";
            this.tabPageSSH.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSSH.Size = new System.Drawing.Size(356, 338);
            this.tabPageSSH.TabIndex = 1;
            this.tabPageSSH.Text = "SSH Tunnel";
            this.tabPageSSH.UseVisualStyleBackColor = true;
            // 
            // cbSSLModeRequired
            // 
            this.cbSSLModeRequired.AutoSize = true;
            this.cbSSLModeRequired.Location = new System.Drawing.Point(22, 160);
            this.cbSSLModeRequired.Name = "cbSSLModeRequired";
            this.cbSSLModeRequired.Size = new System.Drawing.Size(122, 17);
            this.cbSSLModeRequired.TabIndex = 56;
            this.cbSSLModeRequired.Text = "SSL Mode Required";
            this.cbSSLModeRequired.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 16;
            // 
            // dbSSLModePreferred
            // 
            this.dbSSLModePreferred.AutoSize = true;
            this.dbSSLModePreferred.Location = new System.Drawing.Point(22, 137);
            this.dbSSLModePreferred.Name = "dbSSLModePreferred";
            this.dbSSLModePreferred.Size = new System.Drawing.Size(122, 17);
            this.dbSSLModePreferred.TabIndex = 55;
            this.dbSSLModePreferred.Text = "SSL Mode Preferred";
            this.dbSSLModePreferred.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 20);
            this.textBox2.TabIndex = 20;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 20);
            this.textBox3.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "SSH Host";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "SSH Port:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Password:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(118, 71);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(191, 20);
            this.textBox4.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Username:";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(419, 378);
            this.hScrollBar1.Maximum = 200;
            this.hScrollBar1.Minimum = 10;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(191, 19);
            this.hScrollBar1.TabIndex = 22;
            this.hScrollBar1.Value = 10;
            // 
            // listViewUploadList
            // 
            this.listViewUploadList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderConnections,
            this.columnHeaderSubscriber});
            this.listViewUploadList.ContextMenuStrip = this.contextMenuStripSettings;
            this.listViewUploadList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUploadList.FullRowSelect = true;
            this.listViewUploadList.GridLines = true;
            this.listViewUploadList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUploadList.HideSelection = false;
            this.listViewUploadList.Location = new System.Drawing.Point(3, 16);
            this.listViewUploadList.Name = "listViewUploadList";
            this.listViewUploadList.Size = new System.Drawing.Size(347, 241);
            this.listViewUploadList.TabIndex = 53;
            this.listViewUploadList.UseCompatibleStateImageBehavior = false;
            this.listViewUploadList.View = System.Windows.Forms.View.Details;
            this.listViewUploadList.Click += new System.EventHandler(this.listViewUploadList_Click);
            // 
            // columnHeaderConnections
            // 
            this.columnHeaderConnections.Text = "Connection Name";
            this.columnHeaderConnections.Width = 100;
            // 
            // columnHeaderSubscriber
            // 
            this.columnHeaderSubscriber.Text = "Subscribed";
            this.columnHeaderSubscriber.Width = 80;
            // 
            // contextMenuStripSettings
            // 
            this.contextMenuStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.subscribeToolStripMenuItem,
            this.unsubscribeToolStripMenuItem});
            this.contextMenuStripSettings.Name = "contextMenuStripSettings";
            this.contextMenuStripSettings.Size = new System.Drawing.Size(140, 120);
            this.contextMenuStripSettings.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripSettings_Opening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::BACnetBrowser.Properties.Resources.server_add;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::BACnetBrowser.Properties.Resources.server_edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::BACnetBrowser.Properties.Resources.server_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // subscribeToolStripMenuItem
            // 
            this.subscribeToolStripMenuItem.Image = global::BACnetBrowser.Properties.Resources.server_go;
            this.subscribeToolStripMenuItem.Name = "subscribeToolStripMenuItem";
            this.subscribeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.subscribeToolStripMenuItem.Text = "Subscribe";
            this.subscribeToolStripMenuItem.Click += new System.EventHandler(this.subscribeToolStripMenuItem_Click);
            // 
            // unsubscribeToolStripMenuItem
            // 
            this.unsubscribeToolStripMenuItem.Image = global::BACnetBrowser.Properties.Resources.server_error;
            this.unsubscribeToolStripMenuItem.Name = "unsubscribeToolStripMenuItem";
            this.unsubscribeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.unsubscribeToolStripMenuItem.Text = "Unsubscribe";
            this.unsubscribeToolStripMenuItem.Click += new System.EventHandler(this.unsubscribeToolStripMenuItem_Click);
            // 
            // listViewTableNames
            // 
            this.listViewTableNames.AllowDrop = true;
            this.listViewTableNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewTableNames.ContextMenuStrip = this.contextMenuStripCommands;
            this.listViewTableNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTableNames.GridLines = true;
            this.listViewTableNames.HideSelection = false;
            this.listViewTableNames.Location = new System.Drawing.Point(0, 0);
            this.listViewTableNames.MultiSelect = false;
            this.listViewTableNames.Name = "listViewTableNames";
            this.listViewTableNames.Size = new System.Drawing.Size(29, 364);
            this.listViewTableNames.TabIndex = 54;
            this.listViewTableNames.UseCompatibleStateImageBehavior = false;
            this.listViewTableNames.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tablenames";
            this.columnHeader2.Width = 250;
            // 
            // contextMenuStripCommands
            // 
            this.contextMenuStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sELECTToolStripMenuItem});
            this.contextMenuStripCommands.Name = "contextMenuStripCommands";
            this.contextMenuStripCommands.Size = new System.Drawing.Size(198, 26);
            this.contextMenuStripCommands.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCommands_Opening);
            // 
            // sELECTToolStripMenuItem
            // 
            this.sELECTToolStripMenuItem.Name = "sELECTToolStripMenuItem";
            this.sELECTToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.sELECTToolStripMenuItem.Text = "SQL SELECT Command";
            this.sELECTToolStripMenuItem.Click += new System.EventHandler(this.sELECTToolStripMenuItem_Click);
            // 
            // goupBoxDateTimeUpload
            // 
            this.goupBoxDateTimeUpload.Controls.Add(this.tLayPanWeekdays);
            this.goupBoxDateTimeUpload.Controls.Add(this.lblSecondsToUplaod);
            this.goupBoxDateTimeUpload.Controls.Add(this.ScrollUploadTime);
            this.goupBoxDateTimeUpload.Controls.Add(this.label10);
            this.goupBoxDateTimeUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goupBoxDateTimeUpload.Location = new System.Drawing.Point(0, 0);
            this.goupBoxDateTimeUpload.MinimumSize = new System.Drawing.Size(250, 0);
            this.goupBoxDateTimeUpload.Name = "goupBoxDateTimeUpload";
            this.goupBoxDateTimeUpload.Size = new System.Drawing.Size(353, 94);
            this.goupBoxDateTimeUpload.TabIndex = 56;
            this.goupBoxDateTimeUpload.TabStop = false;
            this.goupBoxDateTimeUpload.Text = "Settings for Upload COV Data";
            // 
            // tLayPanWeekdays
            // 
            this.tLayPanWeekdays.ColumnCount = 7;
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tLayPanWeekdays.Controls.Add(this.cbSo, 6, 0);
            this.tLayPanWeekdays.Controls.Add(this.cbMi, 2, 0);
            this.tLayPanWeekdays.Controls.Add(this.cbSa, 5, 0);
            this.tLayPanWeekdays.Controls.Add(this.cbMo, 0, 0);
            this.tLayPanWeekdays.Controls.Add(this.cbFr, 4, 0);
            this.tLayPanWeekdays.Controls.Add(this.cbDi, 1, 0);
            this.tLayPanWeekdays.Controls.Add(this.cbDo, 3, 0);
            this.tLayPanWeekdays.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tLayPanWeekdays.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tLayPanWeekdays.Location = new System.Drawing.Point(3, 30);
            this.tLayPanWeekdays.Name = "tLayPanWeekdays";
            this.tLayPanWeekdays.RowCount = 1;
            this.tLayPanWeekdays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLayPanWeekdays.Size = new System.Drawing.Size(347, 29);
            this.tLayPanWeekdays.TabIndex = 57;
            // 
            // groupBoxConnectionsAndSubsriber
            // 
            this.groupBoxConnectionsAndSubsriber.Controls.Add(this.listViewUploadList);
            this.groupBoxConnectionsAndSubsriber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConnectionsAndSubsriber.Location = new System.Drawing.Point(0, 0);
            this.groupBoxConnectionsAndSubsriber.MinimumSize = new System.Drawing.Size(300, 0);
            this.groupBoxConnectionsAndSubsriber.Name = "groupBoxConnectionsAndSubsriber";
            this.groupBoxConnectionsAndSubsriber.Size = new System.Drawing.Size(353, 260);
            this.groupBoxConnectionsAndSubsriber.TabIndex = 59;
            this.groupBoxConnectionsAndSubsriber.TabStop = false;
            this.groupBoxConnectionsAndSubsriber.Text = "Connections/Subscriber:";
            this.groupBoxConnectionsAndSubsriber.SizeChanged += new System.EventHandler(this.groupBoxConnectionsAndSubsriber_SizeChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem8,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 61;
            this.menuStrip1.Text = "Edit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewProvider,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDelete,
            this.toolStripSeparator1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 20);
            this.toolStripMenuItem1.Text = "Settings - Connection";
            // 
            // toolStripMenuItemNewProvider
            // 
            this.toolStripMenuItemNewProvider.Image = global::BACnetBrowser.Properties.Resources.server_add;
            this.toolStripMenuItemNewProvider.Name = "toolStripMenuItemNewProvider";
            this.toolStripMenuItemNewProvider.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemNewProvider.Text = "New";
            this.toolStripMenuItemNewProvider.Click += new System.EventHandler(this.toolStripMenuItemNew_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Image = global::BACnetBrowser.Properties.Resources.server_edit;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemEdit.Text = "Edit";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::BACnetBrowser.Properties.Resources.server_delete;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItemAddSub,
            this.removeToolStripMenuItemRemoveSub});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(74, 20);
            this.toolStripMenuItem8.Text = "Subscriber";
            // 
            // addToolStripMenuItemAddSub
            // 
            this.addToolStripMenuItemAddSub.Image = global::BACnetBrowser.Properties.Resources.server_go;
            this.addToolStripMenuItemAddSub.Name = "addToolStripMenuItemAddSub";
            this.addToolStripMenuItemAddSub.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItemAddSub.Text = "Subscribe";
            this.addToolStripMenuItemAddSub.Click += new System.EventHandler(this.addToolStripMenuItemAddSub_Click);
            // 
            // removeToolStripMenuItemRemoveSub
            // 
            this.removeToolStripMenuItemRemoveSub.Image = global::BACnetBrowser.Properties.Resources.server_error;
            this.removeToolStripMenuItemRemoveSub.Name = "removeToolStripMenuItemRemoveSub";
            this.removeToolStripMenuItemRemoveSub.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItemRemoveSub.Text = "Unsubscribe";
            this.removeToolStripMenuItemRemoveSub.Click += new System.EventHandler(this.removeToolStripMenuItemRemoveSub_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem3.Text = "View";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem4.Text = "Show TableNames";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Image = global::BACnetBrowser.Properties.Resources.bell;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem2.Text = "Save";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItemSaveSettings_Click);
            // 
            // imagelist
            // 
            this.imagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist.ImageStream")));
            this.imagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist.Images.SetKeyName(0, "world_add.png");
            this.imagelist.Images.SetKeyName(1, "world_delete.png");
            this.imagelist.Images.SetKeyName(2, "world_edit.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 330;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(760, 364);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 61;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxConnectionsAndSubsriber);
            this.splitContainer2.Panel1MinSize = 50;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.goupBoxDateTimeUpload);
            this.splitContainer2.Size = new System.Drawing.Size(353, 364);
            this.splitContainer2.SplitterDistance = 260;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControlControlConnection);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.CausesValidation = false;
            this.splitContainer3.Panel2.Controls.Add(this.listViewTableNames);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(397, 364);
            this.splitContainer3.SplitterDistance = 364;
            this.splitContainer3.TabIndex = 0;
            // 
            // DatabaseConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 410);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DatabaseConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Settings";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panTryConnection.ResumeLayout(false);
            this.panTryConnection.PerformLayout();
            this.tabControlControlConnection.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.panConnectionName.ResumeLayout(false);
            this.panConnectionName.PerformLayout();
            this.panConnectionDetails.ResumeLayout(false);
            this.panConnectionDetails.PerformLayout();
            this.tabPageSSH.ResumeLayout(false);
            this.tabPageSSH.PerformLayout();
            this.contextMenuStripSettings.ResumeLayout(false);
            this.contextMenuStripCommands.ResumeLayout(false);
            this.goupBoxDateTimeUpload.ResumeLayout(false);
            this.goupBoxDateTimeUpload.PerformLayout();
            this.tLayPanWeekdays.ResumeLayout(false);
            this.tLayPanWeekdays.PerformLayout();
            this.groupBoxConnectionsAndSubsriber.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbPW;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblSecondsToUplaod;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.HScrollBar ScrollUploadTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbMo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbSo;
        private System.Windows.Forms.CheckBox cbSa;
        private System.Windows.Forms.CheckBox cbFr;
        private System.Windows.Forms.CheckBox cbDo;
        private System.Windows.Forms.CheckBox cbMi;
        private System.Windows.Forms.CheckBox cbDi;
        private System.Windows.Forms.Button btnTryConnection;
        private System.Windows.Forms.Button btnSaveConnection;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btnShowTableNames;
        private System.Windows.Forms.CheckBox chbVPN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbConnectionName;
        private System.Windows.Forms.Panel panTryConnection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBoxConnectionType;
        private System.Windows.Forms.TabControl tabControlControlConnection;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageSSH;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.ListView listViewUploadList;
        private System.Windows.Forms.ColumnHeader columnHeaderConnections;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comBoxDatabases;
        private System.Windows.Forms.Button btnNewDatabase;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripStatusLabel m_StatusStripLabel1;
        private System.Windows.Forms.ToolStripStatusLabel m_StatusStripLabel2;
        private System.Windows.Forms.ListView listViewTableNames;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.CheckBox cbSSLModeRequired;
        private System.Windows.Forms.CheckBox dbSSLModePreferred;
        private System.Windows.Forms.Panel panConnectionDetails;
        private System.Windows.Forms.Panel panConnectionName;
        private System.Windows.Forms.GroupBox goupBoxDateTimeUpload;
        private System.Windows.Forms.TableLayoutPanel tLayPanWeekdays;
        private System.Windows.Forms.ColumnHeader columnHeaderSubscriber;
        private System.Windows.Forms.GroupBox groupBoxConnectionsAndSubsriber;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewProvider;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItemAddSub;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItemRemoveSub;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSettings;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem subscribeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsubscribeToolStripMenuItem;
        private System.Windows.Forms.ImageList imagelist;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel m_statusStripLabelErgebnis;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCommands;
        private System.Windows.Forms.ToolStripMenuItem sELECTToolStripMenuItem;
    }
}