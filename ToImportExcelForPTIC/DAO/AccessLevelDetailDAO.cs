using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AccessLevelDetailDAO
    {
        Base b = new Base();
        public int Insert(AccessLevelDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AccessLevel_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AccessLevelDetailVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("AccessLevel_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("AccessLevel_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AccessLevel_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public AccessLevelDetailVO GetByID(int id)
        {
            AccessLevelDetailVO vo = new AccessLevelDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AccessLevelDetailVO()) as AccessLevelDetailVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AccessLevel_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("AccessLevel_Detail", key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataTable SelectAllView()
        //{
        //    DataTable dt;
        //    try
        //    {
        //        dt = b.SelectAll("APIssueInfo_Join_Department_AND_Employee_View");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
    }
}
