using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class APCategoryDAO
    {
        Base b = new Base();
        public int Insert(APCategoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_Category", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APCategoryVO vo)
        {
            int categoryID = 0;
            try
            {
                b.Update("AP_Category", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("AP_Category", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_Category");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APCategoryVO GetByID(int id)
        {
            APCategoryVO vo = new APCategoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APCategoryVO()) as APCategoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_Category", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByCategory(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                //if (value != "")
                //{
                //    col.Add("CategoryName");
                //    val.Add(value);
                //    return b.SelectByCondition("AP_Category", col, val, "CategoryName=@CategoryName");
                //}
                dt = b.SelectByQuery("select * from AP_Category where CategoryName=N'" + value + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
