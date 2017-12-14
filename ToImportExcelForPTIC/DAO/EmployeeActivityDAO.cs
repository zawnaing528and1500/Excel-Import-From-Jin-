using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class EmployeeActivityDAO
    {
        Base b = new Base();
        public int Insert(EmployeeActivityVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Activity", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeActivityVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Employee_Activity", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Employee_Activity", key);
        }

        public bool isExistEmp(string key)
        {
            return b.isExist("Employee_Activity", key);
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("Employee_Activity", id);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Activity");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeActivityVO GetByID(int id)
        {
            EmployeeActivityVO vo = new EmployeeActivityVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeActivityVO()) as EmployeeActivityVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Activity", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
