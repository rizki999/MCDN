namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    partial class FormExportCSV {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportCSV));
            this.comboExportFrom = new System.Windows.Forms.ComboBox();
            this.labelExportFrom = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboSelectHead = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboExportFrom
            // 
            this.comboExportFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExportFrom.FormattingEnabled = true;
            this.comboExportFrom.Items.AddRange(new object[] {
            "From current grid",
            "From table (all data)"});
            this.comboExportFrom.Location = new System.Drawing.Point(81, 12);
            this.comboExportFrom.Name = "comboExportFrom";
            this.comboExportFrom.Size = new System.Drawing.Size(167, 21);
            this.comboExportFrom.TabIndex = 0;
            // 
            // labelExportFrom
            // 
            this.labelExportFrom.AutoSize = true;
            this.labelExportFrom.Location = new System.Drawing.Point(12, 15);
            this.labelExportFrom.Name = "labelExportFrom";
            this.labelExportFrom.Size = new System.Drawing.Size(63, 13);
            this.labelExportFrom.TabIndex = 1;
            this.labelExportFrom.Text = "Export From";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 66);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(316, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // comboSelectHead
            // 
            this.comboSelectHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectHead.FormattingEnabled = true;
            this.comboSelectHead.Items.AddRange(new object[] {
            "Without Header Table",
            "With Header Table"});
            this.comboSelectHead.Location = new System.Drawing.Point(81, 39);
            this.comboSelectHead.Name = "comboSelectHead";
            this.comboSelectHead.Size = new System.Drawing.Size(167, 21);
            this.comboSelectHead.TabIndex = 3;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(134, 71);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(73, 13);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Count Data....";
            this.labelCount.Visible = false;
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(81, 66);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(167, 20);
            this.textPath.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(254, 66);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(9, 69);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(48, 13);
            this.labelPath.TabIndex = 7;
            this.labelPath.Text = "File Path";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(81, 95);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 8;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(173, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormExportCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 129);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.comboSelectHead);
            this.Controls.Add(this.labelExportFrom);
            this.Controls.Add(this.comboExportFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExportCSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export CSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboExportFrom;
        private System.Windows.Forms.Label labelExportFrom;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboSelectHead;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonCancel;
    }
}