using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SalaryBUS
    {
        Base b = new Base();
        SalaryDAO dao = new SalaryDAO();
        public int Create(SalaryVO vo)
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
