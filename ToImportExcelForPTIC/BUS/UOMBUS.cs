using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class UOMBUS
    {
        Base b = new Base();
        UOMDAO dao = new UOMDAO();
        public int Create(UOMVO vo)
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
