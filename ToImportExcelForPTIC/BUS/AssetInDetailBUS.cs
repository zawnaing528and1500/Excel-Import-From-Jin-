using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssetInDetailBUS
    {
        Base b = new Base();
        AssetInDetailDAO dao = new AssetInDetailDAO();
        public int Create(AssetInDetailVO vo)
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
