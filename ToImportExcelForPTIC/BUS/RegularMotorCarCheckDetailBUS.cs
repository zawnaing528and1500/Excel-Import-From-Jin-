using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class RegularMotorCarCheckDetailBUS
    {
        Base b = new Base();
        RegularMotorCarCheckDetailDAO dao = new RegularMotorCarCheckDetailDAO();
        public int Create(RegularMotorCarCheckDetailVO vo)
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
