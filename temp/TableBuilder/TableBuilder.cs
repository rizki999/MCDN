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

            //setTableBuilderDefault();

            tableBuilderMode = mode;

            this.Dock = DockStyle.Fill;
            this.PageType = TabPageType.TableBuilder;

            sqlPerview = new SQLPerview();

            initializeEditMode();
        }

        private void initializeEditMode() {
            if (tableBuilderMode == TableBuilderMode.AlterTable) {
                dCollAddTemp = new List<string>();
                tableInfo = new MySqlUtil.TableStoreInfos();
            }
        }

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


            MySqlConnection cnn;
            MySqlDataReader dr;
            MySqlCommand cmmd;

            //collation and engine

            if (collInfo == null)
                collInfo = new List<MySqlUtil.CollationStoreInfos>();
            //collInfo.Add(new MySqlUtil.CollationStoreInfos());
            //comboCollation.Items.Add("Default Database");
            string sql = "";
            try {
                using (cnn = new MySqlConnection(MySqlConfig.ConnectionStringUseDatabase("information_schema"))) {
                    //get collation
                    sql =
@"SELECT 
    CHARACTER_SET_NAME, 
    COLLATION_NAME, 
    IS_DEFAULT 
FROM 
    COLLATIONS";
                    int idx = 0;
                    int cnt = 0;
                    using (cmmd = new MySqlCommand(sql, cnn)) {
                        cnn.Open();
                        using (dr = cmmd.ExecuteReader()) {
                            while (dr.Read()) {
                                MySqlUtil.CollationStoreInfos coll = new MySqlUtil.CollationStoreInfos();
                                coll.CharSet = dr[0].ToString();
                                coll.Collation = dr[1].ToString();
                                coll.IsDefault = dr[2].ToString().Equals("Yes");
                                string temp = dr[1].ToString();
                                string tmpColl = dr[2].ToString().Equals("Yes") ? "Default" : temp;
                                if (temp.Equals(defDBCollation)) {
                                    tmpColl += " [Default Database]";
                                    idx = cnt;
                                }
                                comboCollation.Items.Add(dr[0].ToString() + " - " + tmpColl);
                                collInfo.Add(coll);
                                ++cnt;
                            }
                        }
                        comboCollation.SelectedIndex = idx;
                        cnn.Close();
                    }
                    System.Diagnostics.Debug.WriteLine("Collation \n combo : {0}\n coll : {1}",comboCollation.Items.Count, collInfo.Count);
                    //get engine
                    sql =
@"SELECT 
    ENGINE 
FROM 
    ENGINES 
WHERE 
    SUPPORT='DEFAULT' 
OR 
    SUPPORT='YES'";
                    using (cmmd = new MySqlCommand(sql, cnn)) {
                        cnn.Open();
                        using (dr = cmmd.ExecuteReader()) {
                            while (dr.Read()) 
                                comboEngine.Items.Add(dr.GetString(0));
                        }
                        cnn.Close();
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
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
        public SQLPerview sqlPerview;
        public TreeNode db_tree { get; set; }
        public TreeNode tb_tree { get; set; }

        public string DataBase {
            get {
                return lableSchema.Text;
            }
            set {
                lableSchema.Text = value;
                string db_coll_name = "";
                try {
                    string query =
    @"SELECT 
    DEFAULT_COLLATION_NAME 
FROM 
    SCHEMATA 
WHERE 
    SCHEMA_NAME='" + value + "'";
                    using (var cnn = new MySqlConnection(MySqlConfig.ConnectionStringUseDatabase("information_schema"))) {
                        using (var cmmd = new MySqlCommand(query, cnn)) {
                            cnn.Open();
                            using (var dr = cmmd.ExecuteReader()) {
                                while (dr.Read()) {
                                    db_coll_name = dr.GetString(0);
                                    break;
                                }
                            }
                            cnn.Close();
                        }
                    }
                } catch (MySqlException ex) { Msg.Err("Error get collation db : " + ex.Message); }
                defDBCollation = db_coll_name;
                setTableBuilderDefault();
            }
        }

        public void DataSource(string db, string tb) {
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

            DataBase = db;

            MySqlCommand cmmd;
            MySqlConnection cnn;
            MySqlDataReader dr;

            textTableName.Text = tb;
            lableSchema.Text = db;           

            string query = 
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
    KEYCOL.CONSTRAINT_NAME 
FROM 
    COLUMNS AS COL 
LEFT JOIN 
    KEY_COLUMN_USAGE AS KEYCOL 
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
            MySqlUtil.ReadDatas rDatas = new MySqlUtil.ReadDatas(MySqlConfig.ConnectionStringUseDatabase("information_schema"),
                                                                 query);

            System.Diagnostics.Debug.WriteLine("db : {0}\ntb : {1}", db, tb);
            while (rDatas.Read()) {
                var data = new MySqlUtil.ColumnStoreInfos();
                data.ColumnName = data.ColumnNameTemp = rDatas.Data[0].ToString();
                data.ColumnComment = rDatas.Data[1].ToString();
                data.DataType = rDatas.Data[2].ToString().ToUpper();
                data.Size = getDataTypeSize(rDatas.Data[3].ToString());
                data.isPrimary = rDatas.Data[4].ToString().Contains("PRI");
                data.isNotNULL = rDatas.Data[5].ToString().Contains("NO");
                data.isUnsigned = getContinColType(rDatas.Data[3].ToString(), "zerofill");
                data.isZeroFIll = getContinColType(rDatas.Data[3].ToString(), "unsigned");
                data.isAutoIncerement = rDatas.Data[6].ToString().Equals("auto_increment");
                data.isGeneretedColumn = rDatas.Data[6].ToString().Contains("GENERATED");
                data.DefaultORExpression = rDatas.Data[6].ToString().Contains("GENERATED") ? rDatas.Data[8].ToString() : rDatas.Data[7].ToString();
                data.VirtualORStore = rDatas.Data[6].ToString().Contains("VIRTUAL") || rDatas.Data[6].ToString().Contains("STORE") ? (rDatas.Data[6].ToString().Contains("VIRTUAL") ? "VIRTUAL" : "STORE") : "";
                data.ColumnMode = "NULL";
                data.ConstrineName = rDatas.Data[4].ToString().Contains("UNI") ? rDatas.Data[9].ToString() : "";
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
                                   data.VirtualORStore); // Virtual/Store
                
                colInfo.Add(data);
            }

            rDatas.Dispose();
            query =
@"SELECT 
    TBS.TABLE_COMMENT, 
    TBS.ENGINE, 
	COL.CHARACTER_SET_NAME,
    TBS.TABLE_COLLATION,
	COL.IS_DEFAULT 
FROM 
    TABLES AS TBS
LEFT JOIN
	COLLATIONS AS COL
ON
	TBS.TABLE_COLLATION=COL.COLLATION_NAME
WHERE 
    TBS.TABLE_SCHEMA='" + db + @"' 
AND 
    TBS.TABLE_NAME='" + tb + "';";
            rDatas = new MySqlUtil.ReadDatas(MySqlConfig.ConnectionStringUseDatabase("information_schema"),
                                             query);
            
            tableInfo.TableName = tb;
            tableInfo.DatabaseName = db;
            tableInfo.DatabaseEngine = MySqlConfig.DefaultStoreEngine;
            while (rDatas.Read()) {
                tableInfo.TableComment = rDatas.Data.GetString(0);
                tableInfo.TableEngine = rDatas.Data.GetString(1);
                tableInfo.CharsetName = rDatas.Data.GetString(2);
                tableInfo.CollationName = rDatas.Data.GetString(3);
                tableInfo.IsDefaultColl = rDatas.Data.GetString(4).Equals("Yes");
                break;
            }
            rDatas.Dispose();

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
                            MessageBox.Show("Column name is exist");
                            return false;

                        }
                    }
                }
            } else {
                MessageBox.Show("Fill column name");
                return false;
            }


            if (comboDataType.SelectedIndex == -1) {
                MessageBox.Show("Data type not selected");
                return false;
            }

            if (isDecimal()) {
                if (!textSize.Text.Equals("")) {
                    if (!isCorrctFormatSizeDecimal()) {
                        MessageBox.Show("Incorrect format size");
                        return false;
                    }
                }
            }

            if (isInteger()) {
                if (!textSize.Text.Equals("")) {
                    int tmp = 0;
                    if (!int.TryParse(textSize.Text, out tmp)) {
                        MessageBox.Show("Incorrect format size");
                        return false;
                    }
                }
            }

            if (isText()) {
                if (!textSize.Text.Equals("")) {
                    int tmp = 0;
                    if (!int.TryParse(textSize.Text, out tmp)) {
                        MessageBox.Show("Incorrect format size");
                        return false;
                    }
                }
            }

            if (isEnum()) {
                if (!textSize.Text.Equals("")) {
                    if (!isCorrctFormatSizeEnum()) {
                        MessageBox.Show("Incorrect format size");
                        return false;
                    }
                }
            }

            if (comboDefOrExp.SelectedIndex == 1) {
                if (textDefOrExp.Text.Equals("")) {
                    MessageBox.Show("Expression can not be empety");
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
                               storage);
            clearInput();
        }

        private void clearInput() {
            textColName.Text = string.Empty;
            textColComment.Text = string.Empty;
            textDefOrExp.Text = string.Empty;
            comboDataType.SelectedIndex = -1;
            comboDefOrExp.SelectedIndex = 0;
            radioStore.Checked = true;
        }

        private void buttonRemoveColumn_Click(object sender, EventArgs e) {
             if (!buttonRemoveColumn.Text.Equals("Remove Column")) {
                clearInput();
                buttonEditColumn.Text = "Edit Column";
                buttonRemoveColumn.Text = "Remove Column";
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
                    Msg.Warrn("Fill table name !");
                    return;
                }
                if (gridTable.RowCount == 0) {
                    Msg.Warrn("You have no collumn to alter table !");
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
                        dropCol += "\nDROP COLUMN `" + dTemp.ColumnName + "`, ";
                        if (dTemp.isPrimary)
                            dropPrimary = true;
                        dTemp = null;
                    }

                    if ((dTemp = getDataTempTable(gridTable[0, i].Value.ToString(), "E")) != null) {
                        if (isChangedColumn(i, dTemp)) {
                            changeCol += "\nCHANGE COLUMN `" + dTemp.ColumnName + "` `" + dTemp.ColumnNameTemp + "` ";
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
                        addCol += "\nADD COLUMN `" + gridTable[0, i].Value.ToString() + "` ";
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
                    Msg.Warrn("Table not changed");
                    return;
                }

                res = head + res.Remove(res.Length - 1, 1) + ";";

                System.Diagnostics.Debug.WriteLine(res);
                sqlPerview.ConnectionString = MySqlConfig.ConnectionStringUseDatabase(lableSchema.Text);
                sqlPerview.ActionMsg = "Alter Table";
                sqlPerview.setSQLtext(res);
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    List<string> lists = getColumnAttribForTree(lableSchema.Text, textTableName.Text);
                    if (lists.Count == 0) {
                        Msg.Warrn("alter table stetment executed but cannont get information the table");
                        return;
                    }
                    clearDataTemp();
                    DataSource(lableSchema.Text, textTableName.Text);
                    if (tb_tree != null) {
                        tb_tree.Nodes.Clear();
                        tb_tree.Text = textTableName.Text;
                        foreach (var list in lists) {
                            TreeNode node = new TreeNode(list, 2, 2);
                            tb_tree.Nodes.Add(node);
                        }
                        this.IsEdited = false;
                        this.TabHeaderText = "(T) " + textTableName.Text;
                    } else {
                        Msg.Err("The table not found it maybe deleted");
                        clearDataTemp();
                        Mode = TableBuilderMode.CreateTable;
                    }
                }
            } else {
                if (textTableName.Text.Equals("")) {
                    Msg.Warrn("Fill table name !");
                    return;
                }
                if (gridTable.RowCount == 0) {
                    Msg.Warrn("You have no collumn to create table !");
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
                    res += ",\nPRIMARY KEY (" + pri.Remove(pri.Length - 1, 1) + ")";
                res += "\n)";

                int idx = comboCollation.SelectedIndex;
                if (idx != 0) {
                    res += "\nCHARSET = " + collInfo[idx].CharSet;
                    if (!collInfo[idx].IsDefault) {
                        res += "\nCOLLATE = " + collInfo[idx].Collation;
                    }
                }

                int comboSialan = comboEngine.SelectedIndex;
                if (!comboEngine.Items[comboSialan].ToString().Equals(MySqlConfig.DefaultStoreEngine))
                    res += "\nENGINE = " + comboEngine.Items[comboSialan].ToString();

                if (!textTableComment.Text.Equals(string.Empty))
                    res += "\nCOMMENT = '" + textTableComment.Text + "'";

                if (res.Length != 0)
                    res = head + res + ";";

                sqlPerview.ConnectionString = MySqlConfig.ConnectionStringUseDatabase(lableSchema.Text);
                sqlPerview.ActionMsg = "Create Table " + lableSchema.Text + "." + textTableName.Text.Trim();
                sqlPerview.setSQLtext(res);
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    List<string> lists = getColumnAttribForTree(lableSchema.Text, textTableName.Text.Trim());
                    if (lists.Count == 0) {
                        Msg.Warrn("creat table stetment executed but cannont get information the table");
                        return;
                    }
                    TreeNode tNode = new TreeNode(textTableName.Text, 1, 1);
                    Mode = TableBuilderMode.AlterTable;
                    initializeEditMode();
                    DataSource(lableSchema.Text, textTableName.Text);
                    if (db_tree != null) {
                        foreach (var list in lists) {
                            TreeNode node = new TreeNode(list, 2, 2);
                            tNode.Nodes.Add(node);
                        }
                        tb_tree = tNode;
                        int idxN = -1;
                        int cnt = db_tree.Nodes.Count;
                        for (int i = 0; i < cnt; ++i) {
                            idxN = i;
                            if (string.Compare(db_tree.Nodes[i].Text, tNode.Text) >= 0)
                                break;
                        }
                        if ((cnt - 1) == idxN || cnt == 0)
                            db_tree.Nodes.Add(tNode);
                        else
                            db_tree.Nodes.Insert(idxN, tNode);
                        this.IsEdited = false;
                        this.TabHeaderText = "(T) " + textTableName.Text;
                    } else {
                        Msg.Err("The database not found it maybe deleted/moved this tab will be close");
                        this.ForceCloseTabPage();
                    }
                }
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
    COLUMNS 
WHERE
    TABLE_SCHEMA='" + db + @"' 
AND
    TABLE_NAME='" + tb + @"' 
ORDER BY 
    ORDINAL_POSITION 
ASC;";
                using (var cnn = new MySqlConnection(MySqlConfig.ConnectionStringUseDatabase("information_schema"))) {
                    using (var cmmd = new MySqlCommand(query, cnn)) {
                        cnn.Open();
                        using (var dr = cmmd.ExecuteReader()) {
                            while (dr.Read())
                                ls.Add(dr[0].ToString() + " " + dr[1].ToString());
                        }
                        cnn.Close();
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error add columns to table node : " + ex.Message);
            }

            return ls;
        }

        private void clearDataTemp() {
            tableInfo = new MySqlUtil.TableStoreInfos();
            colInfo.Clear();
            dCollAddTemp.Clear();
        }

        private string getAttribCol(int i, string mode) {
            string res = string.Empty;

            res += gridTable[2, i].Value.ToString();
            res += !gridTable[3, i].Value.ToString().Equals(string.Empty) ? "(" + gridTable[3, i].Value.ToString() + ")" : string.Empty;
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
            if (!dTemp.isUnsigned.Equals((bool)gridTable[7, i].Value)) 
                return true;
            if (!dTemp.isZeroFIll.Equals((bool)gridTable[8, i].Value)) 
                return true;
            if (!dTemp.isAutoIncerement.Equals((bool)gridTable[9, i].Value)) 
                return true;
            if (!dTemp.isGeneretedColumn.Equals((bool)gridTable[10, i].Value)) 
                return true;
            if (!dTemp.DefaultORExpression.Equals(gridTable[11, i].Value.ToString()))
                return true;
            if (!dTemp.VirtualORStore.Equals(gridTable[12, i].Value.ToString()))
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
            if (comboDataType.Items[index].ToString().StartsWith("-")) {
                comboDataType.SelectedIndex += 1;
            } else {
                textSize.Text = string.Empty;
                if (isInteger()) { //integer
                    listCheckConstraint.Items.Clear();
                    listCheckConstraint.Items.AddRange(IntegerConstrain);
                    return;
                }
                if (isDecimal()) { //decimal
                    listCheckConstraint.Items.Clear();
                    listCheckConstraint.Items.AddRange(decimalConstrain);
                    return;
                }
                //text/date/binary
                if (comboDataType.Items[comboDataType.SelectedIndex].ToString().StartsWith("VAR")) {
                    textSize.Text = "45";
                }
                listCheckConstraint.Items.Clear();
                listCheckConstraint.Items.AddRange(textConstrain);
            }
        }

        private void gridTable_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show("Error : " + e.Exception.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textSize_Leave(object sender, EventArgs e) {
            if (comboDataType.Items[comboDataType.SelectedIndex].ToString().StartsWith("VAR")) {
                if (textSize.Text.Length == 0) {
                    textSize.Text = "45";
                }
            }
            if (textSize.Text.Length == 0)
                return;
            if (isDecimal()) {
                if (!isCorrctFormatSizeDecimal()) {
                    MessageBox.Show("Incorrect format");
                    textSize.Select();
                }
            }
            if (isInteger() || isText()) {
                int tmp = 0;
                if (!int.TryParse(textSize.Text, out tmp)) {
                    MessageBox.Show("Incorrect format");
                    textSize.Select();
                }
            }
            if (isEnum()) {
                if (!isCorrctFormatSizeEnum()) {
                    MessageBox.Show("Incorrect format");
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
                DataSource(db, tb); 
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


        private void buttonEditColumn_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count <= 0) {
                return;
            }
            if (buttonEditColumn.Text.Equals("Edit Column")) {
                buttonEditColumn.Text = "Save Edit";
                buttonRemoveColumn.Text = "Discard Edit";

                buttonUpRow.Enabled = 
                    buttonDownRow.Enabled =
                    gridTable.Enabled = 
                    buttonAddColumn.Enabled = false;

                idxGrid = gridTable.SelectedRows[0].Index;
            } else {
                if (!checkInput(false)) {
                    return;
                }

                buttonEditColumn.Text = "Edit Column";
                buttonRemoveColumn.Text = "Remove Column";

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

                clearInput();

                return;
            }

            DataGridViewCellCollection rowCell = gridTable.SelectedRows[0].Cells;
            textColName.Text = rowCell[0].Value.ToString();
            textColComment.Text = rowCell[1].Value.ToString();
            selectComboItem(rowCell[2].Value.ToString(), comboDataType);
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
    }
}