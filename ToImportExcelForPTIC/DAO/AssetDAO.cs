using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AssetDAO
    {
        Base b = new Base();
        public int Insert(AssetVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Asset", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssetVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("Asset", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                AssetID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return AssetID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Asset", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Asset");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public AssetVO GetByID(int id)
        {
            AssetVO vo = new AssetVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AssetVO()) as AssetVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Asset", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByAssetName(string value)
        {
            try 
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("Name");
                val.Add(value);
                return b.SelectByCondition("vw_Asset", col, val, "AssetName=@Name");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByAssetID(int value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("Name");
                val.Add(value);
                return b.SelectByCondition("vw_Asset", col, val, "ID=@Name");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
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

        public DataTable SelectByCondition(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("AssetName");
                val.Add(value);
                return b.SelectByCondition("Asset", col, val, "AssetName=@AssetName");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllByView(string viewName)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll(viewName);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectViewByCondition(string viewName, string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select(viewName, condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Asset", start, end);
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
                dt = b.SelectTopRowByCondition("vw_Asset", condition, count, start);

            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
