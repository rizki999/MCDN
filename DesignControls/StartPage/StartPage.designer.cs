namespace MySqlClientDotNET.DesignControls.StartingPage {
    partial class StartPage {
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelListConn = new System.Windows.Forms.Label();
            this.listConnection = new System.Windows.Forms.ListBox();
            this.buttonNewConn = new System.Windows.Forms.LinkLabel();
            this.iconApplication = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoMySqlDotNet = new System.Windows.Forms.PictureBox();
            this.contexMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contexEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contexDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contexOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconApplication)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoMySqlDotNet)).BeginInit();
            this.contexMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelListConn);
            this.panel2.Controls.Add(this.listConnection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 235);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            // 
            // labelListConn
            // 
            this.labelListConn.AutoSize = true;
            this.labelListConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListConn.Location = new System.Drawing.Point(3, 16);
            this.labelListConn.Name = "labelListConn";
            this.labelListConn.Size = new System.Drawing.Size(176, 25);
            this.labelListConn.TabIndex = 3;
            this.labelListConn.Text = "List Connection";
            // 
            // listConnection
            // 
            this.listConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listConnection.BackColor = System.Drawing.SystemColors.Control;
            this.listConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listConnection.FormattingEnabled = true;
            this.listConnection.ItemHeight = 24;
            this.listConnection.Location = new System.Drawing.Point(0, 49);
            this.listConnection.Name = "listConnection";
            this.listConnection.Size = new System.Drawing.Size(223, 168);
            this.listConnection.TabIndex = 0;
            this.listConnection.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listConnection_MouseDoubleClick);
            this.listConnection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listConnection_MouseDown);
            // 
            // buttonNewConn
            // 
            this.buttonNewConn.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.buttonNewConn.AutoSize = true;
            this.buttonNewConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewConn.LinkColor = System.Drawing.Color.Black;
            this.buttonNewConn.Location = new System.Drawing.Point(3, 13);
            this.buttonNewConn.Name = "buttonNewConn";
            this.buttonNewConn.Size = new System.Drawing.Size(131, 50);
            this.buttonNewConn.TabIndex = 4;
            this.buttonNewConn.TabStop = true;
            this.buttonNewConn.Text = "New\r\nConnection";
            this.buttonNewConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonNewConn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buttonNewConn_LinkClicked);
            // 
            // iconApplication
            // 
            this.iconApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconApplication.ErrorImage = null;
            this.iconApplication.InitialImage = null;
            this.iconApplication.Location = new System.Drawing.Point(223, 78);
            this.iconApplication.Name = "iconApplication";
            this.iconApplication.Size = new System.Drawing.Size(231, 235);
            this.iconApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconApplication.TabIndex = 2;
            this.iconApplication.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonNewConn);
            this.panel1.Controls.Add(this.logoMySqlDotNet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 78);
            this.panel1.TabIndex = 3;
            // 
            // logoMySqlDotNet
            // 
            this.logoMySqlDotNet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoMySqlDotNet.ErrorImage = null;
            this.logoMySqlDotNet.InitialImage = null;
            this.logoMySqlDotNet.Location = new System.Drawing.Point(139, 3);
            this.logoMySqlDotNet.Name = "logoMySqlDotNet";
            this.logoMySqlDotNet.Size = new System.Drawing.Size(159, 69);
            this.logoMySqlDotNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoMySqlDotNet.TabIndex = 5;
            this.logoMySqlDotNet.TabStop = false;
            // 
            // contexMenuStrip
            // 
            this.contexMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contexEdit,
            this.contexDelete,
            this.toolStripSeparator1,
            this.contexOpen});
            this.contexMenuStrip.Name = "contexMenuStrip";
            this.contexMenuStrip.Size = new System.Drawing.Size(173, 76);
            // 
            // contexEdit
            // 
            this.contexEdit.Name = "contexEdit";
            this.contexEdit.Size = new System.Drawing.Size(172, 22);
            this.contexEdit.Text = "&Edit Connection";
            this.contexEdit.Click += new System.EventHandler(this.contexEdit_Click);
            // 
            // contexDelete
            // 
            this.contexDelete.Name = "contexDelete";
            this.contexDelete.Size = new System.Drawing.Size(172, 22);
            this.contexDelete.Text = "&Delete Connection";
            this.contexDelete.Click += new System.EventHandler(this.contexDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // contexOpen
            // 
            this.contexOpen.Name = "contexOpen";
            this.contexOpen.Size = new System.Drawing.Size(172, 22);
            this.contexOpen.Text = "&Open Connection";
            this.contexOpen.Click += new System.EventHandler(this.contexOpen_Click);
            // 
            // StartPage
            // 
            this.Controls.Add(this.iconApplication);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(454, 313);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconApplication)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoMySqlDotNet)).EndInit();
            this.contexMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listConnection;
        private System.Windows.Forms.PictureBox iconApplication;
        private System.Windows.Forms.Label labelListConn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel buttonNewConn;
        private System.Windows.Forms.PictureBox logoMySqlDotNet;
        private System.Windows.Forms.ContextMenuStrip contexMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem contexEdit;
        private System.Windows.Forms.ToolStripMenuItem contexDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contexOpen;

    }
}
