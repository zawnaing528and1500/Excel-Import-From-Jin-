using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SupplierTypeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string supplierType;

        public string SupplierType
        {
            get { return supplierType; }
            set { supplierType = value; }
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
