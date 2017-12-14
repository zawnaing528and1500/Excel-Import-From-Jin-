using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TripAssignBUS
    {
        Base b = new Base();
        TripAssignDAO dao = new TripAssignDAO();
        public int Create(TripAssignVO vo)
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
