using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TrainingAttendeeBUS
    {
        Base b = new Base();
        TrainingAttendeeDAO dao = new TrainingAttendeeDAO();
        public int Create(TrainingAttendeeVO vo)
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
