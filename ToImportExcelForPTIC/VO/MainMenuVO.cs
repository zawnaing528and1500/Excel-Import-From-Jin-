using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class MainMenuVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string mainMenuName;

        public string MainMenuName
        {
            get { return mainMenuName; }
            set { mainMenuName = value; }
        }
    }
}
