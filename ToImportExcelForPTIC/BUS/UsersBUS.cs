using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class UsersBUS
    {
        Base b = new Base();
        UsersDAO dao = new UsersDAO();
        //public int Create(UsersVO vo)
        //{
        //    int id;
        //    if (!dao.isExist(vo.ID.ToString()))
        //    {
        //        id = dao.Insert(vo);
        //    }
        //    else
        //    {
        //        id = dao.Update(vo);
        //    }
        //    return id;
        //}
    }
}
