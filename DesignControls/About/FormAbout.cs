using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls {
    public partial class FormAbout : Form {
        public FormAbout() {
            InitializeComponent();
            this.Text = txtAbout.Text = LanguageApp.langFormAbout["FTAbout"];
            txtAbout.Text = LanguageApp.langFormAbout["FTAboutText"];
        }

        private void frmAbout_Load(object sender, EventArgs e) {
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void btOK_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
