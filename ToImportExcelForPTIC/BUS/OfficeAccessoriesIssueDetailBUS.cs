using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesIssueDetailBUS
    {
        Base b = new Base();
        OfficeAccessoriesIssueDetailDAO dao = new OfficeAccessoriesIssueDetailDAO();
        public int Create(OfficeAccessoriesIssueDetailVO vo)
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
