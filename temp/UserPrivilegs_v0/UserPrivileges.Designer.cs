namespace MySqlClientDotNET.DesignControls.UserPrivilegesNS {
    partial class UserPrivileges {
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tb_data = new System.Windows.Forms.TabPage();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.gridTable = new System.Windows.Forms.DataGridView();
            this.col_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_creat = new System.Windows.Forms.TabPage();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPriviliges = new System.Windows.Forms.TabPage();
            this.tabPrivilegs = new System.Windows.Forms.TabControl();
            this.tabPageG = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkDataG = new System.Windows.Forms.CheckBox();
            this.checkListDataG = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkAdminG = new System.Windows.Forms.CheckBox();
            this.checkListAdminG = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkStructG = new System.Windows.Forms.CheckBox();
            this.checkListStructG = new System.Windows.Forms.CheckedListBox();
            this.tabPageD = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboTBD = new System.Windows.Forms.ComboBox();
            this.comboDBD = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkDataD = new System.Windows.Forms.CheckBox();
            this.checkListDataD = new System.Windows.Forms.CheckedListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkAdminD = new System.Windows.Forms.CheckBox();
            this.checkListAdminD = new System.Windows.Forms.CheckedListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkStructD = new System.Windows.Forms.CheckBox();
            this.checkListStructD = new System.Windows.Forms.CheckedListBox();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.numMUC = new System.Windows.Forms.NumericUpDown();
            this.numMC = new System.Windows.Forms.NumericUpDown();
            this.numMU = new System.Windows.Forms.NumericUpDown();
            this.numMQ = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.TextBox();
            this.labelHost = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.contexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPrivilegesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab.SuspendLayout();
            this.tb_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            this.tb_creat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbPriviliges.SuspendLayout();
            this.tabPrivilegs.SuspendLayout();
            this.tabPageG.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageD.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMUC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMQ)).BeginInit();
            this.contexMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tab.Controls.Add(this.tb_data);
            this.tab.Controls.Add(this.tb_creat);
            this.tab.Controls.Add(this.tbPriviliges);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(526, 366);
            this.tab.TabIndex = 0;
            // 
            // tb_data
            // 
            this.tb_data.AutoScroll = true;
            this.tb_data.AutoScrollMinSize = new System.Drawing.Size(502, 292);
            this.tb_data.BackColor = System.Drawing.SystemColors.Control;
            this.tb_data.Controls.Add(this.buttonEdit);
            this.tb_data.Controls.Add(this.buttonRemove);
            this.tb_data.Controls.Add(this.buttonCreate);
            this.tb_data.Controls.Add(this.gridTable);
            this.tb_data.Location = new System.Drawing.Point(4, 25);
            this.tb_data.Name = "tb_data";
            this.tb_data.Padding = new System.Windows.Forms.Padding(3);
            this.tb_data.Size = new System.Drawing.Size(518, 337);
            this.tb_data.TabIndex = 0;
            this.tb_data.Text = "Data";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(339, 302);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(86, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit Privileges";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(431, 302);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Location = new System.Drawing.Point(258, 302);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // gridTable
            // 
            this.gridTable.AllowUserToAddRows = false;
            this.gridTable.AllowUserToDeleteRows = false;
            this.gridTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_user,
            this.col_host});
            this.gridTable.Location = new System.Drawing.Point(6, 6);
            this.gridTable.MultiSelect = false;
            this.gridTable.Name = "gridTable";
            this.gridTable.ReadOnly = true;
            this.gridTable.RowHeadersVisible = false;
            this.gridTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTable.Size = new System.Drawing.Size(500, 290);
            this.gridTable.TabIndex = 0;
            this.gridTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTable_CellMouseDown);
            // 
            // col_user
            // 
            this.col_user.HeaderText = "Users";
            this.col_user.Name = "col_user";
            this.col_user.ReadOnly = true;
            // 
            // col_host
            // 
            this.col_host.HeaderText = "Host";
            this.col_host.Name = "col_host";
            this.col_host.ReadOnly = true;
            // 
            // tb_creat
            // 
            this.tb_creat.AutoScroll = true;
            this.tb_creat.AutoScrollMinSize = new System.Drawing.Size(502, 292);
            this.tb_creat.BackColor = System.Drawing.SystemColors.Control;
            this.tb_creat.Controls.Add(this.buttonBack);
            this.tb_creat.Controls.Add(this.buttonNext);
            this.tb_creat.Controls.Add(this.groupBox1);
            this.tb_creat.Location = new System.Drawing.Point(4, 25);
            this.tb_creat.Name = "tb_creat";
            this.tb_creat.Padding = new System.Windows.Forms.Padding(3);
            this.tb_creat.Size = new System.Drawing.Size(518, 337);
            this.tb_creat.TabIndex = 1;
            this.tb_creat.Text = "Create";
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(417, 299);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 10;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(336, 299);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textPass);
            this.groupBox1.Controls.Add(this.textHost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(23, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 260);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create User";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // textUser
            // 
            this.textUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textUser.Location = new System.Drawing.Point(91, 83);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(224, 20);
            this.textUser.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Left empty if no password";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host";
            // 
            // textPass
            // 
            this.textPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textPass.Location = new System.Drawing.Point(91, 135);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(224, 20);
            this.textPass.TabIndex = 5;
            // 
            // textHost
            // 
            this.textHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textHost.Location = new System.Drawing.Point(91, 109);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(224, 20);
            this.textHost.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Use \'%\' for eny host";
            // 
            // tbPriviliges
            // 
            this.tbPriviliges.AutoScroll = true;
            this.tbPriviliges.AutoScrollMinSize = new System.Drawing.Size(502, 292);
            this.tbPriviliges.BackColor = System.Drawing.SystemColors.Control;
            this.tbPriviliges.Controls.Add(this.tabPrivilegs);
            this.tbPriviliges.Controls.Add(this.buttonDiscard);
            this.tbPriviliges.Controls.Add(this.buttonApply);
            this.tbPriviliges.Controls.Add(this.numMUC);
            this.tbPriviliges.Controls.Add(this.numMC);
            this.tbPriviliges.Controls.Add(this.numMU);
            this.tbPriviliges.Controls.Add(this.numMQ);
            this.tbPriviliges.Controls.Add(this.label12);
            this.tbPriviliges.Controls.Add(this.label9);
            this.tbPriviliges.Controls.Add(this.label10);
            this.tbPriviliges.Controls.Add(this.label11);
            this.tbPriviliges.Controls.Add(this.labelPass);
            this.tbPriviliges.Controls.Add(this.labelHost);
            this.tbPriviliges.Controls.Add(this.labelUser);
            this.tbPriviliges.Controls.Add(this.label6);
            this.tbPriviliges.Controls.Add(this.label7);
            this.tbPriviliges.Controls.Add(this.label8);
            this.tbPriviliges.Location = new System.Drawing.Point(4, 25);
            this.tbPriviliges.Name = "tbPriviliges";
            this.tbPriviliges.Size = new System.Drawing.Size(518, 337);
            this.tbPriviliges.TabIndex = 2;
            this.tbPriviliges.Text = "Privileges";
            // 
            // tabPrivilegs
            // 
            this.tabPrivilegs.Controls.Add(this.tabPageG);
            this.tabPrivilegs.Controls.Add(this.tabPageD);
            this.tabPrivilegs.Location = new System.Drawing.Point(6, 115);
            this.tabPrivilegs.Name = "tabPrivilegs";
            this.tabPrivilegs.SelectedIndex = 0;
            this.tabPrivilegs.Size = new System.Drawing.Size(509, 186);
            this.tabPrivilegs.TabIndex = 29;
            this.tabPrivilegs.SelectedIndexChanged += new System.EventHandler(this.tabPrivilegs_SelectedIndexChanged);
            // 
            // tabPageG
            // 
            this.tabPageG.Controls.Add(this.groupBox2);
            this.tabPageG.Controls.Add(this.groupBox4);
            this.tabPageG.Controls.Add(this.groupBox3);
            this.tabPageG.Location = new System.Drawing.Point(4, 22);
            this.tabPageG.Name = "tabPageG";
            this.tabPageG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageG.Size = new System.Drawing.Size(501, 160);
            this.tabPageG.TabIndex = 0;
            this.tabPageG.Text = "Global";
            this.tabPageG.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkDataG);
            this.groupBox2.Controls.Add(this.checkListDataG);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 143);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // checkDataG
            // 
            this.checkDataG.AutoSize = true;
            this.checkDataG.Location = new System.Drawing.Point(38, 0);
            this.checkDataG.Name = "checkDataG";
            this.checkDataG.Size = new System.Drawing.Size(15, 14);
            this.checkDataG.TabIndex = 1;
            this.checkDataG.UseVisualStyleBackColor = true;
            this.checkDataG.CheckedChanged += new System.EventHandler(this.checkDataG_CheckedChanged);
            // 
            // checkListDataG
            // 
            this.checkListDataG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkListDataG.FormattingEnabled = true;
            this.checkListDataG.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE",
            "FILE"});
            this.checkListDataG.Location = new System.Drawing.Point(6, 19);
            this.checkListDataG.Name = "checkListDataG";
            this.checkListDataG.Size = new System.Drawing.Size(147, 109);
            this.checkListDataG.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkAdminG);
            this.groupBox4.Controls.Add(this.checkListAdminG);
            this.groupBox4.Location = new System.Drawing.Point(333, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(159, 143);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Administration";
            // 
            // checkAdminG
            // 
            this.checkAdminG.AutoSize = true;
            this.checkAdminG.Location = new System.Drawing.Point(78, 0);
            this.checkAdminG.Name = "checkAdminG";
            this.checkAdminG.Size = new System.Drawing.Size(15, 14);
            this.checkAdminG.TabIndex = 3;
            this.checkAdminG.UseVisualStyleBackColor = true;
            this.checkAdminG.CheckedChanged += new System.EventHandler(this.checkAdminG_CheckedChanged);
            // 
            // checkListAdminG
            // 
            this.checkListAdminG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkListAdminG.FormattingEnabled = true;
            this.checkListAdminG.Items.AddRange(new object[] {
            "GRANT",
            "SUPER",
            "PROCESS",
            "RELOAD",
            "SHUTDOWN",
            "SHOW DATABASES",
            "LOCK TABLES",
            "REFERENCES",
            "REPLICATION CLIENT",
            "REPLICATION SLAVE",
            "CREATE USER"});
            this.checkListAdminG.Location = new System.Drawing.Point(6, 19);
            this.checkListAdminG.Name = "checkListAdminG";
            this.checkListAdminG.Size = new System.Drawing.Size(147, 109);
            this.checkListAdminG.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkStructG);
            this.groupBox3.Controls.Add(this.checkListStructG);
            this.groupBox3.Location = new System.Drawing.Point(168, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 143);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Structure";
            // 
            // checkStructG
            // 
            this.checkStructG.AutoSize = true;
            this.checkStructG.Location = new System.Drawing.Point(57, 0);
            this.checkStructG.Name = "checkStructG";
            this.checkStructG.Size = new System.Drawing.Size(15, 14);
            this.checkStructG.TabIndex = 2;
            this.checkStructG.UseVisualStyleBackColor = true;
            this.checkStructG.CheckedChanged += new System.EventHandler(this.checkStructG_CheckedChanged);
            // 
            // checkListStructG
            // 
            this.checkListStructG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkListStructG.FormattingEnabled = true;
            this.checkListStructG.Items.AddRange(new object[] {
            "CREATE",
            "ALTER",
            "INDEX",
            "DROP",
            "CREATE TEMPORARY TABLES",
            "SHOW VIEW",
            "CREATE ROUTINE",
            "ALTER ROUTINE",
            "EXECUTE",
            "CREATE VIEW",
            "EVENT",
            "TRIGGER"});
            this.checkListStructG.Location = new System.Drawing.Point(6, 19);
            this.checkListStructG.Name = "checkListStructG";
            this.checkListStructG.Size = new System.Drawing.Size(147, 109);
            this.checkListStructG.TabIndex = 1;
            // 
            // tabPageD
            // 
            this.tabPageD.AutoScroll = true;
            this.tabPageD.Controls.Add(this.label14);
            this.tabPageD.Controls.Add(this.label13);
            this.tabPageD.Controls.Add(this.comboTBD);
            this.tabPageD.Controls.Add(this.comboDBD);
            this.tabPageD.Controls.Add(this.groupBox5);
            this.tabPageD.Controls.Add(this.groupBox6);
            this.tabPageD.Controls.Add(this.groupBox7);
            this.tabPageD.Location = new System.Drawing.Point(4, 22);
            this.tabPageD.Name = "tabPageD";
            this.tabPageD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageD.Size = new System.Drawing.Size(501, 160);
            this.tabPageD.TabIndex = 1;
            this.tabPageD.Text = "Database.Table";
            this.tabPageD.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(225, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Table :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Database :";
            // 
            // comboTBD
            // 
            this.comboTBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTBD.FormattingEnabled = true;
            this.comboTBD.Location = new System.Drawing.Point(271, 6);
            this.comboTBD.Name = "comboTBD";
            this.comboTBD.Size = new System.Drawing.Size(154, 21);
            this.comboTBD.TabIndex = 20;
            // 
            // comboDBD
            // 
            this.comboDBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDBD.FormattingEnabled = true;
            this.comboDBD.Location = new System.Drawing.Point(65, 6);
            this.comboDBD.Name = "comboDBD";
            this.comboDBD.Size = new System.Drawing.Size(154, 21);
            this.comboDBD.TabIndex = 19;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkDataD);
            this.groupBox5.Controls.Add(this.checkListDataD);
            this.groupBox5.Location = new System.Drawing.Point(3, 43);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(159, 143);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Data";
            // 
            // checkDataD
            // 
            this.checkDataD.AutoSize = true;
            this.checkDataD.Location = new System.Drawing.Point(38, 0);
            this.checkDataD.Name = "checkDataD";
            this.checkDataD.Size = new System.Drawing.Size(15, 14);
            this.checkDataD.TabIndex = 1;
            this.checkDataD.UseVisualStyleBackColor = true;
            // 
            // checkListDataD
            // 
            this.checkListDataD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkListDataD.FormattingEnabled = true;
            this.checkListDataD.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.checkListDataD.Location = new System.Drawing.Point(6, 19);
            this.checkListDataD.Name = "checkListDataD";
            this.checkListDataD.Size = new System.Drawing.Size(147, 109);
            this.checkListDataD.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkAdminD);
            this.groupBox6.Controls.Add(this.checkListAdminD);
            this.groupBox6.Location = new System.Drawing.Point(333, 43);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(159, 143);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Administration";
            // 
            // checkAdminD
            // 
            this.checkAdminD.AutoSize = true;
            this.checkAdminD.Location = new System.Drawing.Point(78, 0);
            this.checkAdminD.Name = "checkAdminD";
            this.checkAdminD.Size = new System.Drawing.Size(15, 14);
            this.checkAdminD.TabIndex = 3;
            this.checkAdminD.UseVisualStyleBackColor = true;
            // 
            // checkListAdminD
            // 
            this.checkListAdminD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkListAdminD.FormattingEnabled = true;
            this.checkListAdminD.Items.AddRange(new object[] {
            "GRANT",
            "LOCK TABLES",
            "REFERENCES"});
            this.checkListAdminD.Location = new System.Drawing.Point(6, 19);
            this.checkListAdminD.Name = "checkListAdminD";
            this.checkListAdminD.Size = new System.Drawing.Size(147, 109);
            this.checkListAdminD.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkStructD);
            this.groupBox7.Controls.Add(this.checkListStructD);
            this.groupBox7.Location = new System.Drawing.Point(168, 43);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(159, 143);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Structure";
            // 
            // checkStructD
            // 
            this.checkStructD.AutoSize = true;
            this.checkStructD.Location = new System.Drawing.Point(57, 0);
            this.checkStructD.Name = "checkStructD";
            this.checkStructD.Size = new System.Drawing.Size(15, 14);
            this.checkStructD.TabIndex = 2;
            this.checkStructD.UseVisualStyleBackColor = true;
            // 
            // checkListStructD
            // 
            this.checkListStructD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkListStructD.FormattingEnabled = true;
            this.checkListStructD.Items.AddRange(new object[] {
            "CREATE",
            "ALTER",
            "INDEX",
            "DROP",
            "CREATE TEMPORARY TABLES",
            "SHOW VIEW",
            "CREATE ROUTINE",
            "ALTER ROUTINE",
            "EXECUTE",
            "CREATE VIEW",
            "EVENT",
            "TRIGGER"});
            this.checkListStructD.Location = new System.Drawing.Point(6, 19);
            this.checkListStructD.Name = "checkListStructD";
            this.checkListStructD.Size = new System.Drawing.Size(147, 109);
            this.checkListStructD.TabIndex = 1;
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDiscard.Location = new System.Drawing.Point(431, 307);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(75, 23);
            this.buttonDiscard.TabIndex = 28;
            this.buttonDiscard.Text = "Discard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(353, 307);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 27;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // numMUC
            // 
            this.numMUC.Location = new System.Drawing.Point(330, 86);
            this.numMUC.Name = "numMUC";
            this.numMUC.Size = new System.Drawing.Size(46, 20);
            this.numMUC.TabIndex = 26;
            // 
            // numMC
            // 
            this.numMC.Location = new System.Drawing.Point(330, 60);
            this.numMC.Name = "numMC";
            this.numMC.Size = new System.Drawing.Size(46, 20);
            this.numMC.TabIndex = 25;
            // 
            // numMU
            // 
            this.numMU.Location = new System.Drawing.Point(330, 34);
            this.numMU.Name = "numMU";
            this.numMU.Size = new System.Drawing.Size(46, 20);
            this.numMU.TabIndex = 24;
            // 
            // numMQ
            // 
            this.numMQ.Location = new System.Drawing.Point(330, 8);
            this.numMQ.Name = "numMQ";
            this.numMQ.Size = new System.Drawing.Size(46, 20);
            this.numMQ.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Max User Conections";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Max Querys Per Hour";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Max Connections";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(216, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Max Update Per Hour";
            // 
            // labelPass
            // 
            this.labelPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelPass.Location = new System.Drawing.Point(85, 59);
            this.labelPass.Name = "labelPass";
            this.labelPass.ReadOnly = true;
            this.labelPass.Size = new System.Drawing.Size(125, 13);
            this.labelPass.TabIndex = 18;
            this.labelPass.Text = "-";
            // 
            // labelHost
            // 
            this.labelHost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelHost.Location = new System.Drawing.Point(85, 36);
            this.labelHost.Name = "labelHost";
            this.labelHost.ReadOnly = true;
            this.labelHost.Size = new System.Drawing.Size(125, 13);
            this.labelHost.TabIndex = 17;
            this.labelHost.Text = "-";
            // 
            // labelUser
            // 
            this.labelUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelUser.Location = new System.Drawing.Point(85, 10);
            this.labelUser.Name = "labelUser";
            this.labelUser.ReadOnly = true;
            this.labelUser.Size = new System.Drawing.Size(125, 13);
            this.labelUser.TabIndex = 16;
            this.labelUser.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "User Name :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Password   :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Host           :";
            // 
            // contexMenu
            // 
            this.contexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPrivilegesToolStripMenuItem,
            this.removeUserToolStripMenuItem});
            this.contexMenu.Name = "contexMenu";
            this.contexMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // editPrivilegesToolStripMenuItem
            // 
            this.editPrivilegesToolStripMenuItem.Name = "editPrivilegesToolStripMenuItem";
            this.editPrivilegesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editPrivilegesToolStripMenuItem.Text = "&Edit Privileges";
            this.editPrivilegesToolStripMenuItem.Click += new System.EventHandler(this.editPrivilegesToolStripMenuItem_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.removeUserToolStripMenuItem.Text = "&Remove User";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
            // 
            // UserPrivileges
            // 
            this.Controls.Add(this.tab);
            this.Size = new System.Drawing.Size(526, 366);
            this.tab.ResumeLayout(false);
            this.tb_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            this.tb_creat.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbPriviliges.ResumeLayout(false);
            this.tbPriviliges.PerformLayout();
            this.tabPrivilegs.ResumeLayout(false);
            this.tabPageG.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageD.ResumeLayout(false);
            this.tabPageD.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMUC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMQ)).EndInit();
            this.contexMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tb_data;
        private System.Windows.Forms.TabPage tb_creat;
        private System.Windows.Forms.TabPage tbPriviliges;
        private System.Windows.Forms.DataGridView gridTable;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_host;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ContextMenuStrip contexMenu;
        private System.Windows.Forms.ToolStripMenuItem editPrivilegesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkListStructG;
        private System.Windows.Forms.CheckedListBox checkListAdminG;
        private System.Windows.Forms.CheckedListBox checkListDataG;
        private System.Windows.Forms.TextBox labelPass;
        private System.Windows.Forms.TextBox labelHost;
        private System.Windows.Forms.TextBox labelUser;
        private System.Windows.Forms.NumericUpDown numMQ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numMUC;
        private System.Windows.Forms.NumericUpDown numMC;
        private System.Windows.Forms.NumericUpDown numMU;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.CheckBox checkStructG;
        private System.Windows.Forms.CheckBox checkAdminG;
        private System.Windows.Forms.CheckBox checkDataG;
        private System.Windows.Forms.TabControl tabPrivilegs;
        private System.Windows.Forms.TabPage tabPageG;
        private System.Windows.Forms.TabPage tabPageD;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkDataD;
        private System.Windows.Forms.CheckedListBox checkListDataD;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkAdminD;
        private System.Windows.Forms.CheckedListBox checkListAdminD;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkStructD;
        private System.Windows.Forms.CheckedListBox checkListStructD;
        private System.Windows.Forms.ComboBox comboDBD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboTBD;
    }
}
