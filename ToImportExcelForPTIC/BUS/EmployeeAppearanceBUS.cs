using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeAppearanceBUS
    {
        Base b = new Base();
        EmployeeAppearanceDAO dao = new EmployeeAppearanceDAO();
        public int Create(EmployeeAppearanceVO vo)
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
