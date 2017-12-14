using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TownshipInfoVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int townID;
        public int TownID
        {
            get { return townID; }
            set { townID = value; }
        }

        private string township;
        public string Township
        {
            get { return township; }
            set { township = value; }
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
