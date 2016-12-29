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

namespace MySqlClientDotNET.DesignControls.GridResultNS {
    public partial class GridResult : DynamicTabPage {
        //DynamicTabPage
        public GridResult(OutGrid oGrid) {
            InitializeComponent();
            IsFromSqlBuilder = false;
            try {
                stripButtonAdd.Image = Image.FromFile(ResourcesPath.img_row_add_S);
                stripButtonDel.Image = Image.FromFile(ResourcesPath.img_rowd_del_S);
            } catch { }

            this.PageType = TabPageType.GridResult;

            colMode = new List<string>();
            colCount = 0;

            enableSqlLimit = true;
            SqlLimitPosUser = "";

            IndexPrimaryKey = new List<int>();

            isEditedCell = false;

            TableName = "";

            sqlText = "";
            sqlLimitCount = 50;

            listDelRowPri = new List<List<string>>();
            listAddRow = new List<int>();
            listEditRow = new List<int>();
            listEditRowPri = new List<List<string>>();

            GridMode = oGrid;
        }

        private List<string> colMode;
        private List<List<string>> listDelRowPri;
        private List<int> listAddRow;
        private List<int> listEditRow;
        private List<List<string>> listEditRowPri;

        private MySqlDataReader dr;
        private MySqlCommand cmmd;
        private MySqlConnection cnn;
        private string cnnstr;
        DataTable dataTable;

        private int colCount;

        public SQLPerview sqlPerview;

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

        public string TableName { get; set; }

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
                    case OutGrid.ExecutedFromSQLBuilderRead :
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

        public void DataSource(string sql, string cnstr) {
            sqlPerview = new SQLPerview();
            sqlPerview.ConnectionString = cnstr;
            dataTable = new DataTable();
            this.cnnstr = cnstr;
            this.sqlText = sql;

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
            if (dataTable != null)
                dataTable.Rows.Clear();
            try {
                using (cnn = new MySqlConnection(cnnstr)) {
                    cnn.Open();
                    using (cmmd = new MySqlCommand(sqll, cnn)) {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmmd)) {
                            da.Fill(dataTable);
                        }
                    }
                    cnn.Close();
                }
            } catch (MySqlException myExcep) {
                OnError("Read data", myExcep.Message);
            }

            initializeColGrid(dataTable);
            initializeRowGrid(dataTable);
            if (outGrid == OutGrid.ExecutedFromSQLBuilder ||
                outGrid == OutGrid.ExecutedFromSQLBuilderInsertOnly)
                identifyDataTypeCol(dataTable);
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
                using (cnn = new MySqlConnection(cnnstr)) {
                    cnn.Open();
                    using (cmmd = new MySqlCommand(limitSQL, cnn)) {
                        List<string> lsCol = new List<string>();
                        using (dr = cmmd.ExecuteReader()) {
                            while (dr.Read()) {
                                for (int i = 0; i < dr.FieldCount; ++i) {
                                    lsCol.Add(dr.GetString(i));
                                }
                                gridTable.Rows.Add(lsCol.ToArray());
                                lsCol.Clear();
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                OnError("moveData() ", ex.Message);
            }

        }

        private void showDataOnGridInsertOnly() {
            string sqll = "";
            try {
                sqll = sqlText + " LIMIT 0, 1";

                using (cnn = new MySqlConnection(cnnstr)) {
                    cnn.Open();
                    using (cmmd = new MySqlCommand(sqll, cnn)) {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmmd)) {
                            da.Fill(dataTable);
                        }
                    }
                    cnn.Close();
                }
            } catch (MySqlException myExcep) {
                OnError("showDataOnGridInsertOnly() ", myExcep.Message);
            }
            initializeColGrid(dataTable);
            identifyDataTypeCol(dataTable);
        }

        private void identifyDataTypeCol(DataTable dTable) {
            colMode.Clear();
            for (int i = 0; i < dTable.Columns.Count; ++i) { //identify execute data column 
                ++colCount;
                if (isNumericCol(dTable.Columns[i].DataType))
                    colMode.Add("");
                else
                    colMode.Add("'");
            }
        }

        public override void DataSourceVirtual(string sql, string cnstr) {
            DataSource(sql, cnnstr);
        }

        private bool initializeColGrid(DataTable dTable) {
            try {
                // add col
                gridTable.Columns.Clear();
                List<DataGridViewTextBoxColumn> dgvCol = new List<DataGridViewTextBoxColumn>();
                for (int i = 0; i < dTable.Columns.Count; ++i) {
                    var colTmp = new DataGridViewTextBoxColumn();
                    colTmp.Name = dTable.Columns[i].ColumnName;
                    colTmp.HeaderText = dTable.Columns[i].ColumnName;
                    colTmp.ValueType = typeof(System.String);
                    dgvCol.Add(colTmp);
                }
                gridTable.Columns.AddRange(dgvCol.ToArray());
                foreach (DataGridViewColumn column in gridTable.Columns) {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            } catch (Exception excep) {
                Msg.Err("Error : " + excep.Message);
                return false;
            }

            return true;
        }

        private bool initializeRowGrid(DataTable dTable) {
            try {
                //add row and fill data row
                gridTable.Rows.Clear();
                List<string> tmpCol = new List<string>();
                for (int i = 0; i < dTable.Rows.Count; ++i) {
                    for (int j = 0; j < dTable.Columns.Count; ++j) {
                        tmpCol.Add(dTable.Rows[i][j].ToString());
                    }
                    gridTable.Rows.Add(tmpCol.ToArray());
                    tmpCol.Clear();
                }
            } catch (Exception ex) {
                Msg.Err("Error : " + ex.Message);
                return false;
            }
            return true;
        }

        private bool isNumericCol(Type type) {
            if (type.Equals(typeof(System.Int16)))
                return true;
            if (type.Equals(typeof(System.Int32)))
                return true;
            if (type.Equals(typeof(System.Int64)))
                return true;
            if (type.Equals(typeof(System.Decimal)))
                return true;
            if (type.Equals(typeof(System.Single)))
                return true;
            if (type.Equals(typeof(System.Double)))
                return true;
            if (type.Equals(typeof(System.SByte)))
                return true;
            return false;
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
                Msg.Warrn("Select the rows to delete");
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

                    for (int p = 0; p < listEditRow.Count; ++p) {
                        if (gridTable.SelectedRows[o].Index == listEditRow[p]) {
                            listDelRowPri.Add(listEditRowPri[p]);
                            dup = true;
                            listEditRow.RemoveAt(p);
                            listEditRowPri.RemoveAt(p);
                        }
                    }

                    if (!dup) {
                        var ls = new List<string>();
                        for (int i = 0; i < IndexPrimaryKey.Count; ++i)
                            ls.Add(gridTable.SelectedRows[o].Cells[IndexPrimaryKey[i]].Value.ToString());
                        listDelRowPri.Add(ls);
                    }  else
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

                for (int p = 0; p < listEditRow.Count; ++p) {
                    int rowIdx = listEditRow[p];
                    if (rowIdx < minIdx)
                        continue;
                    int countIdx = 0;
                    for (int shit = 0; shit < selDelCount; ++shit) {
                        if (rowIdx < lsSelRow[shit])
                            break;
                        else
                            ++countIdx;
                    }
                    listEditRow[p] = rowIdx - countIdx;
                }
                if ((listAddRow.Count + listEditRow.Count + listDelRowPri.Count) > 0)
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

            for (int i = 0; i < listDelRowPri.Count; ++i) {
                for (int j = 0; j < IndexPrimaryKey.Count; ++j) {
                    if (j != 0)
                        val += " AND ";
                    val += "`" + dataTable.Columns[IndexPrimaryKey[j]].ColumnName + "`=" + setValue(listDelRowPri[i][j], IndexPrimaryKey[j]);
                }
                res += "DELETE FROM `" + TableName + "` WHERE " + val + ";\n";
            }

            string update = "";
            for (int i = 0; i < listEditRow.Count; ++i) {
                colName = "";
                update += "UPDATE `" + TableName + "` SET ";
                idx = Convert.ToInt32(listEditRow[i]);
                for (int j = 0; j < dataTable.Columns.Count; ++j) {
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
                    val = setValue(gridTable[j, idx].Value.ToString(), j);
                    colName += ",`" + dataTable.Columns[j].ColumnName + "`=" + val;
                }
                if (!colName.Equals("")) { // "`" + dataTable.Columns[IndexPrimaryKey].ColumnName + "`=" + val + ";\n";
                    val = "";
                    for (int j = 0; j < IndexPrimaryKey.Count; ++j) {
                        if (j != 0)
                            val += " AND ";
                        val += "`" + dataTable.Columns[IndexPrimaryKey[j]].ColumnName + "`=" + setValue(listEditRowPri[i][j], IndexPrimaryKey[j]);
                    }
                    colName = colName.Remove(0, 1);
                    update += colName + " WHERE " + val + ";\n";
                } else {
                    update = string.Empty;
                }
            }
            res += update;

            for (int i = 0; i < listAddRow.Count; ++i) {
                val = "";
                colName = "";
                res += "INSERT INTO `" + TableName + "`(";
                val += "VALUES(";
                idx = Convert.ToInt32(listAddRow[i]);
                
                for (int j = 0; j < dataTable.Columns.Count; ++j) {
                    if (j != 0) {
                        val += ", ";
                        colName += ",";
                    }
                    colName += "`" + dataTable.Columns[j].ColumnName + "`";
                    val += setValue(gridTable[j, idx].Value.ToString(), j);
                }
                res += colName + ") ";
                res += val + ");\n";
            }
            return res;
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                int isChanged = listAddRow.Count + listEditRow.Count + listDelRowPri.Count;
                if (!this.IsEdited) {
                    Msg.Warrn("Table grid is not changed !");
                    return;
                }
                string sql = sqlBuilder();
                if (sql.Equals("")) {
                    Msg.Warrn("Nothing to execute!");
                    return;
                }
                sqlPerview.setSQLtext(sql);
                sqlPerview.ActionMsg = "Apply edit data";
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    ClearTempData();
                    showDataOnGrid();
                }
            }

            if (outGrid == OutGrid.ExecutedFromSQLBuilderInsertOnly) {
                if (gridTable.RowCount < 1) {
                    Msg.Warrn("Table grid is not changed !");
                    return;
                }
                string res = "";
                string val = "";
                string colName = "";
                for (int i = 0; i < gridTable.RowCount; ++i) {
                    res += "INSERT INTO `" + TableName + "`(";
                    val += "VALUES(";

                    for (int j = 0; j < dataTable.Columns.Count; ++j) {
                        if (j != 0) {
                            val += ", ";
                            colName += ",";
                        }
                        colName += "`" + dataTable.Columns[j].ColumnName + "`";
                        val += setValue(gridTable[j, i].Value.ToString(), j);
                    }
                    res += colName + ") ";
                    res += val + ");\n";
                }/*
                for (int i = 0; i < gridTable.Rows.Count; ++i) {
                    res += "INSERT INTO `" + TableName + "` VALUES(";
                    for (int j = 0; j < dataTable.Columns.Count; ++j) {
                        if (j != 0)
                            res += ", ";
                        res += setValue(gridTable[j, i].Value.ToString(), j); ;
                    }
                    res += ");\n";
                }*/
                sqlPerview.setSQLtext(res);
                sqlPerview.ActionMsg = "Apply edit data";
                sqlPerview.ShowDialog();
                if (sqlPerview.isSuccessExecuted) {
                    this.IsEdited = false;
                    ClearTempData();
                }
            }
        }


        private string setValue(string val, int col) {
            return colMode[col] + val + colMode[col];
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            ClearTempData();
        }

        #region EditCell

        private bool isEditedCell;

        private void gridTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                var ls = new List<string>();
                for (int i = 0; i < IndexPrimaryKey.Count; ++i)
                    ls.Add(gridTable[IndexPrimaryKey[i], e.RowIndex].Value.ToString());
                listEditRowPri.Add(ls);
                isEditedCell = false;
            }
        }

        private void gridTable_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                for (int i = 0; i < listAddRow.Count; ++i) {
                    if (listAddRow[i] == e.RowIndex)
                        return;
                }
                for (int i = 0; i < listEditRow.Count; ++i) {
                    if (listEditRow[i] == e.RowIndex)
                        return;
                }
                listEditRow.Add(e.RowIndex);
                isEditedCell = true;
            }
            this.IsEdited = true;
        }

        private void gridTable_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (outGrid == OutGrid.ExecutedFromSQLBuilder) {
                for (int i = 0; i < listAddRow.Count; ++i) {
                    if (listAddRow[i] == e.RowIndex)
                        return;
                }
                for (int i = 0; i < listEditRow.Count; ++i) {
                    if (listEditRow[i] == e.RowIndex)
                        return;
                }
                if (!isEditedCell) {
                    if (listEditRowPri.Count != 0)
                        listEditRowPri.RemoveAt(listEditRowPri.Count - 1);
                } else
                    isEditedCell = false;
            }
        }

        #endregion

        private void ClearTempData() {
            listAddRow.Clear();
            listEditRow.Clear();
            listEditRowPri.Clear();
            listDelRowPri.Clear();
            gridTable.Rows.Clear();
            this.IsEdited = false;
        }

        public event EventHandler<ExecuteMessageEventArgs> ErrorMessage;

        private void OnError(string action, string errMsg) {
            ExecuteMessageEventArgs e = new ExecuteMessageEventArgs();
            e.Action = MessageKeyword.BuildSqlActionMessage(action + " (One/More Failed)");
            e.Error = MessageKeyword.BuildErrorMessage(errMsg);
            if (ErrorMessage != null)
                ErrorMessage(this, e);
        }

        private void OnError(string action, string stet, string errMsg) {
            ExecuteMessageEventArgs e = new ExecuteMessageEventArgs();
            e.Action = MessageKeyword.BuildSqlActionMessage(action + " (One/More Failed)");
            e.Stetment = MessageKeyword.BuildSqlStetmentMessage(stet);
            e.Error = MessageKeyword.BuildErrorMessage(errMsg);
            if (ErrorMessage != null)
                ErrorMessage(this, e);
        }

        public override bool OnSaveFile() {
            sqlPerview.setSQLtext(sqlBuilder());
            sqlPerview.ActionMsg = "Apply edit data";
            sqlPerview.ShowDialog();
            if (sqlPerview.isSuccessExecuted)
                return true;
            return false;
        }

        private void buttonExportCSV_Click(object sender, EventArgs e) {
            FormExportCSV f = new FormExportCSV();
            f.tbCol = gridTable.Columns;
            f.IsLimit = this.EnableSqlLimit;
            f.SQLLimit = this.SqlLimit;
            f.SQLPos = Convert.ToInt32(labelNumPage.Text) > 0 ? (Convert.ToInt32(labelNumPage.Text) - 1) * this.SqlLimit : 0;
            f.SQL = this.sqlText;
            f.cnnstr = this.cnnstr;
            f.ShowDialog();
            f.Dispose();
        }

        #region Import

        private void buttonImportCSV_Click(object sender, EventArgs e) {
            FormImportCSV frm = new FormImportCSV();
            frm.DataTableCol = dataTable;
            frm.TableName = TableName;
            frm.ColMode = colMode;
            frm.cnnstr = cnnstr;
            frm.ShowDialog();
            if (!frm.IsAborted) {
                
            }
        }
        #endregion

        private void buttonInsertOnly_Click(object sender, EventArgs e) {
            GridMode = OutGrid.ExecutedFromSQLBuilderInsertOnly;
            showDataOnGridInsertOnly();
        }

        private void buttonReadOnly_Click(object sender, EventArgs e) {
            if (this.IsEdited) {
                DialogResult dResult;
                dResult = Msg.WarrnQ("Would you like to discard \"insert data ?\"");
                
                if (dResult == DialogResult.No)
                    return;
            }
            this.IsEdited = false;
            GridMode = OutGrid.ExecutedFromSQLBuilderRead;
            showDataOnGrid();
        }
    }
}

public enum OutGrid {
    ExecutedFromSQLTextEdit,
    ExecutedFromSQLBuilder,
    ExecutedFromSQLBuilderInsertOnly,
    ExecutedFromSQLBuilderRead
}