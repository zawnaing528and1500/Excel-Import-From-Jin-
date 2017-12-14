using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_SalaryChangeBUS
    {
        Base b = new Base();
        PR_SalaryChangeDAO dao = new PR_SalaryChangeDAO();
        public int Create(PR_SalaryChangeVO vo)
        {
            int id = 0;
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
