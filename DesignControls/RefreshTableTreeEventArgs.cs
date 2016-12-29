using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.DesignControls {
    public class RefreshDBTreeEventArgs : EventArgs {
        public string DatabaseName;
        public string TableDatabaseName;
        public object TableNameNew;
        public string TableNameOld;
    }
}
