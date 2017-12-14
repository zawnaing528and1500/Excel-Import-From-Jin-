using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SupplierTypeBUS
    {
        Base b = new Base();
        SupplierTypeDAO dao = new SupplierTypeDAO();
        public int Create(SupplierTypeVO vo)
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
