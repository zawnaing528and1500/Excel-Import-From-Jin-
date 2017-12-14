using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class ProbationOfficeOrderBUS
    {
        Base b = new Base();
        ProbationOfficeOrderDAO dao = new ProbationOfficeOrderDAO();
        public int Create(ProbationOfficeOrderVO vo)
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
