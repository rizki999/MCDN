using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql;

namespace MySqlClientDotNET.DesignControls {
    public partial class ExportImortSQL : DesignControls.DynamicTabNS.DynamicTabPage {
        //DesignControls.DynamicTabNS.DynamicTabPage
        public ExportImortSQL() {
            InitializeComponent();
            this.AutoScrollMinSize = new Size(424, 297);
            LoadDatabase();
            mode = MySqlBackMode.Export;
            cancel = false;
            textPathEx.ReadOnly = true;
            textPathIm.ReadOnly = true;
        }

        public override void InitializedOnDynamicTab() {
            language();
        }

        private void language() {
            this.TabHeaderText = LanguageApp.langExportImport["THExportImport"];

            groupBoxEx.Text = LanguageApp.langExportImport["GBEx"];
            groupBoxIm.Text = LanguageApp.langExportImport["GBIm"];

            labelPathEx.Text = LanguageApp.langExportImport["LBPath"];
            labelPathIm.Text = LanguageApp.langExportImport["LBPath"];
            labelSelectDBEx.Text = LanguageApp.langExportImport["LBSelDB"];
            labelSelectDbIm.Text = LanguageApp.langExportImport["LBSelDB"];
            labelStatusLbEx.Text = LanguageApp.langExportImport["LBStatus"];
            labelStatusLbIm.Text = LanguageApp.langExportImport["LBStatus"];

            buttonExport.Text = LanguageApp.langExportImport["BTExport"];
            buttonImport.Text = LanguageApp.langExportImport["BTImport"];
            buttonOpenEx.Text = LanguageApp.langExportImport["BTOpen"];
            buttonOpenIm.Text = LanguageApp.langExportImport["BTOpen"];

            MSGFileNotExist = LanguageApp.langExportImport["MSGFileNotExist"];
            MSGSelFile = LanguageApp.langExportImport["MSGSelFile"];
            MSGImporting = LanguageApp.langExportImport["MSGImporting"];
            MSGSelTargetDir = LanguageApp.langExportImport["MSGSelTargetDir"];
            MSGExporting = LanguageApp.langExportImport["MSGExporting"];
            MSGExportDB = LanguageApp.langExportImport["MSGExportDB"];
            MSGImportDB = LanguageApp.langExportImport["MSGImportDB"];
            MSGSaveDB = LanguageApp.langExportImport["MSGSaveDB"];
            MSGOpenFile = LanguageApp.langExportImport["MSGOpenFile"];
        }

        private string MSGFileNotExist;
        private string MSGSelFile;
        private string MSGImporting;
        private string MSGSelTargetDir;
        private string MSGExporting;
        private string MSGExportDB;
        private string MSGImportDB;
        private string MSGSaveDB;
        private string MSGOpenFile;

        private MySqlBackMode mode;

        private MySqlCommand cmmd;
        private MySqlDataReader dr;

        private MySqlBackup mb;
        private BackgroundWorker bw;

        private bool cancel;

        public event EventHandler<DesignControls.RefreshDBTreeEventArgs> RefreshDbTree;

        private List<string> getAllTBFromDB(string database) {
            List<string> result = new List<string>();
            string query =
@"SELECT 
    TABLE_NAME 
FROM 
    information_schema.TABLES 
WHERE 
    TABLE_SCHEMA='" + database + "'";

            using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                using (var dr = cmmd.ExecuteReader()) {
                    while (dr.Read()) {
                        result.Add(dr[0].ToString());
                    }
                }
            }

            return result;
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            if (!System.IO.File.Exists(textPathIm.Text)) {
                Msg.Err(MSGFileNotExist);
                return;
            }
            if (textPathIm.Text.Equals(string.Empty)) {
                Msg.Err(MSGSelFile);
                return;
            }
            mode = MySqlBackMode.Imort;
            if (mb != null)
                mb.Dispose();
            buttonImport.Enabled = false;
            buttonOpenIm.Enabled = false;
            labelStatusIm.Text = MSGImporting;
            cancel = false;
            cmmd = new MySqlCommand();
            AppConnection.Connection.ChangeDatabase(comboSelectDBImp.SelectedItem.ToString());
            cmmd.Connection = AppConnection.Connection;
            this.CanClose = false;
            mb = new MySqlBackup(cmmd);
            mb.ImportProgressChanged += new MySqlBackup.importProgressChange(mb_ImportProgressChanged);
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            object[] args = {
                getAllTBFromDB(comboSelectDBImp.SelectedItem.ToString()),
                comboSelectDBImp.SelectedItem.ToString()
            };
            bw.RunWorkerAsync(args);
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            if (textPathEx.Text.Equals(string.Empty)) {
                Msg.Err(MSGSelTargetDir);
                return;
            }
            mode = MySqlBackMode.Export;
            if (mb != null)
                mb.Dispose();
            buttonExport.Enabled = false;
            buttonOpenEx.Enabled = false;
            labelStatusEx.Text = MSGExporting;
            cancel = false;
            cmmd = new MySqlCommand();

            try { 
                AppConnection.ChangeDatabase(comboSelectDBEx.SelectedItem.ToString());
            } catch (Exception ex) {
                onErrorMessage("Try Change Database", ex.Message);
                return;
            }

            cmmd.Connection = AppConnection.Connection;
            mb = new MySqlBackup(cmmd);
            this.CanClose = false;
            mb.ExportProgressChanged += new MySqlBackup.exportProgressChange(mb_ExportProgressChanged);
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = null;
            try {
                if (mode == MySqlBackMode.Export)
                    mb.ExportToFile(textPathEx.Text);
                else { 
                    mb.ImportFromFile(textPathIm.Text);
                    object[] args = (object[])e.Argument;
                    List<string> lsExcept = (List<string>)args[0];
                    string db = (string)args[1];
                    var result = getAllTBFromDB(db).Except(lsExcept).ToList();
                    e.Result = result;
                }
            } catch (Exception ex) {
                cancel = true;
                throw new Exception(ex.Message);
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ExecuteMessageEventArgs msg = new ExecuteMessageEventArgs();
            this.CanClose = true;
            if (e.Error != null) {
                if (mode == MySqlBackMode.Export) {
                    msg.Action = MessageKeyword.BuildSqlActionMessage("Export Database");
                    msg.Error = MessageKeyword.BuildErrorMessage(e.Error.Message);
                    labelStatusEx.Text = MSGExporting + " Error";

                } else {
                    msg.Action = MessageKeyword.BuildSqlActionMessage("Import Databse");
                    msg.Error = MessageKeyword.BuildErrorMessage(e.Error.Message);
                    labelStatusIm.Text = MSGImporting + " Error";
                }
            } else {
                if (mode == MySqlBackMode.Export) {
                    msg.Action = MessageKeyword.BuildSqlActionMessage("Export Database");
                    msg.Stetment = MessageKeyword.BuildMessage(MSGExporting + " Success");
                    labelStatusEx.Text = MSGExporting + " Success";
                } else {
                    msg.Action = MessageKeyword.BuildSqlActionMessage("Import Database");
                    msg.Stetment = MessageKeyword.BuildMessage(MSGImporting + " Success");
                    labelStatusIm.Text = MSGImporting + " Success";
                    if (e.Result != null)
                        onRefreshTree(comboSelectDBImp.SelectedItem.ToString(),
                                      e.Result);
                }
            }
            if (mode == MySqlBackMode.Export) {
                buttonExport.Enabled = true;
                buttonOpenEx.Enabled = true;
            } else {
                buttonImport.Enabled = true;
                buttonOpenIm.Enabled = true;
            }
            sendSqlExecutedMessage(msg);
            AppConnection.SetDefaultDatabase();
        }

        void mb_ExportProgressChanged(object sender, ExportProgressArgs e) {
            if (cancel)
                mb.StopAllProcess();
        }

        void mb_ImportProgressChanged(object sender, ImportProgressArgs e) {
            if (cancel)
                mb.StopAllProcess();
        }

        private void CloseConnection() {
            if (cmmd != null)
                cmmd.Dispose();
        }

        private void onRefreshTree(string db, object tb) {
            DesignControls.RefreshDBTreeEventArgs r = new RefreshDBTreeEventArgs();
            r.TableDatabaseName = db;
            r.TableNameNew = tb;
            if (RefreshDbTree != null)
                RefreshDbTree(this, r);
        }

        private void LoadDatabase() {
            comboSelectDBEx.Items.Clear();
            comboSelectDBImp.Items.Clear();
            int index_select = -1;
            int count = 0;
            string sql = 
@"SELECT 
    information_schema.SCHEMATA.SCHEMA_NAME 
FROM 
    information_schema.SCHEMATA;";
            try {
                using (cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            if (!MySqlConfig.DBFromSystem(dr[0].ToString())) {
                                if (dr[0].ToString().Equals(MySqlConfig.DatabaseSelected)) {
                                    index_select = count;
                                }
                                comboSelectDBEx.Items.Add(dr[0].ToString());
                                comboSelectDBImp.Items.Add(dr[0].ToString());
                                ++count;
                            }
                        }
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            comboSelectDBImp.SelectedIndex = index_select;
            comboSelectDBEx.SelectedIndex = index_select;
        }

        private void buttonOpenEx_Click(object sender, EventArgs e) {
            textPathEx.Text = "";
            labelPathEx.Text = "-";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = FileIO.FileInfo.GetSQLFileExtension;
            saveFile.Title = MSGSaveDB;
            if (saveFile.ShowDialog() == DialogResult.OK) {
                textPathEx.Text = saveFile.FileName;
            }
        }

        private void buttonOpenIm_Click(object sender, EventArgs e) {
            textPathIm.Text = "";
            labelPathIm.Text = "-";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = FileIO.FileInfo.GetSQLFileExtension;
            openFile.Title = MSGOpenFile;
            if (openFile.ShowDialog() == DialogResult.OK) {
                textPathIm.Text = openFile.FileName;
            }
        }

        public override void OnClosedTab() {
            cancel = true;
        }
    }
    public enum MySqlBackMode {
        Imort,
        Export
    }
}