using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class MenuItemVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int menuID;

        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }
        private int menuItemName;

        public int MenuItemName
        {
            get { return menuItemName; }
            set { menuItemName = value; }
        }

    }
}
