using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AccessLevelDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int accessLevelID;

        public int AccessLevelID
        {
            get { return accessLevelID; }
            set { accessLevelID = value; }
        }
        private int menuItemID;

        public int MenuItemID
        {
            get { return menuItemID; }
            set { menuItemID = value; }
        }
    }
}
