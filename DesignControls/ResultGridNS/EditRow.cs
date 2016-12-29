using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    public class EditRow {

        public EditRow(List<int> colIdx,
                       List<string> priVal,
                       int rowIdx) {
            this.PrimaryKeyValue = priVal;
            this.ColumnIndex = colIdx;
            this.RowIndex = rowIdx;
        }
        public List<string> PrimaryKeyValue { get; set; }
        public List<int> ColumnIndex { get; set; }
        public int RowIndex { get; set; }
    }
}
