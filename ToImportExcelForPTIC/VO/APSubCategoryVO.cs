using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class APSubCategoryVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int aPCategoryID;

        public int APCategoryID
        {
            get { return aPCategoryID; }
            set { aPCategoryID = value; }
        }
        private string apSubCategoryName;

        public string ApSubCategoryName
        {
            get { return apSubCategoryName; }
            set { apSubCategoryName = value; }
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
