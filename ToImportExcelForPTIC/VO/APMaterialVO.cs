using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APMaterialVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int aPSubCategoryID;

        public int APSubCategoryID
        {
            get { return aPSubCategoryID; }
            set { aPSubCategoryID = value; }
        }
        private string aPMaterialName;

        public string APMaterialName
        {
            get { return aPMaterialName; }
            set { aPMaterialName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
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
