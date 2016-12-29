using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls.StartingPage {
    public partial class FormInputPassword : Form {
        public FormInputPassword() {
            InitializeComponent();
            IsOk = false;
            passIsempety = false;
        }

        public bool passIsempety;

        private void checkVisible_CheckedChanged(object sender, EventArgs e) {
            textInput.PasswordChar = textInput.PasswordChar == '*' ? '\0' : '*';
        }

        public bool IsOk;

        private void buttonOk_Click(object sender, EventArgs e) {
            if (!passIsempety) { 
                if (textInput.Text.Equals(string.Empty)) {
                    Msg.Warrn("Password is empety !");
                    return;
                }
            }
            IsOk = true;
            this.Close();
        }

        private void buttonCancle_Click(object sender, EventArgs e) {
            IsOk = false;
            this.Close();
        }

        private void textInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                e.Handled = true;
                buttonOk_Click(null, null);
            }
        }
    }
}
