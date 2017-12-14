using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeQualificationBUS
    {
        Base b = new Base();
        EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
        public int Create(EmployeeQualificationVO vo)
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
