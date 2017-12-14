using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APStockInBUS
    {
        Base b = new Base();
        APStockInDAO dao = new APStockInDAO();
        public int Create(APStockInVO vo)
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
