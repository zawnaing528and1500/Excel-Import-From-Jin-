using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
namespace Toyo.Core
{
    public class BLOBUS
    {
        Base b = new Base();
        BLODAO dao = new BLODAO();
        public int Create(BLOVO vo)
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
