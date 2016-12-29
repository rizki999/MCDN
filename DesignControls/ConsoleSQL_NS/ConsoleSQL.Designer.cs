namespace MySqlClientDotNET.DesignControls.ConsoleSQL_NS {
    partial class ConsoleSQL {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleSQL));
            this.consoleText1 = new MySqlClientDotNET.DesignControls.ConsoleSQL_NS.ConsoleText();
            this.bgReadText = new System.ComponentModel.BackgroundWorker();
            this.buttonHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.consoleText1)).BeginInit();
            this.SuspendLayout();
            // 
            // consoleText1
            // 
            this.consoleText1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleText1.AutoCompleteBracketsList = new char[] {
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
            this.consoleText1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.consoleText1.BackBrush = null;
            this.consoleText1.BackColor = System.Drawing.Color.Black;
            this.consoleText1.CharHeight = 14;
            this.consoleText1.CharWidth = 8;
            this.consoleText1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.consoleText1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.consoleText1.ForeColor = System.Drawing.Color.Lime;
            this.consoleText1.IndentBackColor = System.Drawing.Color.Black;
            this.consoleText1.IsReadLineMode = false;
            this.consoleText1.IsReplaceMode = false;
            this.consoleText1.LineNumberColor = System.Drawing.Color.Lime;
            this.consoleText1.Location = new System.Drawing.Point(0, 29);
            this.consoleText1.Name = "consoleText1";
            this.consoleText1.Paddings = new System.Windows.Forms.Padding(0);
            this.consoleText1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.consoleText1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("consoleText1.ServiceColors")));
            this.consoleText1.Size = new System.Drawing.Size(245, 173);
            this.consoleText1.TabIndex = 0;
            this.consoleText1.Zoom = 100;
            this.consoleText1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleText1_KeyDown);
            // 
            // bgReadText
            // 
            this.bgReadText.WorkerReportsProgress = true;
            this.bgReadText.WorkerSupportsCancellation = true;
            this.bgReadText.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgReadText_DoWork);
            this.bgReadText.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgReadText_ProgressChanged);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonHelp.Location = new System.Drawing.Point(219, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(23, 20);
            this.buttonHelp.TabIndex = 1;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // ConsoleSQL
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.consoleText1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "ConsoleSQL";
            this.Size = new System.Drawing.Size(245, 202);
            ((System.ComponentModel.ISupportInitialize)(this.consoleText1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ConsoleText consoleText1;
        private System.ComponentModel.BackgroundWorker bgReadText;
        private System.Windows.Forms.Button buttonHelp;
    }
}
