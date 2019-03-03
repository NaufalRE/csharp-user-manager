using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Class
{
    class GlobalVar
    {
        static String u_id_user;
        static String u_username;
        static String u_name_user;
        static String u_email_user;
        static String u_capability;
        static String u_session;
        static String d_b_mac;

        public static void CleanUP()
        {
            U_ID_USER = "";
            U_USERNAME = "";
            U_NAME_USER = "";
            U_EMAIL_USER = "";
            U_CAPABILITY = "";
        }

        public static String U_ID_USER
        {
            get
            {
                return u_id_user;
            }
            set
            {
                u_id_user = value;
            }
        }

        public static String U_USERNAME
        {
            get
            {
                return u_username;
            }
            set
            {
                u_username = value;
            }
        }

        public static String U_NAME_USER
        {
            get
            {
                return u_name_user;
            }
            set
            {
                u_name_user = value;
            }
        }

        public static String U_EMAIL_USER
        {
            get
            {
                return u_email_user;
            }
            set
            {
                u_email_user = value;
            }
        }

        public static String U_CAPABILITY
        {
            get
            {
                return u_capability;
            }
            set
            {
                u_capability = value;
            }
        }

        public static String U_SESSION
        {
            get
            {
                return u_session;
            }
            set
            {
                u_session = value;
            }
        }

        public static String D_B_MAC
        {
            get
            {
                return d_b_mac;
            }
            set
            {
                d_b_mac = value;
            }
        }
    }
}
