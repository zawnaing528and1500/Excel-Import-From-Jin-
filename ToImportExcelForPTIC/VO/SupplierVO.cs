using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SupplierVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int supTypeID;

        public int SupTypeID
        {
            get { return supTypeID; }
            set { supTypeID = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

       
        private string supplierName;

        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }       

        private string contactPerson;
        
        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }
        private string contactPhone;

        public string ContactPhone
        {
            get { return contactPhone; }
            set { contactPhone = value; }
        }
       
        private string phone1;

        public string Phone1
        {
            get { return phone1; }
            set { phone1 = value; }
        }
        private string phone2;

        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
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
