using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class MenuVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int mainMenuID;

        public int MainMenuID
        {
            get { return mainMenuID; }
            set { mainMenuID = value; }
        }
        private int menuName;

        public int MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }


    }
}
