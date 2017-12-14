using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_Additional_AllowanceBUS
    {
        Base b = new Base();
        PR_Additional_AllowanceDAO dao = new PR_Additional_AllowanceDAO();
        public int Create(PR_Additional_AllowanceVO vo)
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
