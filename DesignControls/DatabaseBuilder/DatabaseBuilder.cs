using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlClientDotNET.DesignControls {
    public partial class DatabaseBuilder : DynamicTabNS.DynamicTabPage {
        //DynamicTabNS.DynamicTabPage
        public DatabaseBuilder() {
            InitializeComponent();
            this.Dock = DockStyle.None;
            this.AutoScrollMinSize = new Size(346, 195);
            this.PageType = TabPageType.DatabaseBuilder;
            collInfo = new List<MySqlUtil.CollationStoreInfos>();
            databaseName = "";
            alterIdxColl = 0;
            LoadCharset();
        }

        public override void InitializedOnDynamicTab() {
            language();
        }

        private void language() {
            groupBoxDBBuilder.Text = LanguageApp.langPanDBBuilder["GBDBBuilder"];

            labelDatabaseName.Text = LanguageApp.langPanDBBuilder["LBDatabaseName"];
            labelCollation.Text = LanguageApp.langPanDBBuilder["LBCollat"];
            labelHowToRename.Text = LanguageApp.langPanDBBuilder["LBHowTo"];

            buttonApply.Text = LanguageApp.langPanDBBuilder["BTApply"];
            buttonRevert.Text = LanguageApp.langPanDBBuilder["BTRevert"];

            MSGFill = LanguageApp.langPanDBBuilder["MSGFill"];
            MSGCollNotChanged = LanguageApp.langPanDBBuilder["MSGCollNotChange"];
            if (this.IsCreate) {
                this.TabHeaderText = "[" + LanguageApp.langPanDBBuilder["THDBBuilderNew"] + " " + this.UniqueId + " ]";
            }
        }

        private string MSGFill;
        private string MSGCollNotChanged;

        private bool isCreate;

        private int alterIdxColl;

        private MySqlCommand cmmd;
        private MySqlDataReader dr;

        private string databaseName;
        public event EventHandler<DesignControls.RefreshDBTreeEventArgs> RefreshTree;

        private List<MySqlUtil.CollationStoreInfos> collInfo;

        public bool IsCreate {
            get {
                return isCreate;
            }
            set {
                isCreate = value;
                if (!value) {
                    this.TabHeaderText = textSchema.Text;
                    this.IsEdited = false;
                } else
                    this.IsEdited = true;
                textSchema.Enabled = value;
                labelHowToRename.Visible = !value;
            }
        }

        public string DataBaseName {
            get {
                return databaseName;
            }

            set {
                databaseName = value;
            }
        }

        public void AlterDB(string db) {
            string sql =
@"SELECT 
    DEFAULT_CHARACTER_SET_NAME,
    DEFAULT_COLLATION_NAME 
FROM 
    information_schema.SCHEMATA
WHERE
    SCHEMA_NAME='" + db + "';";
            int cnt = 1;
            try {
                if (comboCollaction.Items.Count > 0) {
                    using (cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                        using (dr = cmmd.ExecuteReader()) {
                            while (dr.Read()) {
                                if (dr.GetString(0).Equals(MySqlConfig.CharSetName) &&
                                    dr.GetString(1).Equals(MySqlConfig.CollationName)) {
                                    cnt = 0;
                                    comboCollaction.SelectedIndex = 0;
                                    break;
                                } else if (dr.GetString(0).Equals(collInfo[cnt].CharSet) &&
                                            dr.GetString(1).Equals(collInfo[cnt].Collation)) {
                                    comboCollaction.SelectedIndex = cnt;
                                    alterIdxColl = cnt;
                                    break;

                                }
                                ++cnt;
                            }
                        }
                    }
                    comboCollaction.SelectedIndex = cnt;
                }
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            textSchema.Text = db;
        }

        private void onRefreshTree(string database) {
            DesignControls.RefreshDBTreeEventArgs r = new RefreshDBTreeEventArgs();
            r.DatabaseName = database;
            if (RefreshTree != null)
                RefreshTree(this, r);
        }

        private void ClearCollation() {
            comboCollaction.Items.Clear();
            collInfo.Clear();
        }

        private void LoadCharset() {
            string sql =
@"SELECT 
    CHARACTER_SET_NAME, 
    COLLATION_NAME, 
    IS_DEFAULT 
FROM 
    information_schema.COLLATIONS";

            ClearCollation();
            comboCollaction.Items.Add("Default Server");
            var tmpColl = new MySqlUtil.CollationStoreInfos();
            tmpColl.CharSet = "";
            tmpColl.Collation = "";
            tmpColl.IsDefault = false;
            collInfo.Add(tmpColl);
            try {
                using (cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            tmpColl = new MySqlUtil.CollationStoreInfos();
                            tmpColl.CharSet = dr[0].ToString();
                            tmpColl.Collation = dr[1].ToString();
                            tmpColl.IsDefault = dr[2].ToString().Equals("Yes");
                            collInfo.Add(tmpColl);
                            string stmpColl = dr[2].ToString().Equals("Yes") ? "Default" : dr[1].ToString();
                            comboCollaction.Items.Add(dr[0].ToString() + " - " + stmpColl);
                        }
                    }
                }
                if (comboCollaction.Items.Count > 0)
                    comboCollaction.SelectedIndex = 0;
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            textSchema.Text = textSchema.Text.Trim();
            if (textSchema.Text.Equals(string.Empty)) {
                Msg.Warrn(MSGFill);
                return;
            }

            if (IsCreate) {
                textSchema.Text = textSchema.Text.Trim();
                string sql = "CREATE DATABASE `" + textSchema.Text + "`";
                if (comboCollaction.SelectedIndex > 0) {
                    int i = comboCollaction.SelectedIndex;
                    if (collInfo[i].IsDefault) {
                        sql += " CHAR SET " + collInfo[i].CharSet;
                    } else {
                        sql += " CHAR SET " + collInfo[i].CharSet + " COLLATE " + collInfo[i].Collation;
                    }
                }
                sql += ";";

                var sqlPerview = new SQLPerview();
                sqlPerview.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
                sqlPerview.setSQLtext(sql);
                sqlPerview.MSGAction1 = "Create Database/Schema";
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    onRefreshTree(textSchema.Text);
                    databaseName = textSchema.Text;
                    this.IsCreate = false;
                    this.TabHeaderText = "(D) " + textSchema.Text;
                }
                sqlPerview.Dispose();
            } else {
                if (!IsEdited) {
                    Msg.Warrn(MSGCollNotChanged);
                    return;
                }
                string sql = "ALTER DATABASE `" + textSchema.Text + "`";
                if (comboCollaction.SelectedIndex > 0) {
                    int i = comboCollaction.SelectedIndex;
                    if (collInfo[i].IsDefault) {
                        sql += " CHAR SET " + collInfo[i].CharSet;
                    } else {
                        sql += " CHAR SET " + collInfo[i].CharSet + " COLLATE " + collInfo[i].Collation;
                    }
                }
                sql += ";";

                var sqlPerview = new SQLPerview();
                sqlPerview.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
                sqlPerview.setSQLtext(sql);
                sqlPerview.MSGAction1 = "Create Database/Schema";
                sqlPerview.ShowDialog();

                if (sqlPerview.isSuccessExecuted) {
                    this.IsCreate = false;
                }
            }
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            if (IsCreate) {
                textSchema.Clear();
                comboCollaction.SelectedIndex = 0;
            } else
                comboCollaction.SelectedIndex = alterIdxColl <= comboCollaction.SelectedIndex ? alterIdxColl : 0;
        }

        private void labelHowToRename_Click(object sender, EventArgs e) {
            var f = new FormHowToRenameDB();
            f.ShowDialog();
            f.Dispose();
        }

        private void comboCollaction_SelectedValueChanged(object sender, EventArgs e) {
            if (!this.IsCreate)
                this.IsEdited = alterIdxColl == comboCollaction.SelectedIndex ? false : true; 
        }
    }
    
}
