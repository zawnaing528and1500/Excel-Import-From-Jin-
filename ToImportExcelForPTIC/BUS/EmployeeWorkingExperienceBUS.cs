using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeWorkingExperienceBUS
    {
        Base b = new Base();
        EmployeeWorkingExperienceDAO dao = new EmployeeWorkingExperienceDAO();
        public int Create(EmployeeWorkingExperienceVO vo)
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
