using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class DepartmentBUS
    {
        Base b = new Base();
        DepartmentDAO dao = new DepartmentDAO();
        public int Create(DepartmentVO vo)
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
