using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class UsedLeaveBUS
    {
        Base b = new Base();
        UsedLeaveDAO dao = new UsedLeaveDAO();
        public int Create(UsedLeaveVO vo)
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
