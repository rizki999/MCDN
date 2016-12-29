namespace MySqlClientDotNET.DesignControls.StartingPage {
    partial class FormNewConnection {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewConnection));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkAskPass = new System.Windows.Forms.CheckBox();
            this.labelHavePassYesNo = new System.Windows.Forms.Label();
            this.labelHavePassword = new System.Windows.Forms.Label();
            this.buttonClearPass = new System.Windows.Forms.Button();
            this.buttonSetPass = new System.Windows.Forms.Button();
            this.buttonTestConn = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textDefaultDB = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.labelConnectionName = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelHostName = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textConnName = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelDefaultDB = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.checkAskPass);
            this.groupBox.Controls.Add(this.labelHavePassYesNo);
            this.groupBox.Controls.Add(this.labelHavePassword);
            this.groupBox.Controls.Add(this.buttonClearPass);
            this.groupBox.Controls.Add(this.buttonSetPass);
            this.groupBox.Controls.Add(this.buttonTestConn);
            this.groupBox.Controls.Add(this.buttonSave);
            this.groupBox.Controls.Add(this.textDefaultDB);
            this.groupBox.Controls.Add(this.textPass);
            this.groupBox.Controls.Add(this.labelConnectionName);
            this.groupBox.Controls.Add(this.textUsername);
            this.groupBox.Controls.Add(this.labelHostName);
            this.groupBox.Controls.Add(this.textPort);
            this.groupBox.Controls.Add(this.labelPort);
            this.groupBox.Controls.Add(this.textHost);
            this.groupBox.Controls.Add(this.labelUsername);
            this.groupBox.Controls.Add(this.textConnName);
            this.groupBox.Controls.Add(this.labelPass);
            this.groupBox.Controls.Add(this.labelDefaultDB);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(552, 225);
            this.groupBox.TabIndex = 11;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "New Connection Form";
            // 
            // checkAskPass
            // 
            this.checkAskPass.AutoSize = true;
            this.checkAskPass.Location = new System.Drawing.Point(268, 90);
            this.checkAskPass.Name = "checkAskPass";
            this.checkAskPass.Size = new System.Drawing.Size(192, 17);
            this.checkAskPass.TabIndex = 19;
            this.checkAskPass.Text = "Ask For The Password Every Login";
            this.checkAskPass.UseVisualStyleBackColor = true;
            this.checkAskPass.Visible = false;
            this.checkAskPass.CheckedChanged += new System.EventHandler(this.checkAskPass_CheckedChanged);
            // 
            // labelHavePassYesNo
            // 
            this.labelHavePassYesNo.AutoSize = true;
            this.labelHavePassYesNo.Location = new System.Drawing.Point(365, 115);
            this.labelHavePassYesNo.Name = "labelHavePassYesNo";
            this.labelHavePassYesNo.Size = new System.Drawing.Size(21, 13);
            this.labelHavePassYesNo.TabIndex = 18;
            this.labelHavePassYesNo.Text = "No";
            // 
            // labelHavePassword
            // 
            this.labelHavePassword.AutoSize = true;
            this.labelHavePassword.Location = new System.Drawing.Point(265, 114);
            this.labelHavePassword.Name = "labelHavePassword";
            this.labelHavePassword.Size = new System.Drawing.Size(84, 13);
            this.labelHavePassword.TabIndex = 17;
            this.labelHavePassword.Text = "Set Password  : ";
            // 
            // buttonClearPass
            // 
            this.buttonClearPass.Location = new System.Drawing.Point(186, 109);
            this.buttonClearPass.Name = "buttonClearPass";
            this.buttonClearPass.Size = new System.Drawing.Size(75, 23);
            this.buttonClearPass.TabIndex = 11;
            this.buttonClearPass.Text = "Clear Password";
            this.buttonClearPass.UseVisualStyleBackColor = true;
            this.buttonClearPass.Click += new System.EventHandler(this.buttonClearPass_Click);
            // 
            // buttonSetPass
            // 
            this.buttonSetPass.Location = new System.Drawing.Point(87, 109);
            this.buttonSetPass.Name = "buttonSetPass";
            this.buttonSetPass.Size = new System.Drawing.Size(93, 23);
            this.buttonSetPass.TabIndex = 10;
            this.buttonSetPass.Text = "Set Password";
            this.buttonSetPass.UseVisualStyleBackColor = true;
            this.buttonSetPass.Click += new System.EventHandler(this.buttonSetPass_Click);
            // 
            // buttonTestConn
            // 
            this.buttonTestConn.Location = new System.Drawing.Point(359, 196);
            this.buttonTestConn.Name = "buttonTestConn";
            this.buttonTestConn.Size = new System.Drawing.Size(106, 23);
            this.buttonTestConn.TabIndex = 13;
            this.buttonTestConn.Text = "Test Connection";
            this.buttonTestConn.UseVisualStyleBackColor = true;
            this.buttonTestConn.Click += new System.EventHandler(this.buttonTestConn_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(471, 196);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textDefaultDB
            // 
            this.textDefaultDB.Location = new System.Drawing.Point(119, 138);
            this.textDefaultDB.Name = "textDefaultDB";
            this.textDefaultDB.Size = new System.Drawing.Size(272, 20);
            this.textDefaultDB.TabIndex = 12;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(87, 112);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(172, 20);
            this.textPass.TabIndex = 15;
            this.textPass.Visible = false;
            this.textPass.TextChanged += new System.EventHandler(this.textPass_TextChanged);
            // 
            // labelConnectionName
            // 
            this.labelConnectionName.AutoSize = true;
            this.labelConnectionName.Location = new System.Drawing.Point(21, 27);
            this.labelConnectionName.Name = "labelConnectionName";
            this.labelConnectionName.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionName.TabIndex = 0;
            this.labelConnectionName.Text = "Connection Name";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(87, 86);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(172, 20);
            this.textUsername.TabIndex = 9;
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Location = new System.Drawing.Point(21, 60);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(60, 13);
            this.labelHostName.TabIndex = 1;
            this.labelHostName.Text = "Host Name";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(297, 60);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(85, 20);
            this.textPort.TabIndex = 8;
            this.textPort.TextChanged += new System.EventHandler(this.textPort_TextChanged);
            this.textPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPort_KeyPress);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(265, 63);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port";
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(87, 60);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(172, 20);
            this.textHost.TabIndex = 7;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(21, 91);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username";
            // 
            // textConnName
            // 
            this.textConnName.Location = new System.Drawing.Point(119, 24);
            this.textConnName.Name = "textConnName";
            this.textConnName.Size = new System.Drawing.Size(272, 20);
            this.textConnName.TabIndex = 6;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(21, 115);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(53, 13);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "Password";
            // 
            // labelDefaultDB
            // 
            this.labelDefaultDB.AutoSize = true;
            this.labelDefaultDB.Location = new System.Drawing.Point(21, 141);
            this.labelDefaultDB.Name = "labelDefaultDB";
            this.labelDefaultDB.Size = new System.Drawing.Size(90, 13);
            this.labelDefaultDB.TabIndex = 5;
            this.labelDefaultDB.Text = "Default Database";
            // 
            // FormNewConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 250);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Connection";
            this.Load += new System.EventHandler(this.FormNewConnection_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textDefaultDB;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label labelConnectionName;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textConnName;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelDefaultDB;
        private System.Windows.Forms.Button buttonTestConn;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClearPass;
        private System.Windows.Forms.Button buttonSetPass;
        private System.Windows.Forms.Label labelHavePassYesNo;
        private System.Windows.Forms.Label labelHavePassword;
        private System.Windows.Forms.CheckBox checkAskPass;
    }
}

