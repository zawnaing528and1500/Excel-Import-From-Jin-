using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PRLateFineBUS
    {
        Base b = new Base();
        PRLateFineDAO dao = new PRLateFineDAO();
        public int Create(PRLateFineVO vo)
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
