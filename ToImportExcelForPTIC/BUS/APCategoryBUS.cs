using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APCategoryBUS
    {
        Base b = new Base();
        APCategoryDAO dao = new APCategoryDAO();
        public int Create(APCategoryVO vo)
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
