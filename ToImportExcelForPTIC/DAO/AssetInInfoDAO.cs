using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AssetInInfoDAO
    {
        Base b = new Base();
        public int Insert(AssetInInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Asset_In_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssetInInfoVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Asset_In_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Asset_In_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Asset_In_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Asset_In_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Asset_In_Info", "Asset_In_Detail", vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public int UpdateInfo_Detail(int infoId, object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.UpdateInfo_Detail("Asset_In_Info", "Asset_In_Detail", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public AssetInInfoVO GetByID(int id)
        {
            AssetInInfoVO vo = new AssetInInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AssetInInfoVO()) as AssetInInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Asset_In_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Asset_In_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Asset_In_Info", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
