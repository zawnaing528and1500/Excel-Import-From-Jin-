using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class Approve_Employee_OrderBUS
    {
        Base b = new Base();
        Approve_Employee_OrderDAO dao = new Approve_Employee_OrderDAO();
        public int Create(Approve_Employee_OrderVO vo)
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
