using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AgencyDAO
    {
        Base b = new Base();
        public int Insert(AgencyVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Agency", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AgencyVO vo)
        {
            int categoryID = 0;
            try
            {
                b.Update("Agency", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                categoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Agency", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Agency");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public AgencyVO GetByID(int id)
        {
            AgencyVO vo = new AgencyVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AgencyVO()) as AgencyVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Agency", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByAgencyName(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("AgencyName");
                val.Add(value);
                return b.SelectByCondition("Agency", col, val, "AgencyName=@AgencyName");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("Agency", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("Agency", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
