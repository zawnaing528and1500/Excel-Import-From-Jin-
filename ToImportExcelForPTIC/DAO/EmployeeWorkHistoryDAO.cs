using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeWorkHistoryDAO
    {
        Base b = new Base();
        public int Insert(EmployeeWorkHistoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_WorkHistory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeWorkHistoryVO vo)
        {
            int empWorkHisID = 0;
            try
            {
                b.Update("Employee_WorkHistory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empWorkHisID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empWorkHisID;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_WorkHistory", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool isExist(string key)
        {
            return b.CheckRec("Employee_WorkHistory", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_WorkHistory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeWorkHistoryVO GetByID(int id)
        {
            EmployeeWorkHistoryVO vo = new EmployeeWorkHistoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeWorkHistoryVO()) as EmployeeWorkHistoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_WorkHistory", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //TblWorkHistoryView
        public DataTable SelectWorkHistoryByEmpID(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("TblWorkHisotryFinalView", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
