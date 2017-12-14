using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_AllLog_DeleteBUS
    {
        Base b = new Base();
        FP_AllLog_DeleteDAO dao = new FP_AllLog_DeleteDAO();
        public int Create(FP_AllLog_DeleteVO vo)
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
