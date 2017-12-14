using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
namespace Toyo.Core
{
    public class FineTypeBUS
    {
        Base b = new Base();
        FineTypeDAO dao = new FineTypeDAO();
        public int Create(FineTypeVO vo)
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
