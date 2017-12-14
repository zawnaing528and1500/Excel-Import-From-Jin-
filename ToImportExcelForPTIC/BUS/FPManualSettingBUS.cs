using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FPManualSettingBUS
    {
        Base b = new Base();
        FPManualSettingDAO dao = new FPManualSettingDAO();
        public int Create(FPManualSettingVO vo)
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
        public int CreateByAtt(FPManualSettingVO vo)
        {
            int id;
            //if (!dao.isExistDateNid(" ManualInDate='" + vo.ManualInDate + "' AND ManualOutDate='" + vo.ManualOutDate + "' AND EMPID='" + vo.EmpID + "'"))
            //{
            //    id = dao.Insert(vo);
            //}
            if (!dao.isExistDateNid("AttendanceID=" + vo.AttendanceID))
            {
                id = dao.Insert(vo);
            }           
            else
            {
                id = dao.UpdateByAtt(vo);
            }
            return id;
        }

    }
}
