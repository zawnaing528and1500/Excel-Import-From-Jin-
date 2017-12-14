using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeePhysicalExaminationBUS
    {
        Base b = new Base();
        EmployeePhysicalExaminationDAO dao = new EmployeePhysicalExaminationDAO();
        public int Create(EmployeePhysicalExaminationVO vo)
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
