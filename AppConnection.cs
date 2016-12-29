using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlClientDotNET {
    public static class AppConnection {
        public static MySqlConnection Connection { get; set; }

        public static MySqlConnection ChangeDatabase(string db) {
            try {
                Connection.ChangeDatabase(db);
            } catch (MySqlException ex) {
                throw ex;
            }
            return Connection;
        }

        public static void SetDefaultDatabase() {
            try { 
                if (!MySqlConfig.DatabaseSelected.Equals(""))
                    Connection.ChangeDatabase(MySqlConfig.DatabaseSelected);
            } catch (MySqlException ex) {
                throw ex;
            }
        }
    }
}
