using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AgencyBUS
    {
        Base b = new Base();
        AgencyDAO dao = new AgencyDAO();
        public int Create(AgencyVO vo)
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
