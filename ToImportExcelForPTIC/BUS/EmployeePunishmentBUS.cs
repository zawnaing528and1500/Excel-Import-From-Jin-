using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeePunishmentBUS
    {
        Base b = new Base();
        EmployeePunishmentDAO dao = new EmployeePunishmentDAO();
        public int Create(EmployeePunishmentVO vo)
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
