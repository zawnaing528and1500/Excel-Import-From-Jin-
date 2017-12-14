using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class OfficeAccessoriesIssueInfoDAO
    {
        Base b = new Base();
        public int Insert(OfficeAccessoriesIssueInfoVO vo)
        {
            int lastInsertId = 0;

            try
            {
                lastInsertId = b.Insert("OfficeAccessories_Issue_Info", b.ConvertColName(vo), b.ConvertValueList(vo));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("OfficeAccessories_Issue_Info", key);
        }

        public int Update(OfficeAccessoriesIssueInfoVO vo)
        {
            int vehiclePartID = 0;
            try
            {
                b.Update("OfficeAccessories_Issue_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                vehiclePartID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vehiclePartID;
        }
        public OfficeAccessoriesIssueInfoVO GetByID(int id)
        {
            OfficeAccessoriesIssueInfoVO vo = new OfficeAccessoriesIssueInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OfficeAccessoriesIssueInfoVO()) as OfficeAccessoriesIssueInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OfficeAccessories_Issue_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OfficeAccessories_Issue_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //vw_OfficeAccessoriesIssueInfo
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_OfficeAccessoriesIssueInfo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllCategory()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_OfficeAccessoriesIssue_XML_Path");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OfficeAccessoriesIssueInfo", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllViewByID(int id)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_OfficeAccessoriesIssueInfo", "ID=" + id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_OfficeAccessories_Issue_Info_Detail
        public DataTable SelectIssue_Info_Detail(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_OfficeAccessories_Issue_Info_Detail", condition);
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
                lastInsertId = b.CreateInfo_Detail("OfficeAccessories_Issue_Info", "OfficeAccessories_Issue_Detail", vo, detalVoList, queryList, deleteList);
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
                lastInsertId = b.UpdateInfo_Detail("OfficeAccessories_Issue_Info", "OfficeAccessories_Issue_Detail", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        #region Paging

        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_OfficeAccessoriesIssueInfo", start, end);
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
                dt = b.SelectTopRowByCondition("vw_OfficeAccessoriesIssueInfo", condition, count, start);

            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        #endregion

    }
}
