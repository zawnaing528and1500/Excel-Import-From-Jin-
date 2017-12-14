using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_AllLogBUS
    {
        Base b = new Base();
        FP_AllLogDAO dao = new FP_AllLogDAO();
        public int Create(FP_AllLogVO vo)
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
        public int InsertLog(FP_AllLogVO vo)
        {
            int id = 0;
            if (!dao.isExistByCondition("FingerID=" + vo.FingerID + " AND AttendanceDateTime='" + vo.AttendanceDateTime + "'"))
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
