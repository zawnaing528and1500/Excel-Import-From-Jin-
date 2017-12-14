using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class ExternalTrainingAssessmentBUS
    {
        Base b = new Base();
        ExternalTrainingAssessmentDAO dao = new ExternalTrainingAssessmentDAO();
        public int Create(ExternalTrainingAssessmentVO vo)
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
