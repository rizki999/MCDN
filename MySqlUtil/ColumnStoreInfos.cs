using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.MySqlUtil {
    public class ColumnStoreInfos {
        public ColumnStoreInfos() {
            ConstrineName = 
                ColumnNameTemp =
                ColumnName = 
                ColumnMode = "";
            isPrimary = false;
        }
        public string ColumnName { get; set; }
        public string ColumnComment { get; set; }
        public string DataType { get; set; }
        public string Size { get; set; }
        public bool isPrimary { get; set; }
        public bool isNotNULL { get; set; }
        public bool isUnsigned { get; set; }
        public bool isZeroFIll { get; set; }
        public bool isAutoIncerement { get; set; }
        public bool isGeneretedColumn { get; set; }
        public string CharSet { get; set; }
        public string Collation { get; set; }
        public string DefaultORExpression { get; set; }
        public string VirtualORStore { get; set; }
        public string ConstrineName { get; set; }
        public string ColumnNameTemp { get; set; }
        public string ColumnMode { get; set; }
    }
}
