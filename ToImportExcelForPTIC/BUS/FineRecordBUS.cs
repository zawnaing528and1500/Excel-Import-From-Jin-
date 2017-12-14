using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FineRecordBUS
    {
        Base b = new Base();
        FineRecordDAO dao = new FineRecordDAO();
        public int Create(FineRecordVO vo)
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
