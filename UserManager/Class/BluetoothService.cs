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
        DataTable _tempTableHolder = new DataTable();
        //public DataTable RefreshBluetoothDevice()
        //{
        //    DataTable TableHolder = new DataTable();
        //    BluetoothDeviceInfo[] Devices;
        //    using (BluetoothClient SDP = new BluetoothClient())
        //        Devices = SDP.DiscoverDevices();
        //    TableHolder.Columns.Add("Device MAC");
        //    TableHolder.Columns.Add("Device Name");
        //    TableHolder.Columns.Add("Signal Strength");
        //    TableHolder.Columns.Add("Pair Status");
        //    int x = 0;
        //    foreach (BluetoothDeviceInfo DeviceInfo in Devices)
        //    {
        //        TableHolder.Rows.Add(new Object[] { "" });
        //        TableHolder.Rows[x].SetField(0, DeviceInfo.DeviceAddress);
        //        TableHolder.Rows[x].SetField(1, DeviceInfo.DeviceName);
        //        TableHolder.Rows[x].SetField(2, DeviceInfo.Rssi);
        //        TableHolder.Rows[x].SetField(3, DeviceInfo.Authenticated);
        //        x++;
        //    }
        //    return TableHolder;
        //}

        public DataTable DiscoverDevices()
        {
            BluetoothClient thisDevice = new BluetoothClient();
            thisDevice.BeginDiscoverDevices(8, true, true, true, false, DiscoverDevicesCallback, thisDevice);
            return _tempTableHolder;
        }

        void DiscoverDevicesCallback(IAsyncResult result)
        {
            int x = 0;
            BluetoothClient thisDevices = result.AsyncState as BluetoothClient;
            if (result.IsCompleted)
            {
                BluetoothDeviceInfo[] Devices = thisDevices.EndDiscoverDevices(result);
                _tempTableHolder.Columns.Add("0");
                _tempTableHolder.Columns.Add("1");
                _tempTableHolder.Columns.Add("2");
                _tempTableHolder.Columns.Add("3");
                foreach (BluetoothDeviceInfo BDI in Devices)
                {
                    _tempTableHolder.Rows.Add(new Object[] { "" });
                    _tempTableHolder.Rows[x].SetField(0, BDI.DeviceAddress);
                    _tempTableHolder.Rows[x].SetField(1, BDI.DeviceName);
                    _tempTableHolder.Rows[x].SetField(2, BDI.Rssi);
                    _tempTableHolder.Rows[x].SetField(3, BDI.Authenticated);
                    x++;
                }
            }
        }
    }
}
