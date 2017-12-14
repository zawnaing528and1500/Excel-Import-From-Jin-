using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_FixedRulesBUS
    {
        Base b = new Base();
        PR_FixedRulesDAO dao = new PR_FixedRulesDAO();
        public int Create(PR_FixedRulesVO vo)
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
