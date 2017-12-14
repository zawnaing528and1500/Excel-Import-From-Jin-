using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class DeviceVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int deviceNo;

        public int DeviceNo
        {
            get { return deviceNo; }
            set { deviceNo = value; }
        }
        private string deviceName;

        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }
        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        
    }
}
