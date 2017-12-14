using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class AssessedByTrainnerDetailBUS
    {
        Base b = new Base();
        AssessedByTrainnerDetailDAO dao = new AssessedByTrainnerDetailDAO();
        public int Create(AssessedByTrainerDetailVO vo)
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
