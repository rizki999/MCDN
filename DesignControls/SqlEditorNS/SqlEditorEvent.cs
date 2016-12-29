using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.DesignControls.SqlEditorNS {
    public class SqlEditorExecuteEventArgs :EventArgs {
        public int UniqueId { get; set; }
        public string SqlScript { get; set; }
        public int LimitPage { get; set; }
    }
}
