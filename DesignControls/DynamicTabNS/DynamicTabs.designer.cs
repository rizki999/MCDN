namespace MySqlClientDotNET.DesignControls.DynamicTabNS {
    partial class DynamicTabs {
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
            this.panTabHeader = new System.Windows.Forms.Panel();
            this.panTabHeaderControls = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btList = new System.Windows.Forms.ToolStripButton();
            this.btClose = new System.Windows.Forms.ToolStripButton();
            this.panHTabHeader = new System.Windows.Forms.Panel();
            this.lsbList = new System.Windows.Forms.ListBox();
            this.panMain = new System.Windows.Forms.Panel();
            this.panTabHeader.SuspendLayout();
            this.panTabHeaderControls.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTabHeader
            // 
            this.panTabHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTabHeader.BackColor = System.Drawing.SystemColors.Control;
            this.panTabHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTabHeader.Controls.Add(this.panTabHeaderControls);
            this.panTabHeader.Controls.Add(this.panHTabHeader);
            this.panTabHeader.Location = new System.Drawing.Point(-1, -1);
            this.panTabHeader.Name = "panTabHeader";
            this.panTabHeader.Size = new System.Drawing.Size(285, 28);
            this.panTabHeader.TabIndex = 1;
            // 
            // panTabHeaderControls
            // 
            this.panTabHeaderControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panTabHeaderControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTabHeaderControls.Controls.Add(this.toolStrip1);
            this.panTabHeaderControls.Location = new System.Drawing.Point(236, -2);
            this.panTabHeaderControls.Name = "panTabHeaderControls";
            this.panTabHeaderControls.Size = new System.Drawing.Size(49, 30);
            this.panTabHeaderControls.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btList,
            this.btClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(47, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btList
            // 
            this.btList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btList.Name = "btList";
            this.btList.Size = new System.Drawing.Size(23, 22);
            this.btList.Text = "List Tab";
            this.btList.Click += new System.EventHandler(this.btList_Click);
            // 
            // btClose
            // 
            this.btClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(23, 22);
            this.btClose.Text = "Close Tab";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panHTabHeader
            // 
            this.panHTabHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panHTabHeader.BackColor = System.Drawing.SystemColors.Control;
            this.panHTabHeader.Location = new System.Drawing.Point(0, 0);
            this.panHTabHeader.Name = "panHTabHeader";
            this.panHTabHeader.Size = new System.Drawing.Size(10, 26);
            this.panHTabHeader.TabIndex = 2;
            // 
            // lsbList
            // 
            this.lsbList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbList.FormattingEnabled = true;
            this.lsbList.ItemHeight = 16;
            this.lsbList.Location = new System.Drawing.Point(58, 27);
            this.lsbList.Name = "lsbList";
            this.lsbList.Size = new System.Drawing.Size(198, 4);
            this.lsbList.TabIndex = 4;
            this.lsbList.Visible = false;
            this.lsbList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsbList_MouseDown);
            // 
            // panMain
            // 
            this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMain.BackColor = System.Drawing.SystemColors.Control;
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMain.Location = new System.Drawing.Point(7, 33);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(269, 120);
            this.panMain.TabIndex = 5;
            // 
            // DynamicTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lsbList);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panTabHeader);
            this.Name = "DynamicTabs";
            this.Size = new System.Drawing.Size(283, 160);
            this.SizeChanged += new System.EventHandler(this.DynamicTabs_SizeChanged);
            this.panTabHeader.ResumeLayout(false);
            this.panTabHeaderControls.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTabHeader;
        private System.Windows.Forms.Panel panHTabHeader;
        private System.Windows.Forms.ListBox lsbList;
        private System.Windows.Forms.Panel panTabHeaderControls;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btList;
        private System.Windows.Forms.ToolStripButton btClose;
        public System.Windows.Forms.Panel panMain;

    }
}
