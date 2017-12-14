using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelRequestInfoBUS
    {
        Base b = new Base();
        FuelRequestInfoDAO dao = new FuelRequestInfoDAO();
        public int Create(FuelRequestInfoVO vo)
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
