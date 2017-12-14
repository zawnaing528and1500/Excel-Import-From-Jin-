using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class IncrementEmployeeBUS
    {
        Base b = new Base();
        IncrementEmployeeDAO dao = new IncrementEmployeeDAO();
        public int Create(IncrementEmployeeVO vo)
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
        public int Insert(IncrementEmployeeVO vo)
        {
            int id=0;

            if (!b.isExist("Increment_Employee", "IncrementDate= '" + vo.IncrementDate + "' and EmpID = " + vo.EmpID + ""))
            {
                id = dao.Insert(vo);
            }
            else {
                id = dao.Update(vo);
            }

            return id;
        }
    }
}
