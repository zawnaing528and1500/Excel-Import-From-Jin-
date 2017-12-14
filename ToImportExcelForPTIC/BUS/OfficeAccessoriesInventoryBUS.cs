using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesInventoryBUS
    {
        Base b = new Base();
        OfficeAccessoriesInventoryDAO dao = new OfficeAccessoriesInventoryDAO();

        public int Create(OfficeAccessoriesInventoryVO vo)
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
        public void updateInventoryQty(string query)
        {
            dao.updateInventoryQty(query);
        }
    }
}
