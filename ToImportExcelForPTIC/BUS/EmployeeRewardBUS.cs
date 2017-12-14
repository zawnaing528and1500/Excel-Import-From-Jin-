using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeRewardBUS
    {
        Base b = new Base();
        EmployeeRewardDAO dao = new EmployeeRewardDAO();
        public int Create(EmployeeRewardVO vo)
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
