using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class PR_Salary_For_Resign_EmployeeDAO
    {

        Base b = new Base();
        public int Insert(PR_Salary_For_Resign_EmployeeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_Salary_For_Resign_Employee", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PR_Salary_For_Resign_EmployeeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_Salary_For_Resign_Employee", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_Salary_For_Resign_Employee", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_Salary_For_Resign_Employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public PR_Salary_For_Resign_EmployeeVO GetByID(int id)
        {
            PR_Salary_For_Resign_EmployeeVO vo = new PR_Salary_For_Resign_EmployeeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_Salary_For_Resign_EmployeeVO()) as PR_Salary_For_Resign_EmployeeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_Salary_For_Resign_Employee", sql);
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
        //vw_PR_Salary_For_Resign_Employee
        public DataTable SelectResignEmployee(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_PR_Salary_For_Resign_Employee", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectResignAllEmployeeByCondition(string sql)
        {
            DataTable dt = new DataTable();
            try
            {                
                dt = b.Select("vw_PR_Salary_For_Resign_Employee_List", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectResignAllEmployee()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_PR_Salary_For_Resign_Employee_List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
