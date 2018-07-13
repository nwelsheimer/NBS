namespace Open_Miracle
{
    partial class frmMsSqlInstallerforOpenmiracle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMsSqlInstallerforOpenmiracle));
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButton3 = new System.Windows.Forms.RadioButton();
      this.radioButton4 = new System.Windows.Forms.RadioButton();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.rbtnNetworkServers = new System.Windows.Forms.RadioButton();
      this.rbtnLocalServer = new System.Windows.Forms.RadioButton();
      this.button2 = new System.Windows.Forms.Button();
      this.cmbDatabase = new System.Windows.Forms.ComboBox();
      this.linkLabel4 = new System.Windows.Forms.LinkLabel();
      this.label13 = new System.Windows.Forms.Label();
      this.cmbServers1 = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.btnOkServer = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(6, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(360, 22);
      this.label1.TabIndex = 4;
      this.label1.Text = "NMS Database Configuration.";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Gainsboro;
      this.panel2.Controls.Add(this.groupBox1);
      this.panel2.Controls.Add(this.rbtnNetworkServers);
      this.panel2.Controls.Add(this.rbtnLocalServer);
      this.panel2.Controls.Add(this.button2);
      this.panel2.Controls.Add(this.cmbDatabase);
      this.panel2.Controls.Add(this.linkLabel4);
      this.panel2.Controls.Add(this.label13);
      this.panel2.Controls.Add(this.cmbServers1);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.btnOkServer);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Location = new System.Drawing.Point(3, 39);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(363, 440);
      this.panel2.TabIndex = 7;
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.radioButton3);
      this.groupBox1.Controls.Add(this.radioButton4);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.label10);
      this.groupBox1.Controls.Add(this.label11);
      this.groupBox1.Controls.Add(this.textBox2);
      this.groupBox1.Location = new System.Drawing.Point(9, 113);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(345, 162);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // radioButton3
      // 
      this.radioButton3.AutoSize = true;
      this.radioButton3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radioButton3.Location = new System.Drawing.Point(21, 37);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new System.Drawing.Size(195, 19);
      this.radioButton3.TabIndex = 56;
      this.radioButton3.Text = "Use SQL Server Authentication.";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
      // 
      // radioButton4
      // 
      this.radioButton4.AutoSize = true;
      this.radioButton4.Checked = true;
      this.radioButton4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radioButton4.Location = new System.Drawing.Point(21, 16);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new System.Drawing.Size(184, 19);
      this.radioButton4.TabIndex = 55;
      this.radioButton4.TabStop = true;
      this.radioButton4.Text = "Use Windows Authentication.";
      this.radioButton4.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Enabled = false;
      this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(19, 78);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(307, 21);
      this.textBox1.TabIndex = 53;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Enabled = false;
      this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(18, 63);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(53, 15);
      this.label10.TabIndex = 51;
      this.label10.Text = "User Id :";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Enabled = false;
      this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(17, 106);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(69, 15);
      this.label11.TabIndex = 52;
      this.label11.Text = "Password :";
      // 
      // textBox2
      // 
      this.textBox2.Enabled = false;
      this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox2.Location = new System.Drawing.Point(19, 121);
      this.textBox2.Name = "textBox2";
      this.textBox2.PasswordChar = '*';
      this.textBox2.Size = new System.Drawing.Size(308, 21);
      this.textBox2.TabIndex = 54;
      // 
      // rbtnNetworkServers
      // 
      this.rbtnNetworkServers.AutoSize = true;
      this.rbtnNetworkServers.Checked = true;
      this.rbtnNetworkServers.Location = new System.Drawing.Point(238, 39);
      this.rbtnNetworkServers.Name = "rbtnNetworkServers";
      this.rbtnNetworkServers.Size = new System.Drawing.Size(104, 17);
      this.rbtnNetworkServers.TabIndex = 65;
      this.rbtnNetworkServers.TabStop = true;
      this.rbtnNetworkServers.Text = "Network Servers";
      this.rbtnNetworkServers.UseVisualStyleBackColor = true;
      // 
      // rbtnLocalServer
      // 
      this.rbtnLocalServer.AutoSize = true;
      this.rbtnLocalServer.Location = new System.Drawing.Point(146, 39);
      this.rbtnLocalServer.Name = "rbtnLocalServer";
      this.rbtnLocalServer.Size = new System.Drawing.Size(90, 17);
      this.rbtnLocalServer.TabIndex = 64;
      this.rbtnLocalServer.Text = "Local Servers";
      this.rbtnLocalServer.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(147, 388);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(68, 30);
      this.button2.TabIndex = 63;
      this.button2.Text = "Ok";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // cmbDatabase
      // 
      this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbDatabase.FormattingEnabled = true;
      this.cmbDatabase.Location = new System.Drawing.Point(28, 338);
      this.cmbDatabase.Name = "cmbDatabase";
      this.cmbDatabase.Size = new System.Drawing.Size(308, 23);
      this.cmbDatabase.TabIndex = 62;
      // 
      // linkLabel4
      // 
      this.linkLabel4.AutoSize = true;
      this.linkLabel4.LinkColor = System.Drawing.Color.Maroon;
      this.linkLabel4.Location = new System.Drawing.Point(294, 64);
      this.linkLabel4.Name = "linkLabel4";
      this.linkLabel4.Size = new System.Drawing.Size(44, 13);
      this.linkLabel4.TabIndex = 60;
      this.linkLabel4.TabStop = true;
      this.linkLabel4.Text = "Refresh";
      this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked_1);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(27, 319);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(67, 15);
      this.label13.TabIndex = 56;
      this.label13.Text = "Database :";
      // 
      // cmbServers1
      // 
      this.cmbServers1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbServers1.FormattingEnabled = true;
      this.cmbServers1.Location = new System.Drawing.Point(28, 84);
      this.cmbServers1.Name = "cmbServers1";
      this.cmbServers1.Size = new System.Drawing.Size(308, 23);
      this.cmbServers1.TabIndex = 53;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(27, 64);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(85, 15);
      this.label9.TabIndex = 52;
      this.label9.Text = "System Name";
      // 
      // btnOkServer
      // 
      this.btnOkServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOkServer.ForeColor = System.Drawing.Color.Maroon;
      this.btnOkServer.Location = new System.Drawing.Point(148, 278);
      this.btnOkServer.Name = "btnOkServer";
      this.btnOkServer.Size = new System.Drawing.Size(67, 30);
      this.btnOkServer.TabIndex = 47;
      this.btnOkServer.Text = "Connect";
      this.btnOkServer.UseVisualStyleBackColor = true;
      this.btnOkServer.Click += new System.EventHandler(this.btnOkServer_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Maroon;
      this.label2.Location = new System.Drawing.Point(110, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(232, 15);
      this.label2.TabIndex = 0;
      this.label2.Text = "MsSQL Installed Instance configuration.";
      // 
      // frmMsSqlInstallerforOpenmiracle
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gainsboro;
      this.ClientSize = new System.Drawing.Size(369, 491);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmMsSqlInstallerforOpenmiracle";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Database configuration";
      this.Load += new System.EventHandler(this.frmMySqlInstallerforOpenmiracle_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbServers1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOkServer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbtnNetworkServers;
        private System.Windows.Forms.RadioButton rbtnLocalServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
    }
}