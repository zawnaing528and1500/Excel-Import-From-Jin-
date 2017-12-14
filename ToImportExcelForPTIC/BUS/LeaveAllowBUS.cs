using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class LeaveAllowBUS
    {
        Base b = new Base();
        LeaveAllowDAO dao = new LeaveAllowDAO();
        public int Create(LeaveAllowVO vo)
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
