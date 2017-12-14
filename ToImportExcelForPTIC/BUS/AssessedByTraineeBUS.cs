using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssessedByTraineeBUS
    {
        Base b = new Base();
        AssessedByTraineeDAO dao = new AssessedByTraineeDAO();
        public int Create(AssessedByTraineeVO vo)
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
