using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeQualificationDAO
    {
        Base b = new Base();
        public int Insert(EmployeeQualificationVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Qualification", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeQualificationVO vo)
        {
            int empQualifyID = 0;
            try
            {
                b.Update("Employee_Qualification", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empQualifyID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empQualifyID;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_Qualification", key);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Qualification", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Qualification");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeQualificationVO GetByID(int id)
        {
            EmployeeQualificationVO vo = new EmployeeQualificationVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeQualificationVO()) as EmployeeQualificationVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Qualification", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Qualification", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
