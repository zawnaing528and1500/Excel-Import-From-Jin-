using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelInventoryBUS
    {
        Base b = new Base();
        FuelInventoryDAO dao = new FuelInventoryDAO();
        public int Create(FuelInventoryVO vo)
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
        public void updateQuery(string query)
        {
            dao.UpdateQuery(query);
        }
    }
}
