namespace MySqlClientDotNET.DesignControls.GridResultNS {
    partial class GridResult {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridResult));
            this.gridTable = new System.Windows.Forms.DataGridView();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.stripMenu = new System.Windows.Forms.ToolStrip();
            this.stripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.stripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.stripSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.stripButtonExport = new System.Windows.Forms.ToolStripSplitButton();
            this.buttonExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonImportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lablePage = new System.Windows.Forms.ToolStripLabel();
            this.buttonDownPage = new System.Windows.Forms.ToolStripButton();
            this.labelNumPage = new System.Windows.Forms.ToolStripLabel();
            this.buttonUpPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonInsertOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReadOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxIgnorePri = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            this.stripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTable
            // 
            this.gridTable.AllowUserToAddRows = false;
            this.gridTable.AllowUserToDeleteRows = false;
            this.gridTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTable.BackgroundColor = System.Drawing.Color.White;
            this.gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTable.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gridTable.Location = new System.Drawing.Point(0, 28);
            this.gridTable.Name = "gridTable";
            this.gridTable.RowHeadersVisible = false;
            this.gridTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTable.Size = new System.Drawing.Size(346, 193);
            this.gridTable.TabIndex = 0;
            this.gridTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridTable_CellBeginEdit);
            this.gridTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTable_CellEndEdit);
            this.gridTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTable_CellValueChanged);
            this.gridTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridTable_DataError);
            this.gridTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridTable_KeyDown);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(187, 225);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDiscard.Location = new System.Drawing.Point(268, 225);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(75, 23);
            this.buttonDiscard.TabIndex = 2;
            this.buttonDiscard.Text = "Discard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // stripMenu
            // 
            this.stripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripButtonAdd,
            this.stripButtonDel,
            this.stripSplit1,
            this.stripButtonExport,
            this.toolStripSeparator1,
            this.lablePage,
            this.buttonDownPage,
            this.labelNumPage,
            this.buttonUpPage,
            this.toolStripSeparator2,
            this.buttonMode});
            this.stripMenu.Location = new System.Drawing.Point(0, 0);
            this.stripMenu.Name = "stripMenu";
            this.stripMenu.Size = new System.Drawing.Size(346, 25);
            this.stripMenu.TabIndex = 6;
            this.stripMenu.Text = "toolStrip1";
            // 
            // stripButtonAdd
            // 
            this.stripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripButtonAdd.Name = "stripButtonAdd";
            this.stripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.stripButtonAdd.Text = "Add Rows";
            this.stripButtonAdd.Click += new System.EventHandler(this.stripButtonAddRow);
            // 
            // stripButtonDel
            // 
            this.stripButtonDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripButtonDel.Name = "stripButtonDel";
            this.stripButtonDel.Size = new System.Drawing.Size(23, 22);
            this.stripButtonDel.Text = "Delete Rows";
            this.stripButtonDel.Click += new System.EventHandler(this.stripButtonDel_Click);
            // 
            // stripSplit1
            // 
            this.stripSplit1.Name = "stripSplit1";
            this.stripSplit1.Size = new System.Drawing.Size(6, 25);
            // 
            // stripButtonExport
            // 
            this.stripButtonExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExportCSV,
            this.buttonImportCSV});
            this.stripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripButtonExport.Name = "stripButtonExport";
            this.stripButtonExport.Size = new System.Drawing.Size(97, 22);
            this.stripButtonExport.Text = "Export/Import";
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(165, 22);
            this.buttonExportCSV.Text = "Export To CSV";
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.Name = "buttonImportCSV";
            this.buttonImportCSV.Size = new System.Drawing.Size(165, 22);
            this.buttonImportCSV.Text = "Import From CSV";
            this.buttonImportCSV.Click += new System.EventHandler(this.buttonImportCSV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lablePage
            // 
            this.lablePage.Name = "lablePage";
            this.lablePage.Size = new System.Drawing.Size(39, 22);
            this.lablePage.Text = "Page :";
            // 
            // buttonDownPage
            // 
            this.buttonDownPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDownPage.Image = global::MySqlClientDotNET.Properties.Resources.downS;
            this.buttonDownPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDownPage.Name = "buttonDownPage";
            this.buttonDownPage.Size = new System.Drawing.Size(23, 22);
            this.buttonDownPage.Text = "toolStripButton1";
            this.buttonDownPage.Click += new System.EventHandler(this.buttonDownPage_Click);
            // 
            // labelNumPage
            // 
            this.labelNumPage.Name = "labelNumPage";
            this.labelNumPage.Size = new System.Drawing.Size(13, 22);
            this.labelNumPage.Text = "0";
            // 
            // buttonUpPage
            // 
            this.buttonUpPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUpPage.Image = global::MySqlClientDotNET.Properties.Resources.upS;
            this.buttonUpPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUpPage.Name = "buttonUpPage";
            this.buttonUpPage.Size = new System.Drawing.Size(23, 22);
            this.buttonUpPage.Text = "toolStripButton2";
            this.buttonUpPage.Click += new System.EventHandler(this.buttonUpPage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonMode
            // 
            this.buttonMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonInsertOnly,
            this.buttonReadOnly});
            this.buttonMode.Image = ((System.Drawing.Image)(resources.GetObject("buttonMode.Image")));
            this.buttonMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMode.Name = "buttonMode";
            this.buttonMode.Size = new System.Drawing.Size(76, 19);
            this.buttonMode.Text = "Mode Grid";
            // 
            // buttonInsertOnly
            // 
            this.buttonInsertOnly.Name = "buttonInsertOnly";
            this.buttonInsertOnly.Size = new System.Drawing.Size(131, 22);
            this.buttonInsertOnly.Text = "Insert Only";
            this.buttonInsertOnly.Click += new System.EventHandler(this.buttonInsertOnly_Click);
            // 
            // buttonReadOnly
            // 
            this.buttonReadOnly.Name = "buttonReadOnly";
            this.buttonReadOnly.Size = new System.Drawing.Size(131, 22);
            this.buttonReadOnly.Text = "Read Only";
            this.buttonReadOnly.Click += new System.EventHandler(this.buttonReadOnly_Click);
            // 
            // checkBoxIgnorePri
            // 
            this.checkBoxIgnorePri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIgnorePri.AutoSize = true;
            this.checkBoxIgnorePri.Location = new System.Drawing.Point(25, 227);
            this.checkBoxIgnorePri.Name = "checkBoxIgnorePri";
            this.checkBoxIgnorePri.Size = new System.Drawing.Size(156, 17);
            this.checkBoxIgnorePri.TabIndex = 8;
            this.checkBoxIgnorePri.Text = "Ignore primary key to edited";
            this.checkBoxIgnorePri.UseVisualStyleBackColor = true;
            // 
            // GridResult
            // 
            this.Controls.Add(this.checkBoxIgnorePri);
            this.Controls.Add(this.stripMenu);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.gridTable);
            this.Name = "GridResult";
            this.Size = new System.Drawing.Size(346, 251);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            this.stripMenu.ResumeLayout(false);
            this.stripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTable;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.ToolStrip stripMenu;
        private System.Windows.Forms.ToolStripButton stripButtonAdd;
        private System.Windows.Forms.ToolStripButton stripButtonDel;
        private System.Windows.Forms.ToolStripSeparator stripSplit1;
        private System.Windows.Forms.ToolStripSplitButton stripButtonExport;
        private System.Windows.Forms.ToolStripMenuItem buttonExportCSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lablePage;
        private System.Windows.Forms.ToolStripMenuItem buttonImportCSV;
        private System.Windows.Forms.CheckBox checkBoxIgnorePri;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton buttonMode;
        private System.Windows.Forms.ToolStripMenuItem buttonInsertOnly;
        private System.Windows.Forms.ToolStripMenuItem buttonReadOnly;
        private System.Windows.Forms.ToolStripButton buttonDownPage;
        private System.Windows.Forms.ToolStripLabel labelNumPage;
        private System.Windows.Forms.ToolStripButton buttonUpPage;
    }
}
