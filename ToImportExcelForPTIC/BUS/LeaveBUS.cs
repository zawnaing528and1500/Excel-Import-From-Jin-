using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class LeaveBUS
    {
        Base b = new Base();
        LeaveDAO dao = new LeaveDAO();
        public int Create(LeaveVO vo)
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
