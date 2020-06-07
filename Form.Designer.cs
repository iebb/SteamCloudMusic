namespace SteamCloudMusic
{
    partial class Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt2FA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chktaskbar = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkCollapse = new System.Windows.Forms.CheckBox();
            this.chkTray = new System.Windows.Forms.CheckBox();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRepl = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelLoggedIn = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelLoggedIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(78, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(322, 25);
            this.txtUserName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(3, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(284, 67);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 37);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(78, 40);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(322, 25);
            this.txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // txt2FA
            // 
            this.txt2FA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.txt2FA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2FA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt2FA.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txt2FA.ForeColor = System.Drawing.Color.White;
            this.txt2FA.Location = new System.Drawing.Point(78, 67);
            this.txt2FA.MaxLength = 5;
            this.txt2FA.Name = "txt2FA";
            this.txt2FA.Size = new System.Drawing.Size(113, 32);
            this.txt2FA.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "2FA";
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.txt2FA);
            this.panelLogin.Controls.Add(this.txtUserName);
            this.panelLogin.Controls.Add(this.lblName);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLogin.Location = new System.Drawing.Point(11, 9);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(410, 114);
            this.panelLogin.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chktaskbar);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chkCollapse);
            this.panel2.Controls.Add(this.chkTray);
            this.panel2.Controls.Add(this.txtProcess);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPattern);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtRepl);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 128);
            this.panel2.TabIndex = 15;
            // 
            // chktaskbar
            // 
            this.chktaskbar.AutoSize = true;
            this.chktaskbar.Checked = true;
            this.chktaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chktaskbar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chktaskbar.ForeColor = System.Drawing.Color.White;
            this.chktaskbar.Location = new System.Drawing.Point(226, 11);
            this.chktaskbar.Name = "chktaskbar";
            this.chktaskbar.Size = new System.Drawing.Size(72, 21);
            this.chktaskbar.TabIndex = 22;
            this.chktaskbar.Text = "Taskbar";
            this.chktaskbar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Search";
            // 
            // chkCollapse
            // 
            this.chkCollapse.AutoSize = true;
            this.chkCollapse.Checked = true;
            this.chkCollapse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCollapse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCollapse.ForeColor = System.Drawing.Color.White;
            this.chkCollapse.Location = new System.Drawing.Point(135, 11);
            this.chkCollapse.Name = "chkCollapse";
            this.chkCollapse.Size = new System.Drawing.Size(85, 21);
            this.chkCollapse.TabIndex = 20;
            this.chkCollapse.Text = "Collapsed";
            this.chkCollapse.UseVisualStyleBackColor = true;
            // 
            // chkTray
            // 
            this.chkTray.AutoSize = true;
            this.chkTray.Checked = true;
            this.chkTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTray.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTray.ForeColor = System.Drawing.Color.White;
            this.chkTray.Location = new System.Drawing.Point(78, 11);
            this.chkTray.Name = "chkTray";
            this.chkTray.Size = new System.Drawing.Size(51, 21);
            this.chkTray.TabIndex = 19;
            this.chkTray.Text = "Tray";
            this.chkTray.UseVisualStyleBackColor = true;
            // 
            // txtProcess
            // 
            this.txtProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.txtProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcess.ForeColor = System.Drawing.Color.White;
            this.txtProcess.Location = new System.Drawing.Point(78, 36);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(108, 25);
            this.txtProcess.TabIndex = 13;
            this.txtProcess.Text = "cloudmusic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Process";
            // 
            // txtPattern
            // 
            this.txtPattern.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.txtPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPattern.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPattern.ForeColor = System.Drawing.Color.White;
            this.txtPattern.Location = new System.Drawing.Point(78, 65);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(322, 25);
            this.txtPattern.TabIndex = 15;
            this.txtPattern.Text = "^(.*?) - (.*)$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Replace";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Pattern";
            // 
            // txtRepl
            // 
            this.txtRepl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.txtRepl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepl.ForeColor = System.Drawing.Color.White;
            this.txtRepl.Location = new System.Drawing.Point(78, 92);
            this.txtRepl.Name = "txtRepl";
            this.txtRepl.Size = new System.Drawing.Size(322, 25);
            this.txtRepl.TabIndex = 17;
            this.txtRepl.Text = "♫ $1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(434, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatusBar
            // 
            this.labelStatusBar.Name = "labelStatusBar";
            this.labelStatusBar.Size = new System.Drawing.Size(12, 17);
            this.labelStatusBar.Text = "-";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(15, 272);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(138, 17);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Connecting to Steam...";
            // 
            // panelLoggedIn
            // 
            this.panelLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoggedIn.Controls.Add(this.label9);
            this.panelLoggedIn.Controls.Add(this.lblNickname);
            this.panelLoggedIn.Controls.Add(this.btnLogout);
            this.panelLoggedIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLoggedIn.Location = new System.Drawing.Point(11, 9);
            this.panelLoggedIn.Name = "panelLoggedIn";
            this.panelLoggedIn.Size = new System.Drawing.Size(410, 114);
            this.panelLoggedIn.TabIndex = 19;
            this.panelLoggedIn.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Logged in as";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNickname.ForeColor = System.Drawing.Color.White;
            this.lblNickname.Location = new System.Drawing.Point(93, 15);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(0, 19);
            this.lblNickname.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(284, 67);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(116, 37);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(434, 329);
            this.Controls.Add(this.panelLoggedIn);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.Opacity = 0.97D;
            this.Text = "SteamCloudMusic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelLoggedIn.ResumeLayout(false);
            this.panelLoggedIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt2FA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRepl;
        private System.Windows.Forms.CheckBox chktaskbar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkCollapse;
        private System.Windows.Forms.CheckBox chkTray;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatusBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panelLoggedIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Button btnLogout;
    }
}

