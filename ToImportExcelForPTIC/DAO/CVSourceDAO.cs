using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
   public class CVSourceDAO
    {
        Base b = new Base();
        public int Insert(CVSourceVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("CVSource", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(CVSourceVO vo)
        {
            int cVSourceID = 0;
            try
            {
                b.Update("CVSource", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                cVSourceID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cVSourceID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("CVSource", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("CVSource");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public CVSourceVO GetByID(int id)
        {
            CVSourceVO vo = new CVSourceVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new CVSourceVO()) as CVSourceVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("CVSource", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByName(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("CVSource");
                val.Add(value);
                return b.SelectByCondition("CVSource", col, val, "CVSource=@CVSource");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
