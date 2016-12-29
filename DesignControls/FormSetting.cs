using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace MySqlClientDotNET.DesignControls {
    public partial class FormSetting : Form {
        public FormSetting() {
            InitializeComponent();
            comboLimit.Items.AddRange(MySqlConfig.ListLimit);
            try {
                FileIniDataParser fileIni = new FileIniDataParser();
                IniData iniData = fileIni.ReadFile(ResourcesPath.ini_file);
                for (int i = 0; i < comboLimit.Items.Count; ++i) {
                    if (iniData["app_config"]["sql_limit"].Equals(comboLimit.Items[i].ToString())) {
                        comboLimit.SelectedIndex = i;
                        break;
                    }
                }
                if (iniData["app_config"]["language"].Equals("id"))
                    comboLanguage.SelectedIndex = 1;
                else
                    comboLanguage.SelectedIndex = 0;
                idxLang = comboLanguage.SelectedIndex;
            } catch (Exception ex) { Msg.Err("Error Read ini file : " + ex.Message); }
            Language();
        }

        private void Language() {
            this.Text = LanguageApp.langFormSetting["TFormSetting"];
            labelLimit.Text = LanguageApp.langFormSetting["LBLimit"];
            labelLanguage.Text = LanguageApp.langFormSetting["LBLanguage"];
            msgRestart = LanguageApp.langFormSetting["MSGRestart"];
            buttonOk.Text = LanguageApp.langFormSetting["BTOk"];
        }

        private int idxLang;
        private string msgRestart;

        private void buttonOk_Click(object sender, EventArgs e) {
            try {
                FileIniDataParser fileIni = new FileIniDataParser();
                IniData iniData = fileIni.ReadFile(ResourcesPath.ini_file);
                iniData["app_config"]["sql_limit"] = comboLimit.SelectedItem.ToString();
                if (comboLanguage.SelectedIndex != idxLang) {
                    Msg.Info(msgRestart);
                    iniData["app_config"]["language"] = comboLanguage.SelectedIndex == 1 ? "id" : "en";
                }
                fileIni.WriteFile(ResourcesPath.ini_file, iniData);
            } catch (Exception ex) {
                Msg.Err("Error Read ini file : " + ex.Message);
            }
            this.Close();
        }
    }
}
