using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeWorkHistoryBUS
    {
        Base b = new Base();
        EmployeeWorkHistoryDAO dao = new EmployeeWorkHistoryDAO();
        public int Create(EmployeeWorkHistoryVO vo)
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
