using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlClientDotNET.DesignControls.DynamicTabNS {
    public class DynamicTabTextHeaderChangedEventArgs : EventArgs {
        public string TextHeader { get; set; }
        public int DynamicTabIndex { get; set; }
    }

    public class DynamicTabCloseTabEventArgs : EventArgs {
        public int IndexTab { get; set; }
        public int UniqueId { get; set; }
        public TabPageType TabPage { get; set; }
    }

    public class DyanamicTabLockControl : EventArgs {
        public bool LockedControl { get; set; }
    }

    public class DynamicTabCompareTabPageEventArgs : EventArgs {
        public string FilePath {get; set; }
        public int TabPageIndex { get; set; }
        public bool TabPageIsExist { get; set; }
    }

    public class DyanamicTabSelectedTabEventArgs : EventArgs {
        public TabPageType TabPage { get; set; }
        public int IndexTab { get; set; }
    }
}
