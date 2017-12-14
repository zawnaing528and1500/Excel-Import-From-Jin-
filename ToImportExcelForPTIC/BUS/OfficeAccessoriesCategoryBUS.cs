using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesCategoryBUS
    {
        Base b = new Base();
        OfficeAccessoriesCategoryDAO dao = new OfficeAccessoriesCategoryDAO();
        public int Create(OfficeAccessoriesCategoryVO vo)
        {
            int id = 0;
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
