using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeRelativeBUS
    {
        Base b = new Base();
        EmployeeRelativeDAO dao = new EmployeeRelativeDAO();
        public int Create(EmployeeRelativeVO vo)
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
