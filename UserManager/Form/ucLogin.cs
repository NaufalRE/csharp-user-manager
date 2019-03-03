using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UserManager.Class;

namespace UserManager.Form
{
    public partial class ucLogin : XtraUserControl
    {
        DataBridge DataBr = new DataBridge();
        DeviceId DeviDer = new DeviceId();
        //Added Session in QrCode to make easier to contact with administrator
        private static ucLogin _instance;
        public static ucLogin Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucLogin();
                return _instance;
            }
        }

        public ucLogin()
        {
            InitializeComponent();
        }

        public void FormOnLoad()
        {
            TokenFill(false);
            L_ErrorStatus.Text = "";
            B_SeekPassword.Text = "\ue052";
            GC_Login.Enabled = true;
            GC_Login.Visible = true;
        }


        private void TokenFill(Boolean required)
        {
            if (required)
            {
                L_Token.Visible = true;
                T_Token.Visible = true;
                T_Token.Enabled = true;
            }
            else
            {
                L_Token.Visible = false;
                T_Token.Visible = false;
                T_Token.Enabled = false;
            }
        }

        private void SeekPassword()
        {
            if (T_Password.Properties.UseSystemPasswordChar)
            {
                T_Password.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                T_Password.Properties.UseSystemPasswordChar = true;
            }
        }

        private void BeginAuth()
        {
            if(T_Username.Text != "" || T_Password.Text != "")
            {
                String _tempPass = SecureKey.RedMd5(T_Password.Text);
                DataTable _tempuser = DataBr.GetSql("SELECT * FROM t_user WHERE username = '" + T_Username.Text + "' AND password = '" + _tempPass + "'");
                if(_tempuser.Rows.Count > 0)
                {
                    DataTable _logHistory = DataBr.GetSql("SELECT id_session, id_user, device_id, time_sign_in, IFNULL(time_sign_out, 'Sedang Login') FROM t_loguser WHERE id_user = '" + _tempuser.Rows[0][0].ToString() + "' AND time_sign_out IS NULL");
                    if(_logHistory.Rows.Count > 0)
                    {
                        L_ErrorStatus.Text = "Maaf, anda sedang login \ndi PC : " + _logHistory.Rows[0][2].ToString() + "\nSilahkan hubungi Administrator !";
                    }
                    else
                    {
                        GlobalVar.U_ID_USER = _tempuser.Rows[0][0].ToString();
                        GlobalVar.U_NAME_USER = _tempuser.Rows[0][1].ToString();
                        GlobalVar.U_USERNAME = _tempuser.Rows[0][2].ToString();
                        GlobalVar.U_EMAIL_USER = _tempuser.Rows[0][3].ToString();
                        GlobalVar.U_CAPABILITY = _tempuser.Rows[0][5].ToString();
                        GlobalVar.U_SESSION = DataBr.AutomaticSessionCode();
                        Boolean LoggingStatus = DataBr.SetSql("CALL LoginCheck('" + GlobalVar.U_SESSION + "', '" + GlobalVar.U_ID_USER + "', '" + DeviDer.DeviceIdIdentifier() + "', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')");
                        if (LoggingStatus)
                        {
                            T_Username.Text = "";
                            T_Password.Text = "";
                            _tempPass = "";
                            //L_ErrorStatus.Text = "Anda berhasil masuk !";
                            GC_Login.Enabled = false;
                            GC_Login.Visible = false;
                        }
                        else
                        {
                            L_ErrorStatus.Text = "Nii-chan, something went wrong with me !";
                        }
                    }
                }
                else
                {
                    L_ErrorStatus.Text = "Username / Password SALAH";
                }
            }
            else
            {
                L_ErrorStatus.Text = "Please fill empty field";
            }

        }

        private void ucLogin_Load(object sender, EventArgs e)
        {
            FormOnLoad();
        }

        private void B_SeekPassword_Click(object sender, EventArgs e)
        {
            SeekPassword();
        }

        private void B_SignMe_Click(object sender, EventArgs e)
        {
            BeginAuth();
        }

        private void T_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BeginAuth();
            }
        }
    }
}
