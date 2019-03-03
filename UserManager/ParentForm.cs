using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserManager.Form;
using UserManager.Class;
using DevExpress.XtraEditors;

namespace UserManager
{
    public partial class ParentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        DataBridge DataBr = new DataBridge();
        public ParentForm()
        {
            InitializeComponent();
        }

        private void FormOnLoad()
        {
            aceMenu.Expanded = false;
        }

        private void UserClockLoad()
        {
            UserClock.Interval = 100;
            UserClock.Start();
        }

        private void GlobalvarUserClear()
        {
            GlobalVar.U_USERNAME = "";
            GlobalVar.U_EMAIL_USER = "";
            GlobalVar.U_CAPABILITY = "";
        }

        private void CheckIfUserLogged()
        {
            if(GlobalVar.U_ID_USER == "")
            {
                aciUser.Visible = false;
                aciUser.Enabled = false;

                aciLogin.Enabled = true;
                aciLogin.Visible = true;

                aciLogout.Enabled = false;
                aciLogout.Visible = false;
                GlobalvarUserClear();
            }
            else
            {
                aciUser.Enabled = true;
                aciUser.Visible = true;

                aciLogin.Enabled = false;
                aciLogin.Visible = false;

                aciLogout.Enabled = true;
                aciLogout.Visible = true;
            }
        }

        private void LogoutFunction()
        {
            Boolean LogoutStatus = DataBr.SetSql("CALL LogoutCheck('" + GlobalVar.U_ID_USER + "', '"+GlobalVar.U_SESSION+"', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')");
            if (LogoutStatus)
            {
                GlobalVar.CleanUP();
                ContainChild.Controls.Clear();
                GlobalVar.U_SESSION = "";
                XtraMessageBox.Show("Anda telah berhasil logout !", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Onii-chan, something went wrong", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenLoginForm()
        {
            ContainChild.Controls.Add(ucLogin.Instance);
            ucLogin.Instance.Dock = DockStyle.Fill;
            ucLogin.Instance.BringToFront();
        }

        private void OpenUserForm()
        {
            ContainChild.Controls.Add(ucUser.Instance);
            ucUser.Instance.Dock = DockStyle.Fill;
            ucUser.Instance.BringToFront();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            FormOnLoad();
            UserClockLoad();
            GlobalVar.CleanUP();
            //FlyoutMessageBox.Show("You need to activate Windows in Settings", "You Windows license will expire soon", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1 );
        }

        private void aciLogin_Click(object sender, EventArgs e)
        {
            if (!ContainChild.Controls.Contains(ucLogin.Instance))
            {
                OpenLoginForm();
            }
            ucLogin.Instance.BringToFront();
            ucLogin.Instance.FormOnLoad();
        }

        private void aciUser_Click(object sender, EventArgs e)
        {
            if (!ContainChild.Controls.Contains(ucUser.Instance))
            {
                OpenUserForm();
            }
            ucUser.Instance.BringToFront();
            ucUser.Instance.FormOnLoad();
        }

        private void UserClock_Tick(object sender, EventArgs e)
        {
            CheckIfUserLogged();
        }

        private void aciLogout_Click(object sender, EventArgs e)
        {
            LogoutFunction();
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogoutFunction();
        }
    }
}
