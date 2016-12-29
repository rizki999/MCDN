using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using MySqlClientDotNET.DesignControls.DynamicTabNS;

namespace MySqlClientDotNET.DesignControls {
    public partial class TableBuilder : DynamicTabPage {
        //DynamicTabPage
        public TableBuilder(TableBuilderMode mode) {
            InitializeComponent();
            initializeDataType();
            initializeConstrain();

            try {
                buttonAddColumn.Image = Image.FromFile(ResourcesPath.img_col_a);
                buttonEditColumn.Image = Image.FromFile(ResourcesPath.img_col_e);
                buttonRemoveColumn.Image = Image.FromFile(ResourcesPath.img_col_d);
                buttonUpRow.Image = Image.FromFile(ResourcesPath.img_up_s);
                buttonDownRow.Image = Image.FromFile(ResourcesPath.img_down_S);
            } catch { }

            this.Dock = DockStyle.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(750, 474);

            tableInfo = new MySqlUtil.TableStoreInfos();
            tableBuilderMode = mode;

            this.Dock = DockStyle.Fill;
            this.PageType = TabPageType.TableBuilder;
        }

        public override void InitializedOnDynamicTab() {
            labelTbName.Text = LanguageApp.langTableBuilder["LBTBName"];
            labelTbCollation.Text = LanguageApp.langTableBuilder["LBTBColl"];
            labelTbComment.Text = LanguageApp.langTableBuilder["LBTBComment"];
            labelTbDatabse.Text = LanguageApp.langTableBuilder["LBTBDatabase"];
            labelTbEngine.Text = LanguageApp.langTableBuilder["LBTBEngine"];
            labelColName.Text = LanguageApp.langTableBuilder["LBColName"];
            labelColComment.Text = LanguageApp.langTableBuilder["LBColComment"];
            labelColCollate.Text = LanguageApp.langTableBuilder["LBColColl"];
            labelColDataType.Text = LanguageApp.langTableBuilder["LBColDataType"];
            labelColStorage.Text = LanguageApp.langTableBuilder["LBColStorage"];
            labelColLen.Text = LanguageApp.langTableBuilder["LBColLen"];

            groupBoxColumn.Text = LanguageApp.langTableBuilder["GBColumn"];

            buttonAddColumn.Text = LanguageApp.langTableBuilder["BTAddCol"];
            BTEditCol =
                buttonEditColumn.Text = LanguageApp.langTableBuilder["BTEditCol"];
            BTDelColumn =
                buttonRemoveColumn.Text = LanguageApp.langTableBuilder["BTDelColumn"];
            buttonUpRow.Text = LanguageApp.langTableBuilder["BTUpRow"];
            buttonDownRow.Text = LanguageApp.langTableBuilder["BTDownRow"];
            buttonApply.Text = LanguageApp.langTableBuilder["BTApply"];
            buttonRevert.Text = LanguageApp.langTableBuilder["BTRevert"];

            gridTable.Columns[0].HeaderText = LanguageApp.langTableBuilder["DGVColName"];
            gridTable.Columns[2].HeaderText = LanguageApp.langTableBuilder["DGVDataType"];

            MSGGetDbInfo = LanguageApp.langTableBuilder["MSGGetDbInfo"];
            MSGGetCollateInfo = LanguageApp.langTableBuilder["MSGGetCollateInfo"];
            MSGGetTbInfo = LanguageApp.langTableBuilder["MSGGetTbInfo"];
            MSGColIsExist = LanguageApp.langTableBuilder["MSGColIsExist"];
            MSGDataTypeNotSelected = LanguageApp.langTableBuilder["MSGFillColName"];
            MSGFillColName = LanguageApp.langTableBuilder["MSGFillColName"];
            MSGIncorectFormat = LanguageApp.langTableBuilder["MSGIncorectFormat"];
            MSGIncorectFormatLsVal = LanguageApp.langTableBuilder["MSGIncorectFormatLsVal"];
            MSGExFillListVal = LanguageApp.langTableBuilder["MSGExFillListVal"];
            MSGExpEmpty = LanguageApp.langTableBuilder["MSGExpEmpty"];
            MSGFillTbName = LanguageApp.langTableBuilder["MSGFillTbName"];
            MSGNoCol = LanguageApp.langTableBuilder["MSGNoCol"];
            MSGTBNoChange = LanguageApp.langTableBuilder["MSGTBNoChange"];
            MSGAlterTB = LanguageApp.langTableBuilder["MSGAlterTB"];
            MSGCannotGetInfo = LanguageApp.langTableBuilder["MSGCannotGetInfo"];
            MSGTBNotFoud = LanguageApp.langTableBuilder["MSGTBNotFoud"];
            MSGCreateTB = LanguageApp.langTableBuilder["MSGCreateTB"];
            MSGCannotGetInfoCr = LanguageApp.langTableBuilder["MSGCannotGetInfoCr"];
            BTEditCol = LanguageApp.langTableBuilder["BTEditCol"];
            BTDelColumn = LanguageApp.langTableBuilder["BTDelColumn"];
            BTSaveEdit = LanguageApp.langTableBuilder["BTSaveEdit"];
            BTCancelEdit = LanguageApp.langTableBuilder["BTCancelEdit"];
        }

        private string MSGGetDbInfo;
        private string MSGGetCollateInfo;
        private string MSGGetTbInfo;
        private string MSGColIsExist;
        private string MSGDataTypeNotSelected;
        private string MSGFillColName;
        private string MSGIncorectFormat;
        private string MSGIncorectFormatLsVal;
        private string MSGExFillListVal;
        private string MSGExpEmpty;
        private string MSGFillTbName;
        private string MSGNoCol;
        private string MSGTBNoChange;
        private string MSGAlterTB;
        private string MSGCannotGetInfo;
        private string MSGTBNotFoud;
        private string MSGCreateTB;
        private string MSGCannotGetInfoCr;
        private string BTEditCol;
        private string BTDelColumn;
        private string BTSaveEdit;
        private string BTCancelEdit;

        #region combo custom
        private void comboDataType_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index == -1)
                return;

            ComboBox combo = ((ComboBox)sender);
            using (SolidBrush brush = new SolidBrush(e.ForeColor)) {
                Font font = e.Font;
                switch (e.Index) {
                    case 0:
                    case 7:
                    case 11:
                    case 14:
                    case 19:
                    case 25:
                    case 28:
                    case 33:
                        font = new System.Drawing.Font(font, FontStyle.Bold);
                        break;
                }
                e.DrawBackground();
                e.Graphics.DrawString(combo.Items[e.Index].ToString(), font, brush, e.Bounds);
            }
        }
        #endregion

        private void initializeDataType() {
            listDataType = new string[] {
                "-Integer-",//0
                "BIT",
                "TINYINT",
                "SMALLINT",
                "MEDIUMINT",
                "INT",
                "BIGINT",
                "-Decimal-", //7
                "DECIMAL",
                "FLOAT",
                "DOUBLE",
                "-Character-",//11
                "CHAR",
                "VARCHAR",
                "-Text-", //14
                "TINYTEXT",
                "MEDIUMTEXT",
                "TEXT",
                "LONGTEXT",
                "-Date And Time-", //19
                "DATE",
                "TIME",
                "DATETIME",
                "TIMESTAMP",
                "YEAR",
                "-Binary-",//25
                "BINARY",
                "VARBINARY",
                "-Binary Large Object-", //28
                "TINYBLOB",
                "BLOB",
                "MEDIUMBLOB",
                "LONGBLOB",
                "-ENUM and SET-", //33
                "ENUM",
                "SET",
            };

            comboDataType.Items.AddRange(listDataType);
        }

        private void initializeConstrain() {
            decimalConstrain = new string[] {
                "Primary Key",
                "Not Null",
                "Unsigned",
                "Zero Fill",
                "Gnereted Column"
            };

            IntegerConstrain = new string[] {
                "Primary Key",
                "Not Null",
                "Unsigned",
                "Zero Fill",
                "Auto Increment",
                "Gnereted Column"
            };

            textConstrain = new string[] {
                "Primary Key",
                "Not Null",
                "Gnereted Column"
            };
        }

        private void setTableBuilderDefault() {
            for (int i = 2; i < gridTable.Columns.Count - 1; ++i) {
                gridTable.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridTable.Columns[i].HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            comboDefOrExp.SelectedIndex = 0;
            radioStore.Checked = true;

            //collation and engine

            if (collInfo == null)
                collInfo = new List<MySqlUtil.CollationStoreInfos>();
            else
                collInfo.Clear();
            string sql = "";
            try {
                //get collation
                comboColCollation.Items.Clear();
                comboCollation.Items.Clear();
                comboColCollation.Items.Add("Table Default");
                comboCollation.Items.Add("Database Default");
                comboCollation.SelectedIndex = 0;
                sql =
@"SELECT 
    CHARACTER_SET_NAME, 
    COLLATION_NAME, 
    IS_DEFAULT 
FROM 
    information_schema.COLLATIONS";
                int idx = 0;
                int cnt = 0;
                using (var cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            MySqlUtil.CollationStoreInfos coll = new MySqlUtil.CollationStoreInfos();
                            coll.CharSet = dr[0].ToString();
                            coll.Collation = dr[1].ToString();
                            coll.IsDefault = dr[2].ToString().Equals("Yes");
                            string temp = dr[1].ToString();
                            string tmpColl = dr[2].ToString().Equals("Yes") ? "Default" : temp;
                            comboCollation.Items.Add(dr[0].ToString() + " - " + tmpColl);
                            comboColCollation.Items.Add(dr[0].ToString() + " - " + tmpColl);
                            collInfo.Add(coll);
                            ++cnt;
                        }
                        dr.Close();
                    }
                    if (tableBuilderMode == TableBuilderMode.AlterTable) //if create
                        comboCollation.SelectedIndex = idx;
                }

                //get engine
                sql =
@"SELECT 
    ENGINE 
FROM 
    information_schema.ENGINES 
WHERE 
    SUPPORT='DEFAULT' 
OR 
    SUPPORT='YES'";
                using (var cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read())
                            comboEngine.Items.Add(dr.GetString(0));
                        dr.Close();
                    }
                }
            } catch (MySqlException ex) {
                onErrorMessage(MSGGetDbInfo, ex.Message);
            }
            selectCombo(MySqlConfig.DefaultStoreEngine, comboEngine);
        }

        private void selectCombo(string key, ComboBox combo) {
            for (int i = 0; i < combo.Items.Count; ++i) {
                if (combo.Items[i].Equals(key)) {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        #region Integer

        private bool isInteger() {
            if (comboDataType.SelectedIndex >= 0 && comboDataType.SelectedIndex < 7)
                return true;
            return false;
        }

        private bool isInteger(string key) {
            int index = -1;
            for (int i = 0; i < listDataType.Length; ++i) {
                if (listDataType[i].Equals(key)) {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            if (index >= 0 && index < 7)
                return true;
            return false;
        }

        #endregion

        #region Decimal

        private bool isDecimal() {
            if (comboDataType.SelectedIndex >= 7 && comboDataType.SelectedIndex < 11)
                return true;
            return false;
        }

        private bool isDecimal(string key) {
            int index = -1;
            for (int i = 0; i < listDataType.Length; ++i) {
                if (listDataType[i].Equals(key)) {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            if (index >= 7 && index < 11)
                return true;
            return false;
        }

        private bool isCorrctFormatSizeDecimal() {
            if (!textSize.Text.Equals("")) {
                string[] tmp = textSize.Text.Split(',');
                if (tmp.Length != 2 || (textSize.Text[0] == ',' || textSize.Text[textSize.Text.Length - 1] == ','))
                    return false;
                int x, y;
                if (!int.TryParse(tmp[0], out x) || !int.TryParse(tmp[1], out y))
                    return false;
            }

            return true;
        }

        #endregion

        #region Text

        private bool isText() {
            if (comboDataType.SelectedIndex >= 11 && comboDataType.SelectedIndex < 33)
                return true;
            return false;
        }

        private bool isText(string key) {
            int index = -1;
            for (int i = 0; i < listDataType.Length; ++i) {
                if (listDataType[i].Equals(key)) {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            if (index >= 11 && index < 33)
                return true;
            return false;
        }

        #endregion

        #region enumORset

        private bool isEnum() {
            if (comboDataType.SelectedIndex >= 33)
                return true;
            return false;
        }

        private bool isEnum(string key) {
            int index = -1;
            for (int i = 0; i < listDataType.Length; ++i) {
                if (listDataType[i].Equals(key)) {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            if (index >= 33)
                return true;
            return false;
        }

        private bool isCorrctFormatSizeEnum() {
            if (!textSize.Text.Equals("")) {
                string str = textSize.Text;
                string tmp = "";
                if (str.Length < 3)
                    return false;
                int count = 0;
                bool inQuote = false;
                List<string> lsStr = new List<string>();

                for (int i = 0; i < str.Length; ++i)
                    count += str[i] == '\'' ? 1 : 0;

                if (count % 2 != 0)
                    return false;

                str = removeSpace(str);

                if (str[0] == ',' || str[str.Length - 1] == ',')
                    return false;

                for (int i = 0; i < str.Length; ++i) {
                    if (str[i] == '\'')
                        inQuote = inQuote ? false : true;
                    if (str[i] == ',' && !inQuote) {
                        lsStr.Add(tmp);
                        tmp = "";
                        continue;
                    }
                    tmp += str[i];
                }
                lsStr.Add(tmp);

                for (int i = 0; i < lsStr.Count; ++i) {
                    if (lsStr[i].Length > 2) {
                        if (lsStr[i][0] != '\'' || lsStr[i][lsStr[i].Length - 1] != '\'')
                            return false;
                    } else
                        return false;
                }

            }
            return true;
        }

        private string removeSpace(string str) {
            bool inQuote = false;
            string res = "";
            for (int i = 0; i < str.Length; ++i) {
                if (str[i] == '\'')
                    inQuote = inQuote ? false : true;
                if (str[i] == ' ' && !inQuote)
                    continue;
                res += str[i];
            }

            return res;
        }

        #endregion

        private string[] decimalConstrain;
        private string[] IntegerConstrain;
        private string[] textConstrain;
        private string[] listDataType;
        private string defDBCollation;
        private List<MySqlUtil.ColumnStoreInfos> colInfo;
        private List<string> dCollAddTemp;
        private List<MySqlUtil.CollationStoreInfos> collInfo;
        private TableBuilderMode tableBuilderMode;
        private MySqlUtil.TableStoreInfos tableInfo;

        public event EventHandler<RefreshDBTreeEventArgs> RefreshTable;

        public string Table {
            get {
                return tableInfo.TableName;
            }
        }

        public string DataBase {
            get {
                return tableInfo.DatabaseName;
            }

            //create mode
            set {
                lableSchema.Text = value;
                tableInfo.DatabaseName = value;
                string db_coll_name = "";
                try {
                    string query =
@"SELECT 
    DEFAULT_COLLATION_NAME 
FROM 
    information_schema.SCHEMATA 
WHERE 
    SCHEMA_NAME='" + value + "'";
                    using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                        using (var dr = cmmd.ExecuteReader()) {
                            while (dr.Read()) {
                                db_coll_name = dr.GetString(0);
                                break;
                            }
                            dr.Close();
                        }
                    }

                } catch (MySqlException ex) { onErrorMessage(MSGGetCollateInfo, ex.Message); }
                defDBCollation = db_coll_name;
                setTableBuilderDefault();
            }
        }

        private void onTableRefresh(string db, string tbOld, string tbNew) {
            RefreshDBTreeEventArgs refresh = new RefreshDBTreeEventArgs();
            refresh.TableDatabaseName = db;
            refresh.TableNameNew = tbNew;
            refresh.TableNameOld = tbOld;
            if (RefreshTable != null)
                RefreshTable(this, refresh);
        }

        public void DataSource(string db, string tb) {
            DataBase = db; //initialize comboTableCollation/comboTableEngine/
            loadTable(db, tb);
        }

        private void loadTable(string db, string tb) {
            gridTable.Rows.Clear();
            if (colInfo != null)
                colInfo.Clear();
            else {
                System.Diagnostics.Debug.WriteLine("colInfo == null");
                colInfo = new List<MySqlUtil.ColumnStoreInfos>();
            }

            if (dCollAddTemp != null)
                dCollAddTemp.Clear();
            else {
                System.Diagnostics.Debug.WriteLine("dCollAddTemp == null");
                dCollAddTemp = new List<string>();
            }

            textTableName.Text = tb;
            lableSchema.Text = db;

            string query =
@"SELECT 
    TBS.TABLE_COMMENT, 
    TBS.ENGINE, 
	COL.CHARACTER_SET_NAME,
    TBS.TABLE_COLLATION,
	COL.IS_DEFAULT 
FROM 
    information_schema.TABLES AS TBS
LEFT JOIN
	information_schema.COLLATIONS AS COL
ON
	TBS.TABLE_COLLATION=COL.COLLATION_NAME
WHERE 
    TBS.TABLE_SCHEMA='" + db + @"' 
AND 
    TBS.TABLE_NAME='" + tb + "';";

            tableInfo.TableName = tb;
            tableInfo.DatabaseName = db;
            tableInfo.DatabaseEngine = MySqlConfig.DefaultStoreEngine;
            try {
                using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            tableInfo.TableComment = dr[0].ToString();
                            tableInfo.TableEngine = dr[1].ToString();
                            tableInfo.CharsetName = dr[2].ToString();
                            tableInfo.CollationName = dr[3].ToString();
                            tableInfo.IsDefaultColl = dr[4].ToString().Equals("Yes");
                            break;
                        }
                        dr.Close();
                    }
                }
            } catch (MySqlException ex) {
                onErrorMessage(MSGGetTbInfo, ex.Message);
            }

            textTableComment.Text = tableInfo.TableComment;

            tableInfo.DatabaseCollation = defDBCollation;

            if (tableInfo.TableEngine.Equals(MySqlConfig.DefaultStoreEngine))
                comboEngine.SelectedIndex = 0;
            else {
                for (int i = 0; i < comboEngine.Items.Count; ++i) {
                    if (comboEngine.Items[i].ToString().Equals(tableInfo.TableEngine)) {
                        comboEngine.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (tableInfo.CollationName.Equals(tableInfo.DatabaseCollation))
                comboCollation.SelectedIndex = 0;
            else {
                for (int i = 0; i < collInfo.Count; ++i) {
                    if (collInfo[i].Collation.Equals(tableInfo.CollationName)) {
                        comboCollation.SelectedIndex = i + 1;
                        break;
                    }
                }
            }

            query =
@"SELECT 
    COL.COLUMN_NAME, 
    COL.COLUMN_COMMENT, 
    COL.DATA_TYPE, 
    COL.COLUMN_TYPE, 
    COL.COLUMN_KEY, 
    COL.IS_NULLABLE, 
    COL.EXTRA, 
    COL.COLUMN_DEFAULT, 
    COL.GENERATION_EXPRESSION, 
    KEYCOL.CONSTRAINT_NAME,
    COL.CHARACTER_SET_NAME,
    COL.COLLATION_NAME 
FROM 
    information_schema.COLUMNS AS COL 
LEFT JOIN 
    information_schema.KEY_COLUMN_USAGE AS KEYCOL 
    ON 
        COL.TABLE_SCHEMA=KEYCOL.TABLE_SCHEMA 
    AND 
        COL.TABLE_NAME=KEYCOL.TABLE_NAME 
    AND 
        COL.COLUMN_NAME=KEYCOL.COLUMN_NAME 
WHERE 
    COL.TABLE_SCHEMA='" + db + @"' 
AND 
    COL.TABLE_NAME='" + tb + @"' 
ORDER BY 
    COL.ORDINAL_POSITION 
ASC;";
            try {
                using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            var data = new MySqlUtil.ColumnStoreInfos();
                            data.ColumnName = data.ColumnNameTemp = dr[0].ToString();
                            data.ColumnComment = dr[1].ToString();
                            data.DataType = dr[2].ToString().ToUpper();
                            data.Size = getDataTypeSize(dr[3].ToString());
                            data.isPrimary = dr[4].ToString().Contains("PRI");
                            data.isNotNULL = dr[5].ToString().Contains("NO");
                            data.isUnsigned = getContinColType(dr[3].ToString(), "zerofill");
                            data.isZeroFIll = getContinColType(dr[3].ToString(), "unsigned");
                            data.isAutoIncerement = dr[6].ToString().Equals("auto_increment");
                            data.isGeneretedColumn = dr[6].ToString().Contains("GENERATED");
                            data.DefaultORExpression = dr[6].ToString().Contains("GENERATED") ? dr[8].ToString() : dr[7].ToString();
                            data.VirtualORStore = dr[6].ToString().Contains("VIRTUAL") || dr[6].ToString().Contains("STORE") ? (dr[6].ToString().Contains("VIRTUAL") ? "VIRTUAL" : "STORE") : "";
                            data.CharSet = dr[10].ToString().Equals("NULL") ? "" : dr[10].ToString();
                            data.Collation = dr[11].ToString().Equals("NULL") ? "" : dr[11].ToString();
                            data.ColumnMode = "NULL";
                            data.ConstrineName = dr[4].ToString().Contains("UNI") ? dr[9].ToString() : "";
                            gridTable.Rows.Add(data.ColumnName,
                                                data.ColumnComment,
                                                data.DataType,
                                                data.Size,
                                                data.isPrimary, // primary key
                                                data.isNotNULL, //Not Null
                                                data.isUnsigned, // Unsigned
                                                data.isZeroFIll, // Zero fill
                                                data.isAutoIncerement, // AI
                                                data.isGeneretedColumn, // G
                                                data.DefaultORExpression, // Default/Expression
                                                data.VirtualORStore, // Virtual/Store
                                                data.CharSet,
                                                data.Collation);

                            colInfo.Add(data);
                        }
                        dr.Close();
                    }
                }
            } catch (MySqlException myEx) {
                Msg.Err("Error : " + myEx.Message);
            }
        }

        private string getDataTypeSize(string str) {
            string res = "";
            bool inBracket = false;
            for (int i = 0; i < str.Length; ++i) {
                if (str[i] == '(' || str[i] == ')') {
                    inBracket = inBracket ? false : true;
                    continue;
                }
                if (inBracket)
                    res += str[i];
            }
            return res;
        }

        private bool getContinColType(string ctype, string val) {
            int index = -1;
            if ((index = ctype.IndexOf(')')) == -1 || ctype.Length == 0)
                return false;
            string res = ctype.Remove(0, index);
            return res.Contains(val);
        }

        private bool checkInput(bool add) {
            if (!textColName.Text.Equals("")) {
                if (add) {
                    for (int i = 0; i < gridTable.Rows.Count; ++i) {
                        if (gridTable[i, 0].Value.ToString().Equals(textColName.Text)) {
                            MessageBox.Show(MSGColIsExist);
                            return false;

                        }
                    }
                }
            } else {
                MessageBox.Show(MSGFillColName);
                return false;
            }


            if (comboDataType.SelectedIndex == -1) {
                MessageBox.Show(MSGDataTypeNotSelected);
                return false;
            }

            if (isDecimal()) {
                if (!textSize.Text.Equals("")) {
                    if (!isCorrctFormatSizeDecimal()) {
                        MessageBox.Show(MSGIncorectFormat);
                        return false;
                    }
                }
            }

            if (isInteger()) {
                if (!textSize.Text.Equals("")) {
                    int tmp = 0;
                    if (!int.TryParse(textSize.Text, out tmp)) {
                        MessageBox.Show(MSGIncorectFormat);
                        return false;
                    }
                }
            }

            if (isText()) {
                if (!textSize.Text.Equals("")) {
                    int tmp = 0;
                    if (!int.TryParse(textSize.Text, out tmp)) {
                        MessageBox.Show(MSGIncorectFormat);
                        return false;
                    }
                }
            }

            if (isEnum()) {
                if (!textSize.Text.Equals("")) {
                    if (!isCorrctFormatSizeEnum()) {
                        Msg.Err(MSGIncorectFormatLsVal);
                        Msg.Info(MSGExFillListVal);
                        return false;
                    }
                }
            }

            if (comboDefOrExp.SelectedIndex == 1) {
                if (textDefOrExp.Text.Equals("")) {
                    MessageBox.Show(MSGExpEmpty);
                    return false;
                }
            }

            return true;
        }

        public TableBuilderMode Mode {
            get {
                return tableBuilderMode;
            }
            set {
                tableBuilderMode = value;
            }
        }

        private void buttonAddColumn_Click(object sender, EventArgs e) {
            if (!checkInput(true)) {
                return;
            }
            this.IsEdited = true;
            if (tableBuilderMode == TableBuilderMode.AlterTable)
                dCollAddTemp.Add(textColName.Text);

            string colName = textColName.Text;
            string colComment = textColComment.Text;
            string dataType = comboDataType.Text;
            string charset = "";
            string collate = "";
            bool primaryKey = listCheckConstraint.GetItemChecked(0);
            bool notNull = listCheckConstraint.GetItemChecked(1);
            bool unsigned = false;
            bool zeroFill = false;
            bool autoIncrement = false;

            if (isInteger()) {
                unsigned = listCheckConstraint.GetItemChecked(2);
                zeroFill = listCheckConstraint.GetItemChecked(3);
                autoIncrement = listCheckConstraint.GetItemChecked(4);
            }

            if (comboColCollation.SelectedIndex > 0) {
                int idx = comboColCollation.SelectedIndex - 1;
                charset = collInfo[idx].CharSet;
                collate = collInfo[idx].Collation;
            }

            if (isDecimal()) {
                unsigned = listCheckConstraint.GetItemChecked(2);
                zeroFill = listCheckConstraint.GetItemChecked(3);
                autoIncrement = listCheckConstraint.GetItemChecked(4);
            }

            bool genereted = comboDefOrExp.SelectedIndex == 1 ? true : false;
            string sdeforexp = textDefOrExp.Text;
            string storage = comboDefOrExp.SelectedIndex == 1 ? (radioStore.Checked ? "STORE" : "VIRTUAL") : "";

            gridTable.Rows.Add(colName,
                               colComment,
                               comboDataType.Text,
                               textSize.Text,
                               primaryKey,
                               notNull,
                               unsigned,
                               zeroFill,
                               autoIncrement,
                               genereted,
                               sdeforexp,
                               storage,
                               charset,
                               collate);
            clearInput();
        }

        private void clearInput() {
            textColName.Text = string.Empty;
            textColComment.Text = string.Empty;
            textDefOrExp.Text = string.Empty;
            comboDataType.SelectedIndex = -1;
            comboDefOrExp.SelectedIndex = 0;
            comboColCollation.Enabled = false;
            labelColLen.Text = LanguageApp.langTableBuilder["LBColLen"];
            comboColCollation.SelectedIndex = -1;
            radioStore.Checked = true;
        }

        private void buttonRemoveColumn_Click(object sender, EventArgs e) {
            if (!buttonRemoveColumn.Text.Equals(BTDelColumn)) {
                clearInput();
                buttonEditColumn.Text = BTEditCol;
                buttonRemoveColumn.Text = BTDelColumn;
                buttonUpRow.Enabled =
                    buttonDownRow.Enabled =
                    gridTable.Enabled =
                    buttonAddColumn.Enabled = true;

                return;
            }

            if (gridTable.Rows.Count <= 0)
                return;

            if (gridTable.SelectedRows.Count <= 0)
                return;
            if (tableBuilderMode == TableBuilderMode.AlterTable)
                setTempTableVal(gridTable[0, gridTable.SelectedRows[0].Index].Value.ToString(),
                                gridTable[0, gridTable.SelectedRows[0].Index].Value.ToString(),
                                "D");
            gridTable.Rows.RemoveAt(gridTable.SelectedRows[0].Index);

        }

        private void comboDefOrExp_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboDefOrExp.SelectedIndex == 0) {
                if (listCheckConstraint.Items.Count > 0)
                    listCheckConstraint.SetItemChecked(listCheckConstraint.Items.Count - 1, false);
                panStorage.Enabled = false;
            } else {
                if (listCheckConstraint.Items.Count > 0)
                    listCheckConstraint.SetItemChecked(listCheckConstraint.Items.Count - 1, true);
                panStorage.Enabled = true;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            textTableName.Text = textTableName.Text.Trim();
            if (tableBuilderMode == TableBuilderMode.AlterTable) {
                if (textTableName.Text.Equals("")) {
                    Msg.Warrn(MSGFillTbName);
                    return;
                }
                if (gridTable.RowCount == 0) {
                    Msg.Warrn(MSGNoCol);
                    return;
                }
                string addPrimary;
                string addCol, changeCol, dropCol;
                string head = "ALTER TABLE `" + lableSchema.Text + "`.`" + tableInfo.TableName + "` ";
                string res = "";

                addCol = string.Empty;
                changeCol = string.Empty;
                dropCol = string.Empty;
                addPrimary = string.Empty;

                MySqlUtil.ColumnStoreInfos dTemp = null;
                bool dropPrimary = false;
                bool priIsExist = false;
                bool isAddPri = false;

                for (int i = 0; i < colInfo.Count; ++i) {
                    if (priIsExist = colInfo[i].isPrimary)
                        break;
                }

                for (int i = 0; i < gridTable.Rows.Count; ++i) {

                    if ((dTemp = getDataTempTable(gridTable[0, i].Value.ToString(), "D")) != null) {
                        dropCol += "\n\tDROP COLUMN `" + dTemp.ColumnName + "`, ";
                        if (dTemp.isPrimary)
                            dropPrimary = true;
                        dTemp = null;
                    }

                    if ((dTemp = getDataTempTable(gridTable[0, i].Value.ToString(), "E")) != null) {
                        if (isChangedColumn(i, dTemp)) {
                            changeCol += "\n\tCHANGE COLUMN `" + dTemp.ColumnName + "` `" + dTemp.ColumnNameTemp + "` ";
                            changeCol += getAttribCol(i, dTemp.ColumnMode) + ",";
                        }
                        if (dTemp.isPrimary) {
                            if (!(bool)gridTable[4, i].Value)
                                dropPrimary = true;
                        } else {
                            if (((bool)gridTable[4, i].Value)) {
                                if (priIsExist)
                                    dropPrimary = true;
                                isAddPri = true;
                            }
                        }
                        dTemp = null;
                    }

                    if (isAddCol(gridTable[0, i].Value.ToString())) {
                        addCol += "\n\tADD COLUMN `" + gridTable[0, i].Value.ToString() + "` ";
                        addCol += getAttribCol(i, "A") + ",";
                        if (priIsExist && (bool)gridTable[4, i].Value)
                            dropPrimary = true;
                        if ((bool)gridTable[4, i].Value)
                            isAddPri = true;
                    }
                    if ((bool)gridTable[4, i].Value)
                        addPrimary += ",`" + gridTable[0, i].Value.ToString() + "`";

                }

                res += dropCol;
                res += changeCol;
                res += addCol;

                if (dropPrimary)
                    res += "\nDROP PRIMARY KEY,";
                if (isAddPri) {
                    if (addPrimary.Length != 0) {
                        addPrimary = addPrimary.Remove(0, 1);
                        res += "\nADD PRIMARY KEY (" + addPrimary + "),";
                    }
                }

                //char set
                int idx = comboCollation.SelectedIndex;
                if (idx > 0) {
                    idx = idx - 1;
                    if (collInfo[idx].CharSet.Equals(tableInfo.CharsetName)) {
                        if (!collInfo[idx].Collation.Equals(tableInfo.CollationName)) {
                            res += "\nCHARSET = " + collInfo[idx].CharSet + ",";
                            res += collInfo[idx].IsDefault ? "" : "\nCOLLATE = " + collInfo[idx].Collation + ",";
                        }
                    } else {
                        res += "\nCHARSET = " + collInfo[idx].CharSet + ",";
                        res += collInfo[idx].IsDefault ? "" : "\nCOLLATE = " + collInfo[idx].Collation + ",";
                    }
                }

                if (!tableInfo.TableEngine.Equals(comboEngine.Text))
                    res += "\nENGINE = " + comboEngine.Text + ",";
                if (!tableInfo.TableComment.Equals(textTableComment.Text))
                    res += "\nCOMMENT = '" + textTableComment.Text + "',";
                if (!tableInfo.TableName.Equals(textTableName.Text))
                    res += "\nRENAME TO `" + lableSchema.Text + "`.`" + textTableName.Text + "`,";

                if (res.Equals("")) {
                    Msg.Warrn(MSGTBNoChange);
                    return;
                }

                res = head + res.Remove(res.Length - 1, 1) + ";";

                System.Diagnostics.Debug.WriteLine(res);
                var sqlPerview = new SQLPerview();
                sqlPerview.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
                sqlPerview.MSGAction1 = MSGAlterTB;
                sqlPerview.setSQLtext(res);
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    List<string> lists = getColumnAttribForTree(lableSchema.Text, textTableName.Text);
                    if (lists.Count == 0) {
                        Msg.Warrn(MSGCannotGetInfo);
                        return;
                    }
                    clearDataTemp();

                    string oldTb, newTb, dbName;
                    dbName = tableInfo.DatabaseName;
                    oldTb = tableInfo.TableName;
                    newTb = textTableName.Text;

                    loadTable(dbName, newTb);

                    onTableRefresh(dbName,
                                   oldTb,
                                   newTb);

                    this.IsEdited = false;
                    this.TabHeaderText = "(T) " + textTableName.Text;
                }
                sqlPerview.Dispose();
            } else {
                if (textTableName.Text.Equals("")) {
                    Msg.Warrn(MSGFillTbName);
                    return;
                }
                if (gridTable.RowCount == 0) {
                    Msg.Warrn(MSGNoCol);
                    return;
                }

                string head = "CREATE TABLE `" + lableSchema.Text + "`.`" + textTableName.Text + "`(";
                string res = "";
                string pri = "";
                for (int i = 0; i < gridTable.RowCount; ++i) {
                    res += "\n\t`" + gridTable[0, i].Value.ToString() + "` ";
                    res += getAttribCol(i, "N") + ",";
                    if ((bool)gridTable[4, i].Value)
                        pri += "`" + gridTable[0, i].Value.ToString() + "`,";
                }

                res = res.Remove(res.Length - 1, 1);

                if (!pri.Equals(""))
                    res += ",\n\tPRIMARY KEY (" + pri.Remove(pri.Length - 1, 1) + ")";
                res += "\n)";

                int idx = comboCollation.SelectedIndex;
                if (idx > 0) {
                    idx = idx - 1;
                    if (!collInfo[idx].Collation.Equals(defDBCollation)) {
                        res += "\nCHARSET = " + collInfo[idx].CharSet;
                        if (!collInfo[idx].IsDefault) {
                            res += "\nCOLLATE = " + collInfo[idx].Collation;
                        }
                    }
                }
                int comboSialan = comboEngine.SelectedIndex;
                if (!comboEngine.Items[comboSialan].ToString().Equals(MySqlConfig.DefaultStoreEngine))
                    res += "\nENGINE = " + comboEngine.Items[comboSialan].ToString();

                if (!textTableComment.Text.Equals(string.Empty))
                    res += "\nCOMMENT = '" + textTableComment.Text + "'";

                if (res.Length != 0)
                    res = head + res + ";";

                var sqlPerview = new SQLPerview();
                sqlPerview.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
                sqlPerview.MSGAction1 = MSGCreateTB + lableSchema.Text + "." + textTableName.Text;
                sqlPerview.setSQLtext(res);
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    List<string> lists = getColumnAttribForTree(lableSchema.Text, textTableName.Text);
                    if (lists.Count == 0) {
                        Msg.Warrn(MSGCannotGetInfoCr);
                        return;
                    }
                    Mode = TableBuilderMode.AlterTable;
                    this.IsEdited = false;
                    this.TabHeaderText = "(T) " + textTableName.Text;
                    loadTable(lableSchema.Text, textTableName.Text);
                    onTableRefresh(tableInfo.DatabaseName,
                                   string.Empty,
                                   tableInfo.TableName);
                }
                sqlPerview.Dispose();
            }
        }

        private List<string> getColumnAttribForTree(string db, string tb) {
            var ls = new List<string>();
            try {
                string query =
@"SELECT 
    COLUMN_NAME,
    COLUMN_TYPE 
FROM 
    information_schema.COLUMNS 
WHERE
    TABLE_SCHEMA='" + db + @"' 
AND
    TABLE_NAME='" + tb + @"' 
ORDER BY 
    ORDINAL_POSITION 
ASC;";

                using (var cmmd = new MySqlCommand(query, AppConnection.Connection)) {
                    using (var dr = cmmd.ExecuteReader()) {
                        while (dr.Read())
                            ls.Add(dr[0].ToString() + " " + dr[1].ToString());
                        dr.Close();
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error add columns to table node : " + ex.Message);
            }

            return ls;
        }

        private void clearDataTemp() {
            colInfo.Clear();
            dCollAddTemp.Clear();
        }

        private string getAttribCol(int i, string mode) {
            string res = string.Empty;

            res += gridTable[2, i].Value.ToString();
            res += !gridTable[3, i].Value.ToString().Equals(string.Empty) ? "(" + gridTable[3, i].Value.ToString() + ")" : string.Empty;
            if (!gridTable[12, i].Value.ToString().Equals(string.Empty)) {
                int idx = 0;
                if ((idx = getIndexColColl(gridTable[13, i].Value.ToString())) != -1) {
                    res += " CHARSET '" + gridTable[12, i].Value.ToString() + "'";
                    if (!collInfo[idx].IsDefault)
                        res += " COLLATE '" + gridTable[13, i].Value.ToString() + "'";
                }
            }
            res += ((bool)gridTable[6, i].Value) ? " unsigned" : string.Empty; // unsigned
            res += ((bool)gridTable[7, i].Value) ? " zerofill" : string.Empty; // zerofill
            res += ((bool)gridTable[5, i].Value) ? " NOT NULL" : string.Empty; // NOT NULL
            res += ((bool)gridTable[8, i].Value) ? " AUTO_INCREMENT" : string.Empty; // AI

            if (!(bool)gridTable[9, i].Value) {
                if (!gridTable[10, i].Value.ToString().Equals("")) { //default
                    if (isInteger(gridTable[0, i].Value.ToString()) ||
                        isDecimal(gridTable[0, i].Value.ToString()) ||
                        gridTable[11, i].Value.ToString().Equals("NULL"))
                        res += " DEFAULT " + gridTable[10, i].Value.ToString();
                    else
                        res += " DEFAULT '" + gridTable[10, i].Value.ToString() + "'";
                }
            } else {
                res += " GENERATED ALWAYS AS (" + gridTable[10, i].Value.ToString() + ") ";
                res += gridTable[11, i].Value.ToString().Equals("STORE") ? "STORED" : "VIRTUAL";
            }

            res += !gridTable[1, i].Value.ToString().Equals(string.Empty) ? " COMMENT '" + gridTable[1, i].Value.ToString() + "'" : string.Empty;

            if (mode.Equals("EP") || mode.Equals("A"))
                res += (i > 0) ? " AFTER `" + gridTable[0, i - 1].Value.ToString() + "`" : " FIRST";
            return res;
        }

        private bool isChangedColumn(int i, MySqlUtil.ColumnStoreInfos dTemp) {
            if (dTemp.ColumnMode.Equals("EP"))
                return true;
            if (!dTemp.ColumnName.Equals(gridTable[0, i].Value.ToString()))
                return true;
            if (!dTemp.ColumnComment.Equals(gridTable[1, i].Value.ToString()))
                return true;
            if (!dTemp.DataType.Equals(gridTable[2, i].Value.ToString()))
                return true;
            if (!dTemp.Size.Equals(gridTable[3, i].Value.ToString()))
                return true;
            if (!dTemp.isNotNULL.Equals((bool)gridTable[5, i].Value))
                return true;
            if (!dTemp.isUnsigned.Equals((bool)gridTable[6, i].Value))
                return true;
            if (!dTemp.isZeroFIll.Equals((bool)gridTable[7, i].Value))
                return true;
            if (!dTemp.isAutoIncerement.Equals((bool)gridTable[8, i].Value))
                return true;
            if (!dTemp.isGeneretedColumn.Equals((bool)gridTable[9, i].Value))
                return true;
            if (!dTemp.DefaultORExpression.Equals(gridTable[10, i].Value.ToString()))
                return true;
            if (!dTemp.VirtualORStore.Equals(gridTable[11, i].Value.ToString()))
                return true;
            if (!dTemp.Collation.Equals(gridTable[13, i].Value.ToString()))
                return true;

            return false;
        }

        private bool isAddCol(string key) {
            for (int i = 0; i < dCollAddTemp.Count; ++i) {
                if (dCollAddTemp[i].Equals(key))
                    return true;
            }

            return false;
        }

        private MySqlUtil.ColumnStoreInfos getDataTempTable(string key, string val) {
            for (int i = 0; i < colInfo.Count; ++i) {
                if (colInfo[i].ColumnNameTemp.Equals(key) && colInfo[i].ColumnMode.Contains(val)) {
                    return colInfo[i];
                }
            }
            return null;
        }

        private void comboDataType_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboDataType.SelectedIndex == -1) {
                comboDefOrExp.Enabled = false;
                textSize.Text = string.Empty;
                listCheckConstraint.Items.Clear();
                return;
            }
            comboDefOrExp.Enabled = true;
            comboDefOrExp.SelectedIndex = 0;
            int index = comboDataType.SelectedIndex;
            labelColLen.Text = LanguageApp.langTableBuilder["LBColLen"];
            if (comboDataType.Items[index].ToString().StartsWith("-")) {
                comboDataType.SelectedIndex += 1;
            } else {
                textSize.Text = string.Empty;
                if (isInteger()) { //integer
                    listCheckConstraint.Items.Clear();
                    listCheckConstraint.Items.AddRange(IntegerConstrain);
                    comboColCollation.SelectedIndex = -1;
                    comboColCollation.Enabled = false;
                    return;
                }
                if (isDecimal()) { //decimal
                    listCheckConstraint.Items.Clear();
                    listCheckConstraint.Items.AddRange(decimalConstrain);
                    comboColCollation.SelectedIndex = -1;
                    comboColCollation.Enabled = false;
                    return;
                }
                //text/date/binary
                if (comboDataType.Items[comboDataType.SelectedIndex].ToString().StartsWith("VAR")) {
                    textSize.Text = "45";
                }

                if (isEnum()) {
                    labelColLen.Text = LanguageApp.langTableBuilder["LBColList"];
                }

                comboColCollation.SelectedIndex = 0;
                comboColCollation.Enabled = true;

                listCheckConstraint.Items.Clear();
                listCheckConstraint.Items.AddRange(textConstrain);
            }
        }

        private void gridTable_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            Msg.Err("Error : " + e.Exception.Message);
        }

        private void textSize_Leave(object sender, EventArgs e) {
            int idx = comboDataType.SelectedIndex;
            if (idx >= 0) {
                if (comboDataType.Items[idx].ToString().StartsWith("VAR")) {
                    if (textSize.Text.Length == 0) {
                        textSize.Text = "45";
                    }
                }
            }
            if (textSize.Text.Length == 0)
                return;
            if (isDecimal()) {
                if (!isCorrctFormatSizeDecimal()) {
                    Msg.Err(MSGIncorectFormat);
                    textSize.Select();
                }
            }
            if (isInteger() || isText()) {
                int tmp = 0;
                if (!int.TryParse(textSize.Text, out tmp)) {
                    Msg.Err(MSGIncorectFormat);
                    textSize.Select();
                }
            }
            if (isEnum()) {
                if (!isCorrctFormatSizeEnum()) {
                    Msg.Err(MSGIncorectFormatLsVal);
                    textSize.Select();
                }
            }
        }

        private void textSize_KeyPress(object sender, KeyPressEventArgs e) {
            if (comboDataType.SelectedIndex < 0)
                e.Handled = true;
            if (isDecimal()) {
                if (e.KeyChar == ',')
                    return;
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
                return;
            }

            if (isInteger() || isText()) {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
                return;
            }
        }

        private void textSize_KeyDown(object sender, KeyEventArgs e) {
            if (isDecimal()) {
                if (e.Modifiers == Keys.Control) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V) {
                    if (Clipboard.ContainsText()) {
                        System.Diagnostics.Debug.WriteLine(Clipboard.GetText());
                    }

                }
            }
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            if (Mode == TableBuilderMode.AlterTable) {
                string tb, db;
                tb = tableInfo.TableName;
                db = tableInfo.DatabaseName;
                loadTable(db, tb);
            } else {
                gridTable.Rows.Clear();
                comboCollation.SelectedIndex = 0;
                selectCombo(MySqlConfig.DefaultStoreEngine, comboEngine);
                textTableComment.Clear();
                textTableName.Clear();
            }
            this.IsEdited = false;
        }

        private int idxGrid;

        private void setTempTableVal(string key, string newKey, string mode) {
            for (int i = 0; i < colInfo.Count; ++i) {
                if (colInfo[i].ColumnNameTemp.Equals(key)) {
                    colInfo[i].ColumnNameTemp = newKey;
                    colInfo[i].ColumnMode = mode;
                    return;
                }
            }
            if (mode.Equals("D")) {
                for (int i = 0; i < dCollAddTemp.Count; ++i) {
                    if (dCollAddTemp[i].Equals(key)) {
                        dCollAddTemp.RemoveAt(i);
                        return;
                    }
                }
            }
            for (int i = 0; i < dCollAddTemp.Count; ++i) {
                if (dCollAddTemp[i].Equals(key)) {
                    dCollAddTemp[i] = newKey;
                    break;
                }
            }
        }

        private bool isEditedCol = false;
        private void buttonEditColumn_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count <= 0) {
                return;
            }
            if (buttonEditColumn.Text.Equals(BTEditCol)) {
                isEditedCol = true;
                buttonEditColumn.Text = BTSaveEdit;
                buttonRemoveColumn.Text = BTCancelEdit;

                buttonUpRow.Enabled =
                    buttonDownRow.Enabled =
                    gridTable.Enabled =
                    buttonAddColumn.Enabled = false;

                idxGrid = gridTable.SelectedRows[0].Index;

                DataGridViewCellCollection rowCell = gridTable.SelectedRows[0].Cells;
                textColName.Text = rowCell[0].Value.ToString();
                textColComment.Text = rowCell[1].Value.ToString();
                System.Diagnostics.Debug.WriteLine(rowCell[13].Value.ToString());
                selectComboItem(rowCell[2].Value.ToString(), comboDataType);
                if (Mode == TableBuilderMode.CreateTable)
                    comboColCollation.SelectedIndex = getIndexColColl(rowCell[13].Value.ToString()) + 1;
                else
                    comboColCollation.SelectedIndex = rowCell[13].Value.ToString().Equals(tableInfo.CollationName) ? 0 : getIndexColColl(rowCell[13].Value.ToString()) + 1;
                textSize.Text = rowCell[3].Value.ToString();
                listCheckConstraint.SetItemChecked(0, (bool)rowCell[4].Value);
                listCheckConstraint.SetItemChecked(1, (bool)rowCell[5].Value);
                if (isInteger()) {
                    listCheckConstraint.SetItemChecked(2, (bool)rowCell[6].Value);
                    listCheckConstraint.SetItemChecked(3, (bool)rowCell[7].Value);
                    listCheckConstraint.SetItemChecked(4, (bool)rowCell[8].Value);
                    listCheckConstraint.SetItemChecked(5, (bool)rowCell[9].Value);
                } else if (isDecimal()) {
                    listCheckConstraint.SetItemChecked(2, (bool)rowCell[6].Value);
                    listCheckConstraint.SetItemChecked(3, (bool)rowCell[7].Value);
                    listCheckConstraint.SetItemChecked(4, (bool)rowCell[8].Value);
                }

                textDefOrExp.Text = rowCell[10].Value.ToString();
                if (!rowCell[11].Value.ToString().Equals("")) {
                    panStorage.Enabled = true;
                    radioStore.Checked = rowCell[11].Value.ToString().Equals("STORE");
                    radioVirtual.Checked = rowCell[11].Value.ToString().Equals("VIRTUAL");
                }
            } else {
                if (!checkInput(false)) {
                    return;
                }
                isEditedCol = false;
                buttonEditColumn.Text = BTEditCol;
                buttonRemoveColumn.Text = BTDelColumn;

                buttonUpRow.Enabled =
                    buttonDownRow.Enabled =
                    gridTable.Enabled =
                    buttonAddColumn.Enabled = true;

                if (tableBuilderMode == TableBuilderMode.AlterTable) {
                    this.IsEdited = true;
                    setTempTableVal(gridTable[0, idxGrid].Value.ToString(),
                                    textColName.Text,
                                    "E");
                }

                string colName = textColName.Text;
                string colComment = textColComment.Text;
                string dataType = comboDataType.Text;
                string collate = "";
                string charset = "";
                bool primaryKey = listCheckConstraint.GetItemChecked(0);
                bool notNull = listCheckConstraint.GetItemChecked(1);
                bool unsigned = false;
                bool zeroFill = false;
                bool autoIncrement = false;

                if (isInteger()) {
                    unsigned = listCheckConstraint.GetItemChecked(2);
                    zeroFill = listCheckConstraint.GetItemChecked(3);
                    autoIncrement = listCheckConstraint.GetItemChecked(4);
                }

                if (isDecimal()) {
                    unsigned = listCheckConstraint.GetItemChecked(2);
                    zeroFill = listCheckConstraint.GetItemChecked(3);
                    autoIncrement = listCheckConstraint.GetItemChecked(4);
                }

                if (comboColCollation.SelectedIndex > 0) {
                    int idx = comboColCollation.SelectedIndex - 1;
                    collate = collInfo[idx].Collation;
                    charset = collInfo[idx].CharSet;
                }

                bool genereted = comboDefOrExp.SelectedIndex == 1 ? true : false;
                string sdeforexp = textDefOrExp.Text;
                string storage = comboDefOrExp.SelectedIndex == 1 ? (radioStore.Checked ? "STORE" : "VIRTUAL") : "";

                gridTable[0, idxGrid].Value = colName;
                gridTable[1, idxGrid].Value = colComment;
                gridTable[2, idxGrid].Value = comboDataType.Text;
                gridTable[3, idxGrid].Value = textSize.Text;
                gridTable[4, idxGrid].Value = primaryKey;
                gridTable[5, idxGrid].Value = notNull;
                gridTable[6, idxGrid].Value = unsigned;
                gridTable[7, idxGrid].Value = zeroFill;
                gridTable[8, idxGrid].Value = autoIncrement;
                gridTable[9, idxGrid].Value = genereted;
                gridTable[10, idxGrid].Value = sdeforexp;
                gridTable[11, idxGrid].Value = storage;
                gridTable[12, idxGrid].Value = charset;
                gridTable[13, idxGrid].Value = collate;
                clearInput();
                return;
            }
        }

        private int getIndexColColl(string coll) {
            if (coll.Equals(string.Empty))
                return -1;
            for (int i = 0; i < collInfo.Count; ++i) {
                if (coll.Equals(collInfo[i].Collation)) {
                    return i;
                }
            }
            return -1;
        }

        private void selectComboItem(string key, ComboBox com) {
            for (int i = 0; i < com.Items.Count; ++i) {
                if (com.Items[i].ToString().Equals(key.ToUpper())) {
                    com.SelectedIndex = i;
                    return;
                }
            }
            com.SelectedIndex = -1;
        }

        private void listCheckConstraint_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (listCheckConstraint.Items[e.Index].ToString().Equals("Gnereted Column")) {
                if (listCheckConstraint.GetItemChecked(e.Index)) { //if false
                    comboDefOrExp.SelectedIndex = 0;
                } else { //if true
                    comboDefOrExp.SelectedIndex = 1;
                    if (isInteger()) {
                        listCheckConstraint.SetItemChecked(e.Index - 1, false);
                        listCheckConstraint.SetItemChecked(1, false);
                    }
                }
            }
            if (listCheckConstraint.Items[e.Index].ToString().Equals("Auto Increment")) {
                if (!listCheckConstraint.GetItemChecked(e.Index)) { //if true
                    listCheckConstraint.SetItemChecked(e.Index + 1, false);
                    textDefOrExp.Text = "";
                }
            }
            if (listCheckConstraint.Items[e.Index].ToString().Equals("Primary Key")) {
                if (!listCheckConstraint.GetItemChecked(e.Index)) { //if true
                    listCheckConstraint.SetItemChecked(e.Index + 1, true);
                    textDefOrExp.Text = "";
                }
            }
        }

        private void buttonUpRow_Click(object sender, EventArgs e) {
            if (gridTable.RowCount > 0) {
                if (gridTable.SelectedRows.Count > 0) {
                    int rowCount = gridTable.Rows.Count;
                    int index = gridTable.SelectedCells[0].OwningRow.Index;

                    if (index == 0)
                        return;
                    this.IsEdited = true;
                    setTempTableVal(gridTable[0, index].Value.ToString(),
                                    gridTable[0, index].Value.ToString(),
                                    "EP");
                    DataGridViewRowCollection rows = gridTable.Rows;

                    DataGridViewRow prevRow = rows[index - 1];

                    rows.Remove(prevRow);
                    prevRow.Frozen = false;
                    rows.Insert(index, prevRow);
                    gridTable.ClearSelection();
                    gridTable.Rows[index - 1].Selected = true;
                }
            }
        }

        private void buttonDownRow_Click(object sender, EventArgs e) {
            if (gridTable.RowCount > 0) {
                if (gridTable.SelectedRows.Count > 0) {
                    int rowCount = gridTable.Rows.Count;
                    int index = gridTable.SelectedCells[0].OwningRow.Index;

                    if (index == (rowCount - 1))
                        return;
                    this.IsEdited = true;
                    setTempTableVal(gridTable[0, index].Value.ToString(),
                                    gridTable[0, index].Value.ToString(),
                                    "EP");
                    DataGridViewRowCollection rows = gridTable.Rows;
                    DataGridViewRow nextRow = rows[index + 1];
                    rows.Remove(nextRow);
                    nextRow.Frozen = false;
                    rows.Insert(index, nextRow);
                    gridTable.ClearSelection();
                    gridTable.Rows[index + 1].Selected = true;
                }
            }
        }

        private void textDefOrExp_TextChanged(object sender, EventArgs e) {
            if (isInteger()) {
                listCheckConstraint.SetItemChecked(listCheckConstraint.Items.Count - 2,
                                                   false);
            }
        }

        private void subMenuEditCol_Click(object sender, EventArgs e) {
            buttonEditColumn_Click(null, null);
        }

        private void subMenuDeleteCol_Click(object sender, EventArgs e) {
            buttonRemoveColumn_Click(null, null);
        }

        private void gridTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            buttonEditColumn_Click(null, null);
        }

        private void gridTable_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                gridTable.CurrentCell = gridTable[e.ColumnIndex, e.RowIndex];
                menuStripColumns.Show(Cursor.Position);
            }
        }
    }
}