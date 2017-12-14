using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    class APIssueDetailBUS
    {
        Base b = new Base();
        APIssueDetailDAO dao = new APIssueDetailDAO();
        public int Create(APIssueDetailVO vo)
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
