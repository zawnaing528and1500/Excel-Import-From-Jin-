using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class APCategoryVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
        private bool isNonAP;

        public bool IsNonAP
        {
            get { return isNonAP; }
            set { isNonAP = value; }
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
