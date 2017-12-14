using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OTRequestInfoBUS
    {
        Base b = new Base();
        OTRequestInfoDAO dao = new OTRequestInfoDAO();
        public int Create(OTRequestInfoVO vo)
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
