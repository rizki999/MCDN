using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace MySqlClientDotNET.DesignControls.StartingPage {
    public partial class StartPage : DesignControls.DynamicTabNS.DynamicTabPage {

        public StartPage() {
            InitializeComponent();
            scnnstr = "Data source=" + ResourcesPath.db_conn + "; Version=3;";
            loadConnName();
            this.AutoScrollMinSize = new System.Drawing.Size(454, 313);
            frmNewConnection = new FormNewConnection();
            simpleAESPass = new FileIO.SimpleAES(FileIO.SimpleAES.KeyPass,
                                                 FileIO.SimpleAES.VectorPass);
            simpleAESAskPass = new FileIO.SimpleAES(FileIO.SimpleAES.KeyAskPass,
                                                 FileIO.SimpleAES.VectorAskPass);
            try {
                iconApplication.Image = Image.FromFile(ResourcesPath.img_mysql_L);
                logoMySqlDotNet.Image = Image.FromFile(ResourcesPath.img_logo);
            } catch (Exception ex) {
                Msg.Err("Error : " + ex.Message);
            }
            setLanguage();
        }

        private void setLanguage() {
            this.TabHeaderText = LanguageApp.langStartPage["HTStartPage"];
            buttonNewConn.Text = LanguageApp.langStartPage["BTNewConnection"];
            labelListConn.Text = LanguageApp.langStartPage["LBListConnection"];

            contexOpen.Text = LanguageApp.langStartPage["CMOpenConn"];
            contexEdit.Text = LanguageApp.langStartPage["CMEditConn"];
            contexDelete.Text = LanguageApp.langStartPage["CMDelConn"];

            MSGErrConnName = LanguageApp.langStartPage["MSGErrConnName"];
            MSGWorngPass = LanguageApp.langStartPage["MSGWorngPass"];
            MSGConnWork = LanguageApp.langStartPage["MSGConnWork"];
            MSGTryToConn = LanguageApp.langStartPage["MSGTryToConn"];
            MSGApplyDel = LanguageApp.langStartPage["MSGApplyDel"];
            MSGConnDel = LanguageApp.langStartPage["MSGConnDel"];
        }

        private string MSGErrConnName;
        private string MSGWorngPass;
        private string MSGConnWork;
        private string MSGTryToConn;
        private string MSGApplyDel;
        private string MSGConnDel;

        private string scnnstr;

        public FormNewConnection frmNewConnection;
        private FileIO.SimpleAES simpleAESPass;
        private FileIO.SimpleAES simpleAESAskPass;
        private BackgroundWorker bgTryOpen;

        private void openConnMySql(string cnn_name) {
            string askPass = "";
            string pass = "";
            try {
                string sql = 
@"SELECT 
    * 
FROM 
    tb_data 
WHERE 
    conn_name='" + cnn_name + "';";
                using (SQLiteConnection scnn = new SQLiteConnection(scnnstr)) {
                    scnn.Open();
                    using (SQLiteCommand scmmd = new SQLiteCommand(sql, scnn)) {
                        using (SQLiteDataReader sdr = scmmd.ExecuteReader()) {
                            if (sdr.HasRows) {
                                while (sdr.Read()) {
                                    MySqlConfig.Server = sdr[1].ToString();
                                    MySqlConfig.Port = sdr[2].ToString();
                                    MySqlConfig.UID = sdr[3].ToString();
                                    pass = sdr[4].ToString();
                                    try {
                                        pass = pass.Equals("") ? "" : simpleAESPass.DecryptString(pass);
                                    } catch (Exception ex) {
                                        Msg.Err("Error decrypt password : " + ex.Message);
                                        MySqlConfig.ClearConnectionString();
                                        return;
                                    }
                                    MySqlConfig.Password = pass;
                                    MySqlConfig.Database = sdr[5].ToString();
                                    askPass = sdr[6].ToString();
                                    break;
                                }
                            } else {
                                Msg.Err(MSGErrConnName);
                                return;
                            }
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Msg.Err("Error : " + ex.Message);
                return;
            }

            if (!pass.Equals("")) {
                if (askPass.Equals("")) {
                    FormInputPassword f = new FormInputPassword();
                    f.ShowDialog();
                    if (f.IsOk) {
                        if (!f.textInput.Text.Equals(pass)) {
                            Msg.Warrn(MSGWorngPass);
                            MySqlConfig.ClearConnectionString();
                            return;
                        }
                    } else {
                        MySqlConfig.ClearConnectionString();
                        return;
                    }
                } else {
                    try { 
                        string decryptPass = simpleAESAskPass.DecryptString(askPass);
                        if (!pass.Equals(decryptPass)) {
                            MySqlConfig.ClearConnectionString();
                            return;
                        }
                    } catch (Exception ex) {
                        Msg.Err("Error decypt AskPass : " + ex.Message);
                        MySqlConfig.ClearConnectionString();
                        return;
                    }
                }
            }

            AppConnection.Connection = new MySqlConnection(MySqlConfig.ConnectionString);
            bgTryOpen = new BackgroundWorker();
            bgTryOpen.DoWork += new DoWorkEventHandler(bgTryOpen_DoWork);
            bgTryOpen.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgTryOpen_RunWorkerCompleted);
            if (BeginToOpen != null)
                BeginToOpen(this, new TryOpenConnectionEventArgs());
            bgTryOpen.RunWorkerAsync();
            listConnection.Enabled = false;
            buttonNewConn.Enabled = false;
        }

        void bgTryOpen_DoWork(object sender, DoWorkEventArgs e) {
            try {
                AppConnection.Connection.Open();
            } catch (MySqlException ex) {
                throw new Exception(ex.Message);
            }
        }

        void bgTryOpen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ExecuteMessageEventArgs exe = new ExecuteMessageEventArgs();
            listConnection.Enabled = true;
            buttonNewConn.Enabled = true;
            if (e.Error == null) {
                if (OpenConnection != null)
                    OpenConnection(this, new EventArgs());
                exe.Stetment = MessageKeyword.BuildMessage(MSGConnWork);
                this.ForceCloseTabPage();
            } else {
                MySqlConfig.ClearConnectionString();
                TryOpenConnectionEventArgs tryOpen = new TryOpenConnectionEventArgs();
                tryOpen.IsError = true;
                if (BeginToOpen != null)
                    BeginToOpen(this, tryOpen);
                exe.Action = MessageKeyword.BuildSqlActionMessage(MSGTryToConn);
                exe.Error = MessageKeyword.BuildErrorMessage(e.Error.Message);
            }

            if (SqlMessage != null)
                SqlMessage(this, exe);
        }

        private void loadConnName() {
            listConnection.Items.Clear();
            string sql =
@"SELECT 
    conn_name 
FROM 
    tb_data;";
            try {
                using (SQLiteConnection scnn = new SQLiteConnection(scnnstr)) {
                    using (SQLiteCommand scmmd = new SQLiteCommand(sql, scnn)) {
                        scnn.Open();
                        using (SQLiteDataReader sdr = scmmd.ExecuteReader()) {
                            while (sdr.Read()) {
                                listConnection.Items.Add(sdr[0].ToString());
                            }
                        }
                    }
                }

            } catch (SQLiteException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            if (listConnection.Items.Count > 0)
                panel2.Visible = true;
            else
                panel2.Visible = false;
        }

        private void buttonNewConn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            frmNewConnection.IsCreate = true;
            frmNewConnection.ShowDialog();
            if (frmNewConnection.isSuccess) {
                ///AppConnection.Connection = new MySqlConnection(MySqlConfig.ConnectionString);
                ExecuteMessageEventArgs ex = new ExecuteMessageEventArgs();
                ex.Action = MessageKeyword.BuildMessage(MSGConnWork);
                ex.ClearMessage = true;
                if (BeginToOpen != null)
                    BeginToOpen(this, new TryOpenConnectionEventArgs());
                if (SqlMessage != null)
                    SqlMessage(this, ex);
                if (OpenConnection != null)
                    OpenConnection(this, new EventArgs());
                frmNewConnection.Dispose();
                this.ForceCloseTabPage();
                return;
            }
            frmNewConnection.ClearText();
            loadConnName();
        }

        private void contexEdit_Click(object sender, EventArgs e) {
            frmNewConnection.IsCreate = false;
            frmNewConnection.SetData(listConnection.SelectedItem.ToString());
            frmNewConnection.ShowDialog();
            if (frmNewConnection.isSuccess) {
                loadConnName();
            }
            frmNewConnection.ClearText();
        }

        private void contexDelete_Click(object sender, EventArgs e) {
            if (Msg.WarrnQ(MSGApplyDel) == DialogResult.No)
                return;
            string sql = "DELETE FROM tb_data WHERE conn_name='" + listConnection.SelectedItem.ToString() + "';";
            try {
                using (SQLiteConnection scnn = new SQLiteConnection(scnnstr)) {
                    using (SQLiteCommand scmmd = new SQLiteCommand(sql, scnn)) {
                        scnn.Open();
                        scmmd.ExecuteNonQuery();
                        scnn.Close();
                    }
                }
                Msg.Succ(MSGConnDel);
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            loadConnName();
        }

        private void listConnection_MouseDown(object sender, MouseEventArgs e) {
            int index = listConnection.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                contexMenuStrip.Show(listConnection, e.Location);
                listConnection.SelectedIndex = index;
            }
        }

        private void contexOpen_Click(object sender, EventArgs e) {
            openConnMySql(listConnection.SelectedItem.ToString());
        }

        private void listConnection_MouseDoubleClick(object sender, MouseEventArgs e) {
            int index = listConnection.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                openConnMySql(listConnection.Items[index].ToString());
            }
        }

        public event EventHandler<EventArgs> OpenConnection;
        public event EventHandler<TryOpenConnectionEventArgs> BeginToOpen;

        public event EventHandler<ExecuteMessageEventArgs> SqlMessage;
    }

    public class TryOpenConnectionEventArgs : EventArgs {
        public TryOpenConnectionEventArgs() {
            this.IsError = false;
        }
        public bool IsError { get; set; }
    }
}
