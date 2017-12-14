using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssessedByTrainnerInfoBUS
    {
        Base b = new Base();
        AssessedByTrainnerInfoDAO dao = new AssessedByTrainnerInfoDAO();
        public int Create(AssessedByTrainerInfoVO vo)
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
