using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AssetInDetailDAO
    {
        Base b = new Base();
        public int Insert(AssetInDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Asset_In_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssetInDetailVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Asset_In_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Asset_In_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Asset_In_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public AssetInDetailVO GetByID(int id)
        {
            AssetInDetailVO vo = new AssetInDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AssetInDetailVO()) as AssetInDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Asset_In_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByCodeNo(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("Name");
                val.Add(value);
                return b.SelectByCondition("Asset_In_Detail", col, val, "CodeNo=@Name");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateQuery(string query)
        {
            try
            {
                b.UpdateQuery("Asset_In_Detail", query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool isUsedCodeNo(string codeNo)
        {
            bool flg = false;
            try
            {
                DataTable dt = b.Select("Asset_In_Detail", "CodeNo='" + codeNo + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    flg = (bool)dr["Status"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;
        }
        public bool isUsedcodeNoByID(int assetInDetailID, string codeNo)
        {
            bool flg = false;
            try
            {
                DataTable dt = b.Select("Asset_In_Detail", "CodeNo='" + codeNo + "' AND ID <> "+ assetInDetailID);
                foreach (DataRow dr in dt.Rows)
                {
                    flg = (bool)dr["Status"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;
        }
    }
}
