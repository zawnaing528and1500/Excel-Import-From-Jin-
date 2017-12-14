using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeApprovalDetailBUS
    {
        Base b = new Base();
        EmployeeApprovalDetailDAO dao = new EmployeeApprovalDetailDAO();
        public int Create(EmployeeApprovalDetailVO vo)
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
