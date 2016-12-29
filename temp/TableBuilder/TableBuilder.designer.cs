namespace MySqlClientDotNET.DesignControls {
    partial class TableBuilder {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableBuilder));
            this.gridTable = new System.Windows.Forms.DataGridView();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primary_key = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.not_null = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.unsigned_data = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fill_if_ziro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.auto_increment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gereneted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.default_expression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_store_or_virtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.lableTableName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textTableName = new System.Windows.Forms.TextBox();
            this.comboCollation = new System.Windows.Forms.ComboBox();
            this.lableSchema = new System.Windows.Forms.Label();
            this.comboEngine = new System.Windows.Forms.ComboBox();
            this.textTableComment = new System.Windows.Forms.TextBox();
            this.panelTable = new System.Windows.Forms.Panel();
            this.panStorage = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.radioStore = new System.Windows.Forms.RadioButton();
            this.radioVirtual = new System.Windows.Forms.RadioButton();
            this.comboDefOrExp = new System.Windows.Forms.ComboBox();
            this.listCheckConstraint = new System.Windows.Forms.CheckedListBox();
            this.textDefOrExp = new System.Windows.Forms.TextBox();
            this.comboDataType = new System.Windows.Forms.ComboBox();
            this.textColComment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textSize = new System.Windows.Forms.TextBox();
            this.textColName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelColName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAddColumn = new System.Windows.Forms.ToolStripButton();
            this.buttonEditColumn = new System.Windows.Forms.ToolStripButton();
            this.buttonRemoveColumn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonUpRow = new System.Windows.Forms.ToolStripButton();
            this.buttonDownRow = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            this.panelTable.SuspendLayout();
            this.panStorage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTable
            // 
            this.gridTable.AllowUserToAddRows = false;
            this.gridTable.AllowUserToDeleteRows = false;
            this.gridTable.AllowUserToResizeRows = false;
            this.gridTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_name,
            this.col_comment,
            this.data_type,
            this.col_size,
            this.primary_key,
            this.not_null,
            this.unsigned_data,
            this.fill_if_ziro,
            this.auto_increment,
            this.gereneted,
            this.default_expression,
            this.col_store_or_virtual});
            this.gridTable.Location = new System.Drawing.Point(0, 121);
            this.gridTable.MultiSelect = false;
            this.gridTable.Name = "gridTable";
            this.gridTable.ReadOnly = true;
            this.gridTable.RowHeadersVisible = false;
            this.gridTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTable.Size = new System.Drawing.Size(748, 205);
            this.gridTable.TabIndex = 0;
            this.gridTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridTable_DataError);
            // 
            // column_name
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column_name.DefaultCellStyle = dataGridViewCellStyle1;
            this.column_name.FillWeight = 215.6082F;
            this.column_name.HeaderText = "Column Name";
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            this.column_name.Width = 250;
            // 
            // col_comment
            // 
            this.col_comment.HeaderText = "comment";
            this.col_comment.Name = "col_comment";
            this.col_comment.ReadOnly = true;
            // 
            // data_type
            // 
            this.data_type.FillWeight = 215.6082F;
            this.data_type.HeaderText = "Data Type";
            this.data_type.Name = "data_type";
            this.data_type.ReadOnly = true;
            this.data_type.Width = 126;
            // 
            // col_size
            // 
            this.col_size.HeaderText = "Size";
            this.col_size.Name = "col_size";
            this.col_size.ReadOnly = true;
            // 
            // primary_key
            // 
            this.primary_key.FillWeight = 57.70638F;
            this.primary_key.HeaderText = "PK";
            this.primary_key.Name = "primary_key";
            this.primary_key.ReadOnly = true;
            this.primary_key.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.primary_key.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.primary_key.Width = 25;
            // 
            // not_null
            // 
            this.not_null.FillWeight = 55.88832F;
            this.not_null.HeaderText = "NN";
            this.not_null.Name = "not_null";
            this.not_null.ReadOnly = true;
            this.not_null.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.not_null.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.not_null.Width = 25;
            // 
            // unsigned_data
            // 
            this.unsigned_data.FillWeight = 56.26896F;
            this.unsigned_data.HeaderText = "UN";
            this.unsigned_data.Name = "unsigned_data";
            this.unsigned_data.ReadOnly = true;
            this.unsigned_data.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unsigned_data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.unsigned_data.Width = 25;
            // 
            // fill_if_ziro
            // 
            this.fill_if_ziro.FillWeight = 56.07389F;
            this.fill_if_ziro.HeaderText = "ZF";
            this.fill_if_ziro.Name = "fill_if_ziro";
            this.fill_if_ziro.ReadOnly = true;
            this.fill_if_ziro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fill_if_ziro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fill_if_ziro.Width = 25;
            // 
            // auto_increment
            // 
            this.auto_increment.FillWeight = 58.92373F;
            this.auto_increment.HeaderText = "AI";
            this.auto_increment.Name = "auto_increment";
            this.auto_increment.ReadOnly = true;
            this.auto_increment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.auto_increment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.auto_increment.Width = 25;
            // 
            // gereneted
            // 
            this.gereneted.HeaderText = "G";
            this.gereneted.Name = "gereneted";
            this.gereneted.ReadOnly = true;
            this.gereneted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gereneted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gereneted.Width = 25;
            // 
            // default_expression
            // 
            this.default_expression.FillWeight = 215.6082F;
            this.default_expression.HeaderText = "Default/Expression";
            this.default_expression.Name = "default_expression";
            this.default_expression.ReadOnly = true;
            this.default_expression.Width = 150;
            // 
            // col_store_or_virtual
            // 
            this.col_store_or_virtual.HeaderText = "Store/Virtual";
            this.col_store_or_virtual.Name = "col_store_or_virtual";
            this.col_store_or_virtual.ReadOnly = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(591, 466);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 22);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDiscard.Location = new System.Drawing.Point(672, 466);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(75, 22);
            this.buttonDiscard.TabIndex = 4;
            this.buttonDiscard.Text = "Discard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // lableTableName
            // 
            this.lableTableName.AutoSize = true;
            this.lableTableName.Location = new System.Drawing.Point(3, 16);
            this.lableTableName.Name = "lableTableName";
            this.lableTableName.Size = new System.Drawing.Size(65, 13);
            this.lableTableName.TabIndex = 5;
            this.lableTableName.Text = "Table Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Collation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Secema";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Engine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Comment";
            // 
            // textTableName
            // 
            this.textTableName.Location = new System.Drawing.Point(71, 13);
            this.textTableName.Name = "textTableName";
            this.textTableName.Size = new System.Drawing.Size(187, 20);
            this.textTableName.TabIndex = 10;
            // 
            // comboCollation
            // 
            this.comboCollation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCollation.DropDownWidth = 280;
            this.comboCollation.FormattingEnabled = true;
            this.comboCollation.Location = new System.Drawing.Point(71, 39);
            this.comboCollation.Name = "comboCollation";
            this.comboCollation.Size = new System.Drawing.Size(187, 21);
            this.comboCollation.TabIndex = 11;
            // 
            // lableSchema
            // 
            this.lableSchema.AutoSize = true;
            this.lableSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableSchema.Location = new System.Drawing.Point(311, 16);
            this.lableSchema.Name = "lableSchema";
            this.lableSchema.Size = new System.Drawing.Size(11, 13);
            this.lableSchema.TabIndex = 12;
            this.lableSchema.Text = "-";
            // 
            // comboEngine
            // 
            this.comboEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEngine.FormattingEnabled = true;
            this.comboEngine.Location = new System.Drawing.Point(314, 39);
            this.comboEngine.Name = "comboEngine";
            this.comboEngine.Size = new System.Drawing.Size(187, 21);
            this.comboEngine.TabIndex = 13;
            // 
            // textTableComment
            // 
            this.textTableComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTableComment.Location = new System.Drawing.Point(71, 66);
            this.textTableComment.Multiline = true;
            this.textTableComment.Name = "textTableComment";
            this.textTableComment.Size = new System.Drawing.Size(444, 57);
            this.textTableComment.TabIndex = 14;
            // 
            // panelTable
            // 
            this.panelTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTable.AutoScroll = true;
            this.panelTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTable.Controls.Add(this.panStorage);
            this.panelTable.Controls.Add(this.comboDefOrExp);
            this.panelTable.Controls.Add(this.listCheckConstraint);
            this.panelTable.Controls.Add(this.textDefOrExp);
            this.panelTable.Controls.Add(this.comboDataType);
            this.panelTable.Controls.Add(this.textColComment);
            this.panelTable.Controls.Add(this.label11);
            this.panelTable.Controls.Add(this.textSize);
            this.panelTable.Controls.Add(this.textColName);
            this.panelTable.Controls.Add(this.label8);
            this.panelTable.Controls.Add(this.label6);
            this.panelTable.Controls.Add(this.labelColName);
            this.panelTable.Controls.Add(this.gridTable);
            this.panelTable.Controls.Add(this.panel1);
            this.panelTable.Location = new System.Drawing.Point(0, 127);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(750, 333);
            this.panelTable.TabIndex = 15;
            // 
            // panStorage
            // 
            this.panStorage.Controls.Add(this.label9);
            this.panStorage.Controls.Add(this.radioStore);
            this.panStorage.Controls.Add(this.radioVirtual);
            this.panStorage.Location = new System.Drawing.Point(222, 61);
            this.panStorage.Name = "panStorage";
            this.panStorage.Size = new System.Drawing.Size(223, 22);
            this.panStorage.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Storage";
            // 
            // radioStore
            // 
            this.radioStore.AutoSize = true;
            this.radioStore.Location = new System.Drawing.Point(91, 3);
            this.radioStore.Name = "radioStore";
            this.radioStore.Size = new System.Drawing.Size(50, 17);
            this.radioStore.TabIndex = 9;
            this.radioStore.TabStop = true;
            this.radioStore.Text = "Store";
            this.radioStore.UseVisualStyleBackColor = true;
            // 
            // radioVirtual
            // 
            this.radioVirtual.AutoSize = true;
            this.radioVirtual.Location = new System.Drawing.Point(159, 3);
            this.radioVirtual.Name = "radioVirtual";
            this.radioVirtual.Size = new System.Drawing.Size(54, 17);
            this.radioVirtual.TabIndex = 10;
            this.radioVirtual.TabStop = true;
            this.radioVirtual.Text = "Virtual";
            this.radioVirtual.UseVisualStyleBackColor = true;
            // 
            // comboDefOrExp
            // 
            this.comboDefOrExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefOrExp.Enabled = false;
            this.comboDefOrExp.FormattingEnabled = true;
            this.comboDefOrExp.Items.AddRange(new object[] {
            "Default",
            "Expression"});
            this.comboDefOrExp.Location = new System.Drawing.Point(222, 34);
            this.comboDefOrExp.Name = "comboDefOrExp";
            this.comboDefOrExp.Size = new System.Drawing.Size(81, 21);
            this.comboDefOrExp.TabIndex = 5;
            this.comboDefOrExp.SelectedIndexChanged += new System.EventHandler(this.comboDefOrExp_SelectedIndexChanged);
            // 
            // listCheckConstraint
            // 
            this.listCheckConstraint.FormattingEnabled = true;
            this.listCheckConstraint.Location = new System.Drawing.Point(451, 33);
            this.listCheckConstraint.Name = "listCheckConstraint";
            this.listCheckConstraint.Size = new System.Drawing.Size(120, 79);
            this.listCheckConstraint.TabIndex = 7;
            this.listCheckConstraint.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listCheckConstraint_ItemCheck);
            // 
            // textDefOrExp
            // 
            this.textDefOrExp.Location = new System.Drawing.Point(314, 34);
            this.textDefOrExp.Name = "textDefOrExp";
            this.textDefOrExp.Size = new System.Drawing.Size(121, 20);
            this.textDefOrExp.TabIndex = 6;
            this.textDefOrExp.TextChanged += new System.EventHandler(this.textDefOrExp_TextChanged);
            // 
            // comboDataType
            // 
            this.comboDataType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataType.FormattingEnabled = true;
            this.comboDataType.IntegralHeight = false;
            this.comboDataType.Location = new System.Drawing.Point(313, 7);
            this.comboDataType.MaxDropDownItems = 10;
            this.comboDataType.Name = "comboDataType";
            this.comboDataType.Size = new System.Drawing.Size(121, 21);
            this.comboDataType.TabIndex = 3;
            this.comboDataType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboDataType_DrawItem);
            this.comboDataType.SelectedIndexChanged += new System.EventHandler(this.comboDataType_SelectedIndexChanged);
            // 
            // textColComment
            // 
            this.textColComment.Location = new System.Drawing.Point(61, 33);
            this.textColComment.Multiline = true;
            this.textColComment.Name = "textColComment";
            this.textColComment.Size = new System.Drawing.Size(155, 57);
            this.textColComment.TabIndex = 2;
            this.textColComment.WordWrap = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Comment";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(480, 7);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(91, 20);
            this.textSize.TabIndex = 4;
            this.textSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSize_KeyDown);
            this.textSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSize_KeyPress);
            this.textSize.Leave += new System.EventHandler(this.textSize_Leave);
            // 
            // textColName
            // 
            this.textColName.Location = new System.Drawing.Point(77, 7);
            this.textColName.Name = "textColName";
            this.textColName.Size = new System.Drawing.Size(139, 20);
            this.textColName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Data Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Size";
            // 
            // labelColName
            // 
            this.labelColName.AutoSize = true;
            this.labelColName.Location = new System.Drawing.Point(3, 10);
            this.labelColName.Name = "labelColName";
            this.labelColName.Size = new System.Drawing.Size(73, 13);
            this.labelColName.TabIndex = 20;
            this.labelColName.Text = "Column Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(-1, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 33);
            this.panel1.TabIndex = 26;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddColumn,
            this.buttonEditColumn,
            this.buttonRemoveColumn,
            this.toolStripSeparator1,
            this.buttonUpRow,
            this.buttonDownRow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(456, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAddColumn
            // 
            this.buttonAddColumn.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddColumn.Image")));
            this.buttonAddColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddColumn.Name = "buttonAddColumn";
            this.buttonAddColumn.Size = new System.Drawing.Size(95, 22);
            this.buttonAddColumn.Text = "Add Column";
            this.buttonAddColumn.Click += new System.EventHandler(this.buttonAddColumn_Click);
            // 
            // buttonEditColumn
            // 
            this.buttonEditColumn.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditColumn.Image")));
            this.buttonEditColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditColumn.Name = "buttonEditColumn";
            this.buttonEditColumn.Size = new System.Drawing.Size(93, 22);
            this.buttonEditColumn.Text = "Edit Column";
            this.buttonEditColumn.Click += new System.EventHandler(this.buttonEditColumn_Click);
            // 
            // buttonRemoveColumn
            // 
            this.buttonRemoveColumn.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveColumn.Image")));
            this.buttonRemoveColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveColumn.Name = "buttonRemoveColumn";
            this.buttonRemoveColumn.Size = new System.Drawing.Size(116, 22);
            this.buttonRemoveColumn.Text = "Remove Column";
            this.buttonRemoveColumn.Click += new System.EventHandler(this.buttonRemoveColumn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonUpRow
            // 
            this.buttonUpRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUpRow.Image = ((System.Drawing.Image)(resources.GetObject("buttonUpRow.Image")));
            this.buttonUpRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUpRow.Name = "buttonUpRow";
            this.buttonUpRow.Size = new System.Drawing.Size(23, 22);
            this.buttonUpRow.Text = "Move Row Up";
            this.buttonUpRow.Click += new System.EventHandler(this.buttonUpRow_Click);
            // 
            // buttonDownRow
            // 
            this.buttonDownRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDownRow.Image = ((System.Drawing.Image)(resources.GetObject("buttonDownRow.Image")));
            this.buttonDownRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDownRow.Name = "buttonDownRow";
            this.buttonDownRow.Size = new System.Drawing.Size(23, 22);
            this.buttonDownRow.Text = "Move Row Down";
            this.buttonDownRow.Click += new System.EventHandler(this.buttonDownRow_Click);
            // 
            // TableBuilder
            // 
            this.Controls.Add(this.panelTable);
            this.Controls.Add(this.lableTableName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboEngine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTableComment);
            this.Controls.Add(this.lableSchema);
            this.Controls.Add(this.textTableName);
            this.Controls.Add(this.comboCollation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonApply);
            this.Size = new System.Drawing.Size(750, 491);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            this.panelTable.ResumeLayout(false);
            this.panelTable.PerformLayout();
            this.panStorage.ResumeLayout(false);
            this.panStorage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTable;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Label lableTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTableName;
        private System.Windows.Forms.ComboBox comboCollation;
        private System.Windows.Forms.Label lableSchema;
        private System.Windows.Forms.ComboBox comboEngine;
        private System.Windows.Forms.TextBox textTableComment;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.TextBox textSize;
        private System.Windows.Forms.TextBox textColName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelColName;
        private System.Windows.Forms.ComboBox comboDataType;
        private System.Windows.Forms.TextBox textColComment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox listCheckConstraint;
        private System.Windows.Forms.RadioButton radioVirtual;
        private System.Windows.Forms.RadioButton radioStore;
        private System.Windows.Forms.TextBox textDefOrExp;
        private System.Windows.Forms.ComboBox comboDefOrExp;
        private System.Windows.Forms.Panel panStorage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAddColumn;
        private System.Windows.Forms.ToolStripButton buttonEditColumn;
        private System.Windows.Forms.ToolStripButton buttonRemoveColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonUpRow;
        private System.Windows.Forms.ToolStripButton buttonDownRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_size;
        private System.Windows.Forms.DataGridViewCheckBoxColumn primary_key;
        private System.Windows.Forms.DataGridViewCheckBoxColumn not_null;
        private System.Windows.Forms.DataGridViewCheckBoxColumn unsigned_data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fill_if_ziro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn auto_increment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gereneted;
        private System.Windows.Forms.DataGridViewTextBoxColumn default_expression;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_store_or_virtual;
    }
}
