using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace UserManager.Class
{
    class DataBridge
    {
        private MySqlConnection MConn;
        private MySqlCommand MComm;
        private MySqlDataAdapter Mda;
        private DataTable Dt;

        String IdUser;
        String Session;

        private void OpenConnection()
        {
            try
            {
                MConn = new MySqlConnection("SERVER = 'localhost'; USERNAME = 'root'; PASSWORD = ''; DATABASE = 'db_user_manager';");
                MConn.Open();
            }
            catch(Exception ErrConn)
            {
                XtraMessageBox.Show("We found an error +\n" + ErrConn.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseConnection()
        {
            MConn.Close();
        }

        public Boolean SetSql(String str)
        {
            Boolean Status = false;
            try
            {
                OpenConnection();
                MComm = new MySqlCommand(str, MConn);
                MComm.ExecuteNonQuery();
                CloseConnection();
                Status = true;
            }
            catch(Exception ErrSetSql)
            {
                Status = false;
                XtraMessageBox.Show("Something went wrong :\n" + ErrSetSql.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Status;
        }

        public DataTable GetSql(string str)
        {
            Dt = new DataTable();
            try
            {
                OpenConnection();
                Mda = new MySqlDataAdapter(str, MConn);
                Mda.Fill(Dt);
                CloseConnection();
            }
            catch(Exception ErrGetSql)
            {
                XtraMessageBox.Show("Something went wrong :\n" + ErrGetSql.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Dt;
        }

        public String AutomaticUserCode()
        {
            IdUser = "U0001";
            try
            {
                OpenConnection();
                Mda = new MySqlDataAdapter("SELECT id_user FROM t_user ORDER BY id_user desc", MConn);
                Dt = new DataTable();
                Mda.Fill(Dt);
                if(Dt.Rows.Count > 0)
                {
                    IdUser = Dt.Rows[0][0].ToString();
                    IdUser = IdUser.Substring(1, 4);
                    IdUser = Convert.ToString(Double.Parse(IdUser) + 1);
                    IdUser = "0000".Substring(0, 4 - IdUser.Length) + IdUser;
                    IdUser = "U" + IdUser;
                }
                else
                {
                    IdUser = "U0001";
                }
            }
            catch(Exception ErrUserCode)
            {
                XtraMessageBox.Show("Owwww, Nii-chan i don't feel good : \n" + ErrUserCode.Message, "Your Imouto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IdUser;
        }

        public String AutomaticSessionCode()
        {
            Session = "S000000001";
            try
            {
                OpenConnection();
                Mda = new MySqlDataAdapter("SELECT id_session FROM t_loguser ORDER BY id_session desc", MConn);
                Dt = new DataTable();
                Mda.Fill(Dt);
                if(Dt.Rows.Count > 0)
                {
                    Session = Dt.Rows[0][0].ToString();
                    Session = Session.Substring(1, 9);
                    Session = Convert.ToString(Double.Parse(Session) + 1);
                    Session = "000000000".Substring(0, 9 - Session.Length) + Session;
                    Session = "S" + Session;
                }
                else
                {
                    Session = "S000000001";
                }
            }
            catch (Exception ErrSessionCode)
            {
                XtraMessageBox.Show("Owwww, Nii-chan i don't feel good : \n" + ErrSessionCode.Message, "Your Imouto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Session;
        }
    }
}
