using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls {
    public partial class FormSelectCol : Form {
        public FormSelectCol() {
            InitializeComponent();
            tableName = "";
            IsOk = false;
            colPri = "";
            isLoaded = true;
        }

        private string colPri;
        private string tableName;

        public int indxPrimary { get; set; }

        public string TableName {
            get {
                return tableName;
            }
            set {
                tableName = value;
                labelTable.Text = value;
            }
        }

        private string getSQL;

        public string GetSQl {
            get {
                return getSQL;
            }
        }

        public List<string> ColList;
        private bool isLoaded;

        public bool IsOk;

        private void FormSelectCol_Load(object sender, EventArgs e) {
            for (int i = 0; i < ColList.Count; ++i) {
                listCol.Items.Add(ColList[i], true);
            }
            if (indxPrimary >= 0) {
                colPri = listCol.Items[indxPrimary].ToString();
            }
            isLoaded = false;
            buttonApply.Select();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            if (indxPrimary < 0) {
                int cnt = 0;
                
                string res = "";
                res += "SELECT";
                string col = "";
                for (int i = 0; i < listCol.Items.Count; ++i) {
                    if (listCol.GetItemChecked(i)) {
                        col += ", " + listCol.Items[i].ToString();
                        ++cnt;
                    }
                }
                if (cnt <= 0) {
                    string msg =
@"you have nothing to insert
select minimal one column !";
                    Msg.Warrn(msg);
                    return;
                }

                if (!col.Equals(""))
                    col = col.Remove(0, 1);
                res += col + " FROM `" + labelTable.Text + "` ";
                this.getSQL = res;
            } else {
                int primary = 0;
                int cnt = 0;
                string res = "";
                res += "SELECT";
                string col = "";
                for (int i = 0; i < listCol.Items.Count; ++i) {
                    if (listCol.GetItemChecked(i)) {
                        col += ", " + listCol.Items[i].ToString();
                        if (listCol.Items[i].ToString().Equals(colPri))
                            primary = cnt;
                        ++cnt;
                    }

                }

                if (!col.Equals(""))
                    col = col.Remove(0, 1);
                res += col + " FROM `" + labelTable.Text + "` ";
                this.getSQL = res;
                this.indxPrimary = primary;
            }
            IsOk = true;
            this.Close();
        }

        private void buttonUp_Click(object sender, EventArgs e) {
            MoveItem(-1);
        }

        private void buttonDown_Click(object sender, EventArgs e) {
            MoveItem(1);
        }

        public void MoveItem(int direction) {
            if (listCol.SelectedItem == null || listCol.SelectedIndex < 0)
                return; 

            int newIndex = listCol.SelectedIndex + direction;

            if (newIndex < 0 || newIndex >= listCol.Items.Count)
                return;

            object selected = listCol.SelectedItem;
            bool val = listCol.GetItemChecked(listCol.SelectedIndex);

            listCol.Items.Remove(selected);

            listCol.Items.Insert(newIndex, selected);

            listCol.SetSelected(newIndex, true);
            listCol.SetItemChecked(newIndex, val);
        }

        private void listCol_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (isLoaded)
                return;
            if (indxPrimary < 0)
                return;
            if (listCol.SelectedItem.ToString().Equals(colPri)) {
                e.NewValue = CheckState.Checked;
            }
        }
    }
}
