namespace UserManager.Form
{
    partial class ucLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.GC_Login = new DevExpress.XtraEditors.GroupControl();
            this.B_SeekPassword = new DevExpress.XtraEditors.SimpleButton();
            this.L_ErrorStatus = new DevExpress.XtraEditors.LabelControl();
            this.B_SignMe = new DevExpress.XtraEditors.SimpleButton();
            this.L_Token = new DevExpress.XtraEditors.LabelControl();
            this.T_Token = new DevExpress.XtraEditors.TextEdit();
            this.L_Password = new DevExpress.XtraEditors.LabelControl();
            this.L_Username = new DevExpress.XtraEditors.LabelControl();
            this.T_Password = new DevExpress.XtraEditors.TextEdit();
            this.T_Username = new DevExpress.XtraEditors.TextEdit();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GC_Login)).BeginInit();
            this.GC_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T_Token.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_Username.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.GC_Login);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(745, 477);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // GC_Login
            // 
            this.GC_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GC_Login.Controls.Add(this.B_SeekPassword);
            this.GC_Login.Controls.Add(this.L_ErrorStatus);
            this.GC_Login.Controls.Add(this.B_SignMe);
            this.GC_Login.Controls.Add(this.L_Token);
            this.GC_Login.Controls.Add(this.T_Token);
            this.GC_Login.Controls.Add(this.L_Password);
            this.GC_Login.Controls.Add(this.L_Username);
            this.GC_Login.Controls.Add(this.T_Password);
            this.GC_Login.Controls.Add(this.T_Username);
            this.GC_Login.Location = new System.Drawing.Point(168, 91);
            this.GC_Login.Name = "GC_Login";
            this.GC_Login.Size = new System.Drawing.Size(403, 319);
            this.GC_Login.TabIndex = 0;
            this.GC_Login.Text = "Login";
            // 
            // B_SeekPassword
            // 
            this.B_SeekPassword.Appearance.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_SeekPassword.Appearance.Options.UseFont = true;
            this.B_SeekPassword.Location = new System.Drawing.Point(339, 183);
            this.B_SeekPassword.Name = "B_SeekPassword";
            this.B_SeekPassword.Size = new System.Drawing.Size(33, 23);
            this.B_SeekPassword.TabIndex = 7;
            this.B_SeekPassword.Text = "%";
            this.B_SeekPassword.Click += new System.EventHandler(this.B_SeekPassword_Click);
            // 
            // L_ErrorStatus
            // 
            this.L_ErrorStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.L_ErrorStatus.Appearance.Options.UseForeColor = true;
            this.L_ErrorStatus.Location = new System.Drawing.Point(20, 272);
            this.L_ErrorStatus.Name = "L_ErrorStatus";
            this.L_ErrorStatus.Size = new System.Drawing.Size(98, 13);
            this.L_ErrorStatus.TabIndex = 9;
            this.L_ErrorStatus.Text = "%errorexperience%";
            // 
            // B_SignMe
            // 
            this.B_SignMe.Location = new System.Drawing.Point(263, 272);
            this.B_SignMe.Name = "B_SignMe";
            this.B_SignMe.Size = new System.Drawing.Size(70, 23);
            this.B_SignMe.TabIndex = 8;
            this.B_SignMe.Text = "Sign In";
            this.B_SignMe.Click += new System.EventHandler(this.B_SignMe_Click);
            // 
            // L_Token
            // 
            this.L_Token.Location = new System.Drawing.Point(58, 229);
            this.L_Token.Name = "L_Token";
            this.L_Token.Size = new System.Drawing.Size(31, 13);
            this.L_Token.TabIndex = 5;
            this.L_Token.Text = "Token";
            // 
            // T_Token
            // 
            this.T_Token.Location = new System.Drawing.Point(151, 226);
            this.T_Token.Name = "T_Token";
            this.T_Token.Size = new System.Drawing.Size(182, 20);
            this.T_Token.TabIndex = 6;
            // 
            // L_Password
            // 
            this.L_Password.Location = new System.Drawing.Point(58, 188);
            this.L_Password.Name = "L_Password";
            this.L_Password.Size = new System.Drawing.Size(49, 13);
            this.L_Password.TabIndex = 3;
            this.L_Password.Text = "Password";
            // 
            // L_Username
            // 
            this.L_Username.Location = new System.Drawing.Point(58, 146);
            this.L_Username.Name = "L_Username";
            this.L_Username.Size = new System.Drawing.Size(51, 13);
            this.L_Username.TabIndex = 1;
            this.L_Username.Text = "Username";
            // 
            // T_Password
            // 
            this.T_Password.Location = new System.Drawing.Point(151, 185);
            this.T_Password.Name = "T_Password";
            this.T_Password.Properties.UseSystemPasswordChar = true;
            this.T_Password.Size = new System.Drawing.Size(182, 20);
            this.T_Password.TabIndex = 4;
            this.T_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.T_Password_KeyPress);
            // 
            // T_Username
            // 
            this.T_Username.Location = new System.Drawing.Point(151, 143);
            this.T_Username.Name = "T_Username";
            this.T_Username.Size = new System.Drawing.Size(182, 20);
            this.T_Username.TabIndex = 2;
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(745, 477);
            this.Load += new System.EventHandler(this.ucLogin_Load);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GC_Login)).EndInit();
            this.GC_Login.ResumeLayout(false);
            this.GC_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T_Token.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_Username.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.GroupControl GC_Login;
        private DevExpress.XtraEditors.LabelControl L_Password;
        private DevExpress.XtraEditors.LabelControl L_Username;
        private DevExpress.XtraEditors.TextEdit T_Password;
        private DevExpress.XtraEditors.TextEdit T_Username;
        private DevExpress.XtraEditors.LabelControl L_Token;
        private DevExpress.XtraEditors.TextEdit T_Token;
        private DevExpress.XtraEditors.SimpleButton B_SignMe;
        private DevExpress.XtraEditors.LabelControl L_ErrorStatus;
        private DevExpress.XtraEditors.SimpleButton B_SeekPassword;
    }
}
