using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class BankVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private string bank;
        public string Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        private int townID;
        public int TownID
        {
            get { return townID; }
            set { townID = value; }
        }

        private string bankAddress;

        public string BankAddress
        {
            get { return bankAddress; }
            set { bankAddress = value; }
        }
                
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private DateTime dateAdded;
        public DateTime DateAdded
        {
            get { return dateAdded; }
            set { dateAdded = value; }
        }

        private DateTime lastModified;

        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
