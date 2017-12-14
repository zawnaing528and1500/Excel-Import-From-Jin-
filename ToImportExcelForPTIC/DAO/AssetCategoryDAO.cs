using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AssetCategoryDAO
    {
        Base b = new Base();
        public int Insert(AssetCategoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Asset_Category", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssetCategoryVO vo)
        {
            int townID = 0;
            try
            {
                b.Update("Asset_Category", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                townID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return townID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Asset_Category", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Asset_Category");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public AssetCategoryVO GetByID(int id)
        {
            AssetCategoryVO vo = new AssetCategoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AssetCategoryVO()) as AssetCategoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Asset_Category", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
   
    }
}
