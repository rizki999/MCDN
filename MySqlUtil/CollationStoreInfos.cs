using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.MySqlUtil {
    public class CollationStoreInfos {
        public CollationStoreInfos() {
            CharSet = string.Empty;
            Collation = string.Empty;
            IsDefault = false;
        }

        public string CharSet;
        public string Collation;
        public bool IsDefault;
    }
}
