using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APMaterialInventoryBUS
    {
        Base b = new Base();
        APMaterialInventoryDAO dao = new APMaterialInventoryDAO();
        public int Create(APMaterialInventoryVO vo)
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
