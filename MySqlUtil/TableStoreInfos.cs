using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.MySqlUtil {
    public class TableStoreInfos {
        public TableStoreInfos() {
            CollationName = string.Empty;
            CharsetName = string.Empty;
            IsDefaultColl = false;
            TableName = string.Empty;
            TableEngine = string.Empty;
            DatabaseName = string.Empty;
            TableComment = string.Empty;
            DatabaseCollation = string.Empty;
            DatabaseEngine = string.Empty;
        }
        public string DatabaseName { get; set; }
        public string DatabaseCollation { get; set; }
        public string DatabaseEngine { get; set; }
        public string TableComment { get; set; }
        public string CollationName { get; set; }
        public string CharsetName { get; set; }
        public bool IsDefaultColl { get; set; }
        public string TableName { get; set; }
        public string TableEngine { get; set; }
    }
}
