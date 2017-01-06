using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace MySqlClientDotNET.DesignControls.StartingPage {
    public partial class FormNewConnection : Form {
        public FormNewConnection() {
            InitializeComponent();
            isSuccess = false;
            isCreate = true;
            scnnstr = "Data source=" + ResourcesPath.db_conn +"; Version=3;";

            simpleAESPass = new FileIO.SimpleAES(FileIO.SimpleAES.KeyPass,
                                             FileIO.SimpleAES.VectorPass);
            simpleAESAskPass = new FileIO.SimpleAES(FileIO.SimpleAES.KeyAskPass,
                                             FileIO.SimpleAES.VectorAskPass);
            setLanguage();
        }

        private void setLanguage() {
            groupBox.Text = LanguageApp.langFormConnection["GBTNewConnection"];
            labelConnectionName.Text = LanguageApp.langFormConnection["LBConnectionName"];
            labelHostName.Text = LanguageApp.langFormConnection["LBHostName"];
            labelUsername.Text = LanguageApp.langFormConnection["LBUserName"];
            labelPass.Text = LanguageApp.langFormConnection["LBPassword"];
            labelDefaultDB.Text = LanguageApp.langFormConnection["LBDefaultDatabase"];
            labelHavePassword.Text = LanguageApp.langFormConnection["LBHavePass"];
            labelHavePassYes = LanguageApp.langFormConnection["LBHavePassYes"];
            labelHavePassNo = LanguageApp.langFormConnection["LBHavePassNo"];
            buttonSetPass.Text = LanguageApp.langFormConnection["BTSetPass"];
            buttonTestConn.Text = LanguageApp.langFormConnection["BTTestConn"];
            buttonSave.Text = LanguageApp.langFormConnection["BTSave"];
            buttonClearPass.Text = LanguageApp.langFormConnection["BTClearPass"];
            checkAskPass.Text = LanguageApp.langFormConnection["CBTAskPass"];
            titleFormNew = LanguageApp.langFormConnection["TFNew"];
            titleFormEdit = LanguageApp.langFormConnection["TFEdit"];
            MSGFillConn = LanguageApp.langFormConnection["MSGFillConnName"];
            MSGFillHost = LanguageApp.langFormConnection["MSGFillHost"];
            MSGFillUser = LanguageApp.langFormConnection["MSGFillUser"];
            MSGConnNameExist = LanguageApp.langFormConnection["MSGConnNameExist"];
            MSGTryConn = LanguageApp.langFormConnection["MSGTryConn"];
            MSGConnMySql = LanguageApp.langFormConnection["MSGConnMysql"];
            MSGErrSaveConn = LanguageApp.langFormConnection["MSGErrSaveConn"];
            MSGErrEditConn = LanguageApp.langFormConnection["MSGErrEditConn"];
            MSGConnected = LanguageApp.langFormConnection["MSGConnected"];
            MSGNotConnected = LanguageApp.langFormConnection["MSGNotConnected"];

            
        }

        private string MSGFillConn;
        private string MSGFillHost;
        private string MSGFillUser;
        private string MSGConnNameExist;
        private string MSGTryConn;
        private string MSGConnMySql;
        private string MSGErrSaveConn;
        private string MSGErrEditConn;
        private string MSGConnected;
        private string MSGNotConnected;

        public bool isSuccess;

        private string titleFormNew;
        private string titleFormEdit;

        private FileIO.SimpleAES simpleAESPass;
        private FileIO.SimpleAES simpleAESAskPass;

        private string scnnstr;
        private SQLiteConnection scnn;
        private SQLiteCommand scmmd;
        private SQLiteDataReader sdr;

        private void textPort_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }


        private string labelHavePassYes;
        private string labelHavePassNo;

        private bool isCreate;

        public bool IsCreate {
            get {
                return isCreate;
            }

            set {
                isCreate = value;
                textConnName.Enabled = value;
                if (value)
                    this.Text = titleFormNew;
                else
                    this.Text = titleFormEdit;
            }
        }


        private void textPort_TextChanged(object sender, EventArgs e) {
            int i = 0;
            if (!int.TryParse(textPort.Text, out i)) {
                textPort.Text = string.Empty;
            }
        }

        private void trimText() {
            textConnName.Text = textConnName.Text.Trim();
            textHost.Text = textHost.Text.Trim();
        }

        private bool isValidInput() {
            if (textConnName.Text.Equals("")) {
                Msg.Info(MSGFillConn);
                return false;
            }
            if (textHost.Text.Equals("")) {
                Msg.Info(MSGFillHost);
                return false;
            }
            if (textUsername.Text.Equals("")) {
                Msg.Info(MSGFillUser);
                return false;
            }

            if (!isCreate)
                return true;

            string sql = "SELECT * FROM tb_data WHERE conn_name='" + textConnName.Text + "'";
            
            bool res = true;

            try {
                using (scnn = new SQLiteConnection(scnnstr)) {
                    scnn.Open();
                    using (scmmd = new SQLiteCommand(sql, scnn)) {
                        using (sdr = scmmd.ExecuteReader()) {
                            if (sdr.HasRows) {
                                Msg.Info(MSGConnNameExist);
                                res = false;
                            }
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            return res;
        }

        public void SetData(string conn_name) {
            string sql = 
@"SELECT 
    * 
FROM 
    tb_data
WHERE 
    conn_name=@ConnName;";
            SQLiteParameter sParam = new SQLiteParameter("@ConnName", DbType.String);
            sParam.Value = conn_name;
            try {
                using (scnn = new SQLiteConnection(scnnstr)) {
                    using (scmmd = new SQLiteCommand(sql, scnn)) {
                        scnn.Open();
                        scmmd.Parameters.Add(sParam);
                        using (sdr = scmmd.ExecuteReader()) {
                            if (sdr.HasRows) {
                                string pass = string.Empty;
                                string askPass = string.Empty;
                                while (sdr.Read()) {
                                    textConnName.Text = sdr[0].ToString();
                                    textHost.Text = sdr[1].ToString();
                                    textPort.Text = sdr[2].ToString();
                                    textUsername.Text = sdr[3].ToString();
                                    pass = sdr[4].ToString();
                                    try {
                                        textPass.Text = pass.Equals("") ? "" : simpleAESPass.DecryptString(pass);
                                    } catch (Exception ex) {
                                        Msg.Err("Error to decrypt password : " + ex.Message);
                                    }
                                    textDefaultDB.Text = sdr[5].ToString();
                                    if (!pass.Equals(string.Empty)) {
                                        checkAskPass.Checked = sdr[6].ToString().Equals("");
                                    } else
                                        checkAskPass.Checked = false;
                                }
                            }
                        }
                    }
                }
            } catch (SQLiteException ex) {
                Msg.Err("Error : " + ex.Message);
            }
        }

        public MySqlConnection testConnection() {
            string cnnstr = "SERVER=" + textHost.Text + ";";
            cnnstr += !textPort.Text.Equals("") ? "PORT=" + textPort.Text + ";" : "";
            cnnstr += "USER ID='" + textUsername.Text + "';";
            cnnstr += !textPass.Text.Equals("") ? "Password='" + textPass.Text + "';" : "";
            cnnstr += !textDefaultDB.Text.Equals("") ? "DATABASE=" + textDefaultDB.Text + ";" : "";

            var cnn = new MySqlConnection(cnnstr);
            ExecuteMessageEventArgs arg = new ExecuteMessageEventArgs();
            arg.Action = MessageKeyword.BuildSqlActionMessage("Trying connecting to MySql");
            try {
                cnn.Open();
                arg.Stetment = MessageKeyword.BuildMessage(MSGConnMySql);
            } catch (MySqlException myEx) {
                arg.Error = MessageKeyword.BuildErrorMessage(myEx.Message);
            }

            if (SqlMessage != null)
                SqlMessage(this, arg);

            return cnn;
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            trimText();
            if (!isValidInput()) {
                return;
            }
            AppConnection.Connection = testConnection(); //get connection open
            bool isError = AppConnection.Connection.State == ConnectionState.Open ? false : true;

            if (isError) {
                AppConnection.Connection.Dispose();
                isSuccess = false;
                string msg;
                if (isCreate)
                    msg = MSGErrSaveConn;
                else
                    msg = MSGErrEditConn;
                switch (Msg.WarrnQC(msg)) {
                    case System.Windows.Forms.DialogResult.Yes:
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        this.Close();
                        return;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                }
            } else {
                isSuccess = true;
                MySqlConfig.Server = textHost.Text;
                MySqlConfig.Port = textPort.Text;
                MySqlConfig.UID = textUsername.Text;
                MySqlConfig.Password = textPass.Text; ;
                MySqlConfig.Database = textDefaultDB.Text;
            }

            string sql = "";
            string askPass = "";
            List<SQLiteParameter> lsParam = new List<SQLiteParameter>();
            string pass = textPass.Text.Equals("") ? textPass.Text : simpleAESPass.EncryptToString(textPass.Text);
            if (!checkAskPass.Checked)
                askPass = textPass.Text.Equals("") ? textPass.Text : simpleAESAskPass.EncryptToString(textPass.Text);

            lsParam.Add(new SQLiteParameter("@ConnName", DbType.String));
            lsParam.Add(new SQLiteParameter("@Host", DbType.String));
            lsParam.Add(new SQLiteParameter("@Port", DbType.String));
            lsParam.Add(new SQLiteParameter("@User", DbType.String));
            lsParam.Add(new SQLiteParameter("@Pass", DbType.String));
            lsParam.Add(new SQLiteParameter("@DefDb", DbType.String));
            lsParam.Add(new SQLiteParameter("@AskPass", DbType.String));
            lsParam[0].Value = textConnName.Text;
            lsParam[1].Value = textHost.Text;
            lsParam[2].Value = textPort.Text;
            lsParam[3].Value = textUsername.Text;
            lsParam[4].Value = pass;
            lsParam[5].Value = textDefaultDB.Text;
            lsParam[6].Value = askPass;
            
            if (isCreate) {
                sql =
@"INSERT INTO 
    tb_data 
VALUES(
    @ConnName, 
    @Host, 
    @Port, 
    @User, 
    @Pass, 
    @DefDb,
    @AskPass
);";
            } else {
                sql =
@"UPDATE 
    tb_data 
SET 
    server=@Host, 
    port=@Port, 
    usr=@User, 
    passwd=@Pass, 
    def_db=@DefDb,
    ask_pass=@AskPass 
WHERE 
    conn_name=@ConnName;";
            }

            try {
                using (scnn = new SQLiteConnection(scnnstr)) {
                    scnn.Open();
                    using (scnn = new SQLiteConnection(scnnstr)) {
                        scnn.Open();
                        using (scmmd = new SQLiteCommand(sql, scnn)) {
                            scmmd.Parameters.AddRange(lsParam.ToArray());
                            scmmd.ExecuteNonQuery();
                        }
                    }
                    
                }
                this.Close();
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
        }

        private void buttonTestConn_Click(object sender, EventArgs e) {
            var conn = testConnection();
            if (conn.State == ConnectionState.Open)
                Msg.Info(MSGConnected);
            else
                Msg.Err(MSGNotConnected);
            conn.Dispose();
        }

        public void ClearText() {
            textUsername.Text = "";
            textHost.Text = "";
            textConnName.Text = "";
            textDefaultDB.Text = "";
            textPass.Text = "";
            textPort.Text = "";
        }

        public event EventHandler<ExecuteMessageEventArgs> SqlMessage;

        private void buttonSetPass_Click(object sender, EventArgs e) {
            FormInputPassword frm = new FormInputPassword();
            frm.ShowDialog();
            if (frm.IsOk) {
                this.textPass.Text = frm.textInput.Text;
            }
            frm.Dispose();
        }

        private void FormNewConnection_Load(object sender, EventArgs e) {
            if (isCreate) {
                buttonClearPass.Enabled = false;
                labelHavePassYesNo.Text = labelHavePassNo;
            }
        }

        private void textPass_TextChanged(object sender, EventArgs e) {
            if (textPass.Text.Equals("")) {
                buttonClearPass.Enabled = false;
                checkAskPass.Checked = false;
                checkAskPass.Visible = false;
                labelHavePassYesNo.Text = labelHavePassNo;
            } else { 
                buttonClearPass.Enabled = true;
                checkAskPass.Visible = true;
                labelHavePassYesNo.Text = labelHavePassYes;
            }
        }

        private void buttonClearPass_Click(object sender, EventArgs e) {
            textPass.Clear();
        }

        private void checkAskPass_CheckedChanged(object sender, EventArgs e) {
            if (isCreate)
                return;
            if (!checkAskPass.Checked) {
                if (textPass.Text.Equals(""))
                    return;
                FormInputPassword f = new FormInputPassword();
                f.ShowDialog();
                if (f.IsOk) {
                    if (!f.textInput.Text.Equals(textPass.Text)) {
                        checkAskPass.Checked = true;
                    }
                } else
                    checkAskPass.Checked = true;
                f.Dispose();
            }
        }
    }
}
