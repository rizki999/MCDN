namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    partial class ResultGrid {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultGrid));
            this.gridTable = new System.Windows.Forms.DataGridView();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.stripMenu = new System.Windows.Forms.ToolStrip();
            this.stripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.stripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.stripSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.stripButtonExportImport = new System.Windows.Forms.ToolStripSplitButton();
            this.buttonExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonImportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelPage = new System.Windows.Forms.ToolStripLabel();
            this.buttonDownPage = new System.Windows.Forms.ToolStripButton();
            this.labelNumPage = new System.Windows.Forms.ToolStripLabel();
            this.buttonUpPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonInsertOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReadOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxIgnorePri = new System.Windows.Forms.CheckBox();
            this.contexMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contexMenuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.contexMenuItemSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contexMenuDeleteRows = new System.Windows.Forms.ToolStripMenuItem();
            this.contexMenuNewRow = new System.Windows.Forms.ToolStripMenuItem();
            this.contexMenuEditCell = new System.Windows.Forms.ToolStripMenuItem();
            this.contexMenuItemSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contexMenuCopySelectedRows = new System.Windows.Forms.ToolStripMenuItem();
            this.contexMenuCopyCellValue = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            this.stripMenu.SuspendLayout();
            this.contexMenuGrid.SuspendLayout();
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
            this.gridTable.Size = new System.Drawing.Size(346, 193);
            this.gridTable.TabIndex = 0;
            this.gridTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridTable_CellBeginEdit);
            this.gridTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTable_CellDoubleClick);
            this.gridTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTable_CellMouseDown);
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
            // buttonRevert
            // 
            this.buttonRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRevert.Location = new System.Drawing.Point(268, 225);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(75, 23);
            this.buttonRevert.TabIndex = 2;
            this.buttonRevert.Text = "Revert";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // stripMenu
            // 
            this.stripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripButtonAdd,
            this.stripButtonDel,
            this.stripSplit1,
            this.stripButtonExportImport,
            this.toolStripSeparator1,
            this.labelPage,
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
            // stripButtonExportImport
            // 
            this.stripButtonExportImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExportCSV,
            this.buttonImportCSV});
            this.stripButtonExportImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripButtonExportImport.Name = "stripButtonExportImport";
            this.stripButtonExportImport.Size = new System.Drawing.Size(97, 22);
            this.stripButtonExportImport.Text = "Export/Import";
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
            // labelPage
            // 
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(39, 22);
            this.labelPage.Text = "Page :";
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
            this.buttonMode.Size = new System.Drawing.Size(76, 22);
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
            // contexMenuGrid
            // 
            this.contexMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contexMenuOpenFile,
            this.contexMenuItemSeparator1,
            this.contexMenuDeleteRows,
            this.contexMenuNewRow,
            this.contexMenuEditCell,
            this.contexMenuItemSeparator2,
            this.contexMenuCopySelectedRows,
            this.contexMenuCopyCellValue});
            this.contexMenuGrid.Name = "contexMenuGrid";
            this.contexMenuGrid.Size = new System.Drawing.Size(189, 170);
            // 
            // contexMenuOpenFile
            // 
            this.contexMenuOpenFile.Name = "contexMenuOpenFile";
            this.contexMenuOpenFile.Size = new System.Drawing.Size(188, 22);
            this.contexMenuOpenFile.Text = "Open File";
            this.contexMenuOpenFile.Click += new System.EventHandler(this.contexMenuItemOpenFile_Click);
            // 
            // contexMenuItemSeparator1
            // 
            this.contexMenuItemSeparator1.Name = "contexMenuItemSeparator1";
            this.contexMenuItemSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // contexMenuDeleteRows
            // 
            this.contexMenuDeleteRows.Name = "contexMenuDeleteRows";
            this.contexMenuDeleteRows.Size = new System.Drawing.Size(188, 22);
            this.contexMenuDeleteRows.Text = "Delete Row(s)";
            this.contexMenuDeleteRows.Click += new System.EventHandler(this.contexMenuItemDeleteRows_Click);
            // 
            // contexMenuNewRow
            // 
            this.contexMenuNewRow.Name = "contexMenuNewRow";
            this.contexMenuNewRow.Size = new System.Drawing.Size(188, 22);
            this.contexMenuNewRow.Text = "New Row";
            this.contexMenuNewRow.Click += new System.EventHandler(this.contexMenuItemNewRow_Click);
            // 
            // contexMenuEditCell
            // 
            this.contexMenuEditCell.Name = "contexMenuEditCell";
            this.contexMenuEditCell.Size = new System.Drawing.Size(188, 22);
            this.contexMenuEditCell.Text = "Edit Cell";
            this.contexMenuEditCell.Click += new System.EventHandler(this.contexMenuItemEditCell_Click);
            // 
            // contexMenuItemSeparator2
            // 
            this.contexMenuItemSeparator2.Name = "contexMenuItemSeparator2";
            this.contexMenuItemSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // contexMenuCopySelectedRows
            // 
            this.contexMenuCopySelectedRows.Name = "contexMenuCopySelectedRows";
            this.contexMenuCopySelectedRows.Size = new System.Drawing.Size(188, 22);
            this.contexMenuCopySelectedRows.Text = "Copy Selected Row(s)";
            this.contexMenuCopySelectedRows.Click += new System.EventHandler(this.contexMenuItemCopySelectedRows_Click);
            // 
            // contexMenuCopyCellValue
            // 
            this.contexMenuCopyCellValue.Name = "contexMenuCopyCellValue";
            this.contexMenuCopyCellValue.Size = new System.Drawing.Size(188, 22);
            this.contexMenuCopyCellValue.Text = "Copy Cell Value";
            this.contexMenuCopyCellValue.Click += new System.EventHandler(this.contexMenuItemCopyCellValue_Click);
            // 
            // ResultGrid
            // 
            this.Controls.Add(this.checkBoxIgnorePri);
            this.Controls.Add(this.stripMenu);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.gridTable);
            this.Name = "ResultGrid";
            this.Size = new System.Drawing.Size(346, 251);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            this.stripMenu.ResumeLayout(false);
            this.stripMenu.PerformLayout();
            this.contexMenuGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTable;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.ToolStrip stripMenu;
        private System.Windows.Forms.ToolStripButton stripButtonAdd;
        private System.Windows.Forms.ToolStripButton stripButtonDel;
        private System.Windows.Forms.ToolStripSeparator stripSplit1;
        private System.Windows.Forms.ToolStripSplitButton stripButtonExportImport;
        private System.Windows.Forms.ToolStripMenuItem buttonExportCSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelPage;
        private System.Windows.Forms.ToolStripMenuItem buttonImportCSV;
        private System.Windows.Forms.CheckBox checkBoxIgnorePri;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton buttonMode;
        private System.Windows.Forms.ToolStripMenuItem buttonInsertOnly;
        private System.Windows.Forms.ToolStripMenuItem buttonReadOnly;
        private System.Windows.Forms.ToolStripButton buttonDownPage;
        private System.Windows.Forms.ToolStripLabel labelNumPage;
        private System.Windows.Forms.ToolStripButton buttonUpPage;
        private System.Windows.Forms.ContextMenuStrip contexMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem contexMenuOpenFile;
        private System.Windows.Forms.ToolStripSeparator contexMenuItemSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contexMenuDeleteRows;
        private System.Windows.Forms.ToolStripMenuItem contexMenuNewRow;
        private System.Windows.Forms.ToolStripMenuItem contexMenuEditCell;
        private System.Windows.Forms.ToolStripMenuItem contexMenuCopySelectedRows;
        private System.Windows.Forms.ToolStripSeparator contexMenuItemSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contexMenuCopyCellValue;
    }
}
