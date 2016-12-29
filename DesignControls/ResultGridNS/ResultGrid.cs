using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlClientDotNET;
using MySqlClientDotNET.DesignControls.DynamicTabNS;
using Microsoft.VisualBasic.FileIO;

namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    public partial class ResultGrid : DynamicTabPage {
        //DynamicTabPage
        public ResultGrid(OutGrid oGrid) {
            InitializeComponent();
            IsFromSqlBuilder = false;
            try {
                stripButtonAdd.Image = Image.FromFile(ResourcesPath.img_row_add_S);
                stripButtonDel.Image = Image.FromFile(ResourcesPath.img_rowd_del_S);
            } catch { }

            this.PageType = TabPageType.GridResult;

            //colMode1 = new List<string>();
            //colMode2 = new List<string>();
            colCount = 0;

            enableSqlLimit = true;
            SqlLimitPosUser = "";

            IndexPrimaryKey = new List<int>();

            isEditedCell = false;

            DatabaseAndTableName = "";

            sqlText = "";
            sqlLimitCount = 50;

            listDelRows = new List<List<string>>();
            listAddRow = new List<int>();
            listEditRows = new List<EditRow>();

            GridMode = oGrid;
            language();
        }

        private void language() {
            stripButtonAdd.Text = LanguageApp.langResultGrid["BTAdd"];
            stripButtonDel.Text = LanguageApp.langResultGrid["BTDel"];
            stripButtonExportImport.Text = LanguageApp.langResultGrid["BTExportImport"];
            buttonExportCSV.Text = LanguageApp.langResultGrid["BTExport"];
            buttonImportCSV.Text = LanguageApp.langResultGrid["BTImport"];
            buttonUpPage.Text = LanguageApp.langResultGrid["BTUp"];
            buttonDownPage.Text = LanguageApp.langResultGrid["BTDown"];
            buttonMode.Text = LanguageApp.langResultGrid["BTMode"];
            buttonInsertOnly.Text = LanguageApp.langResultGrid["BTInsertOnly"];
            buttonReadOnly.Text = LanguageApp.langResultGrid["BTReadOnly"];
            buttonApply.Text = LanguageApp.langResultGrid["BTApply"];
            buttonRevert.Text = LanguageApp.langResultGrid["BTRevert"];

            contexMenuOpenFile.Text = LanguageApp.langResultGrid["CMOpenFile"];
            contexMenuDeleteRows.Text = LanguageApp.langResultGrid["CMDelRow"];
            contexMenuNewRow.Text = LanguageApp.langResultGrid["CMNewRow"];
            contexMenuEditCell.Text = LanguageApp.langResultGrid["CMEditCell"];
            contexMenuCopySelectedRows.Text = LanguageApp.langResultGrid["CMCopySelRow"];
            contexMenuCopyCellValue.Text = LanguageApp.langResultGrid["CMCopySelCell"];

            labelPage.Text = LanguageApp.langResultGrid["LBPage"];

            checkBoxIgnorePri.Text = LanguageApp.langResultGrid["CBIgnorePri"];

            MSGSelRowDel = LanguageApp.langResultGrid["MSGSelRowDel"];
            MSGTbNotChanged = LanguageApp.langResultGrid["MSGTbNotChanged"];
            MSGNothingToExec = LanguageApp.langResultGrid["MSGNothingToExec"];
            MSGApplyEdit = LanguageApp.langResultGrid["MSGApplyEdit"];
            MSGApplyInsert = LanguageApp.langResultGrid["MSGApplyInsert"];
            MSGOneOrMoreFailed = LanguageApp.langResultGrid["MSGOneOrMoreFailed"];
            MSGWarnIgnoreEdit = LanguageApp.langResultGrid["MSGWarnIgnoreEdit"];
            MSGWarnSelCell = LanguageApp.langResultGrid["MSGWarnSelCell"];
        }

        private string MSGSelRowDel;
        private string MSGTbNotChanged;
        private string MSGNothingToExec;
        private string MSGApplyEdit;
        private string MSGApplyInsert;
        private string MSGOneOrMoreFailed;
        private string MSGWarnIgnoreEdit;
        private string MSGWarnSelCell;

        private List<List<string>> listDelRows;
        private List<int> listAddRow;
        private List<EditRow> listEditRows;

        private MySqlDataReader dr;
        private MySqlCommand cmmd;
        private List<ResultGridColumnInfo> columnInfos;

        private int colCount;

        private string sqlText;
        private int sqlLimitCount;
        private bool enableSqlLimit;

        public bool IsFromSqlBuilder {
            get {
                return buttonMode.Visible;
            }

            set {
                buttonMode.Visible = value;
            }
        }

        public string DatabaseAndTableName { get; set; }

        public List<int> IndexPrimaryKey { get; set; }

        public string SqlLimitPosUser { get; set; }
        public bool EnableSqlLimit {
            get {
                return enableSqlLimit;
            }
            set {
                buttonUpPage.Enabled = value;
                buttonDownPage.Enabled = value;
                enableSqlLimit = value;
            }
        }

        private OutGrid outGrid;
        public OutGrid GridMode {
            get {
                return outGrid;
            }

            set {
                outGrid = value;
                switch (outGrid) {
                    case OutGrid.ExecutedFromSQLTextEdit:
                        setUpExecutedFromSQL();
                        break;
                    case OutGrid.ExecutedFromSQLBuilder:
                        setUpExecutedFromSQLBuilder();
                        break;
                    case OutGrid.ExecutedFromSQLBuilderInsertOnly:
                        setUpExecutedFromSQLBuilderInsertOnly();
                        break;
                    case OutGrid.ExecutedFromSQLBuilderRead:
                        setUpExecutedFromSQL();
                        buttonMode.Visible = true;
                        break;
                }
            }
        }

        public int SqlLimit {
            get {
                return sqlLimitCount;
            }
            set {
                sqlLimitCount = value;
            }
        }

        public void DataSource(string sql) {
            this.sqlText = sql;
            columnInfos = new List<ResultGridColumnInfo>();
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {// pimary/nonprimary
                showDataOnGrid();
            } else if (outGrid == OutGrid.ExecutedFromSQLBuilderInsertOnly) {
                showDataOnGridInsertOnly();
            } else if (outGrid == OutGrid.ExecutedFromSQLTextEdit) { // readonly 
                showDataOnGrid();
            }
        }

        private void showDataOnGrid() {
            string sqll = "";

            if (enableSqlLimit) {
                string limit_x;
                if (!SqlLimitPosUser.Equals("")) { //jika limit ditentukan oleh user dengan script
                    limit_x = SqlLimitPosUser;
                    labelNumPage.Text = "0";
                } else { //jika limit ditentukan dengan programmatic
                    limit_x = "0";
                    labelNumPage.Text = "1";
                }
                string limit_y = sqlLimitCount.ToString();
                string sqlTextLimit = sqlText + " LIMIT " + limit_x + ", " + limit_y;
                sqll = sqlTextLimit;
            } else { //if command nonselect
                sqll = sqlText;
            }

            initializeGrid(sqll);
        }

        private void buttonDownPage_Click(object sender, EventArgs e) {
            if (gridTable.RowCount == 0)
                return;
            moveData(1);
        }

        private void buttonUpPage_Click(object sender, EventArgs e) {
            if (labelNumPage.Text.Equals("0") ||
                labelNumPage.Text.Equals("1")) {
                return;
            }
            moveData(-1);
        }

        private void moveData(int move) {
            ClearTempData();
            string limitSQL = sqlText;
            int idx = Convert.ToInt32(labelNumPage.Text) - 1;
            int limit;
            idx = idx + move;
            labelNumPage.Text = (idx + 1).ToString();
            limit = idx * sqlLimitCount;
            limitSQL += " LIMIT " + limit.ToString() + ", " + sqlLimitCount;
            try {
                using (cmmd = new MySqlCommand(limitSQL, AppConnection.Connection)) {
                    List<string> lsCol = new List<string>();
                    using (dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            for (int i = 0; i < dr.FieldCount; ++i) {
                                lsCol.Add(setValueOnGrid(i, dr[i], dr.IsDBNull(i)));
                            }
                            gridTable.Rows.Add(lsCol.ToArray());
                            lsCol.Clear();
                        }
                    }
                }
            } catch (Exception ex) {
                OnError("moveData() ", ex.Message);
            }

        }

        private void loadCurrentData() {
            ClearTempData();
            string limitSQL = sqlText;
            int idx = (Convert.ToInt32(labelNumPage.Text) - 1) < 0 ? 0 : (Convert.ToInt32(labelNumPage.Text) - 1);
            int limit;
            limit = idx * sqlLimitCount;
            limitSQL += " LIMIT " + limit.ToString() + ", " + sqlLimitCount;
            try {
                using (cmmd = new MySqlCommand(limitSQL, AppConnection.Connection)) {
                    List<string> lsCol = new List<string>();
                    using (dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            for (int i = 0; i < dr.FieldCount; ++i) {
                                lsCol.Add(setValueOnGrid(i, dr[i], dr.IsDBNull(i)));
                            }
                            gridTable.Rows.Add(lsCol.ToArray());
                            lsCol.Clear();
                        }
                    }
                }
            } catch (Exception ex) {
                OnError("moveData() ", ex.Message);
            }
        }

        private void showDataOnGridInsertOnly() {
            initializeGrid(sqlText + " LIMIT 0, 1");
        }

        public override void DataSourceVirtual(string sql, string cnstr) {
            DataSource(sql);
        }

        private bool initializeGrid(string sql) {

            try {
                columnInfos.Clear();
                gridTable.Columns.Clear();
                int i = 0;
                using (cmmd = new MySqlCommand(sql, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        MySqlDbType dbType = MySqlDbType.Text;
                        string colName = "";
                        int fieldCount = dr.FieldCount;
                        List<DataGridViewTextBoxColumn> dgvCol = new List<DataGridViewTextBoxColumn>();
                        while (i != fieldCount) {
                            if (i == fieldCount)
                                break;
                            //initilaize columnInfos
                            try {
                                colName = dr.GetName(i);
                                dbType = dr.GetDbType(i);
                            } catch (MySqlException ex) {
                                onErrorMessage("initializeGrid->ColumnInfos", ex.Message);
                                dbType = MySqlDbType.Text;
                            }

                            columnInfos.Add(new ResultGridColumnInfo(dbType, colName));

                            //intialize grid column
                            var colTmp = new DataGridViewTextBoxColumn();
                            colTmp.Name = colName;
                            colTmp.HeaderText = colName;
                            colTmp.ValueType = typeof(System.String);
                            switch (dbType) {
                                case MySqlDbType.Blob :
                                case MySqlDbType.LongBlob :
                                case MySqlDbType.MediumBlob :
                                case MySqlDbType.TinyBlob :
                                    colTmp.ReadOnly = true;
                                    break;
                            }
                            dgvCol.Add(colTmp);
                            ++i;
                        }
                        //intilaize data rows
                        gridTable.Columns.AddRange(dgvCol.ToArray());
                        var tmpDataRows = new List<string>();
                        while (dr.Read()) {
                            for (int j = 0; j < fieldCount; ++j) {
                                tmpDataRows.Add(setValueOnGrid(j, dr[j], dr.IsDBNull(j)));
                            }
                            gridTable.Rows.Add(tmpDataRows.ToArray());
                            tmpDataRows.Clear();
                        }
                    }
                }

            } catch (MySqlException ex) {
                onErrorMessage("initializeGrid", ex.Message);
            }

            return true;
        }

        private string setValueOnGrid(int idx, object val, bool isDbNull) {
            DateTime valueDate = DateTime.Now;
            TimeSpan valueTime;
            string str = "";
            switch (columnInfos[idx].DbType) {
                case MySqlDbType.TinyBlob :
                case MySqlDbType.Blob :
                case MySqlDbType.MediumBlob :
                case MySqlDbType.LongBlob :
                    if (!isDbNull)
                        str = "BINARY LARGE OBJECT";
                    return str;
                case MySqlDbType.Binary :
                case MySqlDbType.VarBinary :
                    if (!isDbNull)
                        str = Encoding.UTF8.GetString((byte[])val);
                    return str;
                case MySqlDbType.Date :
                    try {
                        if (!isDbNull) { 
                            valueDate = (DateTime)val;
                            str = valueDate.ToString(MySqlConfig.MySqlDateToDotNetDate());
                        }
                    } catch { }
                    return str;
                case MySqlDbType.DateTime :
                case MySqlDbType.Timestamp :
                    try {
                        if (!isDbNull) { 
                            valueDate = (DateTime)val;
                            str = valueDate.ToString(MySqlConfig.MySqlDateTimeToDotNetDateTime());
                        }
                    } catch { }
                    return str;
                case MySqlDbType.Time :
                    try {
                        if (!isDbNull) {
                            valueTime = (TimeSpan)val;
                            str = valueTime.ToString(MySqlConfig.MySqlTimeToDotNetTime());
                        }
                    } catch { }
                    return str;
            }

            if (!isDbNull)
                str = val.ToString();

            return str;
        }

        private void setUpExecutedFromSQL() {
            gridTable.ReadOnly = true;
            buttonMode.Visible = false;
            buttonImportCSV.Visible = false;
            stripButtonAdd.Visible = false;
            stripButtonDel.Visible = false;
            stripSplit1.Visible = false;
            buttonApply.Visible = false;
            buttonRevert.Visible = false;
            buttonDownPage.Enabled = true;
            buttonUpPage.Enabled = true;
            checkBoxIgnorePri.Visible = false;
        }

        private void setUpExecutedFromSQLBuilder() {
            stripButtonAdd.Visible = true;
            gridTable.ReadOnly = false;
            buttonMode.Visible = false;
            buttonImportCSV.Visible = true;
            stripButtonDel.Visible = true;
            stripSplit1.Visible = true;
            buttonApply.Visible = true;
            buttonRevert.Visible = true;
            buttonDownPage.Enabled = true;
            buttonUpPage.Enabled = true;
            checkBoxIgnorePri.Visible = true;
        }

        private void setUpExecutedFromSQLBuilderInsertOnly() {
            stripButtonAdd.Visible = true;
            stripButtonDel.Visible = true;
            buttonImportCSV.Visible = true;
            labelNumPage.Text = "0";
            gridTable.ReadOnly = false;
            buttonMode.Visible = true;
            stripSplit1.Visible = true;
            buttonApply.Visible = true;
            buttonRevert.Visible = true;
            buttonDownPage.Enabled = false;
            buttonUpPage.Enabled = false;
            checkBoxIgnorePri.Visible = false;
        }

        private void gridTable_KeyDown(object sender, KeyEventArgs e) {
            if (outGrid == OutGrid.ExecutedFromSQLTextEdit)
                return;
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N) {
                if (outGrid != OutGrid.ExecutedFromSQLTextEdit)
                    stripButtonAddRow(null, null);
            }

            if (e.KeyCode == Keys.Delete) {
                if (outGrid != OutGrid.ExecutedFromSQLTextEdit)
                    stripButtonDel_Click(null, null);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                buttonApply_Click(null, null);
            }
        }

        private void gridTable_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            Msg.Err("Error on grid table : " + e.Exception.Message);
        }

        private void stripButtonAddRow(object sender, EventArgs e) {
            List<string> lsStr = new List<string>();
            for (int i = 0; i < gridTable.Columns.Count; ++i) {
                lsStr.Add("");
            }
            if (outGrid == OutGrid.ExecutedFromSQLBuilder)
                listAddRow.Add(gridTable.Rows.Count);
            gridTable.Rows.Add(lsStr.ToArray());
            this.IsEdited = true;
        }

        private void stripButtonDel_Click(object sender, EventArgs e) {
            //code
            if (gridTable.SelectedRows.Count == 0) {
                Msg.Warrn(MSGSelRowDel);
                return;
            }

            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                int minIdx = gridTable.Rows.Count - 1;
                int selDelCount = gridTable.SelectedRows.Count;
                List<int> lsSelRow = new List<int>();

                for (int o = 0; o < selDelCount; ++o)
                    lsSelRow.Add(gridTable.SelectedRows[o].Index);

                lsSelRow.Sort();
                bool dup = false;
                for (int o = 0; o < selDelCount; ++o) {
                    if (minIdx > gridTable.SelectedRows[o].Index)
                        minIdx = gridTable.SelectedRows[o].Index;

                    for (int p = 0; p < listAddRow.Count; ++p) {
                        if (gridTable.SelectedRows[o].Index == listAddRow[p]) {
                            dup = true;
                            listAddRow.RemoveAt(p);
                        }
                    }

                    for (int p = 0; p < listEditRows.Count; ++p) {
                        if (gridTable.SelectedRows[o].Index == listEditRows[p].RowIndex) {
                            List<string> pri = new List<string>();
                            pri.AddRange(listEditRows[p].PrimaryKeyValue.ToArray());
                            listDelRows.Add(pri);
                            dup = true;
                            listEditRows.RemoveAt(p);
                        }
                    }

                    if (!dup) {
                        var ls = new List<string>();
                        for (int i = 0; i < IndexPrimaryKey.Count; ++i)
                            ls.Add(gridTable.SelectedRows[o].Cells[IndexPrimaryKey[i]].Value.ToString());
                        listDelRows.Add(ls);
                    } else
                        dup = false;
                }

                for (int p = 0; p < listAddRow.Count; ++p) {
                    int rowIdx = listAddRow[p];
                    if (rowIdx < minIdx)
                        continue;
                    int countIdx = 0;
                    for (int shit = 0; shit < selDelCount; ++shit) {
                        if (rowIdx < lsSelRow[shit])
                            break;
                        else
                            ++countIdx;
                    }
                    listAddRow[p] = rowIdx - countIdx;
                }

                for (int p = 0; p < listEditRows.Count; ++p) {
                    int rowIdx = listEditRows[p].RowIndex;
                    if (rowIdx < minIdx)
                        continue;
                    int countIdx = 0;
                    for (int shit = 0; shit < selDelCount; ++shit) {
                        if (rowIdx < lsSelRow[shit])
                            break;
                        else
                            ++countIdx;
                    }
                    listEditRows[p].RowIndex = rowIdx - countIdx;
                }
                if ((listAddRow.Count + listEditRows.Count + listDelRows.Count) > 0)
                    this.IsEdited = true;
                else
                    this.IsEdited = false;
            }

            foreach (DataGridViewRow item in gridTable.SelectedRows) {
                gridTable.Rows.RemoveAt(item.Index);
            }
            gridTable.ClearSelection();
        }

        private string sqlBuilder() {
            string res = "";
            string val = "";
            string colName = "";
            int idx;

            for (int i = 0; i < listDelRows.Count; ++i) {
                for (int j = 0; j < IndexPrimaryKey.Count; ++j) {
                    if (j != 0)
                        val += " AND ";
                    val += "`" + columnInfos[IndexPrimaryKey[j]].ColumnName + "`=" + setValueSqlBuilder(listDelRows[i][j], IndexPrimaryKey[j]);
                }
                res += "DELETE FROM `" + DatabaseAndTableName + "` WHERE " + val + ";\n";
                val = "";
            }

            string update = "";
            for (int i = 0; i < listEditRows.Count; ++i) {
                colName = "";
                update += "UPDATE `" + DatabaseAndTableName + "` SET ";
                idx = listEditRows[i].RowIndex;
                for (int j = 0; j < listEditRows[i].ColumnIndex.Count; ++j) {
                    if (checkBoxIgnorePri.Checked) {
                        bool isContinue = false;
                        for (int k = 0; k < IndexPrimaryKey.Count; ++k) {
                            if (IndexPrimaryKey[k] == j) {
                                isContinue = true;
                                break;
                            }
                        }
                        if (isContinue)
                            continue;
                    }
                    val = setValueSqlBuilder(gridTable[listEditRows[i].ColumnIndex[j], idx].Value.ToString(), listEditRows[i].ColumnIndex[j]);
                    colName += ",`" + columnInfos[listEditRows[i].ColumnIndex[j]].ColumnName + "`=" + val;
                }
                if (!colName.Equals("")) { // "`" + dataTable.Columns[IndexPrimaryKey].ColumnName + "`=" + val + ";\n";
                    val = "";
                    for (int j = 0; j < IndexPrimaryKey.Count; ++j) {
                        if (j != 0)
                            val += " AND ";
                        val += "`" + columnInfos[IndexPrimaryKey[j]].ColumnName + "`=" + setValueSqlBuilder(listEditRows[i].PrimaryKeyValue[j], IndexPrimaryKey[j]);
                    }
                    colName = colName.Remove(0, 1);
                    update += colName + " WHERE " + val + ";\n";
                } else {
                    update = string.Empty;
                }
            }
            res += update;

            string insert = "";
            int cntSplit = 0;
            for (int i = 0; i < listAddRow.Count; ++i) {
                val = "";
                colName = "";
                insert += "INSERT INTO `" + DatabaseAndTableName + "`(";
                val += "VALUES(";
                idx = Convert.ToInt32(listAddRow[i]);

                for (int j = 0; j < columnInfos.Count; ++j) {
                    if (j != cntSplit) {
                        val += ", ";
                        colName += ",";
                    }
                    colName += "`" + columnInfos[j].ColumnName + "`";
                    val += setValueSqlBuilder(gridTable[j, idx].Value.ToString(), j);
                }
                if (!colName.Equals("")) { 
                    insert += colName + ") ";
                    insert += val + ");\n";
                    res += insert;
                }
                insert = "";
            }
            return res;
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            blobUniqueParam = 0;
            mySqlParms.Clear();
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                int isChanged = listAddRow.Count + listEditRows.Count + listDelRows.Count;
                if (!this.IsEdited) {
                    Msg.Warrn(MSGTbNotChanged);
                    return;
                }
                string sql = sqlBuilder();
                if (sql.Equals("")) {
                    Msg.Warrn(MSGNothingToExec);
                    return;
                }
                var sqlPerview = new SQLPerview();
                sqlPerview.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
                sqlPerview.setSQLtext(sql);
                sqlPerview.MSGAction1 = MSGApplyEdit;
                if (mySqlParms.Count != 0)
                    sqlPerview.mySqlParams = mySqlParms;
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    loadCurrentData();
                }
                sqlPerview.Dispose();
            }

            if (outGrid == OutGrid.ExecutedFromSQLBuilderInsertOnly) {
                if (gridTable.RowCount < 1) {
                    Msg.Warrn(MSGTbNotChanged);
                    return;
                }
                string res = "";
                string val = "";
                string colName = "";
                for (int i = 0; i < gridTable.RowCount; ++i) {
                    res += "INSERT INTO `" + DatabaseAndTableName + "`(";
                    val += "VALUES(";

                    for (int j = 0; j < columnInfos.Count; ++j) {
                        if (j != 0) {
                            val += ", ";
                            colName += ",";
                        }
                        colName += "`" + columnInfos[j].ColumnName + "`";
                        val += setValueSqlBuilder(gridTable[j, i].Value.ToString(), j);
                    }
                    res += colName + ") ";
                    res += val + ");\n";
                }

                var sqlPerview = new SQLPerview();
                sqlPerview.setSQLtext(res);
                sqlPerview.MSGAction1 = MSGApplyInsert;
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    this.IsEdited = false;
                    ClearTempData();
                }
                sqlPerview.Dispose();
            }
        }

        private int blobUniqueParam = 0;
        private List<MySqlParameter> mySqlParms = new List<MySqlParameter>();
        private string setValueSqlBuilder(string val, int col) {
            string str = "";
            switch (columnInfos[col].DbType) {
                case MySqlDbType.TinyText :
                case MySqlDbType.Text :
                case MySqlDbType.MediumText :
                case MySqlDbType.LongText :
                case MySqlDbType.VarChar :
                case MySqlDbType.VarBinary :
                case MySqlDbType.Binary :
                case MySqlDbType.Date :
                case MySqlDbType.DateTime :
                case MySqlDbType.Timestamp :
                case MySqlDbType.Time :
                case MySqlDbType.Year :
                    return "'" + val + "'";
                case MySqlDbType.TinyBlob :
                case MySqlDbType.Blob :
                case MySqlDbType.MediumBlob :
                case MySqlDbType.LongBlob :
                    str = "?blob_param" + blobUniqueParam;
                    ++blobUniqueParam;
                    MySqlParameter param = new MySqlParameter(str, columnInfos[col].DbType);
                    param.Value = System.IO.File.ReadAllBytes(val);
                    mySqlParms.Add(param);
                    return str;

            }
            return val;
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            loadCurrentData();
        }

        #region EditCell

        private void gridTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            beginCellEdit(e.RowIndex);
        }

        private void gridTable_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            cellEdited(e.RowIndex, e.ColumnIndex);
        }

        private bool isEditedCell;
        private List<string> lsValPri = new List<string>();
        private void beginCellEdit(int rowIndex) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                lsValPri.Clear();
                for (int i = 0; i < IndexPrimaryKey.Count; ++i)
                    lsValPri.Add(gridTable[IndexPrimaryKey[i], rowIndex].Value.ToString());
                isEditedCell = false;
            }
        }

        private void cellEdited(int rowIndex, int columnIndex) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                for (int i = 0; i < listAddRow.Count; ++i) {
                    if (listAddRow[i] == rowIndex)
                        return;
                }
                for (int i = 0; i < listEditRows.Count; ++i) {
                    if (listEditRows[i].RowIndex == rowIndex) {
                        for (int j = 0; j < listEditRows[i].ColumnIndex.Count; ++j) {
                            if (listEditRows[i].ColumnIndex[j] == columnIndex)
                                return;
                        }
                        listEditRows[i].ColumnIndex.Add(columnIndex);
                        return;
                    }
                }
                List<int> col = new List<int>();
                col.Add(columnIndex);
                List<string> pri = new List<string>();
                pri.AddRange(lsValPri.ToArray());
                EditRow edit = new EditRow(col, pri, rowIndex);
                listEditRows.Add(edit);
            }
            this.IsEdited = true;
        }

        #endregion

        private void ClearTempData() {
            listAddRow.Clear();
            listEditRows.Clear();
            listDelRows.Clear();
            gridTable.Rows.Clear();
            mySqlParms.Clear();
            this.blobUniqueParam = 0;
            this.IsEdited = false;
        }

        public event EventHandler<ExecuteMessageEventArgs> ErrorMessage;

        private void OnError(string action, string errMsg) {
            ExecuteMessageEventArgs e = new ExecuteMessageEventArgs();
            e.Action = MessageKeyword.BuildSqlActionMessage(action + MSGOneOrMoreFailed);
            e.Error = MessageKeyword.BuildErrorMessage(errMsg);
            if (ErrorMessage != null)
                ErrorMessage(this, e);
        }

        private void OnError(string action, string stet, string errMsg) {
            ExecuteMessageEventArgs e = new ExecuteMessageEventArgs();
            e.Action = MessageKeyword.BuildSqlActionMessage(action + MSGOneOrMoreFailed);
            e.Stetment = MessageKeyword.BuildSqlStetmentMessage(stet);
            e.Error = MessageKeyword.BuildErrorMessage(errMsg);
            if (ErrorMessage != null)
                ErrorMessage(this, e);
        }

        /*public override bool OnSaveFile() {
            var sqlPerview = new SQLPerview();
            sqlPerview.ExcutedMessage += new EventHandler<ExecuteMessageEventArgs>(sendSqlExecutedMessage);
            sqlPerview.setSQLtext(sqlBuilder());
            sqlPerview.ActionMsg = "Apply edit data";
            sqlPerview.ShowDialog();
            if (sqlPerview.isSuccessExecuted) {
                sqlPerview.Dispose();
                return true;
            }
            sqlPerview.Dispose();
            return false;
        }*/

        private void buttonExportCSV_Click(object sender, EventArgs e) {
            FormExportCSV f = new FormExportCSV();
            f.columnInfos = columnInfos;
            f.IsLimit = this.EnableSqlLimit;
            f.SQLLimit = this.SqlLimit;
            f.SQLPos = Convert.ToInt32(labelNumPage.Text) > 0 ? (Convert.ToInt32(labelNumPage.Text) - 1) * this.SqlLimit : 0;
            f.SQL = this.sqlText;
            f.ShowDialog();
            f.Dispose();
        }

        #region Import

        private void buttonImportCSV_Click(object sender, EventArgs e) {
            FormImportCSV frm = new FormImportCSV();
            frm.ColumnInfos = columnInfos;
            frm.DatabaseAndTableName = DatabaseAndTableName;
            frm.ShowDialog();
            if (!frm.IsAborted) {
                loadCurrentData();
            }
            frm.Dispose();
        }
        #endregion

        private void buttonInsertOnly_Click(object sender, EventArgs e) {
            GridMode = OutGrid.ExecutedFromSQLBuilderInsertOnly;
            showDataOnGridInsertOnly();
        }

        private void buttonReadOnly_Click(object sender, EventArgs e) {
            if (this.IsEdited) {
                DialogResult dResult;
                dResult = Msg.WarrnQ(MSGWarnIgnoreEdit);

                if (dResult == DialogResult.No)
                    return;
            }
            this.IsEdited = false;
            GridMode = OutGrid.ExecutedFromSQLBuilderRead;
            showDataOnGrid();
        }

        private void contexMenuItemOpenFile_Click(object sender, EventArgs e) {
            if (gridTable.CurrentCell == null)
                return;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.OK) {
                beginCellEdit(gridTable.CurrentCell.RowIndex);
                gridTable.CurrentCell.Value = openFile.FileName;
            }
        }

        private void contexMenuItemDeleteRows_Click(object sender, EventArgs e) {
            stripButtonDel_Click(null, null);
        }

        private void contexMenuItemNewRow_Click(object sender, EventArgs e) {
            stripButtonAddRow(null, null);
        }

        private void contexMenuItemEditCell_Click(object sender, EventArgs e) {
            gridTable.CurrentCell.Selected = true;
        }

        private void contexMenuItemCopySelectedRows_Click(object sender, EventArgs e) {
            if (gridTable.SelectedRows.Count == 0) {
                Msg.Warrn("Select row first !");
                return;
            }

            StringBuilder result = new StringBuilder("");

            List<int> listIndex = new List<int>();
            for (int i = 0; i < gridTable.SelectedRows.Count; ++i)
                listIndex.Add(gridTable.SelectedRows[i].Index);
            listIndex.Sort();

            for (int i = 0; i < listIndex.Count; ++i) {
                for (int j = 0; j < gridTable.Columns.Count; ++j) {
                    if (j != 0)
                        result.Append("\t");
                    result.Append(gridTable[j, listIndex[i]].Value.ToString());
                }
                result.Append("\r\n");
            }
            Clipboard.SetText(result.ToString());
        }

        private void contexMenuItemCopyCellValue_Click(object sender, EventArgs e) {
            if (gridTable.SelectedCells.Count < 1) {
                Msg.Warrn(MSGWarnSelCell);
                return;
            }
            StringBuilder sb = new StringBuilder("");
            List<int> idxRows = new List<int>();
            
            //pilih index yang terseleksi (acak)
            for (int i = 0; i < gridTable.SelectedCells.Count; ++i)
                idxRows.Add(gridTable.SelectedCells[i].RowIndex);

            //grouping dan susun ascending sesuai index
            var groupedListIndex = idxRows.GroupBy(data => data)
                                          .OrderBy(x => x.Key)
                                          .ToList();

            //dapatkan nilai dari cell
            for (int i = 0; i < groupedListIndex.Count; ++i) {
                for (int j = 0; j < gridTable.ColumnCount; ++j) {
                    if (gridTable[j, groupedListIndex[i].Key].Selected)
                        sb.Append(gridTable[j, groupedListIndex[i].Key].Value.ToString()).Append("\t");
                }
                sb.Append("\n");
            }

            //masukan ke Clipboard
            Clipboard.SetText(sb.ToString());
        }

        private void gridTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder ||
                outGrid == OutGrid.ExecutedFromSQLBuilderInsertOnly) {
                if (gridTable.CurrentCell == null)
                    return;
                if (isBlobColumn(gridTable.CurrentCell.ColumnIndex)) {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Multiselect = false;
                    if (openFile.ShowDialog() == DialogResult.OK) {
                        beginCellEdit(gridTable.CurrentCell.RowIndex);
                        gridTable.CurrentCell.Value = openFile.FileName;
                    }
                }
            }
        }

        private void setModeContextMenu(OutGrid oGrid) {
            bool isEditAble = false;
            switch (oGrid) {
                case OutGrid.ExecutedFromSQLBuilder :
                case OutGrid.ExecutedFromSQLBuilderInsertOnly :
                    isEditAble = true;
                    break;
            }
            contexMenuDeleteRows.Visible = isEditAble;
            contexMenuEditCell.Visible = isEditAble;
            contexMenuNewRow.Visible = isEditAble;
            contexMenuItemSeparator1.Visible = isEditAble;
            contexMenuItemSeparator2.Visible = isEditAble;
            contexMenuOpenFile.Visible = isEditAble;
        }

        private void gridTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            setModeContextMenu(outGrid);

            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                if (outGrid == OutGrid.ExecutedFromSQLBuilder ||
                    outGrid == OutGrid.ExecutedFromSQLBuilderInsertOnly) {
                    gridTable.CurrentCell = gridTable[e.ColumnIndex, e.RowIndex];
                    if (isBlobColumn(e.ColumnIndex)) {
                        contexMenuOpenFile.Visible = true;
                        contexMenuItemSeparator1.Visible = true;
                        contexMenuEditCell.Visible = false;
                    } else {
                        contexMenuOpenFile.Visible = false;
                        contexMenuItemSeparator1.Visible = false;
                        contexMenuEditCell.Visible = true;
                    }
                }
                contexMenuGrid.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private bool isBlobColumn(int idx) {
            switch (columnInfos[idx].DbType) {
                case MySqlDbType.Blob :
                case MySqlDbType.LongBlob :
                case MySqlDbType.TinyBlob :
                case MySqlDbType.MediumBlob :
                    return true;
            }
            return false;
        }
    }

    public class ResultGridColumnInfo {
        public ResultGridColumnInfo(){
            this.DbType = MySqlDbType.Text;
            this.ColumnName = "";
        }
        public ResultGridColumnInfo(MySqlDbType dbType,
                                    string colName) {
            this.DbType = dbType;
            this.ColumnName = colName;
        }
        public MySqlDbType DbType { get; set; }
        public string ColumnName { get; set; }
    }
}

public enum OutGrid {
    ExecutedFromSQLTextEdit,
    ExecutedFromSQLBuilder,
    ExecutedFromSQLBuilderInsertOnly,
    ExecutedFromSQLBuilderRead
}