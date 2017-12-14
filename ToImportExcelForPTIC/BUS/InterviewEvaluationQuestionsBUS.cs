using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class InterviewEvaluationQuestionsBUS
    {
        Base b = new Base();
        InterviewEvaluationQuestionDAO dao = new InterviewEvaluationQuestionDAO();
        public int Create(InterviewEvaluationQuestionVO vo)
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
