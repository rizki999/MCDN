		void refresDBTreeFromTabPage_DoWork(object sender, DoWorkEventArgs e) {
            DesignControls.RefreshDBTreeEventArgs r = (DesignControls.RefreshDBTreeEventArgs)e.Argument;
            
            Exception excep = null;
            
            List<object> listArgs = new List<object>(); //argumen untuk result bg worker
            listArgs.Add(false); //konfirmasi untuk jika node database tidak di temukan di database tree
            listArgs.Add(r); // masukan event args refres tabel

            for (int i = 0; i < treeExplorer.Nodes.Count; ++i) {
                if (treeExplorer.Nodes[i].Text.Equals(r.TableDatabaseName)) {
                    listArgs[0] = true; //database ditemukan
                    TreeNode node = treeExplorer.Nodes[i]; //node database


                    if (string.IsNullOrEmpty(r.TableNameOld)) {
                        //node tabel baru
                        string query =
@"SELECT 
    COLUMN_NAME,
    COLUMN_TYPE 
FROM 
    information_schema.COLUMNS 
WHERE 
    TABLE_SCHEMA='" + r.TableDatabaseName + @"' 
AND ";
                        listArgs.Add(true); //konfir jika tabel baru (create)
                        listArgs.Add(node); //masukan node database

                        //buat node tabel baru
                        object cNode = null;

                        try { 
                            //cari informasi table kolom di information_schema
                            if (r.TableNameNew.GetType() == typeof(string)) {
                                query += "TABLE_NAME='" + (string)r.TableNameNew + "';";
                                TreeNode[] tmpTree = getDatabaseInfoToTreeNode(query, 2).ToArray();
                                TreeNode tmpTabelTree = new TreeNode((string)r.TableNameNew, 1, 1); // buat tabel baru
                                tmpTabelTree.Nodes.AddRange(tmpTree); //menambahkan node kolom ke node table
                                cNode = tmpTabelTree; // untuk masukan ke arg result
                            } else if (r.TableNameNew.GetType() == typeof(List<string>)) {
                                List<string> tmp = (List<string>)r.TableNameNew; // mendapatkan nama tabel dari lis arumen
                                List<TreeNode> tmp_cNode = new List<TreeNode>(); //menampung 

                                for (int j = 0; j < tmp.Count; ++j) {
                                    string tmQuery = query + "TABLE_NAME='" + tmp[j] + "';";
                                    TreeNode[] tmpColTree = getDatabaseInfoToTreeNode(tmQuery, 2).ToArray();

                                    TreeNode tmpTableTree = new TreeNode(tmp[j], 1, 1); // Membuat Node Tabel
                                    tmpTableTree.Nodes.AddRange(tmpColTree); // Menambahkan Node kolom Ke Node Tabel

                                    tmp_cNode.Add(tmpTableTree);
                                }
                                cNode = tmp_cNode.ToArray();
                            }
                        } catch (Exception ex) {
                            excep = ex;
                        }

                        //menambahkan node table ke parameter
                        listArgs.Add(cNode);
                    } else {
                        string query =
@"SELECT 
    COLUMN_NAME,
    COLUMN_TYPE 
FROM 
    information_schema.COLUMNS 
WHERE 
    TABLE_SCHEMA='" + r.TableDatabaseName + @"' 
AND 
    TABLE_NAME='" + r.TableNameNew + "';";
                        //node table yang sudah ada

                        listArgs.Add(false); //konfir jika tabel sudah ada (alter)
                        TreeNode cNode = null; //untuk node tabel yang lama

                        //untuk node kolom
                        List<TreeNode> cNode1 = new List<TreeNode>();

                        for (int j = 0; j < node.Nodes.Count; ++j) {
                            if (node.Nodes[j].Text.Equals(r.TableNameOld)) {
                                cNode = node.Nodes[j];
                                try {
                                    TreeNode[] tmpTree = getDatabaseInfoToTreeNode(query, 2).ToArray();
                                    cNode1.AddRange(tmpTree);
                                } catch (Exception ex) {
                                    excep = ex;
                                }
                                break;
                            }
                        }

                        listArgs.Add(cNode); //masukan node table lama ke argumen
                        listArgs.Add(cNode1.ToArray()); //masukan lis node kolom lama ke argumen
                    }
                }
            }
            if (excep != null)
                throw excep;
            e.Result = listArgs.ToArray();
        }

        void refresDBTreeFromTabPage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                Log.WriteL("Error Refresh Tree : " + e.Error.Message);
                return;
            }

            object[] args = (object[])e.Result;
            bool dbIsExist = (bool)args[0];
            DesignControls.RefreshDBTreeEventArgs r = (DesignControls.RefreshDBTreeEventArgs)args[1];

            if (!dbIsExist) {

                return;
            }

            bool newTable = (bool)args[2];
            if (newTable) {
                try {
                    TreeNode dbNode = (TreeNode)args[3];
                    if (args[4].GetType() == typeof(TreeNode)) {
                        TreeNode tbNode = (TreeNode)args[4];
                        insertNode(dbNode.Nodes, tbNode);
                    } else if (args[4].GetType() == typeof(TreeNode[])) {
                        TreeNode[] tbNode = (TreeNode[])args[4];
                        insertNode(dbNode.Nodes, tbNode);
                    }
                } catch (Exception ex) {
                    Log.WriteL("Error :  " + ex.Message);
                }
            } else {
                try {
                    TreeNode tbNode = (TreeNode)args[3];
                    TreeNode[] colNode = (TreeNode[])args[4];

                    tbNode.Text = (string)r.TableNameNew;
                    tbNode.Nodes.Clear();
                    tbNode.Nodes.AddRange(colNode);
                } catch (Exception ex) {
                    Log.WriteL("Error : " + ex.Message);
                }
            }
        }