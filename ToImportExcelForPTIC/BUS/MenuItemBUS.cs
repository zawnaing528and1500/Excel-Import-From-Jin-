using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    class MenuItemBUS
    {
        Base b = new Base();
        MenuItemDAO dao = new MenuItemDAO();
        public int Create(MenuItemVO vo)
        {
            int id;
            if (!dao.isExist(vo.Id.ToString()))
            {
                id = dao.Insert(vo);
            }
            else
            {
                id = dao.Update(vo);
            }
            return id;
        }
    }
}
