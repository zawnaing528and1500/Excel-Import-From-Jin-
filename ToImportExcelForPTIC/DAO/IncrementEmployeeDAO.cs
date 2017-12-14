using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using Toyo.Core;

namespace Toyo.Core
{
    public class IncrementEmployeeDAO
    {
        Base b = new Base();
        public int Insert(IncrementEmployeeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Increment_Employee", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(IncrementEmployeeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Increment_Employee", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }
        public int UpdateWithEmpIDAndDate(IncrementEmployeeVO vo)
        {
            int ID = 0;
            try
            {
                b.UpdateByConditon("Increment_Employee", "IncrementDate= '" + vo.IncrementDate + "' and EmpID = " + vo.EmpID + "", b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Increment_Employee", key);
        }

        public bool isExistByMonthYear(string key)
        {
            return b.isExist("Increment_Employee", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Increment_Employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public IncrementEmployeeVO GetByID(int id)
        {
            IncrementEmployeeVO vo = new IncrementEmployeeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new IncrementEmployeeVO()) as IncrementEmployeeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Increment_Employee", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        //vw_Increment_Employee
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Increment_Employee", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAllView( )
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Increment_Employee");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void ClearData(int month, int year)
        {
            try
            {
                b.DeleteByCondition("Increment_Employee", "Month(IncrementDate)=" + month + " AND Year(IncrementDate)=" + year);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
