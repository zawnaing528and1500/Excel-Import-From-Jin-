using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesBUS
    {
        Base b = new Base();
        OfficeAccessoriesDAO dao = new OfficeAccessoriesDAO();
        public int Create(OfficeAccessoriesVO vo)
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
