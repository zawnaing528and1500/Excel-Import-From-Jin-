using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OfficeAccessoriesStockInDetailDAO
    {
        Base b = new Base();
        public int Insert(OfficeAccessoriesStockInDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OfficeAccessories_StockIn_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public int Update(OfficeAccessoriesStockInDetailVO vo)
        {
            int stockInDetailID = 0;
            try
            {
                b.Update("OfficeAccessories_StockIn_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                stockInDetailID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stockInDetailID;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("OfficeAccessories_StockIn_Detail", key);
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OfficeAccessories_StockIn_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectViewByCondition(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OfficeAccessories_Stock_In_Hand_Entry", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public OfficeAccessoriesStockInDetailVO GetByID(int id)
        {
            OfficeAccessoriesStockInDetailVO vo = new OfficeAccessoriesStockInDetailVO();
            DataTable dtPurchaseDetail = Select("ID=" + id + "");
            if (dtPurchaseDetail.Rows.Count > 0)
            {
                vo = b.ConvertObj(dtPurchaseDetail.Rows[0], new OfficeAccessoriesStockInDetailVO()) as OfficeAccessoriesStockInDetailVO;
            }
            return vo;
        }
    }
}
