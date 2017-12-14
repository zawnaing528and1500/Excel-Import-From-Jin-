using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeApprovalQuestionBUS
    {
        Base b = new Base();
        EmployeeApprovalQuestionDAO dao = new EmployeeApprovalQuestionDAO();
        public int Create(EmployeeApprovalEvaluationQuestionVO vo)
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
