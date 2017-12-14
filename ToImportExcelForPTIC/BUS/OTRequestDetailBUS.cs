using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OTRequestDetailBUS
    {
        Base b = new Base();
        OTRequestDetailDAO dao = new OTRequestDetailDAO();
        public int Create(OTRequestDetailVO vo)
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
