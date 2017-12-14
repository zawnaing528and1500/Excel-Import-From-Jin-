using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class EmployeeApprovalInfoDAO
    {
        Base b = new Base();
        public int Insert(EmployeeApprovalInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Approval_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeApprovalInfoVO vo)
        {
            int infoID = 0;
            try
            {
                b.Update("Employee_Approval_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                infoID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return infoID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Approval_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Approval_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_Employee_Approval_Info
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Employee_Approval_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByView(string Condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Employee_Approval_Info", Condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public bool IsExist(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public EmployeeApprovalInfoVO GetByID(int id)
        {
            EmployeeApprovalInfoVO vo = new EmployeeApprovalInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeApprovalInfoVO()) as EmployeeApprovalInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Approval_Info", sql);
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
                dt = b.SelectTopRowsFinal("vw_Employee_Approval_Info", start, end);
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
                dt = b.SelectTopRowByCondition("vw_Employee_Approval_Info", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
