using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AgencyVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string agencyName;

        public string AgencyName
        {
            get { return agencyName; }
            set { agencyName = value; }
        }
        private string phoneNo;

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string contactName;

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        private string serviceFees;

        public string ServiceFees
        {
            get { return serviceFees; }
            set { serviceFees = value; }
        }
    }
}
