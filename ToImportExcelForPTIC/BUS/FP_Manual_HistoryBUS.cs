using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_Manual_HistoryBUS
    {
        Base b = new Base();
        FP_Manual_HistoryDAO dao = new FP_Manual_HistoryDAO();
        public int Create(FP_Manual_HistoryVO vo)
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
