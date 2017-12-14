using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class SalarySettingBUS
    {
        Base b = new Base();
        SalarySettingDAO dao = new SalarySettingDAO();
        public int Create(SalarySettingVO vo)
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
