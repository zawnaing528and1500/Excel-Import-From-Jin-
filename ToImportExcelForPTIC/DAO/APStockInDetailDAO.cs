using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
   public class APStockInDetailDAO
    {
        Base b = new Base();
        public int Insert(APStockInDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_StockIn_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APStockInDetailVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("AP_StockIn_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AP_StockIn_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_StockIn_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APStockInDetailVO GetByID(int id)
        {
            APStockInDetailVO vo = new APStockInDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APStockInDetailVO()) as APStockInDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_StockIn_Detail", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
