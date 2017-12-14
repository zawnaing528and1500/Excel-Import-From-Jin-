using System;
using System.Collections.Generic;

using System.Text;
using Toyo.Core;
using System.Data;

namespace Toyo.Core
{
    public class OfficeAccessoriesStockInBUS
    {
        Base b = new Base();
        OfficeAccessoriesStockInDAO dao = new OfficeAccessoriesStockInDAO();
        public int Create(OfficeAccessoriesStockInVO vo)
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
        public int CreateInfo_Detail(OfficeAccessoriesStockInVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
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
        public int UpdateInfo_Detail(int infoId, OfficeAccessoriesStockInVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
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
