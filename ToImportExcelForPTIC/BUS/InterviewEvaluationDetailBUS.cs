using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class InterviewEvaluationDetailBUS
    {
        Base b = new Base();
        InterviewEvaluationDetailDAO dao = new InterviewEvaluationDetailDAO();
        public int Create(InterviewEvaluationDetailVO vo)
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
