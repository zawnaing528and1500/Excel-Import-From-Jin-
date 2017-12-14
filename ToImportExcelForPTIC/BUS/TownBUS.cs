using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TownBUS
    {
        Base b = new Base();
        TownDAO dao = new TownDAO();
        public int Create(TownVO vo)
        {
            int id = 0;
            if(!dao.isExist(vo.Id.ToString()))
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
