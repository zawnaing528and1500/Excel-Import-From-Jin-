using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class BankBUS
    {
        Base b = new Base();
        BankDAO dao = new BankDAO();
        public int Create(BankVO vo)
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
