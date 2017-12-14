using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
   public class APIssueInfoDAO
    {
        Base b = new Base();
        public int Insert(APIssueInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_Issue_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APIssueInfoVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("AP_Issue_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("AP_Issue_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_Issue_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public APIssueInfoVO GetByID(int id)
        {
            APIssueInfoVO vo = new APIssueInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APIssueInfoVO()) as APIssueInfoVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_Issue_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("APIssueInfo_Join_Department_AND_Employee_View");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("APIssueInfo_Join_Department_AND_Employee_View",condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
       //APIssueInfo_Join_Department_AND_Employee_View
    }
}
