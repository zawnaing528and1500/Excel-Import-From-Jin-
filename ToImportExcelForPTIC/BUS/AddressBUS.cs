using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AddressBUS
    {
        Base b = new Base();
        AddressDAO dao = new AddressDAO();
        public int Create(AddressVO vo)
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
