using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OTFeesRequestInfoBUS
    {
        Base b = new Base();
        OTFeeRequestInfoDAO dao = new OTFeeRequestInfoDAO();
        public int Create(OTFeesRequestInfoVO vo)
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
