using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class AccessLevelBUS
    {
        Base b = new Base();
        AccessLevelDAO dao = new AccessLevelDAO();
        public int Create(AccessLevelVO vo)
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
