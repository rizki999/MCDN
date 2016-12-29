using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MySqlClientDotNET.DesignControls.ConsoleSQL_NS {
    public partial class ConsoleSQL : DesignControls.DynamicTabNS.DynamicTabPage {
        //DesignControls.DynamicTabNS.DynamicTabPage
        public ConsoleSQL() {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.PageType = TabPageType.ConsoleSQL;
            _resetEvent = new AutoResetEvent(false);
            this.PageType = TabPageType.ConsoleSQL;
            bgReadText.RunWorkerAsync();
            var autoComlete = new FastColoredTextBoxNS.AutocompleteMenu(consoleText1);
            ICollection<string> icol = MySqlConfig.ListKeyword;
            autoComlete.Items.SetAutocompleteItems(icol);
            autoComlete.AppearInterval = 100;
        }

        public override void InitializedOnDynamicTab() {
            this.TabHeaderText = LanguageApp.langConsole["HTConsole"];
            MSGHelp = LanguageApp.langConsole["MSGHelp"];
        }

        private string MSGHelp;

        private bool stop;
        private AutoResetEvent _resetEvent;
        public override void OnClosedTab() {
            Stop();
        }

        void Stop() {
            stop = true;
            consoleText1.IsReadLineMode = false;
            _resetEvent.WaitOne();
            System.Diagnostics.Debug.WriteLine("Disposing bgReadText");
            bgReadText.Dispose();
            System.Diagnostics.Debug.WriteLine("Done !");
        }

        private void bgReadText_DoWork(object sender, DoWorkEventArgs e) {
            string text = "";
            stop = false;
            do {
                consoleText1.WriteLine("MCDN> ");
                text = consoleText1.ReadLine();
                bgReadText.ReportProgress(0, text);
            } while (text != "" && !stop);
            _resetEvent.Set();
        }

        private void bgReadText_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (!((string)e.UserState).Equals("")) {
                DesignControls.SqlEditorNS.SqlEditorExecuteEventArgs arg = new SqlEditorNS.SqlEditorExecuteEventArgs();
                arg.LimitPage = Convert.ToInt32(MySqlConfig.GetLimit());
                arg.SqlScript = (string)e.UserState;
                arg.UniqueId = -1; //this.UniqueId;
                if (ExecuteSQL != null)
                    ExecuteSQL(this, arg);
            }
        }

        public event EventHandler<DesignControls.SqlEditorNS.SqlEditorExecuteEventArgs> ExecuteSQL;

        private void consoleText1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                consoleText1.SelectionStart = consoleText1.Text.Length;

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Return) {
                consoleText1.IsCtrlHold = true;
                consoleText1.AppendText("\n");
                consoleText1.SelectionStart = consoleText1.Text.Length;
                consoleText1.IsCtrlHold = false;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e) {
            Msg.Info(MSGHelp);
        }
    }
}
