using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class InterviewEvaluationInfoBUS
    {
        Base b = new Base();
        InterviewEvaluationInfoDAO dao = new InterviewEvaluationInfoDAO();
        public int Create(InterviewEvaluationInfoVO vo)
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
