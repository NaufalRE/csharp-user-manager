using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net.Sockets;
using System.Data;
using System.Windows.Forms;

namespace UserManager.Class
{
    class BluetoothService
    {

        public DataTable RefreshBluetoothDevice()
        {
            DataTable TableHolder = new DataTable();
            BluetoothDeviceInfo[] Devices;
            using (BluetoothClient SDP = new BluetoothClient())
                Devices = SDP.DiscoverDevices();
            TableHolder.Columns.Add("Device MAC");
            TableHolder.Columns.Add("Device Name");
            TableHolder.Columns.Add("Signal Strength");
            TableHolder.Columns.Add("Pair Status");
            int x = 0;

            foreach (BluetoothDeviceInfo DeviceInfo in Devices)
            {
                TableHolder.Rows.Add(new Object[] { "" });
                TableHolder.Rows[x].SetField(0, DeviceInfo.DeviceAddress);
                TableHolder.Rows[x].SetField(1, DeviceInfo.DeviceName);
                TableHolder.Rows[x].SetField(2, DeviceInfo.Rssi);
                TableHolder.Rows[x].SetField(3, DeviceInfo.Authenticated);
                MessageBox.Show(Convert.ToInt64(TableHolder.Rows[x][2]).ToString());
                x++;
            }
            return TableHolder;
        }
    }
}
