using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_FixedRulesAssignBUS
    {
        Base b = new Base();
        PR_FixedRulesAssignDAO dao = new PR_FixedRulesAssignDAO();
        public int Create(PR_FixedRulesAssignVO vo)
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
        public void Delete(string condition)
        {
            try
            {
                dao.DeleteByCondition(condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
