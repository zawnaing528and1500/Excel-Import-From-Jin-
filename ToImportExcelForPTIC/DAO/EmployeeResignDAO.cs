using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class EmployeeResignDAO
    {
        Base b = new Base();
        public int Insert(EmployeeResignVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Resign", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeResignVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("Employee_Resign", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Employee_Resign", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Resign");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeResignVO GetByID(int id)
        {
            EmployeeResignVO vo = new EmployeeResignVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeResignVO()) as EmployeeResignVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Resign", sql);
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
        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Resign", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectViewByCondition(string condition)
        {
            //vw_ResignList
            DataTable dt= new DataTable();
            try
            {
                dt = b.Select("vw_ResignList", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_ResignList", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public EmployeeResignVO GetByEmpID(int empId)
        {
            EmployeeResignVO vo = new EmployeeResignVO();
            DataTable dt = Select("EmpID=" + empId + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeResignVO()) as EmployeeResignVO;
            return vo;
        }

        public DataTable checkisResignByDateandID(int EmpId, DateTime date)
        {
           DataTable dt = new DataTable();
            //try
            //{
            //    dt= Select(
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return dt;
        }
    }
}
