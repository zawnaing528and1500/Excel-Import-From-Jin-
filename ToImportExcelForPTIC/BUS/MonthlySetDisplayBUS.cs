using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class MonthlySetDisplayBUS
    {
        Base b = new Base();
        MonthlySetDisplayDAO dao = new MonthlySetDisplayDAO();
        public int Create(MonthlySetDisplayVO vo)
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
