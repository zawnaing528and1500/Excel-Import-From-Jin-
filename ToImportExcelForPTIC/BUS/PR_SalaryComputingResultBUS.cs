using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_SalaryComputingResultBUS
    {
        Base b = new Base();
        PR_SalaryComputingResultDAO dao = new PR_SalaryComputingResultDAO();
        public int Create(PR_SalaryComputingResultVO vo)
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

        public int Create_Object_List(List<object> voList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
                id = b.Create_Object_List("PR_SalaryComputingResult", voList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
    }
}
