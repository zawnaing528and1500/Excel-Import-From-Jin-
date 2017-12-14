using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class EmployeeMedicalHistoryBUS
    {
        Base b = new Base();
        EmployeeMedicalHistoryDAO dao = new EmployeeMedicalHistoryDAO();
        public int Create(EmployeeMedicalHistoryVO vo)
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
