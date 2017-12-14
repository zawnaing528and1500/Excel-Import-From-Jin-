using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
   public class FineTypeDAO
    {
        Base b = new Base();
        public int Insert(FineTypeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Fine_Type", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FineTypeVO vo)
        {
            int fineTypeID = 0;
            try
            {
                b.Update("Fine_Type", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                fineTypeID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fineTypeID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Fine_Type", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Fine_Type");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public FineTypeVO GetByID(int id)
        {
            FineTypeVO vo = new FineTypeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FineTypeVO()) as FineTypeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Fine_Type", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByFineType(string value)
        {
            Base b = new Base();
            List<string> col = new List<string>();
            col.Add("FineType");
            List<object> val = new List<object>();
            val.Add(value);

            return b.SelectByCondition("Fine_Type", col, val, "FineType=@FineType");
        }
        public DataTable SelectByFineTypeandID(string FineType, string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("FineType");
                val.Add(FineType);
                col.Add("ID");
                val.Add(ID);
                dt = b.SelectByCondition("Fine_Type", col, val, "FineType=@FineType AND ID<>@ID");
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("Fine_Type", start, end);
            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }


        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("Fine_Type", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
