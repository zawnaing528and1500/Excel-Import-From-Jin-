﻿using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TrainingPlanDetailBUS
    {
        Base b = new Base();
        TrainingPlanDetailDAO dao = new TrainingPlanDetailDAO();
        public int Create(TrainingPlanDetailVO vo)
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
