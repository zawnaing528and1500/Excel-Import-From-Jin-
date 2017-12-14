using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PRIncrementBonusTerminationBUS
    {
        Base b = new Base();
        PRIncrementBonusTerminationDAO dao = new PRIncrementBonusTerminationDAO();
        public int Create(PRIncrementBonusTerminationVO vo)
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
