namespace MySqlClientDotNET.DesignControls {
    partial class DatabaseBuilder {
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
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.labelCollation = new System.Windows.Forms.Label();
            this.textSchema = new System.Windows.Forms.TextBox();
            this.comboCollaction = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.labelHowToRename = new System.Windows.Forms.Label();
            this.groupBoxDBBuilder = new System.Windows.Forms.GroupBox();
            this.groupBoxDBBuilder.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.Location = new System.Drawing.Point(6, 26);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(84, 13);
            this.labelDatabaseName.TabIndex = 0;
            this.labelDatabaseName.Text = "Database Name";
            // 
            // labelCollation
            // 
            this.labelCollation.AutoSize = true;
            this.labelCollation.Location = new System.Drawing.Point(6, 75);
            this.labelCollation.Name = "labelCollation";
            this.labelCollation.Size = new System.Drawing.Size(47, 13);
            this.labelCollation.TabIndex = 1;
            this.labelCollation.Text = "Collation";
            // 
            // textSchema
            // 
            this.textSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSchema.Location = new System.Drawing.Point(96, 23);
            this.textSchema.Name = "textSchema";
            this.textSchema.Size = new System.Drawing.Size(311, 20);
            this.textSchema.TabIndex = 2;
            // 
            // comboCollaction
            // 
            this.comboCollaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCollaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCollaction.FormattingEnabled = true;
            this.comboCollaction.Location = new System.Drawing.Point(96, 72);
            this.comboCollaction.Name = "comboCollaction";
            this.comboCollaction.Size = new System.Drawing.Size(311, 21);
            this.comboCollaction.TabIndex = 3;
            this.comboCollaction.SelectedValueChanged += new System.EventHandler(this.comboCollaction_SelectedValueChanged);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(280, 158);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRevert.Location = new System.Drawing.Point(361, 158);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(75, 23);
            this.buttonRevert.TabIndex = 5;
            this.buttonRevert.Text = "Revert";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // labelHowToRename
            // 
            this.labelHowToRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHowToRename.AutoSize = true;
            this.labelHowToRename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHowToRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHowToRename.Location = new System.Drawing.Point(248, 46);
            this.labelHowToRename.Name = "labelHowToRename";
            this.labelHowToRename.Size = new System.Drawing.Size(159, 13);
            this.labelHowToRename.TabIndex = 6;
            this.labelHowToRename.Text = "How To Rename Database";
            this.labelHowToRename.Click += new System.EventHandler(this.labelHowToRename_Click);
            // 
            // groupBoxDBBuilder
            // 
            this.groupBoxDBBuilder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDBBuilder.Controls.Add(this.labelDatabaseName);
            this.groupBoxDBBuilder.Controls.Add(this.labelHowToRename);
            this.groupBoxDBBuilder.Controls.Add(this.labelCollation);
            this.groupBoxDBBuilder.Controls.Add(this.textSchema);
            this.groupBoxDBBuilder.Controls.Add(this.comboCollaction);
            this.groupBoxDBBuilder.Location = new System.Drawing.Point(23, 21);
            this.groupBoxDBBuilder.Name = "groupBoxDBBuilder";
            this.groupBoxDBBuilder.Size = new System.Drawing.Size(413, 122);
            this.groupBoxDBBuilder.TabIndex = 7;
            this.groupBoxDBBuilder.TabStop = false;
            this.groupBoxDBBuilder.Text = "Database Builder";
            // 
            // DatabaseBuilder
            // 
            this.Controls.Add(this.groupBoxDBBuilder);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.buttonApply);
            this.Size = new System.Drawing.Size(463, 195);
            this.groupBoxDBBuilder.ResumeLayout(false);
            this.groupBoxDBBuilder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDatabaseName;
        private System.Windows.Forms.Label labelCollation;
        private System.Windows.Forms.ComboBox comboCollaction;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.Label labelHowToRename;
        private System.Windows.Forms.GroupBox groupBoxDBBuilder;
        public System.Windows.Forms.TextBox textSchema;
    }
}
