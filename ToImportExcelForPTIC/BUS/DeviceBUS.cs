using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class DeviceBUS
    {
        Base b = new Base();
        DeviceDAO dao = new DeviceDAO();
        public int Create(DeviceVO vo)
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
