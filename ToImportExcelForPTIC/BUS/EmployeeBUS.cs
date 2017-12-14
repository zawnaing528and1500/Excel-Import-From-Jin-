using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeBUS
    {
        Base b = new Base();
        EmployeeDAO dao = new EmployeeDAO();
        public int Create(EmployeeVO vo)
        {
            int id=0;
            if (!dao.isExist(vo.Id.ToString()))
            {
                vo.CreatedDate = DateTime.Now;
                vo.LastModified = DateTime.Now;
                id = dao.Insert(vo);
            }
            else
            {
                // vo.CreatedDate = DateTime.Now;
               // vo.LastModified = DateTime.Now;
               // id = dao.Update(vo);
            }
            return id;
        }
        public void updateEmpStatus(string query)
        {
            dao.UpdateQuery(query);
        }
    }
}
