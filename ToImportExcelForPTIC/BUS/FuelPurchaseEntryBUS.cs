using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelPurchaseEntryBUS
    {
        Base b = new Base();
        FuelPurchaseEntryDAO dao = new FuelPurchaseEntryDAO();
        public int Create(FuelPurchaseEntryVO vo)
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
        public void updateQuery(string query)
        {
            dao.UpdateQuery(query);
        }
        public int CreateInfo_Detail(FuelPurchaseEntryVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
                id = dao.CreateInfo_Detail(vo, detalVoList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
        public int UpdateInfo_Detail(int infoId, FuelPurchaseEntryVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
                id = dao.UpdateInfo_Detail(infoId, vo, detalVoList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
    }
}
