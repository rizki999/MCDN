using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using IniParser;
using IniParser.Model;

namespace MySqlClientDotNET {
    public static class MySqlConfig {
        private static string server = "";
        private static string uid = "";
        private static string passwd = "";
        private static string database = "";
        private static string port = "";

        public static string[] ListKeyword {
            get {
                return new string[] {
                    "SELECT", "UPDATE",
                    "DELETE", "INSERT",
                    "INTO", "TABLES",
                    "DATABASES", "ALTER",
                    "DROP", "FROM",
                    "JOIN", "LEFT",
                    "RIGHT", "INNER",
                    "IF", "EXIST",
                    "DESCRIBE", "WHERE",
                    "USE", "SHOW",
                    "CREATE", "TABLE",
                    "DATABASE", "LIMIT",
                    "VALUES"
                };
            }
        }

        public static void initializeSyntax() {
            string listKey = "";
            for (int i = 0; i < ListKeyword.Length; ++i) {
                if (i != 0)
                    listKey += "|";
                listKey += ListKeyword[i];
            }
            syntaxSQL = @"\b(" + listKey + @")\b";
        }

        public static string syntaxSQL;

        public static string GetLimit() {
            string limit = "25";
            try {
                FileIniDataParser fileIni = new FileIniDataParser();
                IniData iniData = fileIni.ReadFile(ResourcesPath.ini_file);
                limit = iniData["app_config"]["sql_limit"];
            } catch { }
            return limit;
        }

        public static string[] ListLimit {
            get {
                return new string[] {
                    "10", "50", 
                    "100", "150", 
                    "200", "250",
                    "300", "350",
                    "400", "450",
                    "500", "550"
                };
            }
        }

        public static string CollationName { get; set; }
        public static string CharSetName { get; set; }
        public static bool CollDefault { get; set; }
        public static string DefaultStoreEngine { get; set; }

        public static void createINIFile() {
            FileIniDataParser fileIni = new FileIniDataParser();
            IniData iniData;
            fileIni = new FileIniDataParser();
            fileIni.Parser.Configuration.AllowDuplicateKeys = false;
            fileIni.Parser.Configuration.AllowDuplicateSections = false;
            fileIni.Parser.Configuration.CommentString = "#";
            
            iniData = new IniData();
            iniData.Sections.AddSection("app_config");
            iniData.Sections.GetSectionData("app_config").Keys.AddKey("sql_limit", ListLimit[0]);
            if (System.IO.File.Exists(ResourcesPath.ini_file))
                System.IO.File.Delete(ResourcesPath.ini_file);
            fileIni.WriteFile(ResourcesPath.ini_file, iniData, Encoding.ASCII);
        }

        private static string mySqlDateTime;
        private static string mySqlTime;
        private static string mySqlDate;

        public static string SetMySqlDateTime {
            get {
                return mySqlDateTime;
            }
            set {
                mySqlDateTime = value;
            } 
        }

        public static string SetMySqlDate {
            get {
                return mySqlDate;
            }
            set {
                mySqlDate = value;
            } 
        }

        public static string SetMySqlTime {
            get {
                return mySqlTime;
            }
            set {
                mySqlTime = value;
            } 
        }

        public static string MySqlDateTimeToDotNetDateTime() {
            return "yyyy-MM-dd HH:mm:ss";
        }

        public static string MySqlDateToDotNetDate() {
            return "yyyy-MM-dd";
        }

        public static string MySqlTimeToDotNetTime() {
            return "HH:mm:ss";
        }

        public static string GetAppConfig(string get) {
            try {
                FileIniDataParser fileIni = new FileIniDataParser();
                IniData iniData;
                //fileIni.Parser.Configuration.AllowDuplicateKeys = false;
                //fileIni.Parser.Configuration.AllowDuplicateSections = false;
                fileIni.Parser.Configuration.CommentString = "#";
                iniData = fileIni.ReadFile(ResourcesPath.ini_file);
                string str = iniData["app_config"][get];
                return str;
            } catch (Exception ex) { Log.WriteL("Error : {0}", ex.Message); }
            return "";
        }

        public static void settINIFile() {
            try {
                FileIniDataParser fileIni = new FileIniDataParser();
                IniData iniData;
                fileIni = new FileIniDataParser();
                fileIni.Parser.Configuration.AllowDuplicateKeys = false;
                fileIni.Parser.Configuration.AllowDuplicateSections = false;
                fileIni.Parser.Configuration.CommentString = "#";
                iniData = fileIni.ReadFile(ResourcesPath.ini_file);
                string tmp = iniData["app_config"]["sql_limit"];
                for (int i = 0; i < ListLimit.Length; ++i) {
                    if (tmp.Equals(ListLimit[i]))
                        return;
                }
                
                createINIFile();
            } catch { createINIFile(); }
        }

        public static bool DBFromSystem(string db) {
            if (db.Equals("information_schema"))
                return true;
            if (db.Equals("mysql"))
                return true;
            if (db.Equals("performance_schema"))
                return true;
            if (db.Equals("sys"))
                return true;
            return false;
        }

        public static string ConnectionString {
            get {
                return Server + Port + UID + Password + Database;
            }
        }

        public static string ConnectionStringWithotDB {
            get {
                return Server + Port + UID + Password;
            }
        }

        public static void ClearConnectionString() {
            server = string.Empty;
            uid = string.Empty;
            passwd = string.Empty;
            database = string.Empty;
            port = string.Empty;
            DefaultStoreEngine = "";
            CollDefault = false;
            CollationName = "";
            CharSetName = "";
        }

        public static string Host {
            get {
                return server;
            }
        }

        public static string Username {
            get {
                return uid;
            }
        }

        public static string ConnectionStringUseDatabase(string db) {
            return Server + Port + UID + Password + "DATABASE='" + db +"'";
        }

        public static string Server {
            get {
                if (!server.Equals(string.Empty))
                    return "SERVER=" + server + ";";
                return string.Empty;
            }
            set {
                server = value;
            }
        }

        public static string Port {
            get {
                if (!port.Equals(string.Empty))
                    return "PORT=" + port + ";";
                return string.Empty;
            }
            set {
                port = value;
            }
        }

        public static string UID {
            get {
                if (!uid.Equals(string.Empty))
                    return "USER ID=" + uid + ";";
                return string.Empty;
            }
            set {
                uid = value;
            }
        }

        public static string Password {
            get {
                if (!passwd.Equals(string.Empty))
                    return "PASSWORD=" + passwd + ";";
                return string.Empty;
            }
            set {
                passwd = value;
            }
        }

        public static string DatabaseSelected {
            get {
                return database;
            }
        }

        public static string Database {
            get {
                if (!database.Equals(string.Empty))
                    return "DATABASE='" + database + "';";
                return string.Empty;
            }
            set {
                database = value;
            }
        }
    }
}
