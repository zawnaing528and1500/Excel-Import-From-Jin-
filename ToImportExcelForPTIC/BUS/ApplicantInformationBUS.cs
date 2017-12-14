using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    class ApplicantInformationBUS
    {
        Base b = new Base();
        ApplicantInformationDAO dao = new ApplicantInformationDAO();
        public int Create(ApplicantInformationVO vo)
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
