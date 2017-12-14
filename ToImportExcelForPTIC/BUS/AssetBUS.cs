using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssetBUS
    {
        Base b = new Base();
        AssetDAO dao = new AssetDAO();
        public int Create(AssetVO vo)
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
