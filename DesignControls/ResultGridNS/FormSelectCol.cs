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
            databaseAndTableName = "";
            IsOk = false;
            colPri = new List<string>();
            isLoaded = true;
            language();
        }

        private void language() {
            this.Text = LanguageApp.langFormSelCol["FTSelectCol"];
            
            labelTable.Text = LanguageApp.langFormSelCol["LBDbTb"];

            buttonUp.Text = LanguageApp.langFormSelCol["BTUp"];
            buttonDown.Text = LanguageApp.langFormSelCol["BTDown"];
            buttonApply.Text = LanguageApp.langFormSelCol["BTApply"];
            buttonCancel.Text = LanguageApp.langFormSelCol["BTCancel"];

            MSGHaveNoCol = LanguageApp.langFormSelCol["MSGHaveNoCol"];
        }

        private string MSGHaveNoCol;

        private List<string> colPri;
        private string databaseAndTableName;

        public List<int> indexPrimary { get; set; }

        public string DatabaseAndTableName {
            get {
                return databaseAndTableName;
            }
            set {
                databaseAndTableName = value;
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
            if (indexPrimary.Count > 0) {
                for (int i = 0; i < indexPrimary.Count; ++i)
                    colPri.Add(listCol.Items[indexPrimary[i]].ToString());
            }
            isLoaded = false;
            buttonApply.Select();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            if (indexPrimary.Count <= 0) {
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
                    Msg.Warrn(MSGHaveNoCol);
                    return;
                }

                if (!col.Equals(""))
                    col = col.Remove(0, 1);
                res += col + " FROM `" + labelTable.Text + "` ";
                this.getSQL = res;
            } else {
                List<int> primary = new List<int>();
                int cnt = 0;
                string res = "";
                res += "SELECT";
                string col = "";
                for (int i = 0; i < listCol.Items.Count; ++i) {
                    if (listCol.GetItemChecked(i)) {
                        col += ", " + listCol.Items[i].ToString();
                        for (int j = 0; j < colPri.Count; ++j) {
                            if (listCol.Items[i].ToString().Equals(colPri[j]))
                                primary.Add(cnt);
                        }
                        ++cnt;
                    }

                }

                if (!col.Equals(""))
                    col = col.Remove(0, 1);
                res += col + " FROM `" + labelTable.Text + "` ";
                this.getSQL = res;
                this.indexPrimary.Clear();
                for (int i = 0; i < primary.Count; ++i)
                    this.indexPrimary.Add(primary[i]);
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
            int selIdx = listCol.SelectedIndex;
            bool val = listCol.GetItemChecked(listCol.SelectedIndex);

            listCol.Items.Remove(selected);

            listCol.Items.Insert(newIndex, selected);

            listCol.SetSelected(newIndex, true);
            listCol.SetItemChecked(newIndex, val);
        }

        private void listCol_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (isLoaded)
                return;
            if (indexPrimary.Count == 0)
                return;
            for (int i = 0; i < colPri.Count; ++i) {
                if (listCol.SelectedItem.ToString().Equals(colPri[i]))
                    e.NewValue = CheckState.Checked;
            }
        }
    }
}
