using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MySqlClientDotNET.FileIO {
    public static class FileInfo {

        public static string GetSQLFileExtension {
            get {
                return "SQL Files (.sql)|*.sql|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            }
        }

        public static string GetCSVFileExtension {
            get {
                return "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            }
        }

        public static int GetBuffSize(Encoding encode) {
            return (encode.Equals(Encoding.ASCII) || encode.Equals(Encoding.Default)) ? 1024 : 4096;
        }

        public static string GetEncodingS(Encoding encode) {

            if (encode.Equals(Encoding.GetEncoding("utf-32BE"))) // UTF-32 big-endian 
                return "UTF-32 BE BOM"; //Encoding.GetEncoding("utf-32BE");
            if (encode.Equals(Encoding.UTF32)) // UTF-32, little-endian
                return "UTF-32 LE BOM"; //Encoding.UTF32;
            if (encode.Equals(Encoding.BigEndianUnicode)) // UTF-16, big-endian
                return "UTF-16 BE BOM";//Encoding.BigEndianUnicode;
            if (encode.Equals(Encoding.Unicode)) //UTF-16, little-endian
                return "UTF-16 LE BOM";//Encoding.Unicode;
            if (encode.Equals(Encoding.UTF8)) // UTF-8
                return "UTF-8 BOM";//Encoding.UTF8;
            if (encode.Equals(Encoding.UTF7)) // UTF-7
                return "UTF-7 BOM";//Encoding.UTF7;

            return "ASCII/(Unknown)";//Encoding.Default;
        }

        public static Encoding GetEncoding(string path) {
            byte[] b = System.IO.File.ReadAllBytes(path);

            if ((b.Length >= 4) && (b[0] == 0x00 && b[1] == 0x00 && b[2] == 0xFE && b[3] == 0xFF)) // UTF-32 big-endian 
                return Encoding.GetEncoding("utf-32BE");
            if ((b.Length >= 4) && (b[0] == 0xFF && b[1] == 0xFE && b[2] == 0x00 && b[3] == 0x00)) // UTF-32, little-endian
                return Encoding.UTF32;
            if ((b.Length >= 2) && (b[0] == 0xFE && b[1] == 0xFF)) // UTF-16, big-endian
                return Encoding.BigEndianUnicode;
            if ((b.Length >= 2) && (b[0] == 0xFF && b[1] == 0xFE)) //UTF-16, little-endian
                return Encoding.Unicode;
            if ((b.Length >= 3) && (b[0] == 0xEF && b[1] == 0xBB && b[2] == 0xBF)) // UTF-8
                return Encoding.UTF8;
            if ((b.Length >= 3) && (b[0] == 0x2b && b[1] == 0x2f && b[2] == 0x76)) // UTF-7
                return Encoding.UTF7;

            return Encoding.Default;
        }

        public static bool isWriteAble(string path) {
            if ((File.GetAttributes(path) & FileAttributes.ReadOnly) != 0)
                return false;

            var rules = File.GetAccessControl(path).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

            var groups = System.Security.Principal.WindowsIdentity.GetCurrent().Groups;
            string sidCurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;

            if (rules.OfType<System.Security.AccessControl.FileSystemAccessRule>().Any(r =>
                (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) &&
                r.AccessControlType == System.Security.AccessControl.AccessControlType.Deny &&
                (r.FileSystemRights & System.Security.AccessControl.FileSystemRights.WriteData) == System.Security.AccessControl.FileSystemRights.WriteData))
                return false;

            return rules.OfType<System.Security.AccessControl.FileSystemAccessRule>().Any(r =>
                    (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) &&
                    r.AccessControlType == System.Security.AccessControl.AccessControlType.Allow &&
                    (r.FileSystemRights & System.Security.AccessControl.FileSystemRights.WriteData) == System.Security.AccessControl.FileSystemRights.WriteData);
        }

        private const Int32 bufferSize = 128;

        public static int CountLines(string path) {
            int inc = 0;
            using (var fileStream = System.IO.File.OpenRead(path)) {
                string lines;
                using (var sr = new System.IO.StreamReader(fileStream, FileInfo.GetEncoding(path), true, bufferSize)) {
                    while ((lines = sr.ReadLine()) != null) {
                        inc++;
                    }
                }
            }
            return inc;
        }
    }
}
