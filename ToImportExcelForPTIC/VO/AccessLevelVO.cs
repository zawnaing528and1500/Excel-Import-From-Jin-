using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AccessLevelVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int postID;

        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }
        private string accessLevelName;

        public string AccessLevelName
        {
            get { return accessLevelName; }
            set { accessLevelName = value; }
        }
        private int accessLevel;

        public int AccessLevel
        {
            get { return accessLevel; }
            set { accessLevel = value; }
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
