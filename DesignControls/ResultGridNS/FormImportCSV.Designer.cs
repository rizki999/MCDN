namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    partial class FormImportCSV {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportCSV));
            this.textPath = new System.Windows.Forms.TextBox();
            this.labelCSVFile = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.checkContinHeader = new System.Windows.Forms.CheckBox();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelStaus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(69, 14);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(295, 20);
            this.textPath.TabIndex = 0;
            // 
            // labelCSVFile
            // 
            this.labelCSVFile.AutoSize = true;
            this.labelCSVFile.Location = new System.Drawing.Point(12, 17);
            this.labelCSVFile.Name = "labelCSVFile";
            this.labelCSVFile.Size = new System.Drawing.Size(47, 13);
            this.labelCSVFile.TabIndex = 1;
            this.labelCSVFile.Text = "CSV File";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(370, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(54, 23);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // checkContinHeader
            // 
            this.checkContinHeader.AutoSize = true;
            this.checkContinHeader.Location = new System.Drawing.Point(15, 52);
            this.checkContinHeader.Name = "checkContinHeader";
            this.checkContinHeader.Size = new System.Drawing.Size(111, 17);
            this.checkContinHeader.TabIndex = 3;
            this.checkContinHeader.Text = "Is Contain Header";
            this.checkContinHeader.UseVisualStyleBackColor = true;
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Location = new System.Drawing.Point(349, 124);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(75, 23);
            this.buttonDiscard.TabIndex = 4;
            this.buttonDiscard.Text = "Cancel";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(268, 124);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "Import";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelStaus
            // 
            this.labelStaus.AutoSize = true;
            this.labelStaus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStaus.Location = new System.Drawing.Point(150, 90);
            this.labelStaus.Name = "labelStaus";
            this.labelStaus.Size = new System.Drawing.Size(139, 16);
            this.labelStaus.TabIndex = 6;
            this.labelStaus.Text = "Analyze CSV File...";
            this.labelStaus.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 83);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(412, 23);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // FormImportCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 159);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStaus);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.checkContinHeader);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.labelCSVFile);
            this.Controls.Add(this.textPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImportCSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import From CSV File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label labelCSVFile;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.CheckBox checkContinHeader;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelStaus;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}