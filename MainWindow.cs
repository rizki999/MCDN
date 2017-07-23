using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using MySqlClientDotNET.MySqlUtil;
using MySqlClientDotNET.DesignControls;
using IniParser;
using IniParser.Model;

namespace MySqlClientDotNET {

    public partial class MainWindow : Form {
        public MainWindow() {
            if (!System.IO.File.Exists(ResourcesPath.ini_file))
                MySqlConfig.createINIFile(); //create ini if don't exist

            MySqlConfig.settINIFile();//add comment
            if (MySqlConfig.GetAppConfig("language").Equals("id"))
                LanguageApp.initializeLangId();
            else
                LanguageApp.initializeLangEn();
            //hFileIni = System.IO.File.Open(ResourcesPath.ini_file, System.IO.FileMode.Open);

            initializeDynamicTab();
            InitializeComponent();
            this.Menu = mainMenu1;
            this.SuspendLayout();
            InitializeExternalComponent();
            this.ResumeLayout();
            MySqlConfig.initializeSyntax();

            setLanguage();
        }

        #region language
        //set for langauage aplication
        private void setLanguage() {
            mainMenuFiles.Text = LanguageApp.langMainMenu["MMFiles"];
            mainMenuView.Text = LanguageApp.langMainMenu["MMView"];
            mainMenuCreate.Text = LanguageApp.langMainMenu["MMCreate"];
            mainMenuTools.Text = LanguageApp.langMainMenu["MMTools"];
            mainMenuHelp.Text = LanguageApp.langMainMenu["MMHelp"];

            subMainMenuNewSql.Text = LanguageApp.langMainMenu["SMMNewSql"];
            subMainMenuOpenSQLFile.Text = LanguageApp.langMainMenu["SMMOpenSql"];
            subMainMenuSaveSQL.Text = LanguageApp.langMainMenu["SMMSaveSqlFile"];
            subMainMenuSaveAsSQL.Text = LanguageApp.langMainMenu["SMMSaveAsSqlFile"];
            subMainMenuCloseConn.Text = LanguageApp.langMainMenu["SMMCloseConn"];
            subMainMenuExit.Text = LanguageApp.langMainMenu["SMMExit"];
            subMainMenuDBExplorer.Text = LanguageApp.langMainMenu["SMMDatabaseExplorer"];
            subMainMenuIdentityServer.Text = LanguageApp.langMainMenu["SMMServerIdentity"];
            subMainMenuOutput.Text = LanguageApp.langMainMenu["SMMOutput"];
            subMainMenuHideAllPan.Text = LanguageApp.langMainMenu["SMMHideAllPanle"];
            subMainMenuCreateDB.Text = LanguageApp.langMainMenu["SMMCreateDatabase"];
            subMainMenuCreateTB.Text = LanguageApp.langMainMenu["SMMCreateTable"];
            subMainMenuOpenConsole.Text = LanguageApp.langMainMenu["SMMOpenConsole"];
            subMainMenuImportExportDB.Text = LanguageApp.langMainMenu["SMMImportExportDatabase"];
            subMainMenuUserAccount.Text = LanguageApp.langMainMenu["SMMUserAccount"];
            subMainMenuSetting.Text = LanguageApp.langMainMenu["SMMSetting"];
            subMainMenuAbout.Text = LanguageApp.langMainMenu["SMMAbout"];

            toolStripLabelDBExplorer.Text = LanguageApp.langMainMenu["TSLDatabaseExplorer"];
            toolStripButtonDBExplorer.Text = LanguageApp.langMainMenu["TSLDatabaseExplorer"];
            toolStripLabelServerIdentity.Text = LanguageApp.langMainMenu["TSLServerIdentity"];
            toolStripButtonServerIdentity.Text = LanguageApp.langMainMenu["TSLServerIdentity"];
            toolStripLabelOutput.Text = LanguageApp.langMainMenu["TSLOutput"];
            toolStripButtonOutput.Text = LanguageApp.langMainMenu["TSLOutput"];
            toolStripLabelLoadDB.Text = LanguageApp.langMainMenu["TSLLoadDatabase"];

            tabOut.TabPages[0].Text = LanguageApp.langMainMenu["TTMessage"];
            tabOut.TabPages[1].Text = LanguageApp.langMainMenu["TTResultGrid"];

            buttonContextRefresh.Text = LanguageApp.langMainMenu["CMSRefresh"];
            buttonContextUseDB.Text = LanguageApp.langMainMenu["CMSSetDBAsDef"];
            buttonContextDatabases.Text = LanguageApp.langMainMenu["CMSDatabase"];
            buttonContextTables.Text = LanguageApp.langMainMenu["CMSTable"];

            buttonContextAlterDB.Text = LanguageApp.langMainMenu["CSMSAlterDB"];
            buttonContextDropDB.Text = LanguageApp.langMainMenu["CSMSDropDB"];
            buttonContextCreateTB.Text = LanguageApp.langMainMenu["CSMSCraeteTable"];
            buttonContextAlterTB.Text = LanguageApp.langMainMenu["CSMSAlterTB"];
            buttonContextDropTB.Text = LanguageApp.langMainMenu["CSMSDropTB"];
            buttonContextEditData.Text = LanguageApp.langMainMenu["CSMSEditData"];

            MSGWaitAllDatabase = LanguageApp.langMainMenu["MSGWaitAllDatabase"];
            MSGErrLoadDbTree = LanguageApp.langMainMenu["MSGErrLoadDbTree"];
            MSGStetmentExec = LanguageApp.langMainMenu["MSGStetmentExec"];
            MSGErrStetmentAbort = LanguageApp.langMainMenu["MSGErrStetmentAbort"];
            MSGWarnSelectItem = LanguageApp.langMainMenu["MSGWarnSelectItem"];
            MSGErrSetDB = LanguageApp.langMainMenu["MSGErrSetDB"];
            MSGDBCannotDrop = LanguageApp.langMainMenu["MSGDBCannotDrop"];
            MSGDBExistOnTab = LanguageApp.langMainMenu["MSGDbExistOnTab"];
            MSGDBNotFound = LanguageApp.langMainMenu["MSGDbNotFound"];
            MSGActionDropDB = LanguageApp.langMainMenu["MSGActionDropDB"];
            MSGTBExistOnTab = LanguageApp.langMainMenu["MSGTbExistOnTab"];
            MSGTBNotFound = LanguageApp.langMainMenu["MSGTbNotFound"];
            MSGActionDropTB = LanguageApp.langMainMenu["MSGActionDropTB"];
            MSGConfrimCloseConn = LanguageApp.langMainMenu["MSGConfrimCloseConn"];
            MSGWarnSelectDB = LanguageApp.langMainMenu["MSGWarnSelectDB"];
            MSGWarnDiscardAllContent = LanguageApp.langMainMenu["MSGWarnDiscardAllContent"];
            MSGNoPrimary = LanguageApp.langMainMenu["MSGNoPrimary"];
            MSGErrTryCloseConn = LanguageApp.langMainMenu["MSGErrTryCloseConn"];
        }

        private string MSGWaitAllDatabase;
        private string MSGErrLoadDbTree;
        private string MSGStetmentExec;
        private string MSGErrStetmentAbort;
        private string MSGWarnSelectItem;
        private string MSGErrSetDB;
        private string MSGDBCannotDrop;
        private string MSGDBExistOnTab;
        private string MSGDBNotFound;
        private string MSGActionDropDB;
        private string MSGTBExistOnTab;
        private string MSGTBNotFound;
        private string MSGActionDropTB;
        private string MSGConfrimCloseConn;
        private string MSGWarnSelectDB;
        private string MSGWarnDiscardAllContent;
        private string MSGNoPrimary;
        private string MSGErrTryCloseConn;
        #endregion

        //set value window setting to ini file
        private void setWindowToIniFile() {
            int iw_width, iw_hight, ilocate_x, ilocate_y;
            iw_hight = 0;
            iw_width = 0;


            var fileIni = new FileIniDataParser();

            fileIni.Parser.Configuration.CommentString = "#";
            var iniData = fileIni.ReadFile(ResourcesPath.ini_file);

            if (this.WindowState == FormWindowState.Normal) {
                ilocate_x = 0;
                ilocate_y = 0;
                iw_hight = this.Size.Height;
                iw_width = this.Size.Width;
                ilocate_x = this.Location.X;
                ilocate_y = this.Location.Y;
                try {
                    iniData["app_config"]["window_location_x"] = ilocate_x.ToString();
                    iniData["app_config"]["window_location_y"] = ilocate_y.ToString();
                    iniData["app_config"]["window_width"] = iw_width.ToString();
                    iniData["app_config"]["window_hight"] = iw_hight.ToString();
                    iniData["app_config"]["window_fullscreen"] = "0";
                    fileIni.WriteFile(ResourcesPath.ini_file, iniData);
                } catch (Exception ex) { Log.WriteL("Error : " + ex.Message); }
            } else { //fullscreen
                try {
                    iniData["app_config"]["window_fullscreen"] = "1";
                    fileIni.WriteFile(ResourcesPath.ini_file, iniData);
                } catch (Exception ex) { Log.WriteL("Error : " + ex.Message); }
            }

        }

        //seting up window from ini file
        private void setWindowToForm() {
            int iw_width, iw_hight, ilocate_x, ilocate_y, w_fullscreen;
            iw_hight = 0;
            iw_width = 0;
            ilocate_x = 0;
            ilocate_y = 0;
            w_fullscreen = 1;

            int min_wsize, min_hsize;
            min_wsize = this.MinimumSize.Width;
            min_hsize = this.MinimumSize.Height;

            var fileIni = new FileIniDataParser();

            fileIni.Parser.Configuration.CommentString = "#";
            var iniData = fileIni.ReadFile(ResourcesPath.ini_file);

            try {
                int.TryParse(iniData["app_config"]["window_width"], out iw_width);
                int.TryParse(iniData["app_config"]["window_hight"], out iw_hight);
                int.TryParse(iniData["app_config"]["window_location_x"], out ilocate_x);
                int.TryParse(iniData["app_config"]["window_location_y"], out ilocate_y);
                int.TryParse(iniData["app_config"]["window_fullscreen"], out w_fullscreen);
            } catch (Exception ex) { Log.WriteL("Error : " + ex.Message); }

            if (iw_hight < min_hsize || iw_width < min_hsize) {
                this.WindowState = FormWindowState.Maximized;
                return;
            }

            if (w_fullscreen == 0) {
                this.WindowState = FormWindowState.Normal;
                this.Size = new System.Drawing.Size(iw_width, iw_hight);
                this.Location = new Point(ilocate_x, ilocate_y);
            } else
                this.WindowState = FormWindowState.Maximized;
            
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            setWindowToForm();// execute method seting up window from ini file
        }

        //when widow are closing, need set of the main window
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            setWindowToIniFile();
        }

        private string appName = "MySql Client .NET";

        private ImageList imageTree;
        
        private BackgroundWorker loadTreeExplorer;
        
        private DesignControls.DynamicTabNS.DynamicTabs dynamicTab;
        private DesignControls.DynamicTabNS.DynamicTabs dynamicTabResult;
        private DesignControls.SQLMessageNS.SQLMessage sqlMessage;
        
        private bool isBottomPanOpen;
        private bool isRightPanOpen;
        private bool isLeftPanOpen;

        private int limitPage;
        private int uniqueIdTextSql;

        private List<string> selRes;
        private List<string> showRes;

        private TreeNode prevTreeNode;
        private MySqlScript scriptSQL;
        private MySqlCommand cmmd;
        private WaitingConnection waitingForm;
        private bool efectToTree;
        

        private bool databseTableIsExist(string db, string tb) {
            bool result = false;

            string query = "";
            if (!tb.Equals(string.Empty))
                query =
@"SELECT 
    TABLE_SCHEMA,
    TABLE_NAME 
FROM 
    information_schema.TABLES 
WHERE 
    TABLE_SCHEMA='" + db + @"' 
AND 
    TABLE_NAME='" + tb + "'";
            else
                query =
@"SELECT 
    SCHEMA_NAME 
FROM 
    information_schema.SCHEMATA 
WHERE 
    SCHEMA_NAME='" + db + @"'";

            try {
                using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        result = dr.HasRows;
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error Checking Database/Table : " + ex.Message);
            }

            return result;
        }

        private void BeginOpen(object sender, DesignControls.StartingPage.TryOpenConnectionEventArgs e) {
            if (!e.IsError) {
                waitingForm = new WaitingConnection();
                waitingForm.Text = LanguageApp.langMainMenu["MSGWaitConn"];
                waitingForm.Show();
            } else
                waitingForm.Dispose();
        }

        //open connection and initialize user accunt
        public void OpenConnection(object sender, EventArgs e) {
            efectToTree = false;
            enableMenu(true);
            Dictionary<string, string> serverStat = new Dictionary<string, string>();
            string coll_server = "";
            try {
                using (cmmd = new MySqlCommand("SHOW VARIABLES;", AppConnection.Connection)) {
                    using (MySqlDataReader dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            if (dr[0].ToString().Equals("port") ||
                                dr[0].ToString().Equals("version_comment") ||
                                dr[0].ToString().Equals("basedir") ||
                                dr[0].ToString().Equals("version_compile_os") ||
                                dr[0].ToString().Equals("version")) {
                                serverStat.Add(dr[0].ToString(), dr[1].ToString());
                            } else if (dr[0].ToString().Equals("collation_server")) {
                                coll_server = dr[1].ToString();
                            } else if (dr[0].ToString().Equals("default_storage_engine")) {
                                MySqlConfig.DefaultStoreEngine = dr[1].ToString();
                            }
                        }
                    }
                }
                string query =
@"SELECT 
    CHARACTER_SET_NAME,
    COLLATION_NAME,
    IS_DEFAULT 
FROM
    information_schema.COLLATIONS 
WHERE 
    COLLATION_NAME='" + coll_server + "';";
                
                using (cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (MySqlDataReader dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            MySqlConfig.CharSetName = dr.GetString(0);
                            MySqlConfig.CollationName = dr.GetString(1);
                            MySqlConfig.CollDefault = dr.GetString(2).Equals("Yes");
                        }
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }

            textServerStatus.Text = "\n\n";
            textServerStatus.Text += "User :\n\t" + MySqlConfig.Username + "\n\n";
            textServerStatus.Text += "Host :\n\t" + MySqlConfig.Host + "\n\n";
            if (serverStat.ContainsKey("port"))
                textServerStatus.Text += "Port :\n\t" + serverStat["port"] + "\n\n";
            if (serverStat.ContainsKey("version_comment"))
                textServerStatus.Text += "DBMS :\n\t" + serverStat["version_comment"] + "\n\n";
            if (serverStat.ContainsKey("version"))
                textServerStatus.Text += LanguageApp.langMainMenu["DTXTVersion"] + " :\n\t" + serverStat["version"] + "\n\n";
            if (serverStat.ContainsKey("basedir"))
                textServerStatus.Text += LanguageApp.langMainMenu["DTXTBasedir"]  + " :\n\t" + serverStat["basedir"] + "\n\n";
            if (serverStat.ContainsKey("version_compile_os"))
                textServerStatus.Text += LanguageApp.langMainMenu["DTXTCompiled"] + " :\n\t" + serverStat["version_compile_os"] + "\n\n";

            this.Text = appName + " --" + MySqlConfig.Username + "@" + MySqlConfig.Host + "--";

            loadTreeExplorer = new BackgroundWorker();
            loadTreeExplorer.WorkerReportsProgress = true;
            loadTreeExplorer.DoWork += new DoWorkEventHandler(loadDatabaseTree);
            loadTreeExplorer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadTreeExplorer_RunWorkerCompleted);
            loadTreeExplorer.ProgressChanged += new ProgressChangedEventHandler(loadTreeExplorer_ProgressChanged);
            toolStripLabelLoadDB.Visible = true;
            treeExplorer.Enabled = false;
            waitingForm.Text = MSGWaitAllDatabase;
            loadTreeExplorer.RunWorkerAsync();
        }

        #region Initialize External Controls

        private void initializeDynamicTab() {
            dynamicTab = new DesignControls.DynamicTabNS.DynamicTabs();
            dynamicTab.Name = "dynamicTab";
            dynamicTab.ClosingTab +=  new EventHandler<DesignControls.DynamicTabNS.DynamicTabCloseTabEventArgs>(dynamicTab_Close);
            dynamicTab.SelectedTab += new EventHandler<DesignControls.DynamicTabNS.DyanamicTabSelectedTabEventArgs>(dynamicTab_SelectedTab);
            dynamicTab.Dock = DockStyle.Fill;
            this.Controls.Add(dynamicTab);
        }

        private void InitializeExternalComponent() {
            limitPage = 25;
            uniqueIdTextSql = 0;

            enableMenu(false);

            scriptSQLErr = false;
            selRes = new List<string>();
            showRes = new List<string>();

            treeExplorer.HideSelection = false;

            dynamicTabResult = new DesignControls.DynamicTabNS.DynamicTabs();
            dynamicTabResult.Name = "dynamicTabResult";
            dynamicTabResult.Dock = DockStyle.Fill;
            this.tabOut.TabPages[1].Controls.Add(dynamicTabResult);

            sqlMessage = new DesignControls.SQLMessageNS.SQLMessage();
            sqlMessage.Dock = DockStyle.Fill;
            this.tabOut.TabPages[0].Controls.Add(sqlMessage);

            isBottomPanOpen = 
                isRightPanOpen = 
                isLeftPanOpen = true;
            buttonSelectDB.Enabled = false;
            buttonSelectDB.Text = "Set Database As Default";
            buttonRefresh.Text = "Refresh";
            toolStripRight.Visible = toolStripLeft.Visible = toolStripBottom.Visible = false;
            closeAllPanel(true);
            ImageList imgList = new ImageList();
            imageTree = new ImageList();
            buttonCreate.Visible = false;
            buttonAlter.Visible = false;
            buttonDrop.Visible = false;
            try {
                buttonRefresh.Image = Image.FromFile(ResourcesPath.img_refresh_S);
                buttonSelectDB.Image = Image.FromFile(ResourcesPath.img_database_use_S);
                imgList.Images.Add(Image.FromFile(ResourcesPath.img_database_S));
                imgList.Images.Add(Image.FromFile(ResourcesPath.img_table_S));
                imgList.Images.Add(Image.FromFile(ResourcesPath.img_col_S));
                imageTree.Images.Add(Image.FromFile(ResourcesPath.img_database_create_S));
                imageTree.Images.Add(Image.FromFile(ResourcesPath.img_database_alter_S));
                imageTree.Images.Add(Image.FromFile(ResourcesPath.img_database_drop_S));
                imageTree.Images.Add(Image.FromFile(ResourcesPath.img_table_create_S));
                imageTree.Images.Add(Image.FromFile(ResourcesPath.img_table_alter_S));
                imageTree.Images.Add(Image.FromFile(ResourcesPath.img_table_drop_S));
                treeExplorer.ImageList = imgList;
            } catch (Exception e) { Msg.Err("Error : " + e.Message); }

            DesignControls.StartingPage.StartPage startPage = new DesignControls.StartingPage.StartPage();
            startPage.Size = new System.Drawing.Size(dynamicTab.panMain.Size.Width,
                                                    dynamicTab.panMain.Size.Height);

            startPage.frmNewConnection.SqlMessage += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            startPage.SqlMessage += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            startPage.OpenConnection += new EventHandler<EventArgs>(OpenConnection);
            startPage.BeginToOpen += new EventHandler<DesignControls.StartingPage.TryOpenConnectionEventArgs>(BeginOpen);
            startPage.CanClose = false;
            dynamicTab.AddTabPage(startPage);
        }

        //for connetion mode or disconnect mode
        private void enableMenu(bool itIs) {
            if (itIs) {
                subMainMenuSetting.Enabled = true;
                subMainMenuNewSql.Enabled = true;
                subMainMenuOpenSQLFile.Enabled = true;
                mainMenuCreate.Enabled = true;
                subMainMenuImportExportDB.Enabled = true;
                subMainMenuUserAccount.Enabled = true;
                subMainMenuOpenConsole.Enabled = true;
                mainMenuTools.Enabled = true;
                subMainMenuCloseConn.Enabled = true;
            } else {
                subMainMenuSetting.Enabled = false;
                subMainMenuNewSql.Enabled = false;
                subMainMenuOpenSQLFile.Enabled = false;
                mainMenuCreate.Enabled = false;
                subMainMenuImportExportDB.Enabled = false;
                subMainMenuUserAccount.Enabled = false;
                subMainMenuOpenConsole.Enabled = false;
                subMainMenuSaveSQL.Enabled = false;
                subMainMenuSaveAsSQL.Enabled = false;
                mainMenuTools.Enabled = false;
                subMainMenuCloseConn.Enabled = false;
            }
        }

        #endregion

        #region dynamicTab
        //event when tab are closed
        private void dynamicTab_Close(object sender, DesignControls.DynamicTabNS.DynamicTabCloseTabEventArgs e) {
            System.Diagnostics.Debug.WriteLine("Index : {0}\nUnique ID : {1}",
                                               e.IndexTab,
                                               e.UniqueId);
            if (e.TabPage == TabPageType.SqlEditor || e.TabPage == TabPageType.ConsoleSQL) {
                subMainMenuSaveSQL.Enabled = false;
                subMainMenuSaveAsSQL.Enabled = false;
                dynamicTabResult.CloseTabByForeginId(e.UniqueId);
            }
        }

        void dynamicTab_SelectedTab(object sender, DesignControls.DynamicTabNS.DyanamicTabSelectedTabEventArgs e) {
            if (e.TabPage == TabPageType.SqlEditor) {
                subMainMenuSaveSQL.Enabled = true;
                subMainMenuSaveAsSQL.Enabled = true;
            } else {
                subMainMenuSaveSQL.Enabled = false;
                subMainMenuSaveAsSQL.Enabled = false;
            }
        }

        #endregion

        #region Thread Load Database tree
        private void refreshTree() {
            try {
                treeExplorer.Nodes.Clear();
            } catch (Exception ex) { Msg.Err("Error : " + ex.Message); }
            if (loadTreeExplorer != null) {
                if (loadTreeExplorer.IsBusy)
                    return;
                loadTreeExplorer.Dispose();
            }

            loadTreeExplorer = new BackgroundWorker();
            loadTreeExplorer.WorkerReportsProgress = true;
            loadTreeExplorer.DoWork += new DoWorkEventHandler(loadDatabaseTree);
            loadTreeExplorer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadTreeExplorer_RunWorkerCompleted);
            loadTreeExplorer.ProgressChanged += new ProgressChangedEventHandler(loadTreeExplorer_ProgressChanged);
            toolStripLabelLoadDB.Visible = true;
            treeExplorer.Enabled = false;

            loadTreeExplorer.RunWorkerAsync();
            //MySqlConfig.Database = string.Empty;
            buttonSelectDB.Enabled = false;
            buttonDrop.Visible = false;
            buttonCreate.Visible = false; 
            buttonAlter.Visible = false;
        }

        private void loadDatabaseTree(object sender, DoWorkEventArgs ev) {
            TreeNode tree = new TreeNode();
            string query = string.Empty;

            try {
                query = "SELECT SCHEMA_NAME FROM information_schema.SCHEMATA;";
                TreeNode[] tmpTree = getDatabaseInfoToTreeNode(query, 0).ToArray();
                tree.Nodes.AddRange(tmpTree);
            } catch (MySqlException e) {
                throw new Exception(e.Message);
            }

            for (int i = 0; i < tree.Nodes.Count; ++i) {
                try {
                    query = "SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_SCHEMA='" + tree.Nodes[i].Text + "';";
                    TreeNode[] tmpTree = getDatabaseInfoToTreeNode(query, 1).ToArray();
                    tree.Nodes[i].Nodes.AddRange(tmpTree);
                    for (int j = 0; j < tree.Nodes[i].Nodes.Count; ++j) {
                        query = "SELECT COLUMN_NAME, COLUMN_TYPE FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='" + tree.Nodes[i].Text + "' AND TABLE_NAME='" + tree.Nodes[i].Nodes[j].Text + "';";
                        tmpTree = getDatabaseInfoToTreeNode(query, 2).ToArray();
                        tree.Nodes[i].Nodes[j].Nodes.AddRange(tmpTree);
                    }
                } catch (MySqlException e) {
                    throw new Exception(e.Message);
                }
            }

            for (int k = 0; k < tree.Nodes.Count; ++k) {
                loadTreeExplorer.ReportProgress(k, tree.Nodes[k]);
            }
        }

        void loadTreeExplorer_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            treeExplorer.Nodes.Add((TreeNode)e.UserState);
        }

        void loadTreeExplorer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            waitingForm.Dispose();
            if (e.Error != null)
                ErrorMessage(MSGErrLoadDbTree, e.Error.Message);
            else {
                toolStripLeftShow_Click(null, null);
                selectDB(MySqlConfig.DatabaseSelected);
            }
            toolStripLabelLoadDB.Visible = false;
            treeExplorer.Enabled = true;
        }

        private List<TreeNode> getDatabaseInfoToTreeNode(string query, int imgList) {
            List<TreeNode> lsResult = new List<TreeNode>();
            using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                using (var dr = cmmd.ExecuteReader()) {
                    while (dr.Read()) {
                        string tmpStr = "";
                        switch (imgList) {
                            case 0 : // jika database
                                if (!MySqlConfig.DBFromSystem(dr[0].ToString()))
                                    tmpStr = dr[0].ToString();
                                break;
                            case 1 : // jika table
                                tmpStr = dr[0].ToString();
                                break;
                            case 2 : // jika kolom
                                tmpStr = dr[0].ToString() + " " + dr[1].ToString();
                                break;
                        }
                        if (!string.IsNullOrEmpty(tmpStr))
                            lsResult.Add(new TreeNode(tmpStr, imgList, imgList));
                    }
                }
            }
            return lsResult;
        }

        private void selectDB(string db) {
            if (!db.Equals(string.Empty)) {
                bool isExist = false;
                for (int i = 0; i < treeExplorer.Nodes.Count; ++i) {
                    if (treeExplorer.Nodes[i].Text.Equals(db)) {
                        treeExplorer.SelectedNode = treeExplorer.Nodes[i];
                        selectTreeDB(treeExplorer.Nodes[i]);
                        isExist = true;
                        break;
                    }
                }
                if (!isExist) {
                    if (prevTreeNode != null) {
                        prevTreeNode.NodeFont = treeExplorer.Font;
                        prevTreeNode.Text = prevTreeNode.Text;
                    }
                }
            } else {
                if (prevTreeNode != null) {
                    prevTreeNode.NodeFont = treeExplorer.Font;
                    prevTreeNode.Text = prevTreeNode.Text;
                }
            }

        }

        private void refresDBTreeFromTabPage(object sender, DesignControls.RefreshDBTreeEventArgs e) {
            if (!string.IsNullOrEmpty(e.DatabaseName)) {
                insertNode(treeExplorer.Nodes, new TreeNode(e.DatabaseName, 0, 0));
                return;
            }
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(refresDBTreeFromTabPage_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(refresDBTreeFromTabPage_RunWorkerCompleted);
            bg.RunWorkerAsync(e);
        }

        void refresDBTreeFromTabPage_DoWork(object sender, DoWorkEventArgs e) {
            DesignControls.RefreshDBTreeEventArgs r = (DesignControls.RefreshDBTreeEventArgs)e.Argument;

            Exception excep = null;

            List<object> listArgs = new List<object>(); //argumen untuk result bg worker
            listArgs.Add(false); //konfirmasi untuk jika node database tidak di temukan di database tree
            listArgs.Add(r); // masukan event args refres tabel

            for (int i = 0; i < treeExplorer.Nodes.Count; ++i) {
                if (treeExplorer.Nodes[i].Text.Equals(r.TableDatabaseName)) {
                    listArgs[0] = true; //database ditemukan
                    TreeNode node = treeExplorer.Nodes[i]; //node database


                    if (string.IsNullOrEmpty(r.TableNameOld)) {
                        //node tabel baru
                        string query =
@"SELECT 
    COLUMN_NAME,
    COLUMN_TYPE 
FROM 
    information_schema.COLUMNS 
WHERE 
    TABLE_SCHEMA='" + r.TableDatabaseName + @"' 
AND ";
                        listArgs.Add(true); //flag for new table (create)
                        listArgs.Add(node); //add database node

                        //for new table node
                        object cNode = null;

                        try {
                            //find information column table from information_schema
                            if (r.TableNameNew.GetType() == typeof(string)) {
                                query += "TABLE_NAME='" + (string)r.TableNameNew + "';";
                                TreeNode[] tmpTree = getDatabaseInfoToTreeNode(query, 2).ToArray();
                                TreeNode tmpTabelTree = new TreeNode((string)r.TableNameNew, 1, 1); // buat tabel baru
                                tmpTabelTree.Nodes.AddRange(tmpTree); //add column node to table node
                                cNode = tmpTabelTree; // inset to arg result
                            } else if (r.TableNameNew.GetType() == typeof(List<string>)) {
                                List<string> tmp = (List<string>)r.TableNameNew; // got tabel name from list arument
                                List<TreeNode> tmp_cNode = new List<TreeNode>(); //colect

                                for (int j = 0; j < tmp.Count; ++j) {
                                    string tmQuery = query + "TABLE_NAME='" + tmp[j] + "';";
                                    TreeNode[] tmpColTree = getDatabaseInfoToTreeNode(tmQuery, 2).ToArray();

                                    TreeNode tmpTableTree = new TreeNode(tmp[j], 1, 1); // creat new table
                                    tmpTableTree.Nodes.AddRange(tmpColTree); // add column node to table node

                                    tmp_cNode.Add(tmpTableTree);
                                }
                                cNode = tmp_cNode.ToArray();
                            }
                        } catch (Exception ex) {
                            excep = ex;
                        }

                        //add table node to parameter
                        listArgs.Add(cNode);
                    } else {
                        //exsited table node
                        string query =
@"SELECT 
    COLUMN_NAME,
    COLUMN_TYPE 
FROM 
    information_schema.COLUMNS 
WHERE 
    TABLE_SCHEMA='" + r.TableDatabaseName + @"' 
AND 
    TABLE_NAME='" + r.TableNameNew + "';";

                        listArgs.Add(false); //flag for table exist (alter)
                        TreeNode cNode = null; //for pervius tabel node

                        //untuk node kolom
                        List<TreeNode> cNode1 = new List<TreeNode>();

                        for (int j = 0; j < node.Nodes.Count; ++j) {
                            if (node.Nodes[j].Text.Equals(r.TableNameOld)) {
                                cNode = node.Nodes[j];
                                try {
                                    TreeNode[] tmpTree = getDatabaseInfoToTreeNode(query, 2).ToArray();
                                    cNode1.AddRange(tmpTree);
                                } catch (Exception ex) {
                                    excep = ex;
                                }
                                break;
                            }
                        }
                        listArgs.Add(node); //database node
                        listArgs.Add(cNode); //add old table node to argument
                        listArgs.Add(cNode1.ToArray()); //add old columnt node to argument
                    }
                    break;
                }
            }
            if (excep != null)
                throw excep;
            e.Result = listArgs.ToArray();
        }

        void refresDBTreeFromTabPage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                Log.WriteL("Error Refresh Tree : " + e.Error.Message);
                return;
            }

            object[] args = (object[])e.Result;
            bool dbIsExist = (bool)args[0];
            DesignControls.RefreshDBTreeEventArgs r = (DesignControls.RefreshDBTreeEventArgs)args[1];

            if (!dbIsExist) {

                return;
            }

            bool newTable = (bool)args[2];
            if (newTable) {
                try {
                    //New table
                    TreeNode dbNode = (TreeNode)args[3];
                    if (args[4].GetType() == typeof(TreeNode)) {
                        TreeNode tbNode = (TreeNode)args[4];
                        insertNode(dbNode.Nodes, tbNode);
                    } else if (args[4].GetType() == typeof(TreeNode[])) {
                        TreeNode[] tbNode = (TreeNode[])args[4];
                        insertNode(dbNode.Nodes, tbNode);
                    }
                } catch (Exception ex) {
                    Log.WriteL("Error :  " + ex.Message);
                }
            } else {
                //existed table
                try {
                    TreeNode dbNode = (TreeNode)args[3];
                    TreeNode tbNode = (TreeNode)args[4];
                    TreeNode[] colNode = (TreeNode[])args[5];
                    TreeNode newNodeTabel = new TreeNode((string)r.TableNameNew, 1, 1);
                    newNodeTabel.Nodes.AddRange(colNode);
                    dbNode.Nodes.Remove(tbNode); //delete old tbale node 
                    insertNode(dbNode.Nodes, newNodeTabel); //insert new table node
                } catch (Exception ex) {
                    Log.WriteL("Error : " + ex.Message);
                }
            }
        }

        private void insertNode(TreeNodeCollection nodes, TreeNode newNode) {
            for (int i = 0; i < nodes.Count; ++i) {
                if (string.Compare(newNode.Text, nodes[i].Text) < 0) {
                    nodes.Insert(i, newNode);
                    return;
                }
            }
            nodes.Add(newNode);
        }

        private void insertNode(TreeNodeCollection nodes, TreeNode[] newNodes) {
            for (int i = 0; i < newNodes.Length; ++i)
                insertNode(nodes, newNodes[i]);
        }

        #endregion

        #region toolStrip

        private void mainMenuDBExplorer_Click(object sender, EventArgs e) {
            if (subMainMenuDBExplorer.Checked)
                toolStripPanLeftClose_Click(null, null);
            else
                toolStripLeftShow_Click(null, null);
        }

        private void mainMenuStatusServer_Click(object sender, EventArgs e) {
            if (subMainMenuIdentityServer.Checked)
                toolStripPanRightClose_Click(null, null);
            else
                toolStripRightShow_Click(null, null);
        }

        private void mainMenuOutput_Click(object sender, EventArgs e) {
            if (subMainMenuOutput.Checked)
                toolStripPanBottomClose_Click(null, null);
            else
                toolStripBottomShow_Click(null, null);
        }

        private void mainMenuHideAllPan_Click(object sender, EventArgs e) {
            closeAllPanel(true);
        }

        private void closeAllPanel(bool closeIt) {
            if (closeIt) { 
                toolStripPanLeftClose_Click(null, null);
                toolStripPanRightClose_Click(null, null);
                toolStripPanBottomClose_Click(null, null);
                return;
            }
            toolStripLeftShow_Click(null, null);
            toolStripRightShow_Click(null, null);
            toolStripBottomShow_Click(null, null);
        }

        //Left
        private void toolStripPanLeftClose_Click(object sender, EventArgs e) {
            if (!isLeftPanOpen)
                return;
            subMainMenuDBExplorer.Checked = false;
            spLeft.Visible = panLeft.Visible = false;
            toolStripLeft.Visible = true;
            isLeftPanOpen = false;
        }

        private void toolStripLeftShow_Click(object sender, EventArgs e) {
            if (isLeftPanOpen)
                return;
            subMainMenuDBExplorer.Checked = true;
            toolStripLeft.Visible = false;
            panLeft.Visible = spLeft.Visible = true;
            isLeftPanOpen = true;
        }

        //Right
        private void toolStripPanRightClose_Click(object sender, EventArgs e) {
            if (!isRightPanOpen)
                return;
            subMainMenuIdentityServer.Checked = false;
            spRight.Visible = panRight.Visible = false;
            toolStripRight.Visible = true;
            isRightPanOpen = false;
        }

        private void toolStripRightShow_Click(object sender, EventArgs e) {
            if (isRightPanOpen)
                return;
            subMainMenuIdentityServer.Checked = true;
            toolStripRight.Visible = false;
            panRight.Visible = spRight.Visible = true;
            isRightPanOpen = true;
        }

        //Bottom
        private void toolStripPanBottomClose_Click(object sender, EventArgs e) {
            if (!isBottomPanOpen)
                return;
            subMainMenuOutput.Checked = false;
            spBottom.Visible = panBottom.Visible = false;
            toolStripBottom.Visible = true;
            isBottomPanOpen = false;
        }

        private void toolStripBottomShow_Click(object sender, EventArgs e) {
            if (isBottomPanOpen)
                return;
            subMainMenuOutput.Checked = true;
            toolStripBottom.Visible = false;
            panBottom.Visible = spBottom.Visible = true;
            isBottomPanOpen = true;
        }

        #endregion

        #region execute sql script

        public void sqlFile_ExcuteSQL(object sender, DesignControls.SqlEditorNS.SqlEditorExecuteEventArgs e) {
            uniqueIdTextSql = e.UniqueId;
            limitPage = e.LimitPage;
            scriptSQL = new MySqlScript(AppConnection.Connection, e.SqlScript);
            scriptSQL.StatementExecuted += new MySqlStatementExecutedEventHandler(scriptSQL_StatementExecuted);
            scriptSQL.Error += new MySqlScriptErrorEventHandler(scriptSQL_Error);
            scriptSQL.ScriptCompleted += new EventHandler(scriptSQL_ScriptCompleted);
            scriptSQL.ExecuteAsync();
        }

        void scriptSQL_StatementExecuted(object sender, MySqlScriptEventArgs args) {
            if (args.StatementText.StartsWith("SELECT", true, System.Globalization.CultureInfo.CurrentCulture)) {
                MySqlUtil.CheckingSQLSyntax checkFrom = new CheckingSQLSyntax();
                if (checkFrom.isContainFrom(args.StatementText))
                    selRes.Add(args.StatementText);
                else
                    showRes.Add(args.StatementText);
            }

            if (args.StatementText.StartsWith("SHOW", true, System.Globalization.CultureInfo.CurrentCulture) ||
                args.StatementText.StartsWith("DESCRIBE", true, System.Globalization.CultureInfo.CurrentCulture) ||
                args.StatementText.StartsWith("DESC", true, System.Globalization.CultureInfo.CurrentCulture)) {
                showRes.Add(args.StatementText);
            }

            if (args.StatementText.StartsWith("USE", true, System.Globalization.CultureInfo.CurrentCulture)) {
                string tmp = args.StatementText.Remove(0, 4);
                tmp = tmp.Trim();
                selectDB(tmp);
            }

            if (args.StatementText.StartsWith("CREATE", true, System.Globalization.CultureInfo.CurrentCulture) ||
                args.StatementText.StartsWith("ALTER", true, System.Globalization.CultureInfo.CurrentCulture) ||
                args.StatementText.StartsWith("DROP", true, System.Globalization.CultureInfo.CurrentCulture))
                efectToTree = true;


            sqlMessage.SetMesssageAction(MSGStetmentExec);
            sqlMessage.SetMessageSqlStetment(args.StatementText);
            sqlMessage.SetMessage("\n");
        }

        void scriptSQL_Error(object sender, MySqlScriptErrorEventArgs args) {
            sqlMessage.SetMesssageAction(MSGErrStetmentAbort);
            sqlMessage.SetMessageError(args.Exception.Message);
            sqlMessage.SetMessage("\n");
            scriptSQLErr = true;
            if (efectToTree) 
                refreshTree();
            efectToTree = false;
        }

        private bool scriptSQLErr;

        void scriptSQL_ScriptCompleted(object sender, EventArgs e) {
            if (efectToTree)
                refreshTree();
            efectToTree = false;
            if (!scriptSQLErr) {
                dynamicTabResult.CloseTabByForeginId(uniqueIdTextSql);
                for (int i = 0; i < selRes.Count; ++i) {
                    DesignControls.ResultGridNS.ResultGrid gridRes = new DesignControls.ResultGridNS.ResultGrid(OutGrid.ExecutedFromSQLTextEdit);
                    MySqlUtil.CheckingSQLSyntax checkLimit = new CheckingSQLSyntax();
                    string resSql = "";
                    if (checkLimit.isContainLimit(selRes[i])) {
                        gridRes.SqlLimitPosUser = checkLimit.StartLimit.ToString();
                        gridRes.SqlLimit = checkLimit.LengtLimit;
                        resSql = checkLimit.Sql;
                    } else {
                        gridRes.SqlLimit = limitPage;
                        resSql = selRes[i];
                    }
                    gridRes.TabHeaderText = selRes[i];
                    gridRes.Dock = DockStyle.Fill;
                    gridRes.ForeginId = uniqueIdTextSql;
                    dynamicTabResult.AddTabPage(gridRes);
                    gridRes.DataSource(resSql);
                    gridRes.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
                }
                for (int i = 0; i < showRes.Count; ++i) {
                    DesignControls.ResultGridNS.ResultGrid gridRes = new DesignControls.ResultGridNS.ResultGrid(OutGrid.ExecutedFromSQLTextEdit);
                    gridRes.EnableSqlLimit = false;
                    gridRes.TabHeaderText = showRes[i];
                    gridRes.Dock = DockStyle.Fill;
                    gridRes.ForeginId = uniqueIdTextSql;
                    dynamicTabResult.AddTabPage(gridRes);
                    gridRes.DataSource(showRes[i]);
                    gridRes.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
                }
                if ((showRes.Count + selRes.Count) > 0)
                    showResult();
                else
                    showMessage();
                selRes.Clear();
                showRes.Clear();
                return;
            } else scriptSQLErr = false;
            showMessage();
        }

        private void showResult() {
            tabOut.SelectedIndex = 1;
            toolStripBottomShow_Click(null, null);
        }

        private void showMessage() {
            tabOut.SelectedIndex = 0;
            toolStripBottomShow_Click(null, null);
        }

        private void messageFromOtherObject(object sender, DesignControls.ExecuteMessageEventArgs e) {
            if (e.ClearMessage)
                sqlMessage.ClearMessage();
            sqlMessage.setText(e.Action + e.Stetment + e.Error + "\n");
            if(!e.Error.Equals(string.Empty)) Console.Beep();
            showMessage();
        }

        #endregion
        
        #region Tree Explorer

        private void buttonSelectDB_Click(object sender, EventArgs e) {
            if (treeExplorer.SelectedNode == null) {
                Msg.Warrn("Selct item tree first");
                return;
            }
            selectTreeDB(treeExplorer.SelectedNode);
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            refreshTree();
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            //treeExplorer.Select();
            if (treeExplorer.SelectedNode == null)
                return;
            if (treeExplorer.SelectedNode.Level == 0) {
                mainMenuCreateDB_Click(null, null);
            } else if (treeExplorer.SelectedNode.Level > 0) {
                buttonContexCreateTB_Click(null, null);
            }
        }

        private void buttonAlter_Click(object sender, EventArgs e) {
            treeExplorer.Select();
            if (treeExplorer.SelectedNode == null)
                return;
            if (treeExplorer.SelectedNode.Level == 0) {
                buttonContexAlterDB_Click(null, null);
            } else if (treeExplorer.SelectedNode.Level > 0) {
                buttonContexAlterTB_Click(null, null);
            }
        }

        private void buttonDrop_Click(object sender, EventArgs e) {
            treeExplorer.Select();
            if (treeExplorer.SelectedNode == null)
                return;
            if (treeExplorer.SelectedNode.Level == 0) {
                buttonContexDropDB_Click(null, null);
            } else if (treeExplorer.SelectedNode.Level > 0) {
                buttonContexDropTB_Click(null, null);
            }
        }

        private void selectTreeDB(TreeNode tNode) {
            try {
                AppConnection.Connection.ChangeDatabase(tNode.Text);
            } catch (MySqlException ex) {
                ExecuteMessageEventArgs arg = new ExecuteMessageEventArgs();
                arg.Action = MessageKeyword.BuildSqlActionMessage(string.Format("Set Database {0} As Default Failed", tNode.Text));
                arg.Error = MessageKeyword.BuildErrorMessage(ex.Message);
                messageFromOtherObject(this, arg);
                return;
            }
            System.Diagnostics.Debug.WriteLine("Selected db : " + AppConnection.Connection.Database);
            MySqlConfig.Database = tNode.Text;
            if (prevTreeNode != null) {
                prevTreeNode.NodeFont = treeExplorer.Font;
                prevTreeNode.Text = prevTreeNode.Text;
            }
            tNode.NodeFont = new Font(treeExplorer.Font, FontStyle.Bold);
            tNode.Text = tNode.Text;
            treeExplorer.SelectedNode = tNode;
            prevTreeNode = tNode;
        }

        private void treeExplorer_AfterSelect(object sender, TreeViewEventArgs e) {
            if (!buttonCreate.Visible) {
                buttonCreate.Visible = true;
                buttonAlter.Visible = true;
                buttonDrop.Visible = true;
            }
            if (e.Node.Level > 0) {
                buttonSelectDB.Enabled = false;
                buttonCreate.Image = imageTree.Images[3];
                buttonAlter.Image = imageTree.Images[4];
                buttonDrop.Image = imageTree.Images[5];
                buttonCreate.Text = LanguageApp.langMainMenu["CSMSCraeteTable"].Replace("&", "");
                buttonAlter.Text = LanguageApp.langMainMenu["CSMSAlterTB"].Replace("&", "");
                buttonDrop.Text = LanguageApp.langMainMenu["CSMSDropTB"].Replace("&", "");
            } else {
                buttonSelectDB.Enabled = true;
                buttonCreate.Image = imageTree.Images[0];
                buttonAlter.Image = imageTree.Images[1];
                buttonDrop.Image = imageTree.Images[2];
                buttonCreate.Text = LanguageApp.langMainMenu["SMMCreateDatabase"].Replace("&", "");
                buttonAlter.Text = LanguageApp.langMainMenu["CSMSAlterDB"].Replace("&", "");
                buttonDrop.Text = LanguageApp.langMainMenu["CSMSDropDB"].Replace("&", "");
            }
        }

        private void treeExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                treeExplorer.SelectedNode = e.Node;
                if (e.Node.Level > 0) {
                    buttonContextDatabases.Enabled = false;
                    buttonContextUseDB.Enabled = false;
                    buttonContextTables.Enabled = true;
                } else {
                    buttonContextDatabases.Enabled = true;
                    buttonContextUseDB.Enabled = true;
                    buttonContextTables.Enabled = false;
                }
                databaseExplorerContextMenu.Show(treeExplorer, e.Location);
            }
        }

        private bool checkingDBInTab(string db) {
            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.TableBuilder) {
                    TableBuilder tbb = (TableBuilder)dynamicTab.DynamicTabPage[i];
                    if (tbb.DataBase.Equals(db))
                        return true;
                }
            }
            return false;
        }

        private bool checkingTBInTab(string tb) {
            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.TableBuilder) {
                    TableBuilder tbb = (TableBuilder)dynamicTab.DynamicTabPage[i];
                    if (string.IsNullOrEmpty(tbb.Table))
                        continue;
                    if (tbb.Table.Equals(tb))
                        return true;
                }
            }
            return false;
        }

        #endregion

        #region TreeExplorer Contex Menu

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
            refreshTree();
        }

        private void buttonContexUseDB_Click(object sender, EventArgs e) {
            selectTreeDB(treeExplorer.SelectedNode);
        }

        private void buttonContexAlterDB_Click(object sender, EventArgs e) {
            //chacking exiting db on tab
            if (treeExplorer.SelectedNode == null)
                Msg.Warrn("treeExplorer.SelectedNode is null");
            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.DatabaseBuilder) {
                    DatabaseBuilder dbb = (DatabaseBuilder)dynamicTab.DynamicTabPage[i];
                    if (!dbb.IsCreate) {
                        if (treeExplorer.SelectedNode.Text.Equals(dbb.DataBaseName)) {
                            dynamicTab.DynamicTabSelectedIndex = i;
                            return;
                        }
                    }
                }
            }
            int uId = dynamicTab.GetUniqueId(); ;
            DesignControls.DatabaseBuilder dbBuilder = new DatabaseBuilder();
            System.Diagnostics.Debug.WriteLine(treeExplorer.SelectedNode.Text);


            if (!databseTableIsExist(treeExplorer.SelectedNode.Text, string.Empty)) {
                Msg.Err(MSGDBNotFound);
                refreshTree();
                return;
            }
            dbBuilder.UniqueId = uId;
            dbBuilder.IsCreate = false;
            dbBuilder.TabHeaderText = "(D) " + treeExplorer.SelectedNode.Text;
            dbBuilder.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            dbBuilder.AlterDB(treeExplorer.SelectedNode.Text);
            dynamicTab.AddTabPage(dbBuilder);
        }

        private void buttonContexDropDB_Click(object sender, EventArgs e) {
            if (treeExplorer.SelectedNode == null)
                return;
            if (checkingDBInTab(treeExplorer.SelectedNode.Text)) {
                Msg.Info(MSGDBCannotDrop);
                return;
            }
            int idxCloseTab = -1;
            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.DatabaseBuilder) {
                    DatabaseBuilder dbb = (DatabaseBuilder)dynamicTab.DynamicTabPage[i];
                    if (dbb.IsCreate) continue;
                    if (treeExplorer.SelectedNode.Text.Equals(dbb.DataBaseName)) {
                        if (Msg.WarrnQ(MSGDBExistOnTab) == System.Windows.Forms.DialogResult.No)
                            return;
                        idxCloseTab = i;
                        break;
                    }
                }
            }

            if (!databseTableIsExist(treeExplorer.SelectedNode.Text, string.Empty)) {
                Msg.Err("Database not Found !");
                refreshTree();
                return;
            }
            
            SQLPerview sqlPerview = new SQLPerview();
            sqlPerview.setSQLtext("DROP DATABASE `" + treeExplorer.SelectedNode.Text + "`;");
            sqlPerview.MSGAction1 = MSGActionDropDB;
            sqlPerview.ShowDialog();
            if (sqlPerview.isSuccessExecuted) {
                try {
                    if (idxCloseTab >= 0)
                        dynamicTab.DynamicTabPage[idxCloseTab].ForceCloseTabPage();
                    bool isSelected = false;
                    if (prevTreeNode != null) {
                        if (prevTreeNode.Equals(treeExplorer.SelectedNode))
                            isSelected = true;
                    }
                    treeExplorer.Nodes.Remove(treeExplorer.SelectedNode);
                    if (isSelected) {
                        for (int i = 0; i < treeExplorer.Nodes.Count;) {
                            selectDB(treeExplorer.Nodes[i].Text);
                            break;
                        }
                    }
                } catch (Exception ex) { Msg.Err("Error deleting Node : " + ex.Message); }
            }
        }

        private void buttonContexCreateTB_Click(object sender, EventArgs e) {
            if (!databseTableIsExist(treeExplorer.SelectedNode.Text, string.Empty)) {
                Msg.Err(MSGDBNotFound);
                refreshTree();
                return;
            }

            if (treeExplorer.SelectedNode == null) {
                return;
            }

            TableBuilder tbBuilder = new TableBuilder(TableBuilderMode.CreateTable);
            tbBuilder.DataBase = treeExplorer.SelectedNode.Text;
            tbBuilder.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            tbBuilder.IsEdited = true;
            tbBuilder.RefreshTable += new EventHandler<RefreshDBTreeEventArgs>(refresDBTreeFromTabPage);
            dynamicTab.AddTabPage(tbBuilder);
        }

        private void buttonContexAlterTB_Click(object sender, EventArgs e) {
            TreeNode tb, db;
            if (treeExplorer.SelectedNode.Parent == null)
                return;
            if (treeExplorer.SelectedNode.Level == 2) {
                if (treeExplorer.SelectedNode.Parent.Parent == null)
                    return;
                System.Diagnostics.Debug.WriteLine("ALTER : " + treeExplorer.SelectedNode.Parent.Parent.Text + "." + treeExplorer.SelectedNode.Parent.Text);
                tb = treeExplorer.SelectedNode.Parent;
                db = treeExplorer.SelectedNode.Parent.Parent;
            } else {
                System.Diagnostics.Debug.WriteLine("ALTER : " + treeExplorer.SelectedNode.Parent.Text + "." + treeExplorer.SelectedNode.Text);
                tb = treeExplorer.SelectedNode;
                db = treeExplorer.SelectedNode.Parent;
            }

            if (!databseTableIsExist(db.Text , tb.Text)) {
                Msg.Err(MSGTBNotFound);
                refreshTree();
                return;
            }

            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.TableBuilder) {
                    TableBuilder tbb_tmp = (TableBuilder)dynamicTab.DynamicTabPage[i];
                    if (tbb_tmp.Mode == TableBuilderMode.CreateTable)
                        continue;
                    if (db.Text.Equals(tbb_tmp.DataBase) && tb.Text.Equals(tbb_tmp.Table)) {
                        dynamicTab.DynamicTabSelectedIndex = i;
                        return;
                    }
                }
            }
            TableBuilder tbb = new TableBuilder(TableBuilderMode.AlterTable);
            tbb.RefreshTable += new EventHandler<RefreshDBTreeEventArgs>(refresDBTreeFromTabPage);
            tbb.DataSource(db.Text, tb.Text);
            tbb.TabHeaderText = "(T) " + tb.Text;
            tbb.Mode = TableBuilderMode.AlterTable;
            dynamicTab.AddTabPage(tbb);
        }

        private void buttonContexDropTB_Click(object sender, EventArgs e) {
            string tb, db;
            if (treeExplorer.SelectedNode.Parent == null) {
                return;
            }
            TreeNode node = null;
            if (treeExplorer.SelectedNode.Level == 2) {
                if (treeExplorer.SelectedNode.Parent.Parent == null)
                    return;
                db = treeExplorer.SelectedNode.Parent.Parent.Text;
                tb = treeExplorer.SelectedNode.Parent.Text;
                node = treeExplorer.SelectedNode.Parent;
            } else {
                db = treeExplorer.SelectedNode.Parent.Text;
                tb = treeExplorer.SelectedNode.Text;
                node = treeExplorer.SelectedNode;
            }

            if (!databseTableIsExist(db, tb)) {
                Msg.Err(MSGTBNotFound);
                refreshTree();
                return;
            }

            int idxCloseTabe = -1;
            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.TableBuilder) {
                    TableBuilder tbb = (TableBuilder)dynamicTab.DynamicTabPage[i];
                    if (tbb.Mode == TableBuilderMode.CreateTable) continue;
                    if (tb.Equals(tbb.Table)) {
                        if (Msg.WarrnQ(MSGTBExistOnTab) == System.Windows.Forms.DialogResult.No)
                            return;
                        idxCloseTabe = i;
                        break;
                    }
                }
            }

            SQLPerview sqlPerview = new SQLPerview();
            sqlPerview.setSQLtext("DROP TABLE `" + db + "`.`" + tb + "`;");
            sqlPerview.MSGAction1 = "Drop Table";
            sqlPerview.ShowDialog();
            if (sqlPerview.isSuccessExecuted) {
                try {
                    if (idxCloseTabe >= 0)
                        dynamicTab.DynamicTabPage[idxCloseTabe].ForceCloseTabPage();
                    treeExplorer.Nodes.Remove(node);
                } catch (Exception ex) { Msg.Err("Error deleting Node : " + ex.Message); }
            }
        }

        private void buttonContexEditData_Click(object sender, EventArgs e) {
            if (treeExplorer.SelectedNode.Parent == null)
                return;
            string db;
            string tb;
            db = tb = "";
            if (treeExplorer.SelectedNode.Level == 2) {
                if (treeExplorer.SelectedNode.Parent.Parent == null)
                    return;
                db = treeExplorer.SelectedNode.Parent.Parent.Text;
                tb = treeExplorer.SelectedNode.Parent.Text;
            } else {
                db = treeExplorer.SelectedNode.Parent.Text;
                tb = treeExplorer.SelectedNode.Text;
            }

            if (!databseTableIsExist(db, tb)) {
                Msg.Err("Table not Found !");
                refreshTree();
                return;
            }

            DesignControls.ResultGridNS.ResultGrid gridResult;
            List<int> indexPrimary;
            List<string> colList = new List<string>();
            string sql = "SELECT * FROM `" + tb + "`";
            string limit = MySqlConfig.GetLimit();
            
            FormSelectCol f = new FormSelectCol();
            if ((indexPrimary = getIndexColPrimary(tb, db, colList)).Count == 0) {
                DialogResult dResult = Msg.WarrnQ(MSGNoPrimary);
                if (dResult == System.Windows.Forms.DialogResult.Yes) {
                    gridResult = new DesignControls.ResultGridNS.ResultGrid(OutGrid.ExecutedFromSQLBuilderInsertOnly);
                    gridResult.IndexPrimaryKey = new List<int>();
                    gridResult.IsFromSqlBuilder = true;
                    int tmp = 50;
                    int.TryParse(limit, out tmp);
                    gridResult.SqlLimit = tmp;
                    f.DatabaseAndTableName = db + "`.`" + tb;
                    f.ColList = colList;
                    f.indexPrimary = new List<int>();
                    f.ShowDialog();
                    if (!f.IsOk) {
                        f.Dispose();
                        return;
                    }
                    sql = f.GetSQl;
                } else
                    return;
            } else {
                f.DatabaseAndTableName = db + "`.`" + tb;
                f.ColList = colList;
                f.indexPrimary = indexPrimary;
                f.ShowDialog();
                if (!f.IsOk) {
                    f.Dispose();
                    return;
                }
                sql = f.GetSQl;
                indexPrimary = f.indexPrimary;
                gridResult = new DesignControls.ResultGridNS.ResultGrid(OutGrid.ExecutedFromSQLBuilder);
                gridResult.IndexPrimaryKey = indexPrimary;
                gridResult.EnableSqlLimit = true;
                int tmp = 50;
                int.TryParse(limit,out tmp);
                gridResult.SqlLimit = tmp;
            }
            f.Dispose();
            gridResult.DatabaseAndTableName = db + "`.`" + tb;
            gridResult.Dock = DockStyle.Fill;
            gridResult.TabHeaderText = tb;
            dynamicTab.AddTabPage(gridResult);
            gridResult.DataSource(sql);
            gridResult.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
        }

        #endregion

        private List<int> getIndexColPrimary(string tb, string db, List<string> colName) {
            List<int> res = new List<int>();
            try {
                string sql =
@"SELECT
    COLUMN_KEY,
    COLUMN_NAME 
FROM 
    information_schema.COLUMNS 
WHERE 
    TABLE_SCHEMA='" + db + @"' 
AND 
    TABLE_NAME='" + tb + "';";
                using (cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                    using (MySqlDataReader dr = cmmd.ExecuteReader()) {
                        int cnt = 0;
                        while (dr.Read()) {
                            if (dr[0].ToString().Equals("PRI"))
                                res.Add(cnt);
                            colName.Add(dr[1].ToString());
                            ++cnt;
                        }
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            return res;
        }

        #region main menu

        private void menuItemNewSql_Click(object sender, EventArgs e) {
            DesignControls.SqlEditorNS.SqlEditor sqlFile = new DesignControls.SqlEditorNS.SqlEditor();
            sqlFile.Dock = DockStyle.Fill;
            sqlFile.EncodingFile = Encoding.Unicode;
            dynamicTab.AddTabPage(sqlFile);
            sqlFile.ExcuteSQL += new EventHandler<DesignControls.SqlEditorNS.SqlEditorExecuteEventArgs>(sqlFile_ExcuteSQL);
        }
        private void menuItemOpenSql_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = FileIO.FileInfo.GetSQLFileExtension;
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                DesignControls.SqlEditorNS.SqlEditor sqlFile;
                for (int i = 0; i < openFile.FileNames.Length; ++i) {
                    int idx = -1;
                    if ((idx = dynamicTab.isFileLoaded(openFile.FileNames[i])) != -1) {
                        dynamicTab.DynamicTabSelectedIndex = idx;
                        continue;
                    }
                    sqlFile = new DesignControls.SqlEditorNS.SqlEditor();
                    sqlFile.TabHeaderText = System.IO.Path.GetFileName(openFile.FileNames[i]);
                    sqlFile.Dock = DockStyle.Fill;
                    dynamicTab.AddTabPage(sqlFile);
                    sqlFile.ExcuteSQL += new EventHandler<DesignControls.SqlEditorNS.SqlEditorExecuteEventArgs>(sqlFile_ExcuteSQL);
                    sqlFile.FilePath = openFile.FileNames[i];
                }
            }
        }

        private void menuItemSaveSql_Click(object sender, EventArgs e) {
            int idx = dynamicTab.DynamicTabSelectedIndex;
            if (idx < 0)
                return;
            if (idx >= dynamicTab.DynamicTabCount)
                return;
            if (dynamicTab.DynamicTabPage[idx].PageType == TabPageType.SqlEditor) {
                dynamicTab.DynamicTabPage[idx].OnSaveFile();
            }
        }

        private void menuItemSaveAsSql_Click(object sender, EventArgs e) {
            int idx = dynamicTab.DynamicTabSelectedIndex;
            if (idx < 0)
                return;
            if (idx >= dynamicTab.DynamicTabCount)
                return;
            if (dynamicTab.DynamicTabPage[idx].PageType == TabPageType.SqlEditor) {
                DesignControls.SqlEditorNS.SqlEditor sEdit = (DesignControls.SqlEditorNS.SqlEditor)dynamicTab.DynamicTabPage[idx];
                sEdit.creatFile("Save As");
            }
        }
        
        private void menuItemCloseConn_Click(object sender, EventArgs e) {
            DialogResult dResult;
            dResult = Msg.WarrnQ(MSGConfrimCloseConn);

            if (dResult == System.Windows.Forms.DialogResult.No)
                return;
            closeConnectionMode();
        }

        private void mainMenuCreateDB_Click(object sender, EventArgs e) {
            DesignControls.DatabaseBuilder dbBuilder = new DatabaseBuilder();
            dbBuilder.IsCreate = true;
            dbBuilder.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            dbBuilder.RefreshTree += new EventHandler<RefreshDBTreeEventArgs>(refresDBTreeFromTabPage);
            dbBuilder.IsEdited = true;
            dynamicTab.AddTabPage(dbBuilder);
        }

        private void mainMenuCreateTB_Click(object sender, EventArgs e) {
            if (MySqlConfig.DatabaseSelected.Equals(string.Empty)) {
                Msg.Warrn(MSGWarnSelectDB);
                return;
            }
            if (prevTreeNode == null) {
                return;
            }

            if (!databseTableIsExist(MySqlConfig.DatabaseSelected, string.Empty)) {
                Msg.Err(MSGDBNotFound);
                refreshTree();
                return;
            }
            TableBuilder tbBuilder = new TableBuilder(TableBuilderMode.CreateTable);
            tbBuilder.DataBase = MySqlConfig.DatabaseSelected;
            tbBuilder.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            tbBuilder.IsEdited = true;
            dynamicTab.AddTabPage(tbBuilder);
        }

        private void menuItemExportImportDB_Click(object sender, EventArgs e) {
            for (int i = 0; i < dynamicTab.DynamicTabPage.Count; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.ImpotExport) {
                    dynamicTab.DynamicTabSelectedIndex = i;
                    return;
                }
            }
            DesignControls.ExportImortSQL exIm = new ExportImortSQL();
            exIm.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            exIm.RefreshDbTree += new EventHandler<RefreshDBTreeEventArgs>(refresDBTreeFromTabPage);
            exIm.PageType = TabPageType.ImpotExport;
            exIm.TabHeaderText = "Export/Import DB";
            exIm.Dock = DockStyle.None;
            dynamicTab.AddTabPage(exIm);
        }

        private void menuItemUserAccount_Click(object sender, EventArgs e) {
            for (int i = 0; i < dynamicTab.DynamicTabCount; ++i) {
                if (dynamicTab.DynamicTabPage[i].PageType == TabPageType.UserAccounts) {
                    dynamicTab.DynamicTabSelectedIndex = i;
                    return;
                }
            }
            DesignControls.UserAccount usr = new DesignControls.UserAccount();
            usr.SqlExecuteMessaeg += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            dynamicTab.AddTabPage(usr);
            usr.loadUserAccount();
        }

        private void menuItemConsole_Click(object sender, EventArgs e) {
            DesignControls.ConsoleSQL_NS.ConsoleSQL con = new DesignControls.ConsoleSQL_NS.ConsoleSQL();
            con.ExecuteSQL += new EventHandler<DesignControls.SqlEditorNS.SqlEditorExecuteEventArgs>(sqlFile_ExcuteSQL);
            dynamicTab.AddTabPage(con);
        }

        private void mainMenuSettingLimit_Click(object sender, EventArgs e) {
            DesignControls.FormSetting frm = new FormSetting();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void menuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        private void closeConnectionMode() {
            this.Text = appName;
            efectToTree = false;
            dynamicTab.CloseAllTab();
            if (treeExplorer.Nodes != null)
                treeExplorer.Nodes.Clear();
            closeAllPanel(true);
            enableMenu(false);
            try {
                if (AppConnection.Connection.State != ConnectionState.Closed) { 
                    AppConnection.Connection.Close();
                    MySqlConnection.ClearPool(AppConnection.Connection);
                    AppConnection.Connection.Dispose();
                }
            } catch (MySqlException ex) {
                ErrorMessage(MSGErrTryCloseConn, ex.Message);
            }
            textServerStatus.Text = "";
            DesignControls.StartingPage.StartPage startPage = new DesignControls.StartingPage.StartPage();
            startPage.frmNewConnection.SqlMessage += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            startPage.SqlMessage += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
            startPage.OpenConnection += new EventHandler<EventArgs>(OpenConnection);
            startPage.BeginToOpen += new EventHandler<DesignControls.StartingPage.TryOpenConnectionEventArgs>(BeginOpen);
            startPage.CanClose = false;
            dynamicTab.AddTabPage(startPage);
            sqlMessage.ClearMessage();
        }

        protected void ErrorMessage(string msgAction, string msgErr) {
            ExecuteMessageEventArgs exec = new ExecuteMessageEventArgs();
            exec.Action = MessageKeyword.BuildSqlActionMessage(msgAction);
            exec.Error = MessageKeyword.BuildErrorMessage(msgErr);
            messageFromOtherObject(this, exec);
        }

        private void subMainMenuAbout_Click(object sender, EventArgs e) {
            DesignControls.FormAbout f = new FormAbout();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
