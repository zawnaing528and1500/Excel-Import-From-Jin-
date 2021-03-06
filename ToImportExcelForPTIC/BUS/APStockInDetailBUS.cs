﻿using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APStockInDetailBUS
    {
        Base b = new Base();
        APStockInDetailDAO dao = new APStockInDetailDAO();
        public int Create(APStockInDetailVO vo)
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
