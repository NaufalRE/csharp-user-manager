using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UserManager.Class;
using InTheHand.Net.Sockets;

namespace UserManager.Form
{
    public partial class ucUser : XtraUserControl
    {
        DataBridge DataBr = new DataBridge();
        String Id_user;
        String nama_user;
        //じゃこれはレッドニメのスクリプト
        private static ucUser _instance;
        public static ucUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucUser();
                return _instance;
            }
        }

        private String Method;


        public ucUser()
        {
            InitializeComponent();
        }

        private void T_NamaErrorField()
        {
            T_Nama.BackColor = Color.Red;
        }

        private void T_NamaResetField()
        {
            T_Nama.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void T_UsernameErrorField()
        {
            T_Username.BackColor = Color.Red;
        }

        private void T_UsernameResetField()
        {
            T_Username.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void T_EmailErrorField()
        {
            T_Email.BackColor = Color.Red;
        }

        private void T_EmailResetField()
        {
            T_Email.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void T_CurrPassErrorField()
        {
            T_CurrPass.BackColor = Color.Red;
        }

        private void T_CurrPassResetField()
        {
            T_CurrPass.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void T_NewPassErrorField()
        {
            T_NewPass.BackColor = Color.Red;
        }

        private void T_NewPassResetField()
        {
            T_NewPass.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void T_ConfPassErrorField()
        {
            T_ConfPass.BackColor = Color.Red;
        }

        private void T_ConfPassResetField()
        {
            T_ConfPass.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void CB_CapabilityErrorField()
        {
            CB_Capability.BackColor = Color.Red;
        }

        private void CB_CapabilityResetField()
        {
            CB_Capability.BackColor = Color.FromArgb(48, 48, 48);
            CB_Capability.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void CleanUP()
        {
            L_ID_User.Text = "";
            T_SearchField.Text = "";

            L_Status.Text = "";
            T_Nama.Text = "";
            T_Username.Text = "";
            T_Email.Text = "";
            T_CurrPass.Text = "";
            T_NewPass.Text = "";
            T_ConfPass.Text = "";
            CB_Capability.Text = "";
            PB_ComplexPass.Position = 0;
        }

        private void DisableInput()
        {
            T_Nama.Enabled = false;
            T_Username.Enabled = false;
            T_Email.Enabled = false;
            T_CurrPass.Enabled = false;
            T_NewPass.Enabled = false;
            T_ConfPass.Enabled = false;
            CB_Capability.Enabled = false;

            B_SeekPassword1.Enabled = false;
            B_SeekPassword2.Enabled = false;
            B_SeekPassword3.Enabled = false;

            CE_ComplexPass.Enabled = false;

            B_Simpan.Enabled = false;
            B_Cancel.Enabled = false;

            CE_ComplexPass.Checked = false;
        }

        private void EnableInput(string Exception)
        {
            if(Exception == "InsertMode")
            {
                T_Nama.Enabled = true;
                T_Username.Enabled = true;
                T_Email.Enabled = true;
                T_CurrPass.Enabled = false;
                T_NewPass.Enabled = true;
                T_ConfPass.Enabled = true;

                B_SeekPassword1.Enabled = true;
                B_SeekPassword2.Enabled = true;
                B_SeekPassword3.Enabled = true;
                CE_ComplexPass.Enabled = true;
                if(GlobalVar.U_CAPABILITY == "Admin")
                {
                    CB_Capability.Enabled = true;
                }
                else
                {
                    CB_Capability.Enabled = false;
                }


                B_Simpan.Enabled = true;
                B_Cancel.Enabled = true;
            }
            else if(Exception == "Default")
            {
                T_Nama.Enabled = true;
                T_Username.Enabled = true;
                T_Email.Enabled = true;
                T_CurrPass.Enabled = true;
                T_NewPass.Enabled = true;
                T_ConfPass.Enabled = true;
                if (GlobalVar.U_CAPABILITY == "Admin")
                {
                    CB_Capability.Enabled = true;
                }
                else
                {
                    CB_Capability.Enabled = false;
                }

                B_Simpan.Enabled = true;
                B_Cancel.Enabled = true;
            }
            
        }

        public void FormOnLoad()
        {
            B_SeekPassword1.Text = "\ue052";
            B_SeekPassword2.Text = "\ue052";
            B_SeekPassword3.Text = "\ue052";
            PB_ComplexPass.Position = 0;
            PB_ComplexPass.Visible = false;
            if (GlobalVar.U_CAPABILITY == "Admin")
            {
                ShowData("All", "Admin", "");
                B_Insert.Enabled = true;
                B_Remove.Enabled = true;
            }
            else
            {
                ShowData("All", "Operator", "");
                B_Insert.Enabled = false;
                B_Remove.Enabled = false;
            }
            CleanUP();
            DisableInput();

            DataTable AdvanceLoginChecker = DataBr.GetSql("SELECT b_special_key FROM t_user WHERE id_user = '" + GlobalVar.U_ID_USER + "'");
            if(AdvanceLoginChecker.Rows[0][0].ToString() == "")
            {
                GC_BluetoothDevices.Visible = true;
                B_RegisterDevice.Enabled = true;
                B_UnregisterDevice.Enabled = false;
                B_RefreshDevice.Enabled = true;
            }
            else
            {
                GC_BluetoothDevices.Visible = false;
                B_RegisterDevice.Enabled = false;
                B_UnregisterDevice.Enabled = true;
                B_RefreshDevice.Enabled = false;
            }
        }


        private void SelectedItem()
        {
            Id_user = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "ID User").ToString();
            nama_user = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "Nama").ToString();

            L_ID_User.Text = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "ID User").ToString();
            T_Nama.Text = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "Nama").ToString();
            T_Username.Text = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "Username").ToString();
            T_Email.Text = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "Email").ToString();
            CB_Capability.Text = GV_Data.GetRowCellValue(GV_Data.GetSelectedRows()[0], "Hak Akses").ToString();
        }

        private void ShowData(string option, string capability , string parameter)
        {
            DataTable ShowIdValid = new DataTable();
            DataTable ShowNama = new DataTable();
            DataTable ShowUsername = new DataTable();
            DataTable ShowEmail = new DataTable();
            if (option == "All")
            {
                if(capability == "Admin")
                {
                    DGC_User.DataSource = DataBr.GetSql("SELECT id_user as 'ID User', nama as 'Nama', username as 'Username', email as 'Email', hak_akses as 'Hak Akses', IFNULL(date_modified, 'Belum ada perubahan') as 'Date Modified', date_created as 'Date Created' FROM t_user");
                }
                else
                {
                    DGC_User.DataSource = DataBr.GetSql("SELECT id_user as 'ID User', nama as 'Nama', username as 'Username', email as 'Email', hak_akses as 'Hak Akses', IFNULL(date_modified, 'Belum ada perubahan') as 'Date Modified', date_created as 'Date Created' FROM t_user WHERE id_user = '"+GlobalVar.U_ID_USER+"'");
                }
                
            }
            else if(option == "Specific")
            {
                if(capability == "Admin")
                {
                    ShowIdValid = DataBr.GetSql("SELECT id_user as 'ID User', nama as 'Nama', username as 'Username', email as 'Email', hak_akses as 'Hak Akses', IFNULL(date_modified, 'Belum ada perubahan') as 'Date Modified', date_created as 'Date Created' FROM t_user WHERE id_user LIKE '%" + parameter + "%'");
                    ShowNama = DataBr.GetSql("SELECT id_user as 'ID User', nama as 'Nama', username as 'Username', email as 'Email', hak_akses as 'Hak Akses', IFNULL(date_modified, 'Belum ada perubahan') as 'Date Modified', date_created as 'Date Created' FROM t_user WHERE nama LIKE '%" + parameter + "%'");
                    ShowUsername = DataBr.GetSql("SELECT id_user as 'ID User', nama as 'Nama', username as 'Username', email as 'Email', hak_akses as 'Hak Akses', IFNULL(date_modified, 'Belum ada perubahan') as 'Date Modified', date_created as 'Date Created' FROM t_user WHERE username LIKE '%" + parameter + "%'");
                    ShowEmail = DataBr.GetSql("SELECT id_user as 'ID User', nama as 'Nama', username as 'Username', email as 'Email', hak_akses as 'Hak Akses', IFNULL(date_modified, 'Belum ada perubahan') as 'Date Modified', date_created as 'Date Created' FROM t_user WHERE email LIKE '%" + parameter + "%'");
                    if (ShowIdValid.Rows.Count > 0)
                    {
                        DGC_User.DataSource = ShowIdValid;
                    }
                    else if (ShowNama.Rows.Count > 0)
                    {
                        DGC_User.DataSource = ShowNama;
                    }
                    else if (ShowUsername.Rows.Count > 0)
                    {
                        DGC_User.DataSource = ShowUsername;
                    }
                    else if (ShowEmail.Rows.Count > 0)
                    {
                        DGC_User.DataSource = ShowEmail;
                    }
                    else
                    {
                        XtraMessageBox.Show("Sorry, We could't find the data", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Fail to get something !");
                }
                
            }
            GC_UserTrackHistory.DataSource = DataBr.GetSql("SELECT id_session as 'ID Session', id_user as 'ID User', device_id as 'Device ID', time_sign_in as'Time Sign In', IFNULL(time_sign_out, 'Sedang Login') as 'Time Sign Out' FROM t_loguser WHERE id_user = '"+GlobalVar.U_ID_USER+"'");
        }

        private void SaveChange()
        {
            Boolean StatusInsert = false;
            Boolean StatusUpdate = false;
            if (Method == "Insert")
            {
                if(T_Nama.Text.Trim() == "" || T_Username.Text.Trim() == "" || T_Email.Text.Trim() == "" || T_NewPass.Text.Trim() == "" || T_ConfPass.Text.Trim() == "" || CB_Capability.Text.Trim() == "")
                {
                    L_Status.Text = "There is empty field !";
                    if (T_Nama.Text.Trim() == "")
                    {
                        T_NamaErrorField();

                    }
                    if (T_Username.Text.Trim() == "")
                    {
                        T_UsernameErrorField();

                    }
                    if (T_Email.Text.Trim() == "")
                    {
                        T_EmailErrorField();

                    }
                    if (T_NewPass.Text.Trim() == "")
                    {
                        T_NewPassErrorField();

                    }
                    if (T_ConfPass.Text.Trim() == "")
                    {
                        T_ConfPassErrorField();

                    }
                    if (CB_Capability.Text.Trim() == "")
                    {
                        CB_CapabilityErrorField();
                    }
                    return;
                }
                else
                {
                    if (CE_ComplexPass.Checked)
                    {
                        if (T_NewPass.Text == T_ConfPass.Text)
                        {
                            String _tempPass = SecureKey.RedMd5(T_NewPass.Text);
                            String _tempAutoCode = DataBr.AutomaticUserCode();
                            String _tempDate = DateTime.Now.ToString("yyy-MM-dd hh:mm:ss");
                            StatusInsert = DataBr.SetSql("CALL InsertNewUser('" + _tempAutoCode + "','" + T_Nama.Text + "','" + T_Username.Text + "','" + T_Email.Text + "','" + _tempPass + "','" + CB_Capability.Text + "','" + _tempDate + "')");
                            if (StatusInsert)
                            {
                                L_Status.Text = "Success input data !";
                                CleanUP();
                                _tempPass = "";
                                _tempAutoCode = "";
                                _tempDate = "";
                                if (GlobalVar.U_CAPABILITY == "Admin")
                                {
                                    ShowData("All", "Admin", "");
                                }
                                else
                                {
                                    ShowData("All", "Operator", "");
                                }
                            }
                            else
                            {
                                L_Status.Text = "Something went wrong, contact RedSolution !";
                            }
                        }
                        else
                        {
                            L_Status.Text = "Password arent match ! (>_<)";
                            T_NewPassErrorField();
                            T_ConfPassErrorField();
                        }
                    }
                    else
                    {
                        if (T_NewPass.Text.Length >= 8)
                        {
                            if (T_NewPass.Text.Any(char.IsLetter) && T_NewPass.Text.Any(char.IsNumber))
                            {
                                if (T_NewPass.Text == T_ConfPass.Text)
                                {
                                    String _tempPass = SecureKey.RedMd5(T_NewPass.Text);
                                    String _tempAutoCode = DataBr.AutomaticUserCode();
                                    String _tempDate = DateTime.Now.ToString("yyy-MM-dd");
                                    StatusInsert = DataBr.SetSql("CALL InsertNewUser('" + _tempAutoCode + "','" + T_Nama.Text + "','" + T_Username.Text + "','" + T_Email.Text + "','" + _tempPass + "','" + CB_Capability.Text + "','" + _tempDate + "')");
                                    if (StatusInsert)
                                    {
                                        L_Status.Text = "Success input data !";
                                        CleanUP();
                                        _tempPass = "";
                                        _tempAutoCode = "";
                                        _tempDate = "";
                                        if (GlobalVar.U_CAPABILITY == "Admin")
                                        {
                                            ShowData("All", "Admin", "");
                                        }
                                        else
                                        {
                                            ShowData("All", "Operator", "");
                                        }
                                    }
                                    else
                                    {
                                        L_Status.Text = "Something went wrong, contact RedSolution !";
                                    }
                                }
                                else
                                {
                                    L_Status.Text = "Password arent match ! (>_<)";
                                    T_NewPassErrorField();
                                    T_ConfPassErrorField();
                                }
                            }
                            else
                            {
                                L_Status.Text = "Only letter and number are allowed !";
                                T_NewPassErrorField();
                                //T_ConfPassErrorField();
                            }
                        }
                        else
                        {
                            L_Status.Text = "Password is too short !";
                            T_NewPassErrorField();
                            //T_ConfPassErrorField();
                        }
                    }
                }
            }
            else if(Method == "Update")
            {
                if (T_Nama.Text.Trim() == "" || T_Username.Text.Trim() == "" || T_Email.Text.Trim() == "" || T_NewPass.Text.Trim() == "" || T_ConfPass.Text.Trim() == "" || CB_Capability.Text.Trim() == "")
                {
                    L_Status.Text = "There is empty field !";
                    if (T_Nama.Text.Trim() == "")
                    {
                        T_NamaErrorField();
                    }
                    if (T_Username.Text.Trim() == "")
                    {
                        T_UsernameErrorField();
                    }
                    if (T_Email.Text.Trim() == "")
                    {
                        T_EmailErrorField();

                    }
                    if (T_NewPass.Text.Trim() == "")
                    {
                        T_NewPassErrorField();

                    }
                    if (T_ConfPass.Text.Trim() == "")
                    {
                        T_ConfPassErrorField();

                    }
                    if (CB_Capability.Text.Trim() == "")
                    {
                        CB_CapabilityErrorField();
                    }
                    return;
                }
                else
                {
                    String _tempPass = DataBr.GetSql("SELECT password FROM t_user WHERE id_user = '" + L_ID_User.Text + "'").Rows[0][0].ToString();
                    if (SecureKey.RedMd5(T_CurrPass.Text) == _tempPass)
                    {
                        if (CE_ComplexPass.Checked)
                        {
                            if (T_NewPass.Text == T_ConfPass.Text)
                            {
                                String _tempNewPass = SecureKey.RedMd5(T_CurrPass.Text);
                                String _tempdate = DateTime.Now.ToString("yyyy-MM-dd");
                                StatusUpdate = DataBr.SetSql("CALL UpdateUser('" + L_ID_User.Text + "','" + T_Nama.Text + "','" + T_Username.Text + "','" + T_Email.Text + "','" + _tempNewPass + "','" + CB_Capability.Text + "','" + _tempdate + "')");
                                if (StatusUpdate)
                                {
                                    if (L_ID_User.Text == GlobalVar.U_ID_USER)
                                    {
                                        DataTable _tempuser = DataBr.GetSql("SELECT * FROM  t_user WHERE id_user = '" + L_ID_User.Text + "'");
                                        if (_tempuser.Rows.Count > 0)
                                        {
                                            GlobalVar.U_ID_USER = _tempuser.Rows[0][0].ToString();
                                            GlobalVar.U_NAME_USER = _tempuser.Rows[0][1].ToString();
                                            GlobalVar.U_USERNAME = _tempuser.Rows[0][2].ToString();
                                            GlobalVar.U_EMAIL_USER = _tempuser.Rows[0][3].ToString();
                                            GlobalVar.U_CAPABILITY = _tempuser.Rows[0][5].ToString();
                                        }
                                        else
                                        {
                                            L_Status.Text = "FAILED !";
                                        }

                                    }
                                    L_Status.Text = "Data updated !";
                                }
                                else
                                {
                                    L_Status.Text = "Something went wrong, contact RedSolution !";
                                }
                            }
                            else
                            {
                                L_Status.Text = "Oww, come on this thing aren't match !";
                                T_NewPassErrorField();
                                T_ConfPassErrorField();
                            }
                        }
                        else
                        {
                            if (T_NewPass.Text.Length >= 8)
                            {
                                if (T_NewPass.Text.Any(char.IsLetter) && T_NewPass.Text.Any(char.IsNumber))
                                {
                                    if (T_NewPass.Text == T_ConfPass.Text)
                                    {
                                        String _tempNewPass = SecureKey.RedMd5(T_CurrPass.Text);
                                        String _tempdate = DateTime.Now.ToString("yyyy-MM-dd");
                                        StatusUpdate = DataBr.SetSql("CALL UpdateUser('" + L_ID_User.Text + "','" + T_Nama.Text + "','" + T_Username.Text + "','" + T_Email.Text + "','" + _tempNewPass + "','" + CB_Capability.Text + "','" + _tempdate + "')");
                                        if (StatusUpdate)
                                        {
                                            if (L_Status.Text == GlobalVar.U_ID_USER)
                                            {
                                                DataTable _tempuser = DataBr.GetSql("SELECT * FROM  t_user WHERE id_user = '" + L_ID_User.Text + "'");
                                                if (_tempuser.Rows.Count > 0)
                                                {
                                                    GlobalVar.U_ID_USER = _tempuser.Rows[0][0].ToString();
                                                    GlobalVar.U_NAME_USER = _tempuser.Rows[0][1].ToString();
                                                    GlobalVar.U_USERNAME = _tempuser.Rows[0][2].ToString();
                                                    GlobalVar.U_EMAIL_USER = _tempuser.Rows[0][3].ToString();
                                                    GlobalVar.U_CAPABILITY = _tempuser.Rows[0][5].ToString();
                                                }
                                                else
                                                {
                                                    L_Status.Text = "FAILED !";
                                                }

                                            }
                                            L_Status.Text = "Data updated !";
                                        }
                                        else
                                        {
                                            L_Status.Text = "Something went wrong, contact RedSolution !";
                                        }
                                    }
                                    else
                                    {
                                        L_Status.Text = "Oww, come on this thing aren't match !";
                                        T_NewPassErrorField();
                                        T_ConfPassErrorField();
                                    }
                                }
                                else
                                {
                                    L_Status.Text = "Only letter and number are allowed !";
                                    T_NewPassErrorField();
                                }
                            }
                            else
                            {
                                L_Status.Text = "Password is too short !";
                                T_NewPassErrorField();
                            }
                        }
                    }
                    else
                    {
                        L_Status.Text = "Your current password is not correct !";
                        T_CurrPassErrorField();
                    }
                }
            }
            else
            {
                L_Status.Text = "Something went wrong, contact Developer !";
            }
        }

        private void SeekPass(int keyBox)
        {
            if(keyBox == 1)
            {
                if (T_CurrPass.Properties.UseSystemPasswordChar)
                {
                    T_CurrPass.Properties.UseSystemPasswordChar = false;
                }
                else
                {
                    T_CurrPass.Properties.UseSystemPasswordChar = true;
                }
            }
            else if(keyBox == 2)
            {
                if (T_NewPass.Properties.UseSystemPasswordChar)
                {
                    T_NewPass.Properties.UseSystemPasswordChar = false;
                }
                else
                {
                    T_NewPass.Properties.UseSystemPasswordChar = true;
                }
            }
            else if(keyBox == 3)
            {
                if (T_ConfPass.Properties.UseSystemPasswordChar)
                {
                    T_ConfPass.Properties.UseSystemPasswordChar = false;
                }
                else
                {
                    T_ConfPass.Properties.UseSystemPasswordChar = true;
                }
            }
        }

        private void RemoveUser()
        {
            Boolean RemovalStatus = false;
            if(Id_user.Trim() != "")
            {
                if (XtraMessageBox.Show("Apakah anda yakin akan menghapus user dengan :\nID User : " + Id_user + "\nNama : " + nama_user + "", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    RemovalStatus = DataBr.SetSql("CALL RemoveUser('" + Id_user + "')");
                    if (RemovalStatus)
                    {
                        XtraMessageBox.Show("User dengan ID User : " + Id_user + "\nNama : " + nama_user + "\nberhasil dihapus !", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Id_user = "";
                        nama_user = "";
                        if (GlobalVar.U_CAPABILITY == "Admin")
                        {
                            ShowData("Specific", "Admin", "");
                        }
                        else
                        {
                            ShowData("Specific", "Operator", "");
                        }
                    }
                    else
                    {
                        L_Status.Text = "(´･_･`)ごめんなさい。私はできない";
                    }
                }
            }
        }

        private void RefreshBluetoothDevice()
        {
            BluetoothDeviceInfo[] Devices;
            using (BluetoothClient SDP = new BluetoothClient())
                Devices = SDP.DiscoverDevices();
            DataTable TableHolder = new DataTable();
            TableHolder.Columns.Add("Device MAC");
            TableHolder.Columns.Add("Device Name");
            TableHolder.Columns.Add("Pair Status");
            int x = 0;

            foreach (BluetoothDeviceInfo DeviceInfo in Devices)
            {
                TableHolder.Rows.Add(new Object[] { "" });
                TableHolder.Rows[x].SetField(0, DeviceInfo.DeviceAddress);
                TableHolder.Rows[x].SetField(1, DeviceInfo.DeviceName);
                TableHolder.Rows[x].SetField(2, DeviceInfo.Authenticated);
                x++;
            }
            GC_BluetoothDevices.DataSource = TableHolder;
        }

        private void ucUser_Load(object sender, EventArgs e)
        {
            FormOnLoad();
            TN_UserTrackHistory.Caption += " (" + GlobalVar.U_NAME_USER + ")";
        }

        private void B_Find_Click(object sender, EventArgs e)
        {
            if(GlobalVar.U_CAPABILITY == "Admin")
            {
                ShowData("Specific", "Admin",T_SearchField.Text);
            }
            else
            {
                ShowData("Specific", "Operator", T_SearchField.Text);
            }
            
        }

        private void DGC_User_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedItem();
        }

        private void B_Refresh_Click(object sender, EventArgs e)
        {
            if (GlobalVar.U_CAPABILITY == "Admin")
            {
                ShowData("All", "Admin", "");
            }
            else
            {
                ShowData("All", "Operator", "");
            }
        }

        private void B_Insert_Click(object sender, EventArgs e)
        {
            Method = "Insert";
            CleanUP();
            EnableInput("InsertMode");
        }

        private void B_Change_Click(object sender, EventArgs e)
        {
            Method = "Update";
            EnableInput("Default");
        }

        private void B_Remove_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }

        private void B_Simpan_Click(object sender, EventArgs e)
        {
            SaveChange();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CleanUP();
            DisableInput();
            Method = "";
        }

        private void T_Nama_EditValueChanged(object sender, EventArgs e)
        {
            T_NamaResetField();
        }

        private void T_Username_EditValueChanged(object sender, EventArgs e)
        {
            T_UsernameResetField();
        }

        private void T_Email_EditValueChanged(object sender, EventArgs e)
        {
            T_EmailResetField();
        }

        private void T_CurrPass_EditValueChanged(object sender, EventArgs e)
        {
            T_CurrPassResetField();
        }

        private void T_NewPass_EditValueChanged(object sender, EventArgs e)
        {
            T_NewPassResetField();
            PB_ComplexPass.Position = PasswordScore.CheckStrength(T_NewPass.Text);

        }

        private void T_ConfPass_EditValueChanged(object sender, EventArgs e)
        {
            T_ConfPassResetField();
        }

        private void CB_Capability_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_CapabilityResetField();
        }

        private void B_SeekPassword1_Click(object sender, EventArgs e)
        {
            SeekPass(1);
        }

        private void B_SeekPassword2_Click(object sender, EventArgs e)
        {
            SeekPass(2);
        }

        private void B_SeekPassword3_Click(object sender, EventArgs e)
        {
            SeekPass(3);
        }

        private void CE_ComplexPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CE_ComplexPass.Checked)
            {
                PB_ComplexPass.Visible = true;
            }
            else
            {
                PB_ComplexPass.Visible = false;
            }
        }

        private void T_SearchField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (GlobalVar.U_CAPABILITY == "Admin")
                {
                    ShowData("Specific", "Admin", T_SearchField.Text);
                }
                else
                {
                    ShowData("Specific", "Operator", T_SearchField.Text);
                }
            }
        }

        private void B_RefreshDevice_Click(object sender, EventArgs e)
        {
            RefreshBluetoothDevice();
        }
    }
}
