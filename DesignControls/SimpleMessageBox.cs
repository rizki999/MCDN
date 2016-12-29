using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls {
    public static class Msg {
        public static void Err(string msg) {
            MessageBox.Show(msg, "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }

        public static void Succ(string msg) {
            MessageBox.Show(msg, "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
        }

        public static void Info(string msg) {
            MessageBox.Show(msg, "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
        }

        public static DialogResult WarrnQ(string msg) {
            System.Media.SystemSounds.Exclamation.Play();
            return MessageBox.Show(msg, "Warrning !",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
        }
        public static DialogResult WarrnQC(string msg) {
            System.Media.SystemSounds.Exclamation.Play();
            return MessageBox.Show(msg, "Warrning !",
                                   MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Question);
        }
        public static void Warrn(string msg) {
            MessageBox.Show(msg, "Warrning !",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }
    }
}
