using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlClientDotNET.MySqlUtil {
    public class ReadDatas {
        private MySqlConnection mySqlCon;
        private MySqlCommand mySqlCmd;
        private MySqlDataReader mySqlRead;

        public ReadDatas(string conStr, string sql) {
            try {
                mySqlCon = new MySqlConnection(conStr);
                mySqlCon.Open();
                mySqlCmd = new MySqlCommand(sql, mySqlCon);
                mySqlRead = mySqlCmd.ExecuteReader();
            } catch (MySqlException e) {
                if (mySqlCon != null) 
                    mySqlCon.Dispose();
                if (mySqlCmd != null) 
                    mySqlCmd.Dispose();
                if (mySqlRead != null) 
                    mySqlRead.Dispose();
                throw e;
            }
        }

        public MySqlDataReader Data {
            get {
                if (mySqlRead != null)
                    return mySqlRead;
                return null;
            }
        }

        public bool Read() {
            if (mySqlRead != null)
                return mySqlRead.Read();
            return false;
        }

        public void Close() {
            if (mySqlCon.State == System.Data.ConnectionState.Open)
                mySqlCon.Close();
            if (!mySqlRead.IsClosed)
                mySqlRead.Close();
        }

        public bool HasRows {
            get {
                if (mySqlRead != null)
                    return mySqlRead.HasRows;
                return false;
            }
        }

        public void Dispose() {
            if (mySqlCon != null)
                mySqlCon.Dispose();
            if (mySqlCmd != null)
                mySqlCmd.Dispose();
            if (mySqlRead != null)
                mySqlRead.Dispose();
        }
    }
}
