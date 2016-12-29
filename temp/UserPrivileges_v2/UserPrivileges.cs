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

namespace MySqlClientDotNET.DesignControls.UserPrivilegesNS {
    public partial class UserPrivileges : DynamicTabNS.DynamicTabPage {
        //DynamicTabNS.DynamicTabPage
        public UserPrivileges() {
            InitializeComponent();
            this.PageType = TabPageType.UserAccounts;
            this.Dock = DockStyle.Fill;
            tab.ItemSize = new Size(0, 1);
            hItemCheck = false;
            hcheckAll = false;
            cntItem = 0;
            checkListData.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._ItemCheck);
            checkListStructure.ItemCheck += new ItemCheckEventHandler(this._ItemCheck);
            checkListAdmin.ItemCheck += new ItemCheckEventHandler(this._ItemCheck);
        }

        private string scnnstr = "Data source=" + ResourcesPath.db_conn + "; Version=3;";

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
                            if (dr[0].ToString().Equals(MySqlConfig.Username) && dr[1].ToString().Equals(MySqlConfig.Host)) continue;
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
            loadUserPriv(gridTable.SelectedRows[0].Cells[0].Value.ToString(),
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
            string command = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "'; REVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "'; ";
            command += "DROP USER '" + user + "'@'" + host + "';";
            SQLPerview sqlp = new SQLPerview();
            sqlp.setSQLtext(command);
            sqlp.ShowDialog();
            sqlp.Dispose();
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            tab.SelectedIndex = 1;
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn("Select user on grid");
                return;
            }
            loadUserPriv(gridTable.SelectedRows[0].Cells[0].Value.ToString(),
                         gridTable.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn("Select user on grid");
                return;
            }

            string user = gridTable.SelectedRows[0].Cells[0].Value.ToString();
            string host = gridTable.SelectedRows[0].Cells[1].Value.ToString();
            string msg = "Are you sure wat to drop user '" + user + "'@'" + host + "'";
            if (Msg.WarrnQ(msg) == DialogResult.No)
                return;
            string command = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "'; REVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "'; ";
            command += "DROP USER '" + user + "'@'" + host + "';";
            SQLPerview sqlp = new SQLPerview();
            sqlp.setSQLtext(command);
            sqlp.ShowDialog();
            loadUserAccount();
            sqlp.Dispose();
        }



        private void buttonChangPassword_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count < 1) {
                Msg.Warrn("Select user on grid");
                return;
            }

            string user = gridTable.SelectedRows[0].Cells[0].Value.ToString();
            string host = gridTable.SelectedRows[0].Cells[1].Value.ToString();

            DesignControls.StartingPage.FormInputPassword fPasswd = new StartingPage.FormInputPassword();
            fPasswd.Text = "Change Password";
            fPasswd.passIsempety = true;
            fPasswd.ShowDialog();
            if (!fPasswd.IsOk)
                return;
            string passwd = fPasswd.textInput.Text.Replace("'", "");

            string command = "ALTER USER '" + user + "'@'" + host + "' IDENTIFIED BY '" + passwd + "';";

            SQLPerview sqlp = new SQLPerview();
            sqlp.ReadOnlySQLText = true;
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
                Msg.Warrn("Fill user !");
                return;
            }
            if (textHost.Text.Equals("")) {
                Msg.Warrn("Fill host or fill with '%' for any host !");
                return;
            }

            textUser.Text = textUser.Text.Replace("'", "");
            textHost.Text = textHost.Text.Replace("'", "");
            textPass.Text = textPass.Text.Replace("'", "");

            labelUser.Text = textUser.Text;
            labelHost.Text = textHost.Text;
            labelPass.Text = textPass.Text.Equals("") ? "-" : textPass.Text;

            isCreat = true;


            loadDB();
            loadDefTB();

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

        private void loadDB() {
            comboDB.Items.Clear();
            comboDB.Items.Add("*");
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
                            comboDB.Items.Add(db);
                        }
                    }
                }
            } catch (MySqlException ex) {
                onErrorMessage("loadDbTb()", ex.Message);
            }
            comboDB.SelectedIndex = 0;
        }

        private void loadTB(string tb) {
            comboTB.Items.Clear();
            comboTB.Items.Add("*");
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

        private void loadUserPriv(string user, string host) {
            string query =
@"SELECT 
    Select_priv,
    Insert_priv,
    Update_priv,
    Delete_priv,
    File_priv,
    Create_priv,
    Alter_priv,
    Index_priv,
    Drop_priv,
    Create_tmp_table_priv,
    Show_view_priv,
    Create_routine_priv,
    Alter_routine_priv,
    Execute_priv,
    Create_view_priv,
    Event_priv,
    Trigger_priv,
    Grant_priv,
    Super_priv,
    Process_priv,
    Reload_priv,
    Shutdown_priv,
    Show_db_priv,
    Lock_tables_priv,
    References_priv,
    Repl_client_priv,
    Repl_slave_priv,
    Create_user_priv,
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
                        int _cnt1 = 0;
                        int _cnt2 = 0;
                        int _cnt3 = 0;
                        hcheckAll = true;
                        hItemCheck = true;
                        while (dr.Read()) {
                            for (int i = 0; i < 28; ++i) {
                                string res = dr[i].ToString();
                                if (i >= 0 && i < 5) {
                                    checkListData.SetItemChecked(cnt1, res.Equals("Y"));
                                    if (res.Equals("Y")) {
                                        ++_cnt1;
                                        ++cntItem;
                                    }
                                    ++cnt1;
                                    continue;
                                } 
                                if (i >= 5 && i < 17) {
                                    checkListStructure.SetItemChecked(cnt2, res.Equals("Y"));
                                    if (res.Equals("Y")) {
                                        ++_cnt2;
                                        ++cntItem;
                                    }
                                    ++cnt2;
                                    continue;
                                }
                                if (i >= 17) {
                                    checkListAdmin.SetItemChecked(cnt3, res.Equals("Y"));
                                    if (res.Equals("Y")) {
                                        ++_cnt3;
                                        ++cntItem;
                                    }
                                    ++cnt3;
                                }
                            }

                            if (cnt1 == _cnt1)
                                checkData.Checked = true;
                            else
                                checkData.Checked = false;

                            if (cnt2 == _cnt2)
                                checkStruct.Checked = true;
                            else
                                checkStruct.Checked = false;

                            if (cnt3 == _cnt3)
                                checkAdmin.Checked = true;
                            else
                                checkAdmin.Checked = false;

                            if (checkData.Checked && checkAdmin.Checked && checkStruct.Checked)
                                checkAll.Checked = true;
                            else
                                checkAll.Checked = false;

                            labelUser.Text = dr[28].ToString();
                            labelHost.Text = dr[29].ToString();
                            numMQ.Value = dr.GetInt32(30);
                            numMU.Value = dr.GetInt32(31);
                            numMC.Value = dr.GetInt32(32);
                            numMUC.Value = dr.GetInt32(33);
                            tab.SelectedIndex = 2;
                            isCreat = false;
                            break;
                        }
                        hItemCheck = false;
                        hcheckAll = false;
                    }
                }
                if (!hasRows)
                    onErrorMessage("loadUserPriv()", "user not found");
            } catch (Exception ex) {
                onErrorMessage("loadUserPriv()", ex.Message);
            }
            loadDB();
            loadDefTB();
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            string query = "";
            string user = labelUser.Text.Trim();
            string host = labelHost.Text.Trim();
            string pass = labelPass.Text.Equals("-") ? "" : " IDENTIFIED BY '" + labelPass.Text.Trim() + "'";

            if (!isCreat)
                query = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "';\nREVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "'; ";
            else
                query = "CREATE USER '" + user + "'@'" + host + "'" + pass + " ";

            //code

            string _db, _tb;
            _db = "*";
            _tb = "*";

            if (comboDB.SelectedIndex > 0)
                _db = "`" + comboDB.Text + "`";
            if (comboTB.SelectedIndex > 0)
                _tb = "`" + comboTB.Text + "`";

            if (cntItem == 28) {
                if (!isCreat)
                    query += "GRANT USAGE ON *.* TO '" + user + "'@'" + host + "'; ";
                query += "\nGRANT ALL PRIVILEGES ON " + _db + "." + _tb + " TO '" + user + "'@'" + host + "';\nGRANT GRANT OPTION ON " + _db + "." + _tb + " TO '" + user + "'@'" + host + "' ";
            } else if (cntItem == 0) {
                query += "\nGRANT USAGE ON *.* TO '" + user + "'@'" + host + "' ";
            } else {
                if (!isCreat)
                    query += "\nGRANT USAGE ON *.* TO '" + user + "'@'" + host + "'; ";
                string data = "";
                for (int i = 0; i < checkListData.Items.Count; ++i) {
                    if (!checkListData.GetItemChecked(i))
                        continue;
                    data += ", " + checkListData.Items[i].ToString();
                }

                for (int i = 0; i < checkListStructure.Items.Count; ++i) {
                    if (!checkListStructure.GetItemChecked(i))
                        continue;
                    data += ", " + checkListStructure.Items[i].ToString();
                }

                for (int i = 0; i < checkListAdmin.Items.Count; ++i) {
                    if (!checkListAdmin.GetItemChecked(i))
                        continue;
                    if (i == 0)
                        data += ", GRANT OPTION";
                    else
                        data += ", " + checkListAdmin.Items[i].ToString();
                }
                if (!data.Equals(""))
                    query += "\nGRANT " + data.Remove(0, 1) + " ON *.* TO '" + user + "'@'" + host + "' ";

            }
            query += "WITH ";
            query += "MAX_QUERIES_PER_HOUR " + numMQ.Value.ToString() + " ";
            query += "MAX_UPDATES_PER_HOUR " + numMU.Value.ToString() + " ";
            query += "MAX_CONNECTIONS_PER_HOUR " + numMC.Value.ToString() + " ";
            query += "MAX_USER_CONNECTIONS " + numMUC.Value.ToString() + ";";

            SQLPerview sqlp = new SQLPerview();
            sqlp.setSQLtext(query);
            sqlp.ShowDialog();
            if (sqlp.isSuccessExecuted) { 
                tab.SelectedIndex = 0;
                if (isCreat)
                    loadUserAccount();
            }
            sqlp.Dispose();
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            if (Msg.WarrnQ("Are you sure ?") == DialogResult.No)
                return;
            ClearPrivilages();
            tab.SelectedIndex = 0;
            isCreat = false;
        }

        private void ClearPrivilages() {
            labelUser.Text = "-";
            labelHost.Text = "-";
            labelPass.Text = "-";
            numMC.Value = 0;
            numMQ.Value = 0;
            numMU.Value = 0;
            numMUC.Value = 0;
            checkAll.Checked = false;
            cntItem = 0;
            comboDB.Items.Clear();
            comboTB.Items.Clear();
            textHost.Clear();
            textPass.Clear();
            textUser.Clear();
        }

        private bool hItemCheck;
        private int cntItem;
        private void _ItemCheck(object sender, ItemCheckEventArgs e) {
            if (hItemCheck)
                return;
            if (e.NewValue == CheckState.Checked) {
                ++cntItem;
                if (cntItem > 28)
                    Msg.Err("over 28");
            } else {
                --cntItem;
                if (cntItem < 0)
                    Msg.Err("minus");
            }

            try {
                if (((CheckedListBox)sender).Name.Equals("checkListData")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListData.Items.Count; ++i) {
                        if (checkListData.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    if (checkListData.Items.Count == cnt) {
                        hcheckAll = true;
                        checkData.Checked = true;
                        hcheckAll = false;
                    } else {
                        hcheckAll = true;
                        checkData.Checked = false;
                        hcheckAll = false;
                    }
                } else if (((CheckedListBox)sender).Name.Equals("checkListStructure")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListStructure.Items.Count; ++i) {
                        if (checkListStructure.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    if (checkListStructure.Items.Count == cnt) {
                        hcheckAll = true;
                        checkStruct.Checked = true;
                        hcheckAll = false;
                    } else {
                        hcheckAll = true;
                        checkStruct.Checked = false;
                        hcheckAll = false;
                    }
                } else if (((CheckedListBox)sender).Name.Equals("checkListAdmin")) {
                    int cnt = 0;
                    for (int i = 0; i < checkListAdmin.Items.Count; ++i) {
                        if (checkListAdmin.GetItemChecked(i))
                            ++cnt;
                    }
                    cnt += e.NewValue == CheckState.Checked ? 1 : -1;
                    if (checkListAdmin.Items.Count == cnt) {
                        hcheckAll = true;
                        checkAdmin.Checked = true;
                        hcheckAll = false;
                    } else {
                        hcheckAll = true;
                        checkAdmin.Checked = false;
                        hcheckAll = false;
                    }
                }
            } catch (Exception ex) { Msg.Err(ex.Message); }

            if (cntItem == 28) {
                checkAll.Checked = true;
            } else {
                hcheckAll = true;
                checkAll.Checked = false;
                hcheckAll = false;
            }
        }

        private void loadDefTB() {
            comboTB.Items.Clear();
            comboTB.Items.Add("*");
            comboTB.SelectedIndex = 0;
        }

        private bool hcheckAll;
        private void checkAll_CheckedChanged(object sender, EventArgs e) {
            if (hcheckAll)
                return;
            checkData.Checked = checkAll.Checked;
            checkStruct.Checked = checkAll.Checked;
            checkAdmin.Checked = checkAll.Checked;
        }

        private void checkData_CheckedChanged(object sender, EventArgs e) {
            if (hcheckAll)
                return;
            hItemCheck = true;
            for (int i = 0; i < checkListData.Items.Count; ++i) {
                if (checkData.Checked) {
                    if (!checkListData.GetItemChecked(i))
                        ++cntItem;
                } else {
                    if (checkListData.GetItemChecked(i))
                        --cntItem;
                }
                checkListData.SetItemChecked(i, checkData.Checked);
            }
            hcheckAll = true;
            if (cntItem == 28)
                checkAll.Checked = true;
            else
                checkAll.Checked = false;
            hcheckAll = false;
            hItemCheck = false;
        }

        private void checkStruct_CheckedChanged(object sender, EventArgs e) {
            if (hcheckAll)
                return;
            hItemCheck = true;
            for (int i = 0; i < checkListStructure.Items.Count; ++i) {
                if (checkStruct.Checked) {
                    if (!checkListStructure.GetItemChecked(i))
                        ++cntItem;
                } else {
                    if (checkListStructure.GetItemChecked(i))
                        --cntItem;
                }
                checkListStructure.SetItemChecked(i, checkStruct.Checked);
            }
            hcheckAll = true;
            if (cntItem == 28)
                checkAll.Checked = true;
            else
                checkAll.Checked = false;
            hcheckAll = false;
            hItemCheck = false;
        }

        private void checkAdmin_CheckedChanged(object sender, EventArgs e) {
            if (hcheckAll)
                return;
            hItemCheck = true;
            for (int i = 0; i < checkListAdmin.Items.Count; ++i) {
                if (checkAdmin.Checked) {
                    if (!checkListAdmin.GetItemChecked(i))
                        ++cntItem;
                } else {
                    if (checkListAdmin.GetItemChecked(i))
                        --cntItem;
                }
                checkListAdmin.SetItemChecked(i, checkAdmin.Checked);
            }
            hcheckAll = true;
            if (cntItem == 28)
                checkAll.Checked = true;
            else
                checkAll.Checked = false;
            hcheckAll = false;
            hItemCheck = false;
        }
        #endregion

        private bool isCreat;

        private void gridTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
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
                loadDefTB();
                return;
            }
            loadTB(comboDB.Text);
        }
    }
}
