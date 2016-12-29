namespace MySqlClientDotNET.DesignControls {
    partial class SQLPerview {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLPerview));
            this.tabExecuteSQL = new System.Windows.Forms.TabControl();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.textSQL = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabProgress = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textExecuting = new System.Windows.Forms.TextBox();
            this.progressBarExecute = new System.Windows.Forms.ProgressBar();
            this.tabMessage = new System.Windows.Forms.TabPage();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textMessage = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabExecuteSQL.SuspendLayout();
            this.tabSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSQL)).BeginInit();
            this.tabProgress.SuspendLayout();
            this.tabMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabExecuteSQL
            // 
            this.tabExecuteSQL.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabExecuteSQL.Controls.Add(this.tabSQL);
            this.tabExecuteSQL.Controls.Add(this.tabProgress);
            this.tabExecuteSQL.Controls.Add(this.tabMessage);
            this.tabExecuteSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabExecuteSQL.Location = new System.Drawing.Point(0, 0);
            this.tabExecuteSQL.Name = "tabExecuteSQL";
            this.tabExecuteSQL.SelectedIndex = 0;
            this.tabExecuteSQL.Size = new System.Drawing.Size(536, 460);
            this.tabExecuteSQL.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabExecuteSQL.TabIndex = 0;
            // 
            // tabSQL
            // 
            this.tabSQL.BackColor = System.Drawing.SystemColors.Control;
            this.tabSQL.Controls.Add(this.buttonCancle);
            this.tabSQL.Controls.Add(this.buttonApply);
            this.tabSQL.Controls.Add(this.textSQL);
            this.tabSQL.Location = new System.Drawing.Point(4, 25);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQL.Size = new System.Drawing.Size(528, 431);
            this.tabSQL.TabIndex = 0;
            this.tabSQL.Text = "tab1";
            // 
            // buttonCancle
            // 
            this.buttonCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancle.Location = new System.Drawing.Point(445, 402);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 2;
            this.buttonCancle.Text = "Cancel";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(364, 402);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textSQL
            // 
            this.textSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSQL.AutoCompleteBracketsList = new char[] {
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
            this.textSQL.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.textSQL.BackBrush = null;
            this.textSQL.CharHeight = 14;
            this.textSQL.CharWidth = 8;
            this.textSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textSQL.IsReplaceMode = false;
            this.textSQL.Location = new System.Drawing.Point(0, 0);
            this.textSQL.Name = "textSQL";
            this.textSQL.Paddings = new System.Windows.Forms.Padding(0);
            this.textSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textSQL.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textSQL.ServiceColors")));
            this.textSQL.Size = new System.Drawing.Size(532, 395);
            this.textSQL.TabIndex = 0;
            this.textSQL.Zoom = 100;
            this.textSQL.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.textSQL_TextChangedDelayed);
            // 
            // tabProgress
            // 
            this.tabProgress.BackColor = System.Drawing.SystemColors.Control;
            this.tabProgress.Controls.Add(this.label1);
            this.tabProgress.Controls.Add(this.textExecuting);
            this.tabProgress.Controls.Add(this.progressBarExecute);
            this.tabProgress.Location = new System.Drawing.Point(4, 25);
            this.tabProgress.Name = "tabProgress";
            this.tabProgress.Padding = new System.Windows.Forms.Padding(3);
            this.tabProgress.Size = new System.Drawing.Size(528, 431);
            this.tabProgress.TabIndex = 1;
            this.tabProgress.Text = "tab2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Execute SQL Stetment :";
            // 
            // textExecuting
            // 
            this.textExecuting.BackColor = System.Drawing.SystemColors.Control;
            this.textExecuting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textExecuting.Location = new System.Drawing.Point(45, 82);
            this.textExecuting.Multiline = true;
            this.textExecuting.Name = "textExecuting";
            this.textExecuting.ReadOnly = true;
            this.textExecuting.Size = new System.Drawing.Size(475, 341);
            this.textExecuting.TabIndex = 1;
            // 
            // progressBarExecute
            // 
            this.progressBarExecute.Location = new System.Drawing.Point(8, 26);
            this.progressBarExecute.Name = "progressBarExecute";
            this.progressBarExecute.Size = new System.Drawing.Size(512, 17);
            this.progressBarExecute.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarExecute.TabIndex = 0;
            // 
            // tabMessage
            // 
            this.tabMessage.Controls.Add(this.buttonOK);
            this.tabMessage.Controls.Add(this.buttonBack);
            this.tabMessage.Controls.Add(this.textMessage);
            this.tabMessage.Location = new System.Drawing.Point(4, 25);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessage.Size = new System.Drawing.Size(528, 431);
            this.tabMessage.TabIndex = 2;
            this.tabMessage.Text = "tab3";
            this.tabMessage.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(445, 402);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(364, 402);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Visible = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textMessage
            // 
            this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textMessage.AutoCompleteBracketsList = new char[] {
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
            this.textMessage.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.textMessage.BackBrush = null;
            this.textMessage.CharHeight = 14;
            this.textMessage.CharWidth = 8;
            this.textMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textMessage.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textMessage.IsReplaceMode = false;
            this.textMessage.Location = new System.Drawing.Point(0, 0);
            this.textMessage.Name = "textMessage";
            this.textMessage.Paddings = new System.Windows.Forms.Padding(0);
            this.textMessage.ReadOnly = true;
            this.textMessage.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textMessage.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textMessage.ServiceColors")));
            this.textMessage.ShowLineNumbers = false;
            this.textMessage.Size = new System.Drawing.Size(534, 395);
            this.textMessage.TabIndex = 5;
            this.textMessage.WordWrap = true;
            this.textMessage.Zoom = 100;
            this.textMessage.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.textMessage_TextChanged);
            // 
            // SQLPerview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 460);
            this.Controls.Add(this.tabExecuteSQL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLPerview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Perview";
            this.Load += new System.EventHandler(this.SQLPerview_Load);
            this.tabExecuteSQL.ResumeLayout(false);
            this.tabSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textSQL)).EndInit();
            this.tabProgress.ResumeLayout(false);
            this.tabProgress.PerformLayout();
            this.tabMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabExecuteSQL;
        private System.Windows.Forms.TabPage tabSQL;
        private FastColoredTextBoxNS.FastColoredTextBox textSQL;
        private System.Windows.Forms.TabPage tabProgress;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TabPage tabMessage;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonBack;
        private FastColoredTextBoxNS.FastColoredTextBox textMessage;
        private System.Windows.Forms.ProgressBar progressBarExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textExecuting;
    }
}