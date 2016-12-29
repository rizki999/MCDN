using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET {
    public static class Log {
        public static void WriteL(string msg, params object[] p) {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(msg, p);
            System.Media.SystemSounds.Hand.Play();
#endif
        }

        public static void WriteL(object msg) {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(msg);
            System.Media.SystemSounds.Hand.Play();
#endif
        }

        public static void Write(string msg) {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(msg);
            System.Media.SystemSounds.Hand.Play();
#endif
        }
    }
}
