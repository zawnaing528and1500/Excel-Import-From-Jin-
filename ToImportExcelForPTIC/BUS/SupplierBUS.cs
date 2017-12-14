using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SupplierBUS
    {
        Base b = new Base();
        SupplierDAO dao = new SupplierDAO();
        public int Create(SupplierVO vo)
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
