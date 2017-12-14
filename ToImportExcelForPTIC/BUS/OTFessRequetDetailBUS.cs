using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OTFessRequetDetailBUS
    {
        Base b = new Base();
        OTFeesRequestDetailDAO dao = new OTFeesRequestDetailDAO();
        public int Create(OTFeesRequestDetailVO vo)
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
