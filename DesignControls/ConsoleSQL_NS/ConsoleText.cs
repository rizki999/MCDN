using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using FastColoredTextBoxNS;
namespace MySqlClientDotNET.DesignControls.ConsoleSQL_NS {
    public class ConsoleText : FastColoredTextBox {
        private volatile bool isReadLineMode;
        private volatile bool isUpdating;
        private Place StartReadPlace { get; set; }

        /// <summary>
        /// Control is waiting for line entering. 
        /// </summary>
        public bool IsReadLineMode {
            get { return isReadLineMode; }
            set { isReadLineMode = value; }
        }

        /// <summary>
        /// Append line to end of text.
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text) {
            IsReadLineMode = false;
            isUpdating = true;
            try {
                AppendText(text);
                GoEnd();
            } finally {
                isUpdating = false;
                ClearUndo();
            }
        }

        /// <summary>
        /// Wait for line entering.
        /// Set IsReadLineMode to false for break of waiting.
        /// </summary>
        /// <returns></returns>
        public string ReadLine() {
            GoEnd();
            StartReadPlace = Range.End;
            IsReadLineMode = true;
            try {
                while (IsReadLineMode) {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }
            } finally {
                IsReadLineMode = false;
                ClearUndo();
            }

            return new Range(this, StartReadPlace, Range.End).Text.TrimEnd('\r', '\n');
        }

        public bool IsCtrlHold;
        public override void OnTextChanging(ref string text) {
            if (!IsReadLineMode && !isUpdating) {
                text = ""; //cancel changing
                return;
            }

            if (IsReadLineMode) {
                if (Selection.Start < StartReadPlace || Selection.End < StartReadPlace)
                    GoEnd();//move caret to entering position

                if (Selection.Start == StartReadPlace || Selection.End == StartReadPlace) {
                    if (text == "\b") //backspace 
                        text = ""; //cancel deleting of last char of readonly text
                        return;
                    }

                if (text != null && text.Contains('\n')) {
                    if (!IsCtrlHold) {
                        text = text.Substring(0, text.IndexOf('\n') + 1);
                        IsReadLineMode = false;
                    }
                }
            }

            base.OnTextChanging(ref text);
        }

        public override void Clear() {
            var oldIsReadMode = isReadLineMode;

            isReadLineMode = false;
            isUpdating = true;

            base.Clear();

            isUpdating = false;
            isReadLineMode = oldIsReadMode;

            StartReadPlace = Place.Empty;
        }

        private void InitializeComponent() {
            IsCtrlHold = false;
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsoleText
            // 
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.AutoScrollMinSize = new System.Drawing.Size(585, 15);
            this.BackBrush = null;
            this.BackColor = System.Drawing.Color.Black;
            this.CaretColor = System.Drawing.Color.White;
            this.CharHeight = 15;
            this.CharWidth = 7;
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FoldingIndicatorColor = System.Drawing.Color.Gold;
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.IndentBackColor = System.Drawing.Color.Black;
            this.IsReadLineMode = false;
            this.IsReplaceMode = false;
            this.LineNumberColor = System.Drawing.Color.Gold;
            this.Location = new System.Drawing.Point(12, 41);
            this.Name = "consoleTextBox1";
            this.PaddingBackColor = System.Drawing.Color.Black;
            this.Paddings = new System.Windows.Forms.Padding(0);
            this.PreferredLineWidth = 80;
            this.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ServiceLinesColor = System.Drawing.Color.DimGray;
            this.Size = new System.Drawing.Size(713, 342);
            this.TabIndex = 0;
            this.WordWrap = true;
            this.WordWrapMode = FastColoredTextBoxNS.WordWrapMode.CharWrapPreferredWidth;
            this.Zoom = 100;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
