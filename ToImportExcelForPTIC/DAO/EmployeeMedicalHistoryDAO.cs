using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeMedicalHistoryDAO
    {
        Base b = new Base();
        public int Insert(EmployeeMedicalHistoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_MedicalHistory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeMedicalHistoryVO vo)
        {
            int empMedicalHisID = 0;
            try
            {
                b.Update("Employee_MedicalHistory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empMedicalHisID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empMedicalHisID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee_MedicalHistory", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_MedicalHistory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeMedicalHistoryVO GetByID(int id)
        {
            EmployeeMedicalHistoryVO vo = new EmployeeMedicalHistoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeMedicalHistoryVO()) as EmployeeMedicalHistoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_MedicalHistory", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public void DeleteByEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_MedicalHistory", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
