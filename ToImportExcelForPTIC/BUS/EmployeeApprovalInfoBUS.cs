using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeApprovalInfoBUS
    {
        Base b = new Base();
        EmployeeApprovalInfoDAO dao = new EmployeeApprovalInfoDAO();
        public int Create(EmployeeApprovalInfoVO vo)
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
