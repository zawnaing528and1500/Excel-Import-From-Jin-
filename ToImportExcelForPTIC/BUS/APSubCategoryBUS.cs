using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APSubCategoryBUS
    {
        Base b = new Base();
        APSubCategoryDAO dao = new APSubCategoryDAO();
        public int Create(APSubCategoryVO vo)
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
