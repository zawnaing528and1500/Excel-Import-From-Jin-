using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class APIssueInfoBUS
    {
        Base b = new Base();
        APIssueInfoDAO dao = new APIssueInfoDAO();
        public int Create(APIssueInfoVO vo)
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
