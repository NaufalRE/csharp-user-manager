namespace UserManager
{
    partial class ParentForm
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
            this.components = new System.ComponentModel.Container();
            this.ContainChild = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aciLogin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aciUser = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aciLogout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceAbout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.UserClock = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ContainChild
            // 
            this.ContainChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainChild.Location = new System.Drawing.Point(260, 30);
            this.ContainChild.Name = "ContainChild";
            this.ContainChild.Size = new System.Drawing.Size(928, 503);
            this.ContainChild.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceMenu,
            this.aceAbout});
            this.accordionControl1.Location = new System.Drawing.Point(0, 30);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 503);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // aceMenu
            // 
            this.aceMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aciLogin,
            this.aciUser,
            this.aciLogout});
            this.aceMenu.Expanded = true;
            this.aceMenu.Name = "aceMenu";
            this.aceMenu.Text = "Menu";
            // 
            // aciLogin
            // 
            this.aciLogin.Name = "aciLogin";
            this.aciLogin.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aciLogin.Text = "Login";
            this.aciLogin.Click += new System.EventHandler(this.aciLogin_Click);
            // 
            // aciUser
            // 
            this.aciUser.Name = "aciUser";
            this.aciUser.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aciUser.Text = "User";
            this.aciUser.Click += new System.EventHandler(this.aciUser_Click);
            // 
            // aciLogout
            // 
            this.aciLogout.Name = "aciLogout";
            this.aciLogout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aciLogout.Text = "Logout";
            this.aciLogout.Click += new System.EventHandler(this.aciLogout_Click);
            // 
            // aceAbout
            // 
            this.aceAbout.Name = "aceAbout";
            this.aceAbout.Text = "About";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1188, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // UserClock
            // 
            this.UserClock.Tick += new System.EventHandler(this.UserClock_Tick);
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 533);
            this.ControlContainer = this.ContainChild;
            this.Controls.Add(this.ContainChild);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "ParentForm";
            this.NavigationControl = this.accordionControl1;
            this.Text = "ParentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParentForm_FormClosing);
            this.Load += new System.EventHandler(this.ParentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer ContainChild;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceMenu;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceAbout;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aciLogin;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aciUser;
        private System.Windows.Forms.Timer UserClock;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aciLogout;
    }
}