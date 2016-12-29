using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace MySqlClientDotNET.DesignControls {
    public partial class UserAccount : DynamicTabNS.DynamicTabPage {
        //DynamicTabNS.DynamicTabPage
        public UserAccount() {
            InitializeComponent();
            this.PageType = TabPageType.UserAccounts;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;//569, 350
            this.AutoScrollMinSize = new Size(569, 350);
            tab.ItemSize = new Size(0, 1);
            
            hItemCheckGlob = false;
            checkListDataGlob.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._ItemCheckGlob);
            checkListStructureGlob.ItemCheck += new ItemCheckEventHandler(this._ItemCheckGlob);
            checkListAdminGlob.ItemCheck += new ItemCheckEventHandler(this._ItemCheckGlob);
            initilazeCheckListGlob();
            initilazeCheckListDb();
            initilazeCheckListTb();
            language();
        }

        private void language() {
            this.TabHeaderText = LanguageApp.langUserAccount["HTUserAccount"];
            gridTable.Columns[0].HeaderText = LanguageApp.langUserAccount["DGVUsers"];
            gridTable.Columns[1].HeaderText = LanguageApp.langUserAccount["DGVHost"];

            labelUserCr.Text = 
                labelUserGlob.Text = 
                labelUserDB.Text =
                labelUserTB.Text = LanguageApp.langUserAccount["LBUser"];
            labelHostCr.Text =
                labelHostGlob.Text =
                labelHostDB.Text =
                labelHostTB.Text = LanguageApp.langUserAccount["LBHost"];
            labelPass.Text = LanguageApp.langUserAccount["LBPass"];
            labelUsePercent.Text = LanguageApp.langUserAccount["LBPercent"];
            labelLeftEmpetyPass.Text = LanguageApp.langUserAccount["LBLeftPass"];
            labelMaxQueryGlob.Text = LanguageApp.langUserAccount["LBMaxQuery"];
            labelMaxUpdateGlob.Text = LanguageApp.langUserAccount["LBMaxUpdates"];
            labelMaxConnGlob.Text = LanguageApp.langUserAccount["LBMaxConn"];
            labelMaxUserConnGlob.Text = LanguageApp.langUserAccount["LBMaxUserConn"];
            labelSelDBDB.Text =
                labelSelDBTB.Text = LanguageApp.langUserAccount["LBSelDB"];
            labelSelTBTB.Text = LanguageApp.langUserAccount["LBSelTB"];

            groupBoxCr.Text = LanguageApp.langUserAccount["GBCreate"];
            groupBoxDataGlob.Text =
                groupBoxDataDB.Text =
                groupBoxDataTB.Text = LanguageApp.langUserAccount["GBData"];
            groupBoxStructGlob.Text =
                groupBoxStructDB.Text =
                groupBoxStructTB.Text = LanguageApp.langUserAccount["GBStruct"];
            groupBoxAdminGlob.Text =
                groupBoxAdminDB.Text =
                groupBoxAdminTB.Text = LanguageApp.langUserAccount["GBAdmin"];

            buttonCreate.Text = LanguageApp.langUserAccount["BTCreate"];
            contextMenuChangePass.Text =
                buttonChangPassword.Text = LanguageApp.langUserAccount["BTChangePass"];
            contextMenuRemoveUser.Text =
                buttonRemove.Text = LanguageApp.langUserAccount["BTRemove"];
            contextMenuEditPriv.Text =
                buttonEdit.Text = LanguageApp.langUserAccount["BTEditPriv"];
            buttonNext.Text = LanguageApp.langUserAccount["BTNext"];
            buttonBack.Text = LanguageApp.langUserAccount["BTBack"];
            buttonApplyGlob.Text =
                buttonApplyDb.Text =
                buttonApplyTb.Text = LanguageApp.langUserAccount["BTApply"];
            buttonCancleGlob.Text =
                buttonCancelDb.Text =
                buttonCancelTb.Text = LanguageApp.langUserAccount["BTCancel"];
            buttonPrivGlobGlob.Text = 
                buttonPrivGlobDB.Text =
                buttonPrivGlobTB.Text = LanguageApp.langUserAccount["BTGlobPriv"];
            buttonPrivDbGlob.Text =
                buttonPrivDbDB.Text =
                buttonPrivDbTB.Text = LanguageApp.langUserAccount["BTDBPriv"];
            buttonPrivTbGlob.Text =
                buttonPrivTbDB.Text =
                buttonPrivTbTB.Text = LanguageApp.langUserAccount["BTTBPriv"];

            MSGSelUser = LanguageApp.langUserAccount["MSGSelUser"];
            MSGWarnDropUser = LanguageApp.langUserAccount["MSGWarnDropUser"];
            MSGChangePass = LanguageApp.langUserAccount["MSGChangePass"];
            MSGFillUser = LanguageApp.langUserAccount["MSGFillUser"];
            MSGFillHost = LanguageApp.langUserAccount["MSGFillHost"];
            MSGUserNotFound = LanguageApp.langUserAccount["MSGUserNotFound"];
            MSGConfrim = LanguageApp.langUserAccount["MSGConfrim"];
            MSGSelDB = LanguageApp.langUserAccount["MSGSelDB"];
            MSGSelTB = LanguageApp.langUserAccount["MSGSelTB"];
            MSGCheckUser = LanguageApp.langUserAccount["MSGCheckUser"];
        }

        private string MSGSelUser;
        private string MSGWarnDropUser;
        private string MSGChangePass;
        private string MSGFillUser;
        private string MSGFillHost;
        private string MSGUserNotFound;
        private string MSGConfrim;
        private string MSGSelDB;
        private string MSGSelTB;
        private string MSGCheckUser;

        private string scnnstr = "Data source=" + ResourcesPath.db_conn + "; Version=3;";

        #region Global Priv
        //Global
        private string[] arrPrivDataGlob = new string[]{ 
            "SELECT,Select_priv",
            "INSERT,Insert_priv",
            "UPDATE,Update_priv",
            "DELETE,Delete_priv",
            "FILE,File_priv" 
        };

        private string[] arrPrivStructGlob = new string[]{ 
            "CREATE,Create_priv",
            "ALTER,Alter_priv",
            "INDEX,Index_priv",
            "DROP,Drop_priv",
            "CREATE TEMPORARY TABLES,Create_tmp_table_priv",
            "SHOW VIEW,Show_view_priv",
            "CREATE ROUTINE,Create_routine_priv",
            "ALTER ROUTINE,Alter_routine_priv",
            "EXECUTE,Execute_priv",
            "CREATE VIEW,Create_view_priv",
            "EVENT,Event_priv",
            "TRIGGER,Trigger_priv"
        };

        private string[] arrPrivAdminGlob = new string[]{ 
            "GRANT,Grant_priv",
            "SUPER,Super_priv",
            "PROCESS,Process_priv",
            "RELOAD,Reload_priv",
            "SHUTDOWN,Shutdown_priv",
            "SHOW DATABASES,Show_db_priv",
            "LOCK TABLES,Lock_tables_priv",
            "REFERENCES,References_priv",
            "REPLICATION CLIENT,Repl_client_priv",
            "REPLICATION SLAVE,Repl_slave_priv",
            "CREATE USER,Create_user_priv"
        };
        #endregion

        #region Database Priv
        //Database
        private string[] arrPrivDataDb = new string[]{ 
            "SELECT,Select_priv",
            "INSERT,Insert_priv",
            "UPDATE,Update_priv",
            "DELETE,Delete_priv"
        };

        private string[] arrPrivStructDb = new string[]{ 
            "CREATE,Create_priv",
            "ALTER,Alter_priv",
            "DROP,Drop_priv",
            "INDEX,Index_priv",
            "CREATE TEMPORARY TABLES,Create_tmp_table_priv",
            "SHOW VIEW,Show_view_priv",
            "CREATE ROUTINE,Create_routine_priv",
            "ALTER ROUTINE,Alter_routine_priv",
            "EXECUTE,Execute_priv",
            "CREATE VIEW,Create_view_priv",
            "EVENT,Event_priv",
            "TRIGGER,Trigger_priv"
        };

        private string[] arrPrivAdminDb = new string[]{ 
            "GRANT,Grant_priv",
            "LOCK TABLES,Lock_tables_priv",
            "REFERENCES,References_priv"
        };
        #endregion

        #region Table Priv
        //Table
        private string[] arrPrivDataTb = new string[]{ 
            "SELECT,Select_priv",
            "INSERT,Insert_priv",
            "UPDATE,Update_priv",
            "DELETE,Delete_priv"
        };

        private string[] arrPrivStructTb = new string[]{ 
            "CREATE,Create_priv",
            "ALTER,Alter_priv",
            "DROP,Drop_priv",
            "INDEX,Index_priv",
            "SHOW VIEW,Show_view_priv",
            "CREATE VIEW,Create_view_priv",
            "TRIGGER,Trigger_priv"
        };

        private string[] arrPrivAdminTb = new string[]{ 
            "GRANT,Grant_priv",
            "REFERENCES,References_priv"
        };
        #endregion

        private string getColPrivFromArr(string[] priv) {
            string result = "";
            for (int i = 0; i < priv.Length; ++i) {
                string[] tmp = priv[i].Split(',');
                result += i == 0 ? "" : ",";
                result += tmp[1] + " AS '" + tmp[0] + "'";
            }

            return result;
        }

        private string[] getPrivFromArr(string[] priv) {
            List<string> result = new List<string>();
            for (int i = 0; i < priv.Length; ++i) {
                result.Add(priv[i].Split(',')[0]);
            }

            return result.ToArray();
        }

        private int setPrivChaked(string priv, bool val, CheckedListBox clb) {
            for (int i = 0; i < clb.Items.Count; ++i) {
                if (priv.Equals(clb.GetItemText(clb.Items[i]))) {
                    clb.SetItemChecked(i, val);
                    if (val)
                        return 1;
                    break;
                }
            }
            return 0;
        }

        private void initilazeCheckListGlob() {
            this.checkListDataGlob.Items.AddRange(getPrivFromArr(arrPrivDataGlob));

            this.checkListStructureGlob.Items.AddRange(getPrivFromArr(arrPrivStructGlob));

            this.checkListAdminGlob.Items.AddRange(getPrivFromArr(arrPrivAdminGlob));
        }

        private void initilazeCheckListDb() {
            this.checkListDataDb.Items.AddRange(getPrivFromArr(arrPrivDataDb));

            this.checkListStructDb.Items.AddRange(getPrivFromArr(arrPrivStructDb));

            this.checkListAdminDb.Items.AddRange(getPrivFromArr(arrPrivAdminDb));
        }

        private void initilazeCheckListTb() {
            this.checkListDataTb.Items.AddRange(getPrivFromArr(arrPrivDataTb));

            this.checkListStructTb.Items.AddRange(getPrivFromArr(arrPrivStructTb));

            this.checkListAdminTb.Items.AddRange(getPrivFromArr(arrPrivAdminTb));
        }

        #region Tab Grid User 1

        public void loadUserAccount() {
            gridTable.Rows.Clear();
            string query =
@"SELECT 
    User,
    Host 
FROM
    mysql.user";
            MySqlCommand cmmd;
            MySqlDataReader dr;
            try {
                using (cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            if (dr[0].ToString().Equals("mysql.sys")) continue;
                            //if (dr[0].ToString().Equals(MySqlConfig.Username) && dr[1].ToString().Equals(MySqlConfig.Host)) continue;
                            gridTable.Rows.Add(dr[0].ToString(),
                                            dr[1].ToString());
                        }
                    }
                }
            } catch (MySqlException ex) {
                System.Diagnostics.Debug.WriteLine("error : {0}, error code : {1}", ex.Message, ex.ErrorCode);
                onErrorMessage("loadUserAccount()", ex.Message);
            }
        }

        private void editPrivilegesToolStripMenuItem_Click(object sender, EventArgs e) {
            loadUserPrivGlob(gridTable.SelectedRows[0].Cells[0].Value.ToString(),
                         gridTable.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn("Select user on grid");
                return;
            }

            string user = gridTable.SelectedRows[0].Cells[0].Value.ToString();
            string host = gridTable.SelectedRows[0].Cells[1].Value.ToString();
            string msg = "Are you sure wat to drop user '" + user + "'@'" + host + "'";
            if (Msg.WarrnQ(msg) == DialogResult.No)
                return;
            string command = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "';\nREVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "'; ";
            command += "DROP USER '" + user + "'@'" + host + "';";
            SQLPerview sqlp = new SQLPerview();
            sqlp.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlp.setSQLtext(command);
            sqlp.ReadOnlySQLText = true;
            sqlp.ShowDialog();
            sqlp.Dispose();
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            tab.SelectedIndex = 1;
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn(MSGSelUser);
                return;
            }
            loadUserPrivGlob(gridTable.SelectedRows[0].Cells[0].Value.ToString(),
                         gridTable.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn(MSGSelUser);
                return;
            }

            string user = gridTable.SelectedRows[0].Cells[0].Value.ToString();
            string host = gridTable.SelectedRows[0].Cells[1].Value.ToString();
            string msg = MSGWarnDropUser  +  " '" + user + "'@'" + host + "'";
            if (Msg.WarrnQ(msg) == DialogResult.No)
                return;
            string command = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "'; REVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "'; ";
            command += "DROP USER '" + user + "'@'" + host + "';";
            SQLPerview sqlp = new SQLPerview();
            sqlp.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlp.setSQLtext(command);
            sqlp.ShowDialog();
            loadUserAccount();
            sqlp.Dispose();
        }



        private void buttonChangPassword_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn(MSGSelUser);
                return;
            }

            string user = gridTable.SelectedRows[0].Cells[0].Value.ToString();
            string host = gridTable.SelectedRows[0].Cells[1].Value.ToString();

            DesignControls.StartingPage.FormInputPassword fPasswd = new StartingPage.FormInputPassword();
            fPasswd.Text = MSGChangePass;
            fPasswd.passIsempety = true;
            fPasswd.ShowDialog();
            if (!fPasswd.IsOk)
                return;
            string passwd = fPasswd.textInput.Text.Replace("'", "");

            string command = "ALTER USER '" + user + "'@'" + host + "' IDENTIFIED BY '" + passwd + "';";

            SQLPerview sqlp = new SQLPerview();
            sqlp.ReadOnlySQLText = true;
            sqlp.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlp.setSQLtext(command);
            sqlp.ShowDialog();

            if (sqlp.isSuccessExecuted) {
                string askPass = "";
                string pass = "";
                bool isExist = false;
                string query = 
@"SELECT 
    passwd,
    ask_pass 
FROM 
    tb_data 
WHERE 
    usr='" + user + @"' 
AND 
    server='" + host + "';";
                try { 
                    using (SQLiteConnection scnn = new System.Data.SQLite.SQLiteConnection(scnnstr)) {
                        using (SQLiteCommand scmmd = new System.Data.SQLite.SQLiteCommand(query, scnn)) {
                            scnn.Open();
                            using (SQLiteDataReader sdr = scmmd.ExecuteReader()) {
                                if (isExist = sdr.HasRows) {
                                    while (sdr.Read()) {
                                        pass = sdr[0].ToString();
                                        askPass = sdr[1].ToString();
                                        break;
                                    }
                                }
                            }
                            scnn.Close();
                        }
                    }
                } catch (SQLiteException ex) {
                    Msg.Err("Change password in local db : " + ex.Message);
                    sqlp.Dispose();
                    return;
                }
                if (isExist) {
                    FileIO.SimpleAES aesPass = new FileIO.SimpleAES(FileIO.SimpleAES.KeyPass,
                                                                    FileIO.SimpleAES.VectorPass);
                    FileIO.SimpleAES aesAskPass = new FileIO.SimpleAES(FileIO.SimpleAES.KeyAskPass,
                                                                       FileIO.SimpleAES.VectorAskPass);
                    if (passwd.Equals(string.Empty)) { 
                        if (!askPass.Equals(string.Empty)) {
                            try {
                                aesAskPass.DecryptString(askPass);
                                changePass(user,
                                           host,
                                           "passwd='" + aesPass.EncryptToString(passwd) + "', ask_pass='" + aesAskPass.EncryptToString(passwd) + "'");
                            } catch {
                                changePass(user,
                                           host,
                                           "passwd='" + aesPass.EncryptToString(passwd) + "', ask_pass=''");
                            }
                        } else
                            changePass(user,
                                       host,
                                       "passwd='" + aesPass.EncryptToString(passwd) + "'");
                    } else
                        changePass(user,
                                   host,
                                   "passwd='" + aesPass.EncryptToString(passwd) + "', ask_pass=''");
                }
            }
            sqlp.Dispose();
        }

        private void changePass(string usr, string host, string updateVal) {
            string query =
@"UPDATE 
    tb_data 
SET
    " + updateVal + @" 
WHERE 
    usr='" + usr + @"' 
AND 
    server='" + host + "';";
            try {
                using (SQLiteConnection scnn = new System.Data.SQLite.SQLiteConnection(scnnstr)) {
                    scnn.Open();
                    using (SQLiteCommand scmmd = new System.Data.SQLite.SQLiteCommand(query, scnn)) {
                        scmmd.ExecuteNonQuery();
                    }
                    scnn.Close();
                }
            } catch (SQLiteException ex) { Msg.Err(ex.Message); }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e) {
            buttonChangPassword_Click(null, null);
        }

        #endregion

        #region Tab Create User 2

        private void buttonNext_Click(object sender, EventArgs e) {
            if (textUser.Text.Equals("")) {
                Msg.Warrn(MSGFillUser);
                return;
            }
            if (textHost.Text.Equals("")) {
                Msg.Warrn(MSGFillHost);
                return;
            }

            textUser.Text = textUser.Text.Replace("'", "");
            textHost.Text = textHost.Text.Replace("'", "");
            textPass.Text = textPass.Text.Replace("'", "");

            textUserGlob.Text = textUser.Text;
            textHostGlob.Text = textHost.Text;

            isCreat = true;

            tab.SelectedIndex = 2;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            ClearCreateUser();
            tab.SelectedIndex = 0;
        }

        private void ClearCreateUser() {
            textUser.Text = "";
            textHost.Text = "";
            textPass.Text = "";
        }
        #endregion

        #region Tab Privileges 3

        private void loadDB(ComboBox cb) {
            cb.Items.Clear();
            string query =
@"SELECT 
    SCHEMA_NAME 
FROM 
    information_schema.SCHEMATA;";
            string db = string.Empty;
            try {
                using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            db = dr[0].ToString();
                            if (MySqlConfig.DBFromSystem(db))
                                continue;
                            cb.Items.Add(db);
                        }
                    }
                }
            } catch (MySqlException ex) {
                onErrorMessage("loadDbTb()", ex.Message);
            }
        }

        private void loadTB(string tb) {
            comboTB.Items.Clear();
            string query =
@"SELECT 
    TABLE_NAME 
FROM 
    information_schema.TABLES 
WHERE 
    TABLE_SCHEMA='" + tb + "';";
            try {
                using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read())
                            comboTB.Items.Add(dr[0].ToString());
                    }
                }
            } catch (MySqlException ex) {
                onErrorMessage("loadTb()", ex.Message);
            }
            comboTB.SelectedIndex = 0;
        }

        private string labelUser {
            get {
                return textUserGlob.Text;
            }
            set {
                textUserGlob.Text = value;
                textUserDb.Text = value;
                textUserTb.Text = value;
            }
        }

        private string labelHost {
            get {
                return textHostGlob.Text;
            }
            set {
                textHostGlob.Text = value;
                textHostDb.Text = value;
                textHostTb.Text = value;
            }
        }

        private void loadUserPrivGlob(string user, string host) {
            string query =
@"SELECT 
    " + getColPrivFromArr(arrPrivDataGlob) + @",
    " + getColPrivFromArr(arrPrivStructGlob) + @",
    " + getColPrivFromArr(arrPrivAdminGlob) + @",
    User,
    Host,
    max_questions,
    max_updates,
    max_connections,
    max_user_connections 
FROM
    mysql.user 
WHERE 
    User='" + user +  @"' 
AND 
    Host='" + host + "'";
            MySqlCommand cmmd;
            MySqlDataReader dr;
            try {
                bool hasRows = false;
                using (cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        hasRows = dr.HasRows;
                        int cnt1 = 0;
                        int cnt2 = 0;
                        int cnt3 = 0;
                        int _cnt1 = checkListDataGlob.Items.Count;
                        int _cnt2 = checkListStructureGlob.Items.Count;
                        int _cnt3 = checkListAdminGlob.Items.Count;
                        hItemCheckGlob = true;
                        while (dr.Read()) {
                            for (int i = 0; i < dr.FieldCount; ++i) {
                                string res = dr[i].ToString();
                                cnt1 += setPrivChaked(dr.GetName(i), res.Equals("Y"), checkListDataGlob);
                                cnt2 += setPrivChaked(dr.GetName(i), res.Equals("Y"), checkListStructureGlob);
                                cnt3 += setPrivChaked(dr.GetName(i), res.Equals("Y"), checkListAdminGlob);
                                
                            }
                            
                            checkDataGlob.Checked = cnt1 == _cnt1;
                            checkStructGlob.Checked = cnt2 == _cnt2;
                            checkAdminGlob.Checked = cnt3 == _cnt3;

                            labelUser = dr["User"].ToString();
                            labelHost = dr["Host"].ToString();
                            numMQ.Value = dr.GetInt32("max_questions");
                            numMU.Value = dr.GetInt32("max_updates");
                            numMC.Value = dr.GetInt32("max_connections");
                            numMUC.Value = dr.GetInt32("max_user_connections");
                            tab.SelectedIndex = 2;
                            isCreat = false;
                            break;
                        }
                        hItemCheckGlob = false;
                    }
                }
                if (!hasRows)
                    onErrorMessage("loadUserPriv()", MSGUserNotFound);
            } catch (Exception ex) {
                onErrorMessage("loadUserPriv()", ex.Message);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            string query = "";
            string user = textUserGlob.Text.Trim();
            string host = textHostGlob.Text.Trim();
            string pass = textPass.Text.Equals("") ? ";\n" : " IDENTIFIED BY '" + textPass.Text + "';\n";

            if (!isCreat)
                query = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "';\nREVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "';\n";
            else
                query = "CREATE USER '" + user + "'@'" + host + "'" + pass + " ";

            //code

            int cntItem = 0;
            cntItem += checkDataGlob.Checked ? 1 : 0;
            cntItem += checkStructGlob.Checked ? 1 : 0;
            cntItem += checkAdminGlob.Checked ? 1 : 0;

            if (cntItem == 3) {
                query += "GRANT ALL PRIVILEGES ON *.* TO '" + user + "'@'" + host + "';\nGRANT GRANT OPTION ON *.* TO '" + user + "'@'" + host + "' ";
            } else {
                string data = "";
                for (int i = 0; i < checkListDataGlob.Items.Count; ++i) {
                    if (!checkListDataGlob.GetItemChecked(i))
                        continue;
                    data += ", " + checkListDataGlob.Items[i].ToString();
                }

                for (int i = 0; i < checkListStructureGlob.Items.Count; ++i) {
                    if (!checkListStructureGlob.GetItemChecked(i))
                        continue;
                    data += ", " + checkListStructureGlob.Items[i].ToString();
                }

                for (int i = 0; i < checkListAdminGlob.Items.Count; ++i) {
                    if (!checkListAdminGlob.GetItemChecked(i))
                        continue;
                    if (checkListAdminGlob.Items[i].ToString().Equals("GRANT"))
                        data += ", GRANT OPTION";
                    else
                        data += ", " + checkListAdminGlob.Items[i].ToString();
                }
                if (!data.Equals(""))
                    query += "\nGRANT " + data.Remove(0, 1) + " ON *.* TO '" + user + "'@'" + host + "' ";
                else
                    query += "GRANT USAGE ON *.* TO '" + user + "'@'" + host + "' ";

            }
            query += "WITH ";
            query += "MAX_QUERIES_PER_HOUR " + numMQ.Value.ToString() + " ";
            query += "MAX_UPDATES_PER_HOUR " + numMU.Value.ToString() + " ";
            query += "MAX_CONNECTIONS_PER_HOUR " + numMC.Value.ToString() + " ";
            query += "MAX_USER_CONNECTIONS " + numMUC.Value.ToString() + ";";

            SQLPerview sqlp = new SQLPerview();
            sqlp.ReadOnlySQLText = true;
            sqlp.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlp.setSQLtext(query);
            sqlp.ShowDialog();
            if (sqlp.isSuccessExecuted) { 
                tab.SelectedIndex = 0;
                if (isCreat)
                    loadUserAccount();
            }
            sqlp.Dispose();
        }

        private void buttonCancelPriv_Click(object sender, EventArgs e) {
            if (Msg.WarrnQ(MSGConfrim) == DialogResult.No)
                return;
            ClearPrivilages();
            tab.SelectedIndex = 0;
            isCreat = false;
        }

        private void ClearPrivilages() {
            labelUser = "-";
            labelHost = "-";
            numMC.Value = 0;
            numMQ.Value = 0;
            numMU.Value = 0;
            numMUC.Value = 0;
            comboDB.Items.Clear();
            comboTB.Items.Clear();
            textHost.Clear();
            textPass.Clear();
            textUser.Clear();
            clearCheckGlob();
            clearCheckDb();
            clearCheckTb();
        }

        private bool hItemCheckGlob = false;
        private void _ItemCheckGlob(object sender, ItemCheckEventArgs e) {
            if (hItemCheckGlob)
                return;
            try {
                if (((CheckedListBox)sender).Name.Equals("checkListDataGlob")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListDataGlob.Items.Count; ++i) {
                        if (checkListDataGlob.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckGlob = true;
                    checkDataGlob.Checked = checkListDataGlob.Items.Count == cnt;
                    hItemCheckGlob = false;
                } else if (((CheckedListBox)sender).Name.Equals("checkListStructureGlob")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListStructureGlob.Items.Count; ++i) {
                        if (checkListStructureGlob.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckGlob = true;
                    checkStructGlob.Checked = checkListStructureGlob.Items.Count == cnt;
                    hItemCheckGlob = false;
                } else if (((CheckedListBox)sender).Name.Equals("checkListAdminGlob")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListAdminGlob.Items.Count; ++i) {
                        if (checkListAdminGlob.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckGlob = true;
                    checkAdminGlob.Checked = checkListAdminGlob.Items.Count == cnt;
                    hItemCheckGlob = false;
                }
            } catch (Exception ex) { Msg.Err(ex.Message); }
        }

        private void checkDataGlob_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckGlob)
                return;
            hItemCheckGlob = true;
            for (int i = 0; i < checkListDataGlob.Items.Count; ++i) {
                checkListDataGlob.SetItemChecked(i, checkDataGlob.Checked);
            }
            hItemCheckGlob = false;
        }

        private void checkStructGlob_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckGlob)
                return;
            hItemCheckGlob = true;
            for (int i = 0; i < checkListStructureGlob.Items.Count; ++i) {
                checkListStructureGlob.SetItemChecked(i, checkStructGlob.Checked);
            }
            hItemCheckGlob = false;
        }

        private void checkAdminGlob_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckGlob)
                return;
            hItemCheckGlob = true;
            for (int i = 0; i < checkListAdminGlob.Items.Count; ++i) {
                checkListAdminGlob.SetItemChecked(i, checkAdminGlob.Checked);
            }
            hItemCheckGlob = false;
        }

        private void clearCheckGlob() {
            hItemCheckGlob = true;
            checkDataGlob.Checked = false;
            checkStructGlob.Checked = false;
            checkAdminGlob.Checked = false;
            for (int i = 0; i < checkListDataGlob.Items.Count; ++i)
                checkListDataGlob.SetItemChecked(i, false);
            for (int i = 0; i < checkListStructureGlob.Items.Count; ++i)
                checkListStructureGlob.SetItemChecked(i, false);
            for (int i = 0; i < checkListAdminGlob.Items.Count; ++i)
                checkListAdminGlob.SetItemChecked(i, false);
            hItemCheckGlob = false;
        }
        #endregion


        #region priv db

        bool privIsExistDb = false;
        bool privGrantIsExistDb = false;
        private void loadUserPrivDb(string user, string host, string db) {
            string query =
@"SELECT 
    " + getColPrivFromArr(arrPrivDataDb) + @",
    " + getColPrivFromArr(arrPrivStructDb) + @",
    " + getColPrivFromArr(arrPrivAdminDb) + @",
    User,
    Host
FROM
    mysql.db 
WHERE 
    User='" + user + @"' 
AND 
    Host='" + host + @"' 
AND
    Db='" + db + "'";
            MySqlCommand cmmd;
            MySqlDataReader dr;
            try {
                using (cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        privIsExistDb = dr.HasRows;
                        int cnt1 = 0;
                        int cnt2 = 0;
                        int cnt3 = 0;
                        int _cnt1 = checkListDataDb.Items.Count;
                        int _cnt2 = checkListStructDb.Items.Count;
                        int _cnt3 = checkListAdminDb.Items.Count;
                        hItemCheckDb = true;
                        privGrantIsExistDb = false;
                        while (dr.Read()) {
                            for (int i = 0; i < dr.FieldCount; ++i) {
                                string res = dr[i].ToString();
                                if (dr.GetName(i).Equals("GRANT"))
                                    privGrantIsExistDb = res.Equals("Y");
                                cnt1 += setPrivChaked(dr.GetName(i), res.Equals("Y"), checkListDataDb);
                                cnt2 += setPrivChaked(dr.GetName(i), res.Equals("Y"), checkListStructDb);
                                cnt3 += setPrivChaked(dr.GetName(i), res.Equals("Y"), checkListAdminDb);
                            }

                            checkDataDb.Checked = cnt1 == _cnt1;
                            checkStructDb.Checked = cnt2 == _cnt2;
                            checkAdminDb.Checked = cnt3 == _cnt3;
                            break;
                        }
                        hItemCheckDb = false;
                    }
                }
            } catch (Exception ex) {
                onErrorMessage("loadUserPriv()", ex.Message);
            }
        }

        private bool hItemCheckDb = false;
        private void _ItemCheckDb(object sender, ItemCheckEventArgs e) {
            if (hItemCheckDb)
                return;
            try {
                if (((CheckedListBox)sender).Name.Equals("checkListDataDb")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListDataDb.Items.Count; ++i) {
                        if (checkListDataDb.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckDb = true;
                    checkDataDb.Checked = checkListDataDb.Items.Count == cnt;
                    hItemCheckDb = false;
                } else if (((CheckedListBox)sender).Name.Equals("checkListStructDb")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListStructDb.Items.Count; ++i) {
                        if (checkListStructDb.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckDb = true;
                    checkStructDb.Checked = checkListStructDb.Items.Count == cnt;
                    hItemCheckDb = false;
                } else if (((CheckedListBox)sender).Name.Equals("checkListAdminDb")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListAdminDb.Items.Count; ++i) {
                        if (checkListAdminDb.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckDb = true;
                    checkAdminDb.Checked = checkListAdminDb.Items.Count == cnt;
                    hItemCheckDb = false;
                }
            } catch (Exception ex) { Msg.Err(ex.Message); }
        }

        private void checkDataDb_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckDb)
                return;
            hItemCheckDb = true;
            for (int i = 0; i < checkListDataDb.Items.Count; ++i) {
                checkListDataDb.SetItemChecked(i, checkDataDb.Checked);
            }
            hItemCheckDb = false;
        }

        private void checkStructDb_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckDb)
                return;
            hItemCheckDb = true;
            for (int i = 0; i < checkListStructDb.Items.Count; ++i) {
                checkListStructDb.SetItemChecked(i, checkStructDb.Checked);
            }
            hItemCheckDb = false;
        }

        private void checkAdminDb_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckDb)
                return;
            hItemCheckDb = true;
            for (int i = 0; i < checkListAdminDb.Items.Count; ++i) {
                checkListAdminDb.SetItemChecked(i, checkAdminDb.Checked);
            }
            hItemCheckDb = false;
        }

        private void comboDB_SelectedIndexChanged(object sender, EventArgs e) {
            if (isCreat)
                return;
            if (comboDB.SelectedIndex < 0)
                return;
            clearCheckDb();
            loadUserPrivDb(labelUser, labelHost, comboDB.Text);
        }

        private void clearCheckDb() {
            hItemCheckDb = true;
            checkDataDb.Checked = false;
            checkStructDb.Checked = false;
            checkAdminDb.Checked = false;
            for (int i = 0; i < checkListDataDb.Items.Count; ++i)
                checkListDataDb.SetItemChecked(i, false);
            for (int i = 0; i < checkListStructDb.Items.Count; ++i)
                checkListStructDb.SetItemChecked(i, false);
            for (int i = 0; i < checkListAdminDb.Items.Count; ++i)
                checkListAdminDb.SetItemChecked(i, false);
            hItemCheckDb = false;
        }

        private void buttonApplyDb_Click(object sender, EventArgs e) {
            if (comboDB.SelectedIndex < 0) {
                Msg.Warrn(MSGSelDB);
                return;
            }

            
            string query = "";
            string user = labelUser.Trim();
            string host = labelHost.Trim();
            string pass = textPass.Text.Equals("") ? "" : " IDENTIFIED BY '" + textPass.Text + "'";
            bool revoke = privIsExistDb;
            string withGrant = privGrantIsExistDb ? ";\nREVOKE GRANT OPTION ON `" + comboDB.Text + "`.* FROM '" + user + "'@'" + host + "';" : ";";

            if (!isCreat) { 
                if (revoke)
                    query = "REVOKE ALL PRIVILEGES ON `" + comboDB.Text + "`.* FROM '" + user + "'@'" + host + "'" + withGrant + "\n";
            } else
                query = "CREATE USER '" + user + "'@'" + host + "'" + pass + " ";

            //code

            int cntItem = 0;
            cntItem += checkDataDb.Checked ? 1 : 0;
            cntItem += checkStructDb.Checked ? 1 : 0;
            cntItem += checkAdminDb.Checked ? 1 : 0;

            bool grantOption = false;

            if (cntItem == 3) {
                query += !isCreat ? "" : ";\n";
                query += "GRANT ALL PRIVILEGES ON `" + comboDB.Text + "`.* TO '" + user + "'@'" + host + "'";
                grantOption = true;
            } else {
                string data = "";
                for (int i = 0; i < checkListDataDb.Items.Count; ++i) {
                    if (!checkListDataDb.GetItemChecked(i))
                        continue;
                    data += ", " + checkListDataDb.Items[i].ToString();
                }

                for (int i = 0; i < checkListStructDb.Items.Count; ++i) {
                    if (!checkListStructDb.GetItemChecked(i))
                        continue;
                    data += ", " + checkListStructDb.Items[i].ToString();
                }

                for (int i = 0; i < checkListAdminDb.Items.Count; ++i) {
                    if (!checkListAdminDb.GetItemChecked(i))
                        continue;
                    if (i == 0)
                        grantOption = true;
                    else
                        data += ", " + checkListAdminDb.Items[i].ToString();
                }
                if (!data.Equals("")) {
                    query += !isCreat ? "" : ";\n";
                    query += "GRANT " + data.Remove(0, 1) + " ON `" + comboDB.Text + "`.* TO '" + user + "'@'" + host + "'";
                }

            }
            if (grantOption)
                query += " WITH GRANT OPTION;"; // do something*
            else
                query += ";";

            SQLPerview sqlp = new SQLPerview();
            sqlp.ReadOnlySQLText = true;
            sqlp.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlp.setSQLtext(query);
            sqlp.ShowDialog();
            if (sqlp.isSuccessExecuted) {
                tab.SelectedIndex = 0;
                if (isCreat)
                    loadUserAccount();
            }
            sqlp.Dispose();
        }

        private void buttonCancelDb_Click(object sender, EventArgs e) {
            ClearPrivilages();
            tab.SelectedIndex = 0;
        }

        #endregion

        #region priv Tb

        bool privIsExistTb = false;
        bool privGrantIsExistTb = false;
        private void loadUserPrivTb(string user, string host, string db, string tb) {
            string query =
@"SELECT 
    Table_priv,
    User,
    Host
FROM
    mysql.tables_priv
WHERE 
    User='" + user + @"' 
AND 
    Host='" + host + @"' 
AND
    Db='" + db + @"'
AND 
    Table_name='" + tb + "'";
            MySqlCommand cmmd;
            MySqlDataReader dr;
            try {
                using (cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        privIsExistTb = dr.HasRows;
                        int cnt1 = 0;
                        int cnt2 = 0;
                        int cnt3 = 0;
                        int _cnt1 = checkListDataTb.Items.Count;
                        int _cnt2 = checkListStructTb.Items.Count;
                        int _cnt3 = checkListAdminTb.Items.Count;
                        hItemCheckTb = true;
                        privGrantIsExistTb = false;
                        while (dr.Read()) {
                            string res = dr[0].ToString().ToUpper();
                            string[] resArr = res.Split(',');

                            for (int i = 0; i < resArr.Length; ++i) {
                                if (resArr[i].Equals("GRANT"))
                                    privGrantIsExistTb = true;
                                cnt1 += setPrivChaked(resArr[i], true, checkListDataTb);
                                cnt2 += setPrivChaked(resArr[i], true, checkListStructTb);
                                cnt3 += setPrivChaked(resArr[i], true, checkListAdminTb);
                            }

                            checkDataTb.Checked = cnt1 == _cnt1;
                            checkStructTb.Checked = cnt2 == _cnt2;
                            checkAdminTb.Checked = cnt3 == _cnt3;
                            break;
                        }
                        hItemCheckTb = false;
                    }
                }
            } catch (Exception ex) {
                onErrorMessage("loadUserPriv()", ex.Message);
            }
        }

        private bool hItemCheckTb = false;
        private void _ItemCheckTb(object sender, ItemCheckEventArgs e) {
            if (hItemCheckTb)
                return;
            try {
                if (((CheckedListBox)sender).Name.Equals("checkListDataTb")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListDataTb.Items.Count; ++i) {
                        if (checkListDataTb.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckTb = true;
                    checkDataTb.Checked = checkListDataTb.Items.Count == cnt;
                    hItemCheckTb = false;
                } else if (((CheckedListBox)sender).Name.Equals("checkListStructTb")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListStructTb.Items.Count; ++i) {
                        if (checkListStructTb.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckTb = true;
                    checkStructTb.Checked = checkListStructTb.Items.Count == cnt;
                    hItemCheckTb = false;
                } else if (((CheckedListBox)sender).Name.Equals("checkListAdminTb")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListAdminTb.Items.Count; ++i) {
                        if (checkListAdminTb.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    hItemCheckTb = true;
                    checkAdminTb.Checked = checkListAdminTb.Items.Count == cnt;
                    hItemCheckTb = false;
                }
            } catch (Exception ex) { Msg.Err(ex.Message); }
        }

        private void checkDataTb_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckTb)
                return;
            hItemCheckTb = true;
            for (int i = 0; i < checkListDataTb.Items.Count; ++i) {
                checkListDataTb.SetItemChecked(i, checkDataTb.Checked);
            }
            hItemCheckTb = false;
        }

        private void checkStructTb_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckTb)
                return;
            hItemCheckTb = true;
            for (int i = 0; i < checkListStructTb.Items.Count; ++i) {
                checkListStructTb.SetItemChecked(i, checkStructTb.Checked);
            }
            hItemCheckTb = false;
        }

        private void checkAdminTb_CheckedChanged(object sender, EventArgs e) {
            if (hItemCheckTb)
                return;
            hItemCheckTb = true;
            for (int i = 0; i < checkListAdminTb.Items.Count; ++i) {
                checkListAdminTb.SetItemChecked(i, checkAdminTb.Checked);
            }
            hItemCheckTb = false;
        }

        private void comboDBTb_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboDBTb.SelectedIndex < 0)
                return;
            loadTB(comboDBTb.Text);
        }

        private void comboTB_SelectedIndexChanged(object sender, EventArgs e) {
            if (isCreat)
                return;
            if (comboDBTb.SelectedIndex < 0)
                return;
            clearCheckTb();
            loadUserPrivTb(labelUser, labelHost, comboDBTb.Text, comboTB.Text);
        }

        private void clearCheckTb() {
            hItemCheckTb = true;
            checkDataTb.Checked = false;
            checkStructTb.Checked = false;
            checkAdminTb.Checked = false;
            for (int i = 0; i < checkListDataTb.Items.Count; ++i)
                checkListDataTb.SetItemChecked(i, false);
            for (int i = 0; i < checkListStructTb.Items.Count; ++i)
                checkListStructTb.SetItemChecked(i, false);
            for (int i = 0; i < checkListAdminTb.Items.Count; ++i)
                checkListAdminTb.SetItemChecked(i, false);
            hItemCheckTb = false;
        }

        private void buttonApplyTb_Click(object sender, EventArgs e) {
            if (comboDBTb.SelectedIndex < 0) {
                Msg.Warrn(MSGSelDB);
                return;
            }

            if (comboTB.SelectedIndex < 0) {
                Msg.Warrn("Select Table first");
                return;
            }

            string query = "";
            string user = labelUser.Trim();
            string host = labelHost.Trim();
            string pass = textPass.Text.Equals("") ? "" : " IDENTIFIED BY '" + textPass.Text + "'";
            bool revoke = privIsExistTb;
            string withGrant = privGrantIsExistTb ? ";\nREVOKE GRANT OPTION ON `" + comboDBTb.Text + "`.`" + comboTB.Text + "` FROM '" + user + "'@'" + host + "';" : ";";

            if (!isCreat) { 
                if (revoke)
                    query = "REVOKE ALL PRIVILEGES ON `" + comboDBTb.Text + "`.`" + comboTB.Text + "` FROM '" + user + "'@'" + host + "'" + withGrant + "\n";
            } else
                query = "CREATE USER '" + user + "'@'" + host + "'" + pass + " ";

            //code

            int cntItem = 0;
            cntItem += checkDataTb.Checked ? 1 : 0;
            cntItem += checkStructTb.Checked ? 1 : 0;
            cntItem += checkAdminTb.Checked ? 1 : 0;

            bool grantOption = false;

            if (cntItem == 3) {
                query += !isCreat ? "" : ";\n";
                query += "GRANT ALL PRIVILEGES ON `" + comboDBTb.Text + "`.`" + comboTB.Text + "` TO '" + user + "'@'" + host + "'";
                grantOption = true;
            } else {
                string data = "";
                for (int i = 0; i < checkListDataTb.Items.Count; ++i) {
                    if (!checkListDataTb.GetItemChecked(i))
                        continue;
                    data += ", " + checkListDataTb.Items[i].ToString();
                }

                for (int i = 0; i < checkListStructTb.Items.Count; ++i) {
                    if (!checkListStructTb.GetItemChecked(i))
                        continue;
                    data += ", " + checkListStructTb.Items[i].ToString();
                }

                for (int i = 0; i < checkListAdminTb.Items.Count; ++i) {
                    if (!checkListAdminTb.GetItemChecked(i))
                        continue;
                    if (checkListAdminTb.Items[i].ToString().Equals("GRANT"))
                        grantOption = true;
                    else
                        data += ", " + checkListAdminTb.Items[i].ToString();
                }
                if (!data.Equals("")) {
                    query += !isCreat ? "" : ";\n";
                    query += "GRANT " + data.Remove(0, 1) + " ON `" + comboDBTb.Text + "`.`" + comboTB.Text + "` TO '" + user + "'@'" + host + "'";
                }

            }

            if (grantOption)
                query += " WITH GRANT OPTION;"; // do something
            else
                query += ";";

            SQLPerview sqlp = new SQLPerview();
            sqlp.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlp.ReadOnlySQLText = true;
            sqlp.setSQLtext(query);
            sqlp.ShowDialog();
            if (sqlp.isSuccessExecuted) {
                tab.SelectedIndex = 0;
                if (isCreat)
                    loadUserAccount();
            }
            sqlp.Dispose();
        }

        #endregion

        private bool privIsExist(string SQL) {
            bool result = false;
            try {
                using (var cmmd = new MySqlCommand(SQL, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        result = dr.HasRows;
                    }
                }
            } catch (MySqlException ex) {
                onErrorMessage(MSGCheckUser, ex.Message);
            }
            return result;
        }

        private bool isCreat;

        private void gridTableGlob_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                contexMenu.Show(gridTable, e.X, e.Y);
                if (gridTable[e.ColumnIndex, e.RowIndex].Selected)
                    return;
                gridTable[e.ColumnIndex, e.RowIndex].Selected = true;
            }
        }

        private void comboDB_SelectedValueChanged(object sender, EventArgs e) {
            if (comboDB.SelectedIndex < 1) {
                return;
            }

            loadTB(comboDB.Text);
        }

        private void buttonPrivGlob_Click(object sender, EventArgs e) {
            tab.SelectedIndex = 2;
        }

        private void buttonPrivDb_Click(object sender, EventArgs e) {
            loadDB(comboDB);
            clearCheckDb();
            tab.SelectedIndex = 3;
        }

        private void buttonPrivTb_Click(object sender, EventArgs e) {
            comboTB.Items.Clear();
            loadDB(comboDBTb);
            clearCheckTb();
            tab.SelectedIndex = 4;
        }
    }
}
