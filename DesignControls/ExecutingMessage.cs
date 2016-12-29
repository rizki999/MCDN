using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.DesignControls {
    public class ExecuteMessageEventArgs : EventArgs {
        public ExecuteMessageEventArgs() {
            this.Action = "";
            this.Error = "";
            this.Stetment = "";
            ClearMessage = false;
        }
        public bool ClearMessage;
        public string Action { get; set; }
        public string Stetment { get; set; }
        public string Error { get; set; }
    }

    public static class MessageKeyword {
        public static string BuildErrorMessage(string msg) {
            return LanguageApp.langMessage["MSGError"] + " : " + msg + "\n";
        }

        public static string BuildSqlStetmentMessage(string msg) {
            return LanguageApp.langMessage["MSGSQLStetment"] + " : " + msg + "\n";
        }

        public static string BuildSqlActionMessage(string msg) {
            return LanguageApp.langMessage["MSGAction"] + " : " + msg + "\n";
        }
        public static string BuildMessage(string msg) {
            return LanguageApp.langMessage["MSGMessage"] + " : " + msg + "\n";
        }
    }
}
