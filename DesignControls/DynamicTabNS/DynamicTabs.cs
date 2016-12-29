using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls.DynamicTabNS {
    public partial class DynamicTabs : UserControl {
        
        public DynamicTabs() {
            InitializeComponent();
            lsbList.LostFocus += new System.EventHandler(this.lsbList_LostFocus);
            try {
                this.btClose.Image = Image.FromFile(ResourcesPath.img_close_S);
                this.btList.Image = Image.FromFile(ResourcesPath.img_down_S);
            } catch { }
            wtab = 140;
            lentab = -1;
            dynamicTabPage = new List<DynamicTabPage>();
            dynamicTabIndex = -1;
            dynamicTabTextHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 
                                                               9.0F, 
                                                               System.Drawing.FontStyle.Regular, 
                                                               System.Drawing.GraphicsUnit.Point, 
                                                               ((byte)(0)));
            panTabHeaderControls.Visible = false;
            maxListTab = 7;
            panHTabHeader.Size = new System.Drawing.Size(1, 26);
            panMain.BackgroundImage = Image.FromFile(ResourcesPath.img_mysql_L);
            panMain.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private byte wtab;
        private int lentab;
        private int dynamicTabIndex;
        private byte maxListTab;
        private List<DynamicTabPage> dynamicTabPage;
        private Font dynamicTabTextHeaderFont;

        public int DynamicTabSelectedIndex { //aksjknjkajs
            get {
                return dynamicTabIndex;
            }
            set {
                int val = value;
                if (dynamicTabIndex == val) {
                    DyanamicTabSelectedTabEventArgs e = new DyanamicTabSelectedTabEventArgs();
                    e.IndexTab = val;
                    e.TabPage = dynamicTabPage[val].PageType;
                    return;
                }
                if (val >= 0 && val < DynamicTabCount) {

                    selectTab(val);
                    deselectTab(dynamicTabIndex);
                    dynamicTabIndex = val;

                } else
                    throw new IndexOutOfRangeException("Index Out of Range !");
            }
        }

        public List<DynamicTabPage> DynamicTabPage {
            get {
                return dynamicTabPage;               
            }
        }

        public int DynamicTabCount {
            get {
                return dynamicTabPage.Count;
            }
        }

        private void tabClick(object sender, EventArgs e) {
            for (int i = 0; i < panHTabHeader.Controls.Count; ++i) {
                if (panHTabHeader.Controls[i].Focused) {
                    if (i == dynamicTabIndex)
                        return;
                    DynamicTabSelectedIndex = i;
                    tabSizeChangd();
                    break;
                }
            }
        }

        private void OnSelctedTab(DyanamicTabSelectedTabEventArgs e) {
            if (SelectedTab != null)
                SelectedTab(this, e);
        }

        private int getIndexFromMouseHover() {
            int i = 0;
            int x = panHTabHeader.PointToClient(Cursor.Position).X;
            for (i = 0; i < panHTabHeader.Controls.Count; ++i) {
                if (((i * (wtab - 1)) + (wtab - 1)) > x) {
                    return i;
                }
            }
            return i;
        }

        private void TabMouseDown(object sender, MouseEventArgs e) {
            int i = getIndexFromMouseHover();
            if (i == dynamicTabIndex)
                return;
            DynamicTabSelectedIndex = i;
            tabSizeChangd();
        }

        private void lsbAdd(string item) {
            lsbList.Items.Add(item);
            if (lsbList.Items.Count <= maxListTab) {
                int y1 = lsbList.Size.Height;
                int y2 = lsbList.Font.Height + 1;
                int x = lsbList.Size.Width;
                lsbList.Size = new System.Drawing.Size(x, y1 + y2);
            }
            
        }

        private void lsbRemoveAt(int idx) {
            lsbList.Items.RemoveAt(idx);
            if (lsbList.Size.Height >= 13) {
                if (lsbList.Items.Count < maxListTab)
                    lsbList.Size = new System.Drawing.Size(lsbList.Size.Width, lsbList.Size.Height - lsbList.Font.Height);
            }
        }

        private void tabSizeChangd() {
            int endTab = this.Size.Width - panTabHeaderControls.Size.Width;//57;
            int startTab = 0;
            int cPositionTab = (wtab - 1) * dynamicTabIndex;
            int middle = lentab / 2;
            if (lentab < endTab) {
                panHTabHeader.Location = new System.Drawing.Point(startTab, panHTabHeader.Location.Y);
                return;
            }
            
            if (dynamicTabIndex == 0) {
                panHTabHeader.Location = new System.Drawing.Point(startTab, panHTabHeader.Location.Y);
                return;
            } else if (dynamicTabIndex == (panHTabHeader.Controls.Count - 1)) {
                panHTabHeader.Location = new System.Drawing.Point(endTab - lentab, panHTabHeader.Location.Y);
                return;
            }

            if (((panHTabHeader.Location.X + cPositionTab) + (wtab - 1)) >= endTab) 
                panHTabHeader.Location = new System.Drawing.Point(endTab - (cPositionTab + (wtab - 1)), panHTabHeader.Location.Y);
            if ((panHTabHeader.Location.X + cPositionTab) < startTab) 
                panHTabHeader.Location = new System.Drawing.Point(startTab - cPositionTab, panHTabHeader.Location.Y);
        }

        private void selectTab(int idx) {
            if (panHTabHeader.Controls.Count < 1)
                return;
            lsbList.SelectedIndex = idx;
            Button bt = (Button)panHTabHeader.Controls[idx];
            bt.Location = new System.Drawing.Point(bt.Location.X, 0);
            bt.Size = new System.Drawing.Size(bt.Size.Width, 30);
            bt.UseVisualStyleBackColor = true;
            panMain.Controls.Clear();
            panMain.Controls.Add(dynamicTabPage[idx]);
            dynamicTabPage[idx].SelectControls();
        }

        private void deselectTab(int idx) {
            if (panHTabHeader.Controls.Count <= 1)
                return;
            Button bt = (Button)panHTabHeader.Controls[idx];
            bt.Location = new System.Drawing.Point(bt.Location.X, 4);
            bt.Size = new System.Drawing.Size(bt.Size.Width, 26);
            bt.UseVisualStyleBackColor = false;
        }

        public int GetUniqueId() {
            int idx = dynamicTabPage.Count;
            int max = -1;
            for (int i = 0; i < idx; ++i) {
                if (max < dynamicTabPage[i].UniqueId) 
                    max = dynamicTabPage[i].UniqueId;
            }
            return ++max;
        }

        public void AddTabPage(DynamicTabPage tabPage) {
            int idx = panHTabHeader.Controls.Count;

            tabPage.TabIndex = idx;
            tabPage.DynamicTabIndex = idx;

            if (tabPage.Dock == DockStyle.None) {
                tabPage.Location = new Point(0, 0);
                tabPage.Size = new System.Drawing.Size(this.panMain.Size.Width, this.panMain.Size.Height);
                tabPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left)
                                | System.Windows.Forms.AnchorStyles.Right)));
            }

            tabPage.TabHeaderTextChanged += new EventHandler<DynamicTabTextHeaderChangedEventArgs>(dynamicTabPages_TabHeaderTextChanged);
            tabPage.ForceCloseTab += new EventHandler<DynamicTabCloseTabEventArgs>(forceCloseTab);
            tabPage.CompareTabPage += new EventHandler<DynamicTabCompareTabPageEventArgs>(CompareTabPage);

            if (tabPage.UniqueId == -1)
                tabPage.UniqueId = GetUniqueId();


            Button bt = new Button();
            bt.Font = dynamicTabTextHeaderFont;
            bt.Location = new System.Drawing.Point(lentab, 4);
            bt.Name = "Tab_headr" + idx;
            bt.Size = new System.Drawing.Size(wtab, 26);
            bt.Text = tabPage.TabHeaderText;
            bt.UseVisualStyleBackColor = true;
            bt.TextAlign = ContentAlignment.MiddleLeft;
            bt.Click += new EventHandler(tabClick);
            bt.MouseDown += new System.Windows.Forms.MouseEventHandler(TabMouseDown);
            bt.MouseWheel += new MouseEventHandler(bt_MouseWheel);

            panHTabHeader.Controls.Add(bt);
            dynamicTabPage.Add(tabPage);
            lsbAdd(tabPage.TabHeaderText);
            DyanamicTabSelectedTabEventArgs e = new DyanamicTabSelectedTabEventArgs();
            e.IndexTab = idx;
            e.TabPage = tabPage.PageType;
            OnSelctedTab(e);
            panHTabHeader.Size = new System.Drawing.Size(panHTabHeader.Size.Width + (wtab - 1),
                                                         panHTabHeader.Size.Height);

            DynamicTabSelectedIndex = idx;

            dynamicTabIndex = idx;
            lentab += wtab - 1;
            tabSizeChangd();

            if (tabPage.TabHeaderText.Equals("")) {
                tabPage.TabHeaderText = "[" + LanguageApp.langDynamicTabDoc["THNew"] + " " + tabPage.UniqueId + "]";
                tabPage.IsEdited = true;
            } else
                SetTextTab(tabPage.TabHeaderText, idx);

            if (!panTabHeaderControls.Visible)
                panTabHeaderControls.Visible = true;
            tabPage.IsEdited = tabPage.IsEdited;
            tabPage.InitializedOnDynamicTab();
        }

        void bt_MouseWheel(object sender, MouseEventArgs e) {
            int res = 0;
            int delta = e.Delta / 8;
            int resLocation = 0;
            int del = 0;
            int endTab = this.Size.Width - panTabHeaderControls.Size.Width;
            int startTab = 0;

            if (panHTabHeader.Size.Width < endTab)
                return;

            if (e.Delta < 0) {
                res = panHTabHeader.Location.X + panHTabHeader.Size.Width;
                del = res + delta;
                resLocation = del < endTab - 4 ? panHTabHeader.Location.X : panHTabHeader.Location.X + delta;
            }

            if (e.Delta > 0) {
                del = panHTabHeader.Location.X + delta;
                resLocation = del >= startTab ? 0 : panHTabHeader.Location.X + delta;
            }
            panHTabHeader.Location = new Point(resLocation, 0);
        }

        private void dynamicTabPages_TabHeaderTextChanged(object sender, DynamicTabTextHeaderChangedEventArgs e) {
            SetTextTab(e.TextHeader, e.DynamicTabIndex);
        }

        private void LoackControlPanHeader(object sender, DyanamicTabLockControl e) {
            panTabHeaderControls.Enabled = e.LockedControl;

        }

        public int isFileLoaded(string path) {
            for (int i = 0; i < dynamicTabPage.Count; ++i) {
                if (dynamicTabPage[i].LoadedFile.Equals(path))
                    return i;
            }

            return -1;
        }

        private void SetTextTab(string text, int idx) {
            if (idx < 0)
                return;

            string htext = text;

            using (Graphics dynamicTabGraphics = this.CreateGraphics()) {
                SizeF sf = new SizeF();
                int i = 0;
                int sizeF = 0;

                for (i = 0; i < text.Length; ++i) {
                    sf = dynamicTabGraphics.MeasureString(text[i].ToString(), dynamicTabTextHeaderFont);
                    sizeF += (int)Math.Ceiling(sf.Width) <= 11 ? (int)Math.Floor(sf.Width - 1.5) : (int)Math.Ceiling(sf.Width - 3.5);
                    if (sizeF >= wtab) {
                        htext = text.Remove(i) + "...";
                        break;
                    }
                }
            }

            panHTabHeader.Controls[idx].Text = htext;
            if (idx < lsbList.Items.Count)
                lsbList.Items[idx] = text;
        }

        private void btClose_Click(object sender, EventArgs e) {
            CloseTabByIndex(dynamicTabIndex);
        }

        public void CloseTabByForeginId(int id) {
            int max = DynamicTabCount;
            int cnt = 0;
            var lsClose = new List<int>();
            for (int i = 0; i < max; ++i) {
                if (id == dynamicTabPage[i].ForeginId) {
                    lsClose.Add(i);
                }
            }

            for (int i = 0; i < lsClose.Count; ++i) {
                DynamicTabSelectedIndex = lsClose[i] - cnt;
                CloseTabByIndex(lsClose[i] - cnt);
                ++cnt;
            }
        }

        private void changeIndaxTabInTabPage() {
            for (int i = 0; i < dynamicTabPage.Count; ++i) {
                dynamicTabPage[i].DynamicTabIndex = i;


                dynamicTabPage[i].TabIndex = i;
            }
        }

        private void forceCloseTab(object sender, DynamicTabCloseTabEventArgs e) {
            dynamicTabPage[e.IndexTab].OnClosedTab();
            //onCloseTab(e.IndexTab, dynamicTabPage[e.IndexTab].UniqueId);
            panHTabHeader.Controls[e.IndexTab].Dispose();
            dynamicTabPage[e.IndexTab].Dispose();
            dynamicTabPage.RemoveAt(e.IndexTab);
            panMain.Controls.Clear();
            lsbRemoveAt(e.IndexTab);


            panHTabHeader.Size = new System.Drawing.Size(panHTabHeader.Size.Width - (wtab - 1),
                                                         panHTabHeader.Size.Height);

            lentab -= (wtab - 1);

            if (e.IndexTab == panHTabHeader.Controls.Count) {
                dynamicTabIndex = (e.IndexTab > 0) ? e.IndexTab - 1 : -1;
            } else {
                for (int i = dynamicTabIndex; i < panHTabHeader.Controls.Count; ++i) {
                    panHTabHeader.Controls[i].Location = new Point(panHTabHeader.Controls[i].Location.X - wtab + 1,
                                                                   panHTabHeader.Controls[i].Location.Y);
                }
            }

            changeIndaxTabInTabPage();

            selectTab(dynamicTabIndex);
            tabSizeChangd();
            //pa$nTabHeaderControls.Visible = dynamicTabIndex < 0 ? false : true;
        }

        public void CloseAllTab() {

            for (int idx = 0; idx < dynamicTabPage.Count; ++idx) {
                dynamicTabPage[idx].OnClosedTab();
                onCloseTab(idx, dynamicTabPage[idx].UniqueId, dynamicTabPage[idx].PageType);
            }

            panMain.Controls.Clear();

            foreach (Control ctrl in panHTabHeader.Controls)
                ctrl.Dispose();
            panHTabHeader.Controls.Clear();
            foreach (DynamicTabPage page in dynamicTabPage)
                page.Dispose();
            dynamicTabPage.Clear();
            lsbList.Size = new System.Drawing.Size(lsbList.Size.Width, 0);


            panHTabHeader.Size = new System.Drawing.Size(1, 26);

            lentab = -1;
            dynamicTabIndex = -1;

            //panTabHeaderControls.Visible = false;
        }

        public void CloseTabByIndex(int idx) {
            if (idx < 0)
                return;
            if (!dynamicTabPage[idx].CanClose)
                return;
            if (dynamicTabPage[idx].IsEdited) {
                if (!dynamicTabPage[idx].CloseTabAnyway()) {
                    return;
                }
            }

            dynamicTabPage[idx].OnClosedTab();
            onCloseTab(idx, dynamicTabPage[idx].UniqueId, dynamicTabPage[idx].PageType);
            panHTabHeader.Controls[idx].Dispose();
            dynamicTabPage[idx].Dispose();
            dynamicTabPage.RemoveAt(idx);
            panMain.Controls.Clear();
            lsbRemoveAt(idx);

            panHTabHeader.Size = new System.Drawing.Size(panHTabHeader.Size.Width - (wtab - 1),
                                                         panHTabHeader.Size.Height);

            lentab -= (wtab - 1);

            if (idx == panHTabHeader.Controls.Count) 
                dynamicTabIndex = (idx > 0) ? idx - 1 : -1;
            else {
                for (int i = dynamicTabIndex; i < panHTabHeader.Controls.Count; ++i)
                    panHTabHeader.Controls[i].Location = new Point(panHTabHeader.Controls[i].Location.X - wtab + 1,
                                                                   panHTabHeader.Controls[i].Location.Y);
            }

            changeIndaxTabInTabPage();

            selectTab(dynamicTabIndex);
            tabSizeChangd();
            //panTabHeaderControls.Visible = dynamicTabIndex < 0 ? false : true;
        }

        public bool getUniqueIdByIndex(int idx, out int res) {
            res = -1;
            if (idx < DynamicTabCount) {
                res = dynamicTabPage[idx].UniqueId;
                return true;
            }
            return false;
        }

        public void CompareTabPage(object sender, DynamicTabCompareTabPageEventArgs e) {
            //e.TabPageIsExist = false;
            for (int i = 0; i < dynamicTabPage.Count; ++i) {
                if (e.TabPageIndex == i)
                    continue;
                if (dynamicTabPage[i].LoadedFile.Equals(e.FilePath)) {
                    e.TabPageIsExist = true;
                    break;
                }
            }
        }

        private void btList_Click(object sender, EventArgs e) {
            if (lsbList.Items.Count == 0)
                return;
            if (lsbList.Visible) {
                lsbList.Visible = false;
                return;
            }
            lsbList.Visible = true;
            lsbList.Select();
        }

        private void lsbList_LostFocus(object sender, EventArgs e) {
            lsbList.Visible = false;
        }

        private void DynamicTabs_SizeChanged(object sender, EventArgs e) {
            tabSizeChangd();
        }

        private void lsbList_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                DynamicTabSelectedIndex = lsbList.SelectedIndex;
                panHTabHeader.Controls[DynamicTabSelectedIndex].Select();
                tabSizeChangd();
                lsbList.Visible = false;
            }
        }

        private void onCloseTab(int idx, int uniqueId, TabPageType tPageType) {
            DynamicTabCloseTabEventArgs e = new DynamicTabCloseTabEventArgs();
            e.IndexTab = idx;
            e.UniqueId = uniqueId;
            e.TabPage = tPageType;
            EventHandler<DynamicTabCloseTabEventArgs> handler = ClosingTab;
            if (handler != null)
                handler(this, e);
        }

        public event EventHandler<DynamicTabCloseTabEventArgs> ClosingTab;
        public event EventHandler<DyanamicTabSelectedTabEventArgs> SelectedTab;
    }
}
