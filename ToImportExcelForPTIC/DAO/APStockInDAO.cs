using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    public class APStockInDAO
    {
        Base b = new Base();
        public int Insert(APStockInVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_StockIn", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APStockInVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("AP_StockIn", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("AP_StockIn", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_StockIn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APStockInVO GetByID(int id)
        {
            APStockInVO vo = new APStockInVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APStockInVO()) as APStockInVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_StockIn", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

       
    }
}
