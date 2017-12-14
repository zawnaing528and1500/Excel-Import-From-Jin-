using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    public class APIssueDetailDAO
    {
        Base b = new Base();
        public int Insert(APIssueDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_Issue_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APIssueDetailVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("AP_Issue_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("AP_Issue_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_Issue_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public APIssueDetailVO GetByID(int id)
        {
            APIssueDetailVO vo = new APIssueDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APIssueDetailVO()) as APIssueDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_Issue_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //APIssueDetail_Join_APMaterial_AND_APSubCategory_View
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("APIssueDetail_Join_APMaterial_AND_APSubCategory_View", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
