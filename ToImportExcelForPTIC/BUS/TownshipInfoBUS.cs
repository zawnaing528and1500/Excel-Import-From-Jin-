using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TownshipInfoBUS
    {
        Base b = new Base();
        TownshipInfoDAO dao = new TownshipInfoDAO();
        public int Create(TownshipInfoVO vo)
        {
            int id = 0;
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
