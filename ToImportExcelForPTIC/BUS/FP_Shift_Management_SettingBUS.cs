using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_Shift_Management_SettingBUS
    {
        Base b = new Base();
        FP_Shift_Management_SettingDAO dao = new FP_Shift_Management_SettingDAO();
        public int Create(FP_Shift_Management_SettingVO vo)
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
