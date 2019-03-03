using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DevExpress.XtraEditors;

namespace UserManager.Class
{
    class DeviceId
    {
        public String DeviceIdIdentifier()
        {
            //[REQUIRE - REFERENCE]System.Management
            String MotherBoardId = "";
            try
            {
                //MOS REQUIRE SQL in WMI !
                ManagementObjectSearcher Mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection Moc = Mos.Get();

                foreach (ManagementObject MO in Moc)
                {
                    MotherBoardId = MO["SerialNumber"].ToString();
                }
                return MotherBoardId;
            }
            catch (Exception)
            {
                return MotherBoardId;
            }
        }
    }
}
