using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class CVSourceBUS
    {
        Base b = new Base();
        CVSourceDAO dao = new CVSourceDAO();
        public int Create(CVSourceVO vo)
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
