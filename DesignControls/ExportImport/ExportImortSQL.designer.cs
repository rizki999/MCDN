namespace MySqlClientDotNET.DesignControls {
    partial class ExportImortSQL {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxEx = new System.Windows.Forms.GroupBox();
            this.labelStatusEx = new System.Windows.Forms.Label();
            this.labelStatusLbEx = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonOpenEx = new System.Windows.Forms.Button();
            this.textPathEx = new System.Windows.Forms.TextBox();
            this.comboSelectDBEx = new System.Windows.Forms.ComboBox();
            this.labelPathEx = new System.Windows.Forms.Label();
            this.labelSelectDBEx = new System.Windows.Forms.Label();
            this.groupBoxIm = new System.Windows.Forms.GroupBox();
            this.labelStatusIm = new System.Windows.Forms.Label();
            this.buttonImport = new System.Windows.Forms.Button();
            this.labelStatusLbIm = new System.Windows.Forms.Label();
            this.comboSelectDBImp = new System.Windows.Forms.ComboBox();
            this.buttonOpenIm = new System.Windows.Forms.Button();
            this.labelSelectDbIm = new System.Windows.Forms.Label();
            this.textPathIm = new System.Windows.Forms.TextBox();
            this.labelPathIm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxEx.SuspendLayout();
            this.groupBoxIm.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 20);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(394, 260);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxEx);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxIm);
            this.splitContainer1.Size = new System.Drawing.Size(394, 260);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxEx
            // 
            this.groupBoxEx.Controls.Add(this.labelStatusEx);
            this.groupBoxEx.Controls.Add(this.labelStatusLbEx);
            this.groupBoxEx.Controls.Add(this.buttonExport);
            this.groupBoxEx.Controls.Add(this.buttonOpenEx);
            this.groupBoxEx.Controls.Add(this.textPathEx);
            this.groupBoxEx.Controls.Add(this.comboSelectDBEx);
            this.groupBoxEx.Controls.Add(this.labelPathEx);
            this.groupBoxEx.Controls.Add(this.labelSelectDBEx);
            this.groupBoxEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEx.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEx.Name = "groupBoxEx";
            this.groupBoxEx.Size = new System.Drawing.Size(394, 132);
            this.groupBoxEx.TabIndex = 0;
            this.groupBoxEx.TabStop = false;
            this.groupBoxEx.Text = "Export Database To SQL File";
            // 
            // labelStatusEx
            // 
            this.labelStatusEx.AutoSize = true;
            this.labelStatusEx.Location = new System.Drawing.Point(64, 91);
            this.labelStatusEx.Name = "labelStatusEx";
            this.labelStatusEx.Size = new System.Drawing.Size(10, 13);
            this.labelStatusEx.TabIndex = 9;
            this.labelStatusEx.Text = "-";
            // 
            // labelStatusLbEx
            // 
            this.labelStatusLbEx.AutoSize = true;
            this.labelStatusLbEx.Location = new System.Drawing.Point(6, 91);
            this.labelStatusLbEx.Name = "labelStatusLbEx";
            this.labelStatusLbEx.Size = new System.Drawing.Size(37, 13);
            this.labelStatusLbEx.TabIndex = 8;
            this.labelStatusLbEx.Text = "Status";
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonExport.Location = new System.Drawing.Point(179, 81);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(55, 23);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonOpenEx
            // 
            this.buttonOpenEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenEx.Location = new System.Drawing.Point(333, 52);
            this.buttonOpenEx.Name = "buttonOpenEx";
            this.buttonOpenEx.Size = new System.Drawing.Size(55, 23);
            this.buttonOpenEx.TabIndex = 6;
            this.buttonOpenEx.Text = "Open";
            this.buttonOpenEx.UseVisualStyleBackColor = true;
            this.buttonOpenEx.Click += new System.EventHandler(this.buttonOpenEx_Click);
            // 
            // textPathEx
            // 
            this.textPathEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPathEx.Location = new System.Drawing.Point(67, 55);
            this.textPathEx.Name = "textPathEx";
            this.textPathEx.Size = new System.Drawing.Size(260, 20);
            this.textPathEx.TabIndex = 5;
            // 
            // comboSelectDBEx
            // 
            this.comboSelectDBEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSelectDBEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectDBEx.FormattingEnabled = true;
            this.comboSelectDBEx.Location = new System.Drawing.Point(67, 28);
            this.comboSelectDBEx.Name = "comboSelectDBEx";
            this.comboSelectDBEx.Size = new System.Drawing.Size(321, 21);
            this.comboSelectDBEx.TabIndex = 4;
            // 
            // labelPathEx
            // 
            this.labelPathEx.AutoSize = true;
            this.labelPathEx.Location = new System.Drawing.Point(6, 62);
            this.labelPathEx.Name = "labelPathEx";
            this.labelPathEx.Size = new System.Drawing.Size(29, 13);
            this.labelPathEx.TabIndex = 3;
            this.labelPathEx.Text = "Path";
            // 
            // labelSelectDBEx
            // 
            this.labelSelectDBEx.AutoSize = true;
            this.labelSelectDBEx.Location = new System.Drawing.Point(6, 31);
            this.labelSelectDBEx.Name = "labelSelectDBEx";
            this.labelSelectDBEx.Size = new System.Drawing.Size(55, 13);
            this.labelSelectDBEx.TabIndex = 2;
            this.labelSelectDBEx.Text = "Select DB";
            // 
            // groupBoxIm
            // 
            this.groupBoxIm.Controls.Add(this.labelStatusIm);
            this.groupBoxIm.Controls.Add(this.buttonImport);
            this.groupBoxIm.Controls.Add(this.labelStatusLbIm);
            this.groupBoxIm.Controls.Add(this.comboSelectDBImp);
            this.groupBoxIm.Controls.Add(this.buttonOpenIm);
            this.groupBoxIm.Controls.Add(this.labelSelectDbIm);
            this.groupBoxIm.Controls.Add(this.textPathIm);
            this.groupBoxIm.Controls.Add(this.labelPathIm);
            this.groupBoxIm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxIm.Location = new System.Drawing.Point(0, 0);
            this.groupBoxIm.Name = "groupBoxIm";
            this.groupBoxIm.Size = new System.Drawing.Size(394, 124);
            this.groupBoxIm.TabIndex = 0;
            this.groupBoxIm.TabStop = false;
            this.groupBoxIm.Text = "Import From SQL File";
            // 
            // labelStatusIm
            // 
            this.labelStatusIm.AutoSize = true;
            this.labelStatusIm.Location = new System.Drawing.Point(64, 82);
            this.labelStatusIm.Name = "labelStatusIm";
            this.labelStatusIm.Size = new System.Drawing.Size(10, 13);
            this.labelStatusIm.TabIndex = 11;
            this.labelStatusIm.Text = "-";
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonImport.Location = new System.Drawing.Point(179, 72);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(55, 23);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // labelStatusLbIm
            // 
            this.labelStatusLbIm.AutoSize = true;
            this.labelStatusLbIm.Location = new System.Drawing.Point(6, 82);
            this.labelStatusLbIm.Name = "labelStatusLbIm";
            this.labelStatusLbIm.Size = new System.Drawing.Size(37, 13);
            this.labelStatusLbIm.TabIndex = 10;
            this.labelStatusLbIm.Text = "Status";
            // 
            // comboSelectDBImp
            // 
            this.comboSelectDBImp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSelectDBImp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectDBImp.FormattingEnabled = true;
            this.comboSelectDBImp.Location = new System.Drawing.Point(67, 45);
            this.comboSelectDBImp.Name = "comboSelectDBImp";
            this.comboSelectDBImp.Size = new System.Drawing.Size(321, 21);
            this.comboSelectDBImp.TabIndex = 8;
            // 
            // buttonOpenIm
            // 
            this.buttonOpenIm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenIm.Location = new System.Drawing.Point(333, 16);
            this.buttonOpenIm.Name = "buttonOpenIm";
            this.buttonOpenIm.Size = new System.Drawing.Size(55, 23);
            this.buttonOpenIm.TabIndex = 6;
            this.buttonOpenIm.Text = "Open";
            this.buttonOpenIm.UseVisualStyleBackColor = true;
            this.buttonOpenIm.Click += new System.EventHandler(this.buttonOpenIm_Click);
            // 
            // labelSelectDbIm
            // 
            this.labelSelectDbIm.AutoSize = true;
            this.labelSelectDbIm.Location = new System.Drawing.Point(6, 48);
            this.labelSelectDbIm.Name = "labelSelectDbIm";
            this.labelSelectDbIm.Size = new System.Drawing.Size(55, 13);
            this.labelSelectDbIm.TabIndex = 7;
            this.labelSelectDbIm.Text = "Select DB";
            // 
            // textPathIm
            // 
            this.textPathIm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPathIm.Location = new System.Drawing.Point(67, 19);
            this.textPathIm.Name = "textPathIm";
            this.textPathIm.Size = new System.Drawing.Size(260, 20);
            this.textPathIm.TabIndex = 5;
            // 
            // labelPathIm
            // 
            this.labelPathIm.AutoSize = true;
            this.labelPathIm.Location = new System.Drawing.Point(6, 22);
            this.labelPathIm.Name = "labelPathIm";
            this.labelPathIm.Size = new System.Drawing.Size(29, 13);
            this.labelPathIm.TabIndex = 4;
            this.labelPathIm.Text = "Path";
            // 
            // ExportImortSQL
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExportImortSQL";
            this.Size = new System.Drawing.Size(424, 297);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxEx.ResumeLayout(false);
            this.groupBoxEx.PerformLayout();
            this.groupBoxIm.ResumeLayout(false);
            this.groupBoxIm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxEx;
        private System.Windows.Forms.Label labelPathEx;
        private System.Windows.Forms.Label labelSelectDBEx;
        private System.Windows.Forms.GroupBox groupBoxIm;
        private System.Windows.Forms.Label labelPathIm;
        private System.Windows.Forms.ComboBox comboSelectDBEx;
        private System.Windows.Forms.Button buttonOpenEx;
        private System.Windows.Forms.TextBox textPathEx;
        private System.Windows.Forms.Button buttonOpenIm;
        private System.Windows.Forms.TextBox textPathIm;
        private System.Windows.Forms.ComboBox comboSelectDBImp;
        private System.Windows.Forms.Label labelSelectDbIm;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label labelStatusEx;
        private System.Windows.Forms.Label labelStatusLbEx;
        private System.Windows.Forms.Label labelStatusIm;
        private System.Windows.Forms.Label labelStatusLbIm;
    }
}
