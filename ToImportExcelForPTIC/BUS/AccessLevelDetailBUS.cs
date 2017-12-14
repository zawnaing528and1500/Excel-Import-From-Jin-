using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AccessLevelDetailBUS
    {
        Base b = new Base();
        AccessLevelDetailDAO dao = new AccessLevelDetailDAO();
        public int Create(AccessLevelDetailVO vo)
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
        public void Delete(string id)
        {
            dao.Delete(id);
        }
    }
}
