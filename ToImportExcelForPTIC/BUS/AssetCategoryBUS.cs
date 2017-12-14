using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssetCategoryBUS
    {
        Base b = new Base();
        AssetCategoryDAO dao = new AssetCategoryDAO();
        public int Create(AssetCategoryVO vo)
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
