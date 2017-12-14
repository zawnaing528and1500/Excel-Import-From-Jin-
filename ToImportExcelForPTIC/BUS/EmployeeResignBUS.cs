using System;
using System.Collections.Generic;

using System.Text;
using Toyo.Core;

namespace Toyo.Core
{
    public class EmployeeResignBUS
    {
        Base b = new Base();
        EmployeeResignDAO dao = new EmployeeResignDAO();
        public int Create(EmployeeResignVO vo)
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
