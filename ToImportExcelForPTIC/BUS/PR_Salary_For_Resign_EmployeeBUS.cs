using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_Salary_For_Resign_EmployeeBUS
    {
        Base b = new Base();
        PR_Salary_For_Resign_EmployeeDAO dao = new PR_Salary_For_Resign_EmployeeDAO();
        public int Create(PR_Salary_For_Resign_EmployeeVO vo)
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
