using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class MenuBUS
    {
        Base b = new Base();
        MenuDAO dao = new MenuDAO();
        public int Create(MenuVO vo)
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
