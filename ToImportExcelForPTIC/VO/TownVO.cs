using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TownVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private int stateDivisionID;
        public int StateDivisionID
        {
            get { return stateDivisionID; }
            set { stateDivisionID = value; }
        }

        private string town;

        public string Town
        {
            get { return town; }
            set { town = value; }
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
