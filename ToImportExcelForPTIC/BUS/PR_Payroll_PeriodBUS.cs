using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_Payroll_PeriodBUS
    {
        Base b = new Base();
        PR_Payroll_PeriodDAO dao = new PR_Payroll_PeriodDAO();
        public int Create(PR_Payroll_PeriodVO vo)
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
