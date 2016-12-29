using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlClientDotNET.DesignControls.UserPrivilegesNS {
    public partial class UserPrivileges : DynamicTabNS.DynamicTabPage {
        //DynamicTabNS.DynamicTabPage
        public UserPrivileges() {
            InitializeComponent();
            this.PageType = TabPageType.UserAccounts;
            this.Dock = DockStyle.Fill;
            tab.ItemSize = new Size(0, 0);
            loadUserAccount();
            hItemCheck = false;
            hcheckAll = false;
            cntItem = 0;
            checkListData.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._ItemCheck);
            checkListStructure.ItemCheck += new ItemCheckEventHandler(this._ItemCheck);
            checkListAdmin.ItemCheck += new ItemCheckEventHandler(this._ItemCheck);
        }

        #region Tab Grid User 1

        private void loadUserAccount() {
            gridTable.Rows.Clear();
            string query =
@"SELECT 
    User,
    Host 
FROM
    user";
            MySqlConnection cnn;
            MySqlCommand cmmd;
            MySqlDataReader dr;
            try {
                using (cnn = new MySqlConnection(MySqlConfig.ConnectionStringUseDatabase("mysql"))) {
                    using (cmmd = new MySqlCommand(query, cnn)) {
                        cnn.Open();
                        using (dr = cmmd.ExecuteReader()) {
                            while(dr.Read())
                                gridTable.Rows.Add(dr[0].ToString(),
                                               dr[1].ToString());
                        }
                        cnn.Close();
                    }
                }
            } catch (Exception ex) {
                Msg.Err("Error : " + ex.Message);
            }
        }

        private void editPrivilegesToolStripMenuItem_Click(object sender, EventArgs e) {
            loadUserPriv(gridTable.SelectedRows[0].Cells[0].Value.ToString(),
                         gridTable.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e) {

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
            SqlEditorNS.SqlEditorExecuteEventArgs arg = new SqlEditorNS.SqlEditorExecuteEventArgs();
            arg.LimitPage = 0;
            arg.SqlScript = command;
            arg.UniqueId = 0;
            if (ExecutSQL != null)
                ExecutSQL(this, arg);
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
    user 
WHERE 
    User='" + user +  @"' 
AND 
    Host='" + host + "'";
            MySqlCommand cmmd;
            MySqlDataReader dr;
            MySqlConnection cnn;
            try {
                bool hasRows = false;
                using (cnn = new MySqlConnection(MySqlConfig.ConnectionStringUseDatabase("mysql"))) {
                    using (cmmd = new MySqlCommand(query, cnn)) {
                        cnn.Open();
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
                        cnn.Close();
                    }
                }
                if (!hasRows)
                    Msg.Err("Error : user not found");
            } catch (Exception ex) {
                Msg.Err("Error : " + ex.Message);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            string query = "";
            string user = labelUser.Text.Trim();
            string host = labelHost.Text.Trim();
            string pass = labelPass.Text.Equals("-") ? "" : " IDENTIFIED BY '" + labelPass.Text.Trim() + "'";

            if (!isCreat)
                query = "REVOKE ALL PRIVILEGES ON *.* FROM '" + user + "'@'" + host + "'; REVOKE GRANT OPTION ON *.* FROM '" + user + "'@'" + host + "'; ";
            else
                query = "CREATE USER '" + user + "'@'" + host + "'" + pass + "; ";

            //code

            if (cntItem == 28) {
                query += "GRANT ALL PRIVILEGES ON *.* TO '" + user + "'@'" + host + "'; GRANT GRANT OPTION ON *.* TO '" + user + "'@'" + host + "' ";
            } else {
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
                    query += "GRANT " + data.Remove(0, 1) + " ON *.* TO '" + user + "'@'" + host + "' ";

            }
            query += "WITH ";
            query += "MAX_QUERIES_PER_HOUR " + numMQ.Value.ToString() + " ";
            query += "MAX_UPDATES_PER_HOUR " + numMU.Value.ToString() + " ";
            query += "MAX_CONNECTIONS_PER_HOUR " + numMC.Value.ToString() + " ";
            query += "MAX_USER_CONNECTIONS " + numMUC.Value.ToString() + ";";

            System.Diagnostics.Debug.WriteLine(query);


            SqlEditorNS.SqlEditorExecuteEventArgs arg = new SqlEditorNS.SqlEditorExecuteEventArgs();
            arg.LimitPage = 10;
            arg.SqlScript = query;
            arg.UniqueId = 0;
            if (ExecutSQL != null)
                ExecutSQL(this, arg);
            ClearPrivilages();
            tab.SelectedIndex = 0;
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

        public event EventHandler<SqlEditorNS.SqlEditorExecuteEventArgs> ExecutSQL;
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
    }
}
