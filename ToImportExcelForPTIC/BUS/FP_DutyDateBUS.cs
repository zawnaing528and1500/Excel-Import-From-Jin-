using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_DutyDateBUS
    {
        Base b = new Base();
        FP_DutyDateDAO dao = new FP_DutyDateDAO();
        public int Create(FP_DutyDateVO vo)
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
