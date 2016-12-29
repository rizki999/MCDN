//main window
		private int getIndexColPrimary(string tb, string db, List<string> colName) {
            int res = -1;
            bool keepSearch = true;
            try {
                using (cnn = new MySqlConnection(MySqlConfig.ConnectionStringUseDatabase("information_schema"))) {
                    cnn.Open();
                    string sql =
@"SELECT
    COLUMN_KEY,
    COLUMN_NAME  
FROM 
    COLUMNS 
WHERE 
    TABLE_SCHEMA='" + db + @"' 
AND 
    TABLE_NAME='" + tb + "';";
                    using (cmmd = new MySqlCommand(sql, cnn)) {
                        using (MySqlDataReader dr = cmmd.ExecuteReader()) {
                            int cnt = 0;
                            while (dr.Read()) {
                                if (dr[0].ToString().Equals("PRI") && keepSearch) {
                                    res = cnt;
                                    keepSearch = false;
                                }
                                colName.Add(dr[1].ToString());
                                if (keepSearch)
                                    ++cnt;
                            }
                        }
                    }
                }
            } catch (MySqlException ex) {
                Msg.Err("Error : " + ex.Message);
            }
            return res;
        }
		
		private void buttonContexEditData_Click(object sender, EventArgs e) {
            if (treeExplorer.SelectedNode.Parent == null)
                return;
            string db;
            string tb;
            db = tb = "";
            if (treeExplorer.SelectedNode.Level == 2) {
                if (treeExplorer.SelectedNode.Parent.Parent == null)
                    return;
                db = treeExplorer.SelectedNode.Parent.Parent.Text;
                tb = treeExplorer.SelectedNode.Parent.Text;
            } else {
                db = treeExplorer.SelectedNode.Parent.Text;
                tb = treeExplorer.SelectedNode.Text;
            }
            DesignControls.GridResultNS.GridResult gridResult;
            int indexPrimary = -1;
            List<string> colList = new List<string>();
            string sql = "SELECT * FROM `" + tb + "`";
            string limit = MySqlConfig.GetLimit();
            
            FormSelectCol f = new FormSelectCol();
            if ((indexPrimary = getIndexColPrimary(tb, db, colList)) == -1) {
                string message =
@"                 This table does not has primary key 
       it's mean you can not update/delete by specific
   click 'yes' to continue but you have 'insert' data only
              click 'no' to reopen tree explorer option 
   and select 'Read Data' if you just want to see the data";
                DialogResult dResult = Msg.WarrnQ(message);
                if (dResult == System.Windows.Forms.DialogResult.Yes) {
                    gridResult = new DesignControls.GridResultNS.GridResult(OutGrid.ExecutedFromSQLBuilderInsertOnly);
                    gridResult.IndexPrimaryKey = -1;
                    gridResult.IsFromSqlBuilder = true;
                    int tmp = 50;
                    int.TryParse(limit, out tmp);
                    gridResult.SqlLimit = tmp;
                    f.TableName = tb;
                    f.ColList = colList;
                    f.indxPrimary = -1;
                    f.ShowDialog();
                    if (!f.IsOk) {
                        f.Dispose();
                        return;
                    }
                    sql = f.GetSQl;
                } else
                    return;
            } else {
                f.TableName = tb;
                f.ColList = colList;
                f.indxPrimary = indexPrimary;
                f.ShowDialog();
                if (!f.IsOk) {
                    f.Dispose();
                    return;
                }
                sql = f.GetSQl;
                indexPrimary = f.indxPrimary;
                gridResult = new DesignControls.GridResultNS.GridResult(OutGrid.ExecutedFromSQLBuilder);
                gridResult.IndexPrimaryKey = indexPrimary;
                gridResult.EnableSqlLimit = true;
                int tmp = 50;
                int.TryParse(limit,out tmp);
                gridResult.SqlLimit = tmp;
            }
            f.Dispose();
            gridResult.TableName = tb;
            gridResult.Dock = DockStyle.Fill;
            gridResult.TabHeaderText = tb;
            dynamicTab.AddTabPage(gridResult);
            gridResult.DataSource(sql,
                                  MySqlConfig.ConnectionStringUseDatabase(db));
            gridResult.sqlPerview.MessageExcution += new EventHandler<ExecuteMessageEventArgs>(messageFromOtherObject);
        }