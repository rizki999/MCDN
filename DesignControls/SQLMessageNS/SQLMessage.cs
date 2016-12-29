using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace MySqlClientDotNET.DesignControls.SQLMessageNS {
    public class SQLMessage : Panel {
        public SQLMessage() {
            InitializeComponent();
            SuccessMsg = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
            ErrorMsg = new TextStyle(Brushes.Red, null, FontStyle.Bold);
            this.buttonClear.Text = LanguageApp.langMessage["BTClearMessage"];
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLMessage));
            this.textMessage = new FastColoredTextBoxNS.FastColoredTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.textMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // textMessage
            // 
            this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textMessage.AutoCompleteBracketsList = new char[] {
                '(', ')', '[', ']',
                '\"', '\"', '\'', '\''
            };
            this.textMessage.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.textMessage.BackBrush = null;
            this.textMessage.CharHeight = 14;
            this.textMessage.CharWidth = 8;
            this.textMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textMessage.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textMessage.IndentBackColor = System.Drawing.SystemColors.Control;
            this.textMessage.IsReplaceMode = false;
            this.textMessage.Location = new System.Drawing.Point(0, 0);
            this.textMessage.Name = "textMessage";
            this.textMessage.Paddings = new System.Windows.Forms.Padding(0);
            this.textMessage.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textMessage.WordWrap = true;
            this.textMessage.Size = new System.Drawing.Size(325, 205);
            this.textMessage.TabIndex = 0;
            this.textMessage.Zoom = 100;
            this.textMessage.ReadOnly = true;
            this.textMessage.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.textMessage_TextChanged);
            this.textMessage.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(textMessage_TextChangedDelayed);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(229, 210);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(96, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear Message";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // ExecuteMessage
            // 
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textMessage);
            this.Name = "ExecuteMessage";
            this.Size = new System.Drawing.Size(342, 236);
            ((System.ComponentModel.ISupportInitialize)(this.textMessage)).EndInit();
            this.ResumeLayout(false);
            this.textMessage.Text = "\n";
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox textMessage;
        private System.Windows.Forms.Button buttonClear;
        private FastColoredTextBoxNS.Style SuccessMsg;
        private FastColoredTextBoxNS.Style ErrorMsg;

        public void SetMessage(string msg) {
            textMessage.Text += msg;
            if (msg.Equals("\n")) {
                textMessage.ScrollLeft();
                textMessage.Navigate(textMessage.Lines.Count - 1);
                textMessage.SelectionStart = textMessage.Text.Length;
            }
        }

        public void SetMesssageAction(string msg) {
            textMessage.Text += MessageKeyword.BuildSqlActionMessage(msg);
        }

        public void SetMessageSqlStetment(string msg) {
            textMessage.Text += MessageKeyword.BuildSqlStetmentMessage(msg);
        }

        public void SetMessageError(string msg) {
            textMessage.Text += MessageKeyword.BuildErrorMessage(msg);
            Console.Beep();
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            this.textMessage.Text = "\n";
        }

        public void setText(string msg) {
            textMessage.Text += msg;
        }

        public void ClearMessage() {
            textMessage.Text = "\n";
        }


        void textMessage_TextChangedDelayed(object sender, TextChangedEventArgs e) {
            
        }

        private void textMessage_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            e.ChangedRange.SetStyle(SuccessMsg, "\r\n" + LanguageApp.langMessage["MSGAction"] + " \\:", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(SuccessMsg, "\r\n" + LanguageApp.langMessage["MSGSQLStetment"] + " \\:", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(SuccessMsg, "\r\n" + LanguageApp.langMessage["MSGMessage"] + " \\:", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(ErrorMsg, "\r\n" + LanguageApp.langMessage["MSGError"] + " \\:", RegexOptions.Singleline);
        }
    }
}
