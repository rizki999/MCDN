using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET.DesignControls {
    public class StartPage : DynamicTabNS.DynamicTabPage {
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.listConnection = new System.Windows.Forms.ListBox();
            this.iconApplication = new System.Windows.Forms.PictureBox();
            this.iconConn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.logoMySqlDotNet = new System.Windows.Forms.PictureBox();
            this.buttonNewConn = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconConn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            //this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            /*System.Windows.Forms.Splitter spup = new System.Windows.Forms.Splitter();
            spup.Size = new System.Drawing.Size(3, 10);
            spup.Dock = System.Windows.Forms.DockStyle.Top;
            spup.BackColor = System.Drawing.SystemColors.ControlLight;

            splitter1 = new System.Windows.Forms.Splitter();
            splitter1.Size = new System.Drawing.Size(3, 10);
            splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            splitter1.BackColor = System.Drawing.SystemColors.ControlLight;*/

            //this.panel2.Controls.Add(spup);
            //this.panel2.Controls.Add(splitter1);
            this.panel2.Controls.Add(this.buttonNewConn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.iconConn);
            this.panel2.Controls.Add(this.listConnection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 235);
            this.panel2.TabIndex = 1;
            // 
            // listConnection
            // 
            this.listConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listConnection.BackColor = panel2.BackColor;
            this.listConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listConnection.FormattingEnabled = true;
            this.listConnection.ItemHeight = 24;
            this.listConnection.Location = new System.Drawing.Point(0, 121);
            this.listConnection.Name = "listConnection";
            this.listConnection.Size = new System.Drawing.Size(241, 96);
            this.listConnection.TabIndex = 0;
            this.listConnection.Items.Add("Hello");
            this.listConnection.Items.Add("Hello");
            this.listConnection.Items.Add("Hello");
            // 
            // iconApplication
            // 
            this.iconApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.iconApplication.ErrorImage = null;
            this.iconApplication.InitialImage = null;
            this.iconApplication.Location = new System.Drawing.Point(247, 82);
            this.iconApplication.Name = "iconApplication";
            this.iconApplication.Size = new System.Drawing.Size(204, 228);
            this.iconApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconApplication.TabIndex = 2;
            this.iconApplication.TabStop = false;
            this.iconApplication.ImageLocation = ResourcesPath.img_mysql_L;
            // 
            // iconConn
            // 
            this.iconConn.Location = new System.Drawing.Point(3, 3);
            this.iconConn.Name = "iconConn";
            this.iconConn.Size = new System.Drawing.Size(100, 80);
            this.iconConn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconConn.TabIndex = 1;
            this.iconConn.TabStop = false;
            this.iconConn.ImageLocation = ResourcesPath.img_conn_L;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "List Connection :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logoMySqlDotNet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 78);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "MySql Client .NET";
            // 
            // buttonNewConn
            // 
            this.buttonNewConn.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.buttonNewConn.AutoSize = true;
            this.buttonNewConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewConn.LinkColor = System.Drawing.Color.Black;
            this.buttonNewConn.Location = new System.Drawing.Point(109, 21);
            this.buttonNewConn.Name = "buttonNewConn";
            this.buttonNewConn.Size = new System.Drawing.Size(131, 50);
            this.buttonNewConn.TabIndex = 4;
            this.buttonNewConn.TabStop = true;
            this.buttonNewConn.Text = "New\r\nConnection";
            this.buttonNewConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.logoMySqlDotNet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logoMySqlDotNet.ErrorImage = null;
            this.logoMySqlDotNet.InitialImage = null;
            this.logoMySqlDotNet.Location = new System.Drawing.Point(99, 3);
            this.logoMySqlDotNet.Name = "logoMySqlDotNet";
            this.logoMySqlDotNet.Size = new System.Drawing.Size(257, 69);
            this.logoMySqlDotNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoMySqlDotNet.TabIndex = 5;
            this.logoMySqlDotNet.TabStop = false;
            this.logoMySqlDotNet.ImageLocation = ResourcesPath.img_logo;
            // 
            // StartPage
            // 
            this.Controls.Add(this.iconApplication);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StartPage";
            this.Size = new System.Drawing.Size(454, 313);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconConn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listConnection;
        private System.Windows.Forms.PictureBox iconApplication;
        private System.Windows.Forms.PictureBox iconConn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logoMySqlDotNet;
        private System.Windows.Forms.LinkLabel buttonNewConn;

        public StartPage() {
            InitializeComponent();
        }
    }
}
