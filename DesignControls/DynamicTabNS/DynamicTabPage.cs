using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls.DynamicTabNS {
    public class DynamicTabPage : Panel {

        public DynamicTabPage() {
            TabHeaderText = "";
            isEdited = false;
            UniqueId = -1;
            LoadedFile = "";
            PageType = TabPageType.Unregonized;
            CanClose = true;
        }

        public virtual void InitializedOnDynamicTab() {
            return;
        }

        public TabPageType PageType { get; set; }
        public bool CanClose { get; set; }

        public bool IsEdited {
            get {
                return isEdited;
            }
            set {
                DynamicTabTextHeaderChangedEventArgs e = new DynamicTabTextHeaderChangedEventArgs();
                if (value) {
                    e.TextHeader = "*" + tabHeaderText;
                } else {
                    e.TextHeader = tabHeaderText;
                }
                e.DynamicTabIndex = DynamicTabIndex;
                onTabHeadrTextChanged(e);
                isEdited = value;
            }
        }

        public string LoadedFile { get; set; }
        public bool LockControl {
            get {
                return lockControl;
            }
            set {
                lockControl = value;
                DyanamicTabLockControl dLc = new DyanamicTabLockControl();
                dLc.LockedControl = value;

                onLoackControl(dLc);
            }
        }

        private string tabHeaderText;
        private bool isEdited;
        private bool lockControl;
        public int ForeginId { get; set; }

        protected virtual void onLoackControl(DyanamicTabLockControl e) {
            EventHandler<DyanamicTabLockControl> handler = LoackingControls;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void onTabHeadrTextChanged(DynamicTabTextHeaderChangedEventArgs e) {
            EventHandler<DynamicTabTextHeaderChangedEventArgs> handler = TabHeaderTextChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        public void ForceCloseTabPage() {
            EventHandler<DynamicTabCloseTabEventArgs> handle = ForceCloseTab;
            DynamicTabCloseTabEventArgs e = new DynamicTabCloseTabEventArgs();
            e.IndexTab = DynamicTabIndex;
            e.UniqueId = UniqueId;
            if (handle != null)
                handle(this, e);
        }

        protected bool IsDuplicateFileInTab(string filePath) {
            EventHandler<DynamicTabCompareTabPageEventArgs> handle = CompareTabPage;
                DynamicTabCompareTabPageEventArgs e = new DynamicTabCompareTabPageEventArgs();
                e.TabPageIndex = this.TabIndex;
                e.FilePath = filePath;
                if (handle != null)
                    handle(this, e);
                return e.TabPageIsExist;
        }

        public string TabHeaderText {
            get {
                return tabHeaderText;
            }
            set {
                DynamicTabTextHeaderChangedEventArgs e = new DynamicTabTextHeaderChangedEventArgs();
                e.TextHeader = isEdited ? "*" + value : value;
                e.DynamicTabIndex = DynamicTabIndex;
                onTabHeadrTextChanged(e);
                tabHeaderText = value;
            }
        }

        protected void sendSqlExecutedMessage(ExecuteMessageEventArgs ex) {
            if (SqlExecuteMessaeg != null)
                SqlExecuteMessaeg(this, ex);
        }

        protected void sendSqlExecutedMessage(object sender, ExecuteMessageEventArgs ex) {
            if (SqlExecuteMessaeg != null)
                SqlExecuteMessaeg(sender, ex);
        }

        protected void onErrorMessage(string msgAction, string msgErr) {
            ExecuteMessageEventArgs exec = new ExecuteMessageEventArgs();
            exec.Action = MessageKeyword.BuildSqlActionMessage(msgAction);
            exec.Error = MessageKeyword.BuildErrorMessage(msgErr);
            if (SqlExecuteMessaeg != null)
                SqlExecuteMessaeg(this, exec);
        }

        public virtual bool CloseTabAnyway() {
            DialogResult dialogResult = Msg.WarrnQ(LanguageApp.langDynamicTabDoc["MSGCloseTab"]);
            switch (dialogResult) {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
            }
            return false;
        }

        public event EventHandler<ExecuteMessageEventArgs> SqlExecuteMessaeg;

        public virtual void OnClosedTab() { }
        public virtual bool OnSaveFile() { return true; }
        public virtual void SelectControls() { }
        public virtual void DataSourceVirtual(string sql, string cnstr) { }

        public event EventHandler<DynamicTabTextHeaderChangedEventArgs> TabHeaderTextChanged;
        public event EventHandler<DynamicTabCloseTabEventArgs> ForceCloseTab;
        public event EventHandler<DyanamicTabLockControl> LoackingControls;
        public event EventHandler<DynamicTabCompareTabPageEventArgs> CompareTabPage;
        public int UniqueId { get; set; }
        public int DynamicTabIndex { get; set; }
    }
}
