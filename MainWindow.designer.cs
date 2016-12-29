namespace MySqlClientDotNET {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panBottom = new System.Windows.Forms.Panel();
            this.tabOut = new System.Windows.Forms.TabControl();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.toolStripPanBottom = new System.Windows.Forms.ToolStrip();
            this.toolStripPanBottomClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelOutput = new System.Windows.Forms.ToolStripLabel();
            this.spBottom = new System.Windows.Forms.Splitter();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mainMenuFiles = new System.Windows.Forms.MenuItem();
            this.subMainMenuNewSql = new System.Windows.Forms.MenuItem();
            this.subMainMenuOpenSQLFile = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.subMainMenuSaveSQL = new System.Windows.Forms.MenuItem();
            this.subMainMenuSaveAsSQL = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.subMainMenuCloseConn = new System.Windows.Forms.MenuItem();
            this.subMainMenuExit = new System.Windows.Forms.MenuItem();
            this.mainMenuView = new System.Windows.Forms.MenuItem();
            this.subMainMenuDBExplorer = new System.Windows.Forms.MenuItem();
            this.subMainMenuOutput = new System.Windows.Forms.MenuItem();
            this.subMainMenuIdentityServer = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.subMainMenuHideAllPan = new System.Windows.Forms.MenuItem();
            this.mainMenuCreate = new System.Windows.Forms.MenuItem();
            this.subMainMenuCreateDB = new System.Windows.Forms.MenuItem();
            this.subMainMenuCreateTB = new System.Windows.Forms.MenuItem();
            this.mainMenuTools = new System.Windows.Forms.MenuItem();
            this.subMainMenuOpenConsole = new System.Windows.Forms.MenuItem();
            this.subMainMenuImportExportDB = new System.Windows.Forms.MenuItem();
            this.subMainMenuUserAccount = new System.Windows.Forms.MenuItem();
            this.subMainMenuSetting = new System.Windows.Forms.MenuItem();
            this.mainMenuHelp = new System.Windows.Forms.MenuItem();
            this.subMainMenuAbout = new System.Windows.Forms.MenuItem();
            this.panLeft = new System.Windows.Forms.Panel();
            this.treeExplorer = new System.Windows.Forms.TreeView();
            this.toolStripPanBottomLeft = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLoadDB = new System.Windows.Forms.ToolStripLabel();
            this.buttonSelectDB = new System.Windows.Forms.ToolStripButton();
            this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonCreate = new System.Windows.Forms.ToolStripButton();
            this.buttonAlter = new System.Windows.Forms.ToolStripButton();
            this.buttonDrop = new System.Windows.Forms.ToolStripButton();
            this.toolStripPanLeft = new System.Windows.Forms.ToolStrip();
            this.toolStripPanLeftClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelDBExplorer = new System.Windows.Forms.ToolStripLabel();
            this.panRight = new System.Windows.Forms.Panel();
            this.textServerStatus = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStripPanRight = new System.Windows.Forms.ToolStrip();
            this.toolStripPanRightClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelServerIdentity = new System.Windows.Forms.ToolStripLabel();
            this.spRight = new System.Windows.Forms.Splitter();
            this.spLeft = new System.Windows.Forms.Splitter();
            this.toolStripBottom = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripLeft = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDBExplorer = new System.Windows.Forms.ToolStripButton();
            this.toolStripRight = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonServerIdentity = new System.Windows.Forms.ToolStripButton();
            this.databaseExplorerContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonContextRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextUseDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonContextDatabases = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextAlterDB = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextDropDB = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextCreateTB = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextTables = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextAlterTB = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonContextDropTB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonContextEditData = new System.Windows.Forms.ToolStripMenuItem();
            this.panBottom.SuspendLayout();
            this.tabOut.SuspendLayout();
            this.toolStripPanBottom.SuspendLayout();
            this.panLeft.SuspendLayout();
            this.toolStripPanBottomLeft.SuspendLayout();
            this.toolStripPanLeft.SuspendLayout();
            this.panRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textServerStatus)).BeginInit();
            this.toolStripPanRight.SuspendLayout();
            this.toolStripBottom.SuspendLayout();
            this.toolStripLeft.SuspendLayout();
            this.toolStripRight.SuspendLayout();
            this.databaseExplorerContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBottom
            // 
            this.panBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panBottom.Controls.Add(this.tabOut);
            this.panBottom.Controls.Add(this.toolStripPanBottom);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(227, 176);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(169, 273);
            this.panBottom.TabIndex = 0;
            // 
            // tabOut
            // 
            this.tabOut.Controls.Add(this.tabPageMessage);
            this.tabOut.Controls.Add(this.tabPageTable);
            this.tabOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOut.Location = new System.Drawing.Point(0, 25);
            this.tabOut.Name = "tabOut";
            this.tabOut.SelectedIndex = 0;
            this.tabOut.Size = new System.Drawing.Size(169, 248);
            this.tabOut.TabIndex = 2;
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageMessage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessage.Size = new System.Drawing.Size(161, 222);
            this.tabPageMessage.TabIndex = 0;
            this.tabPageMessage.Text = "Message";
            // 
            // tabPageTable
            // 
            this.tabPageTable.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(161, 222);
            this.tabPageTable.TabIndex = 1;
            this.tabPageTable.Text = "Result Grid";
            // 
            // toolStripPanBottom
            // 
            this.toolStripPanBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPanBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPanBottomClose,
            this.toolStripLabelOutput});
            this.toolStripPanBottom.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanBottom.Name = "toolStripPanBottom";
            this.toolStripPanBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripPanBottom.Size = new System.Drawing.Size(169, 25);
            this.toolStripPanBottom.TabIndex = 1;
            this.toolStripPanBottom.Text = "toolStrip1";
            // 
            // toolStripPanBottomClose
            // 
            this.toolStripPanBottomClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPanBottomClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPanBottomClose.Image")));
            this.toolStripPanBottomClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPanBottomClose.Name = "toolStripPanBottomClose";
            this.toolStripPanBottomClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripPanBottomClose.Text = "Close";
            this.toolStripPanBottomClose.Click += new System.EventHandler(this.toolStripPanBottomClose_Click);
            // 
            // toolStripLabelOutput
            // 
            this.toolStripLabelOutput.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelOutput.Name = "toolStripLabelOutput";
            this.toolStripLabelOutput.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabelOutput.Text = "Output";
            // 
            // spBottom
            // 
            this.spBottom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spBottom.Location = new System.Drawing.Point(227, 173);
            this.spBottom.Name = "spBottom";
            this.spBottom.Size = new System.Drawing.Size(169, 3);
            this.spBottom.TabIndex = 1;
            this.spBottom.TabStop = false;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mainMenuFiles,
            this.mainMenuView,
            this.mainMenuCreate,
            this.mainMenuTools,
            this.mainMenuHelp});
            // 
            // mainMenuFiles
            // 
            this.mainMenuFiles.Index = 0;
            this.mainMenuFiles.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.subMainMenuNewSql,
            this.subMainMenuOpenSQLFile,
            this.menuItem6,
            this.subMainMenuSaveSQL,
            this.subMainMenuSaveAsSQL,
            this.menuItem7,
            this.subMainMenuCloseConn,
            this.subMainMenuExit});
            this.mainMenuFiles.Text = "&Files";
            // 
            // subMainMenuNewSql
            // 
            this.subMainMenuNewSql.Index = 0;
            this.subMainMenuNewSql.Text = "&New SQL Script";
            this.subMainMenuNewSql.Click += new System.EventHandler(this.menuItemNewSql_Click);
            // 
            // subMainMenuOpenSQLFile
            // 
            this.subMainMenuOpenSQLFile.Index = 1;
            this.subMainMenuOpenSQLFile.Text = "&Open SQL Script";
            this.subMainMenuOpenSQLFile.Click += new System.EventHandler(this.menuItemOpenSql_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // subMainMenuSaveSQL
            // 
            this.subMainMenuSaveSQL.Index = 3;
            this.subMainMenuSaveSQL.Text = "&Save SQL Script";
            this.subMainMenuSaveSQL.Click += new System.EventHandler(this.menuItemSaveSql_Click);
            // 
            // subMainMenuSaveAsSQL
            // 
            this.subMainMenuSaveAsSQL.Index = 4;
            this.subMainMenuSaveAsSQL.Text = "Save &As SQL Script";
            this.subMainMenuSaveAsSQL.Click += new System.EventHandler(this.menuItemSaveAsSql_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "-";
            // 
            // subMainMenuCloseConn
            // 
            this.subMainMenuCloseConn.Index = 6;
            this.subMainMenuCloseConn.Text = "&Close Connection";
            this.subMainMenuCloseConn.Click += new System.EventHandler(this.menuItemCloseConn_Click);
            // 
            // subMainMenuExit
            // 
            this.subMainMenuExit.Index = 7;
            this.subMainMenuExit.Text = "E&xit";
            this.subMainMenuExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // mainMenuView
            // 
            this.mainMenuView.Index = 1;
            this.mainMenuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.subMainMenuDBExplorer,
            this.subMainMenuOutput,
            this.subMainMenuIdentityServer,
            this.menuItem3,
            this.subMainMenuHideAllPan});
            this.mainMenuView.Text = "&View";
            // 
            // subMainMenuDBExplorer
            // 
            this.subMainMenuDBExplorer.Index = 0;
            this.subMainMenuDBExplorer.Text = "&Database Explorer";
            this.subMainMenuDBExplorer.Click += new System.EventHandler(this.mainMenuDBExplorer_Click);
            // 
            // subMainMenuOutput
            // 
            this.subMainMenuOutput.Index = 1;
            this.subMainMenuOutput.Text = "&Output";
            this.subMainMenuOutput.Click += new System.EventHandler(this.mainMenuOutput_Click);
            // 
            // subMainMenuIdentityServer
            // 
            this.subMainMenuIdentityServer.Index = 2;
            this.subMainMenuIdentityServer.Text = "&Status Server";
            this.subMainMenuIdentityServer.Click += new System.EventHandler(this.mainMenuStatusServer_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // subMainMenuHideAllPan
            // 
            this.subMainMenuHideAllPan.Index = 4;
            this.subMainMenuHideAllPan.Text = "&Hide All Panle";
            this.subMainMenuHideAllPan.Click += new System.EventHandler(this.mainMenuHideAllPan_Click);
            // 
            // mainMenuCreate
            // 
            this.mainMenuCreate.Index = 2;
            this.mainMenuCreate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.subMainMenuCreateDB,
            this.subMainMenuCreateTB});
            this.mainMenuCreate.Text = "&Create";
            // 
            // subMainMenuCreateDB
            // 
            this.subMainMenuCreateDB.Index = 0;
            this.subMainMenuCreateDB.Text = "&Create Database";
            this.subMainMenuCreateDB.Click += new System.EventHandler(this.mainMenuCreateDB_Click);
            // 
            // subMainMenuCreateTB
            // 
            this.subMainMenuCreateTB.Index = 1;
            this.subMainMenuCreateTB.Text = "Create Table (Default Databse)";
            this.subMainMenuCreateTB.Click += new System.EventHandler(this.mainMenuCreateTB_Click);
            // 
            // mainMenuTools
            // 
            this.mainMenuTools.Index = 3;
            this.mainMenuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.subMainMenuOpenConsole,
            this.subMainMenuImportExportDB,
            this.subMainMenuUserAccount,
            this.subMainMenuSetting});
            this.mainMenuTools.Text = "T&ools";
            // 
            // subMainMenuOpenConsole
            // 
            this.subMainMenuOpenConsole.Index = 0;
            this.subMainMenuOpenConsole.Text = "Open &Console";
            this.subMainMenuOpenConsole.Click += new System.EventHandler(this.menuItemConsole_Click);
            // 
            // subMainMenuImportExportDB
            // 
            this.subMainMenuImportExportDB.Index = 1;
            this.subMainMenuImportExportDB.Text = "&Import/Export Database";
            this.subMainMenuImportExportDB.Click += new System.EventHandler(this.menuItemExportImportDB_Click);
            // 
            // subMainMenuUserAccount
            // 
            this.subMainMenuUserAccount.Index = 2;
            this.subMainMenuUserAccount.Text = "&User Accounts";
            this.subMainMenuUserAccount.Click += new System.EventHandler(this.menuItemUserAccount_Click);
            // 
            // subMainMenuSetting
            // 
            this.subMainMenuSetting.Enabled = false;
            this.subMainMenuSetting.Index = 3;
            this.subMainMenuSetting.Text = "Setting";
            this.subMainMenuSetting.Click += new System.EventHandler(this.mainMenuSettingLimit_Click);
            // 
            // mainMenuHelp
            // 
            this.mainMenuHelp.Index = 4;
            this.mainMenuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.subMainMenuAbout});
            this.mainMenuHelp.Text = "&Help";
            // 
            // subMainMenuAbout
            // 
            this.subMainMenuAbout.Index = 0;
            this.subMainMenuAbout.Text = "About";
            this.subMainMenuAbout.Click += new System.EventHandler(this.subMainMenuAbout_Click);
            // 
            // panLeft
            // 
            this.panLeft.BackColor = System.Drawing.SystemColors.Control;
            this.panLeft.Controls.Add(this.treeExplorer);
            this.panLeft.Controls.Add(this.toolStripPanBottomLeft);
            this.panLeft.Controls.Add(this.toolStripPanLeft);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(200, 449);
            this.panLeft.TabIndex = 2;
            // 
            // treeExplorer
            // 
            this.treeExplorer.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.treeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeExplorer.Location = new System.Drawing.Point(0, 25);
            this.treeExplorer.Name = "treeExplorer";
            this.treeExplorer.Size = new System.Drawing.Size(200, 399);
            this.treeExplorer.TabIndex = 1;
            this.treeExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeExplorer_AfterSelect);
            this.treeExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeExplorer_NodeMouseClick);
            // 
            // toolStripPanBottomLeft
            // 
            this.toolStripPanBottomLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPanBottomLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPanBottomLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLoadDB,
            this.buttonSelectDB,
            this.buttonRefresh,
            this.toolStripSeparator1,
            this.buttonCreate,
            this.buttonAlter,
            this.buttonDrop});
            this.toolStripPanBottomLeft.Location = new System.Drawing.Point(0, 424);
            this.toolStripPanBottomLeft.Name = "toolStripPanBottomLeft";
            this.toolStripPanBottomLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripPanBottomLeft.Size = new System.Drawing.Size(200, 25);
            this.toolStripPanBottomLeft.TabIndex = 2;
            this.toolStripPanBottomLeft.Text = "toolStrip1";
            // 
            // toolStripLabelLoadDB
            // 
            this.toolStripLabelLoadDB.Name = "toolStripLabelLoadDB";
            this.toolStripLabelLoadDB.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabelLoadDB.Text = "Load Database...";
            this.toolStripLabelLoadDB.Visible = false;
            // 
            // buttonSelectDB
            // 
            this.buttonSelectDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSelectDB.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectDB.Image")));
            this.buttonSelectDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSelectDB.Name = "buttonSelectDB";
            this.buttonSelectDB.Size = new System.Drawing.Size(23, 22);
            this.buttonSelectDB.Text = "Set Database As Default";
            this.buttonSelectDB.Click += new System.EventHandler(this.buttonSelectDB_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(23, 22);
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonCreate
            // 
            this.buttonCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCreate.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate.Image")));
            this.buttonCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(23, 22);
            this.buttonCreate.Text = "toolStripButton1";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonAlter
            // 
            this.buttonAlter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAlter.Image = ((System.Drawing.Image)(resources.GetObject("buttonAlter.Image")));
            this.buttonAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAlter.Name = "buttonAlter";
            this.buttonAlter.Size = new System.Drawing.Size(23, 22);
            this.buttonAlter.Text = "toolStripButton2";
            this.buttonAlter.Click += new System.EventHandler(this.buttonAlter_Click);
            // 
            // buttonDrop
            // 
            this.buttonDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDrop.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrop.Image")));
            this.buttonDrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDrop.Name = "buttonDrop";
            this.buttonDrop.Size = new System.Drawing.Size(23, 22);
            this.buttonDrop.Text = "toolStripButton3";
            this.buttonDrop.Click += new System.EventHandler(this.buttonDrop_Click);
            // 
            // toolStripPanLeft
            // 
            this.toolStripPanLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPanLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPanLeftClose,
            this.toolStripLabelDBExplorer});
            this.toolStripPanLeft.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanLeft.Name = "toolStripPanLeft";
            this.toolStripPanLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripPanLeft.Size = new System.Drawing.Size(200, 25);
            this.toolStripPanLeft.TabIndex = 0;
            this.toolStripPanLeft.Text = "toolStrip1";
            // 
            // toolStripPanLeftClose
            // 
            this.toolStripPanLeftClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPanLeftClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPanLeftClose.Image")));
            this.toolStripPanLeftClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPanLeftClose.Name = "toolStripPanLeftClose";
            this.toolStripPanLeftClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripPanLeftClose.Text = "Close";
            this.toolStripPanLeftClose.Click += new System.EventHandler(this.toolStripPanLeftClose_Click);
            // 
            // toolStripLabelDBExplorer
            // 
            this.toolStripLabelDBExplorer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelDBExplorer.Name = "toolStripLabelDBExplorer";
            this.toolStripLabelDBExplorer.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabelDBExplorer.Text = "Database Explorer";
            // 
            // panRight
            // 
            this.panRight.BackColor = System.Drawing.SystemColors.Control;
            this.panRight.Controls.Add(this.textServerStatus);
            this.panRight.Controls.Add(this.toolStripPanRight);
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.Location = new System.Drawing.Point(423, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(166, 449);
            this.panRight.TabIndex = 3;
            // 
            // textServerStatus
            // 
            this.textServerStatus.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textServerStatus.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.textServerStatus.BackBrush = null;
            this.textServerStatus.CharHeight = 14;
            this.textServerStatus.CharWidth = 8;
            this.textServerStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textServerStatus.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textServerStatus.IsReplaceMode = false;
            this.textServerStatus.Location = new System.Drawing.Point(0, 25);
            this.textServerStatus.Name = "textServerStatus";
            this.textServerStatus.Paddings = new System.Windows.Forms.Padding(0);
            this.textServerStatus.ReadOnly = true;
            this.textServerStatus.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textServerStatus.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textServerStatus.ServiceColors")));
            this.textServerStatus.ShowLineNumbers = false;
            this.textServerStatus.Size = new System.Drawing.Size(166, 424);
            this.textServerStatus.TabIndex = 2;
            this.textServerStatus.Zoom = 100;
            // 
            // toolStripPanRight
            // 
            this.toolStripPanRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPanRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPanRightClose,
            this.toolStripLabelServerIdentity});
            this.toolStripPanRight.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanRight.Name = "toolStripPanRight";
            this.toolStripPanRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripPanRight.Size = new System.Drawing.Size(166, 25);
            this.toolStripPanRight.TabIndex = 1;
            this.toolStripPanRight.Text = "toolStrip1";
            // 
            // toolStripPanRightClose
            // 
            this.toolStripPanRightClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripPanRightClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPanRightClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPanRightClose.Image")));
            this.toolStripPanRightClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPanRightClose.Name = "toolStripPanRightClose";
            this.toolStripPanRightClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripPanRightClose.Text = "Close";
            this.toolStripPanRightClose.Click += new System.EventHandler(this.toolStripPanRightClose_Click);
            // 
            // toolStripLabelServerIdentity
            // 
            this.toolStripLabelServerIdentity.Name = "toolStripLabelServerIdentity";
            this.toolStripLabelServerIdentity.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabelServerIdentity.Text = "Server Identity";
            // 
            // spRight
            // 
            this.spRight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.spRight.Location = new System.Drawing.Point(420, 0);
            this.spRight.Name = "spRight";
            this.spRight.Size = new System.Drawing.Size(3, 449);
            this.spRight.TabIndex = 4;
            this.spRight.TabStop = false;
            // 
            // spLeft
            // 
            this.spLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spLeft.Location = new System.Drawing.Point(200, 0);
            this.spLeft.Name = "spLeft";
            this.spLeft.Size = new System.Drawing.Size(3, 449);
            this.spLeft.TabIndex = 5;
            this.spLeft.TabStop = false;
            // 
            // toolStripBottom
            // 
            this.toolStripBottom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOutput});
            this.toolStripBottom.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripBottom.Location = new System.Drawing.Point(227, 148);
            this.toolStripBottom.Name = "toolStripBottom";
            this.toolStripBottom.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripBottom.Size = new System.Drawing.Size(169, 25);
            this.toolStripBottom.TabIndex = 10;
            this.toolStripBottom.Text = "toolStrip3";
            // 
            // toolStripButtonOutput
            // 
            this.toolStripButtonOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutput.Name = "toolStripButtonOutput";
            this.toolStripButtonOutput.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonOutput.Text = "Output";
            this.toolStripButtonOutput.Click += new System.EventHandler(this.toolStripBottomShow_Click);
            // 
            // toolStripLeft
            // 
            this.toolStripLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDBExplorer});
            this.toolStripLeft.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripLeft.Location = new System.Drawing.Point(203, 0);
            this.toolStripLeft.Name = "toolStripLeft";
            this.toolStripLeft.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripLeft.Size = new System.Drawing.Size(24, 449);
            this.toolStripLeft.TabIndex = 11;
            this.toolStripLeft.Text = "toolStrip1";
            // 
            // toolStripButtonDBExplorer
            // 
            this.toolStripButtonDBExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDBExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonDBExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDBExplorer.Name = "toolStripButtonDBExplorer";
            this.toolStripButtonDBExplorer.Size = new System.Drawing.Size(21, 115);
            this.toolStripButtonDBExplorer.Text = "Database Explorer";
            this.toolStripButtonDBExplorer.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            this.toolStripButtonDBExplorer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripButtonDBExplorer.ToolTipText = "Show";
            this.toolStripButtonDBExplorer.Click += new System.EventHandler(this.toolStripLeftShow_Click);
            // 
            // toolStripRight
            // 
            this.toolStripRight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStripRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonServerIdentity});
            this.toolStripRight.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripRight.Location = new System.Drawing.Point(396, 0);
            this.toolStripRight.Name = "toolStripRight";
            this.toolStripRight.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripRight.Size = new System.Drawing.Size(24, 449);
            this.toolStripRight.TabIndex = 12;
            this.toolStripRight.Text = "toolStrip2";
            // 
            // toolStripButtonServerIdentity
            // 
            this.toolStripButtonServerIdentity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonServerIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonServerIdentity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonServerIdentity.Name = "toolStripButtonServerIdentity";
            this.toolStripButtonServerIdentity.Size = new System.Drawing.Size(21, 94);
            this.toolStripButtonServerIdentity.Text = "Server Identity";
            this.toolStripButtonServerIdentity.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            this.toolStripButtonServerIdentity.Click += new System.EventHandler(this.toolStripRightShow_Click);
            // 
            // databaseExplorerContextMenu
            // 
            this.databaseExplorerContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonContextRefresh,
            this.buttonContextUseDB,
            this.toolStripSeparator2,
            this.buttonContextDatabases,
            this.buttonContextTables});
            this.databaseExplorerContextMenu.Name = "treeExplorerContexMenu";
            this.databaseExplorerContextMenu.Size = new System.Drawing.Size(199, 98);
            this.databaseExplorerContextMenu.Text = "Database Explorer Context Meunu";
            // 
            // buttonContextRefresh
            // 
            this.buttonContextRefresh.Name = "buttonContextRefresh";
            this.buttonContextRefresh.Size = new System.Drawing.Size(198, 22);
            this.buttonContextRefresh.Text = "&Refresh";
            this.buttonContextRefresh.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // buttonContextUseDB
            // 
            this.buttonContextUseDB.Name = "buttonContextUseDB";
            this.buttonContextUseDB.Size = new System.Drawing.Size(198, 22);
            this.buttonContextUseDB.Text = "&Set Database As Default";
            this.buttonContextUseDB.Click += new System.EventHandler(this.buttonContexUseDB_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // buttonContextDatabases
            // 
            this.buttonContextDatabases.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonContextAlterDB,
            this.buttonContextDropDB,
            this.buttonContextCreateTB});
            this.buttonContextDatabases.Name = "buttonContextDatabases";
            this.buttonContextDatabases.Size = new System.Drawing.Size(198, 22);
            this.buttonContextDatabases.Text = "&Databases";
            // 
            // buttonContextAlterDB
            // 
            this.buttonContextAlterDB.Name = "buttonContextAlterDB";
            this.buttonContextAlterDB.Size = new System.Drawing.Size(151, 22);
            this.buttonContextAlterDB.Text = "&Alter Database";
            this.buttonContextAlterDB.Click += new System.EventHandler(this.buttonContexAlterDB_Click);
            // 
            // buttonContextDropDB
            // 
            this.buttonContextDropDB.Name = "buttonContextDropDB";
            this.buttonContextDropDB.Size = new System.Drawing.Size(151, 22);
            this.buttonContextDropDB.Text = "&Drop Database";
            this.buttonContextDropDB.Click += new System.EventHandler(this.buttonContexDropDB_Click);
            // 
            // buttonContextCreateTB
            // 
            this.buttonContextCreateTB.Name = "buttonContextCreateTB";
            this.buttonContextCreateTB.Size = new System.Drawing.Size(151, 22);
            this.buttonContextCreateTB.Text = "Create Table";
            this.buttonContextCreateTB.Click += new System.EventHandler(this.buttonContexCreateTB_Click);
            // 
            // buttonContextTables
            // 
            this.buttonContextTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonContextAlterTB,
            this.buttonContextDropTB,
            this.toolStripSeparator3,
            this.buttonContextEditData});
            this.buttonContextTables.Name = "buttonContextTables";
            this.buttonContextTables.Size = new System.Drawing.Size(198, 22);
            this.buttonContextTables.Text = "&Tables";
            // 
            // buttonContextAlterTB
            // 
            this.buttonContextAlterTB.Name = "buttonContextAlterTB";
            this.buttonContextAlterTB.Size = new System.Drawing.Size(293, 22);
            this.buttonContextAlterTB.Text = "&Alter Table";
            this.buttonContextAlterTB.Click += new System.EventHandler(this.buttonContexAlterTB_Click);
            // 
            // buttonContextDropTB
            // 
            this.buttonContextDropTB.Name = "buttonContextDropTB";
            this.buttonContextDropTB.Size = new System.Drawing.Size(293, 22);
            this.buttonContextDropTB.Text = "&Drop Table";
            this.buttonContextDropTB.Click += new System.EventHandler(this.buttonContexDropTB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(290, 6);
            // 
            // buttonContextEditData
            // 
            this.buttonContextEditData.Name = "buttonContextEditData";
            this.buttonContextEditData.Size = new System.Drawing.Size(293, 22);
            this.buttonContextEditData.Text = "Edit Data On Table (Insert/Update/Delete)";
            this.buttonContextEditData.Click += new System.EventHandler(this.buttonContexEditData_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(589, 449);
            this.Controls.Add(this.toolStripBottom);
            this.Controls.Add(this.spBottom);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.toolStripRight);
            this.Controls.Add(this.toolStripLeft);
            this.Controls.Add(this.spLeft);
            this.Controls.Add(this.spRight);
            this.Controls.Add(this.panRight);
            this.Controls.Add(this.panLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(605, 487);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySql Client .NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MinimumSizeChanged += new System.EventHandler(this.MainWindow_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panBottom.ResumeLayout(false);
            this.panBottom.PerformLayout();
            this.tabOut.ResumeLayout(false);
            this.toolStripPanBottom.ResumeLayout(false);
            this.toolStripPanBottom.PerformLayout();
            this.panLeft.ResumeLayout(false);
            this.panLeft.PerformLayout();
            this.toolStripPanBottomLeft.ResumeLayout(false);
            this.toolStripPanBottomLeft.PerformLayout();
            this.toolStripPanLeft.ResumeLayout(false);
            this.toolStripPanLeft.PerformLayout();
            this.panRight.ResumeLayout(false);
            this.panRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textServerStatus)).EndInit();
            this.toolStripPanRight.ResumeLayout(false);
            this.toolStripPanRight.PerformLayout();
            this.toolStripBottom.ResumeLayout(false);
            this.toolStripBottom.PerformLayout();
            this.toolStripLeft.ResumeLayout(false);
            this.toolStripLeft.PerformLayout();
            this.toolStripRight.ResumeLayout(false);
            this.toolStripRight.PerformLayout();
            this.databaseExplorerContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Splitter spBottom;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mainMenuFiles;
        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.Splitter spRight;
        private System.Windows.Forms.Splitter spLeft;
        private System.Windows.Forms.ToolStrip toolStripBottom;
        private System.Windows.Forms.ToolStrip toolStripLeft;
        private System.Windows.Forms.ToolStrip toolStripRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonDBExplorer;
        private System.Windows.Forms.ToolStrip toolStripPanLeft;
        private System.Windows.Forms.ToolStripButton toolStripPanLeftClose;
        private System.Windows.Forms.ToolStripLabel toolStripLabelDBExplorer;
        private System.Windows.Forms.ToolStrip toolStripPanRight;
        private System.Windows.Forms.ToolStripButton toolStripPanRightClose;
        private System.Windows.Forms.ToolStripLabel toolStripLabelServerIdentity;
        private System.Windows.Forms.ToolStripButton toolStripButtonServerIdentity;
        private System.Windows.Forms.ToolStrip toolStripPanBottom;
        private System.Windows.Forms.ToolStripButton toolStripPanBottomClose;
        private System.Windows.Forms.ToolStripLabel toolStripLabelOutput;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutput;
        private System.Windows.Forms.TreeView treeExplorer;
        private System.Windows.Forms.ToolStrip toolStripPanBottomLeft;
        private System.Windows.Forms.ToolStripButton buttonCreate;
        private System.Windows.Forms.ToolStripButton buttonAlter;
        private System.Windows.Forms.ToolStripButton buttonDrop;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLoadDB;
        private System.Windows.Forms.MenuItem subMainMenuNewSql;
        private System.Windows.Forms.MenuItem subMainMenuOpenSQLFile;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem subMainMenuSaveSQL;
        private System.Windows.Forms.MenuItem subMainMenuSaveAsSQL;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem subMainMenuExit;
        private System.Windows.Forms.MenuItem mainMenuCreate;
        private System.Windows.Forms.MenuItem subMainMenuCreateDB;
        private System.Windows.Forms.MenuItem subMainMenuCreateTB;
        private System.Windows.Forms.MenuItem mainMenuView;
        private System.Windows.Forms.MenuItem subMainMenuCloseConn;
        private System.Windows.Forms.TabControl tabOut;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.ToolStripButton buttonSelectDB;
        private System.Windows.Forms.ToolStripButton buttonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip databaseExplorerContextMenu;
        private System.Windows.Forms.ToolStripMenuItem buttonContextUseDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem buttonContextDatabases;
        private System.Windows.Forms.ToolStripMenuItem buttonContextAlterDB;
        private System.Windows.Forms.ToolStripMenuItem buttonContextDropDB;
        private System.Windows.Forms.ToolStripMenuItem buttonContextTables;
        private System.Windows.Forms.ToolStripMenuItem buttonContextAlterTB;
        private System.Windows.Forms.ToolStripMenuItem buttonContextDropTB;
        private System.Windows.Forms.ToolStripMenuItem buttonContextRefresh;
        private FastColoredTextBoxNS.FastColoredTextBox textServerStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem buttonContextEditData;
        private System.Windows.Forms.MenuItem subMainMenuImportExportDB;
        private System.Windows.Forms.MenuItem subMainMenuDBExplorer;
        private System.Windows.Forms.MenuItem mainMenuTools;
        private System.Windows.Forms.MenuItem subMainMenuSetting;
        private System.Windows.Forms.MenuItem mainMenuHelp;
        private System.Windows.Forms.MenuItem subMainMenuAbout;
        private System.Windows.Forms.MenuItem subMainMenuIdentityServer;
        private System.Windows.Forms.MenuItem subMainMenuOutput;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem subMainMenuHideAllPan;
        private System.Windows.Forms.MenuItem subMainMenuOpenConsole;
        private System.Windows.Forms.MenuItem subMainMenuUserAccount;
        private System.Windows.Forms.ToolStripMenuItem buttonContextCreateTB;


    }
}

