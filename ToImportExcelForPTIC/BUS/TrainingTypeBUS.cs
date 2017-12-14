using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TrainingTypeBUS
    {
        Base b = new Base();
        TrainingTypeDAO dao = new TrainingTypeDAO();
        public int Create(TrainingTypeVO vo)
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
