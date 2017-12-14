using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class EmployeePhysicalExaminationDAO
    {
        Base b = new Base();
        public int Insert(EmployeePhysicalExaminationVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_PhysicalExamination", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeePhysicalExaminationVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("Employee_PhysicalExamination", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Employee_PhysicalExamination", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_PhysicalExamination");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeePhysicalExaminationVO GetByID(int id)
        {
            EmployeePhysicalExaminationVO vo = new EmployeePhysicalExaminationVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeePhysicalExaminationVO()) as EmployeePhysicalExaminationVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_PhysicalExamination", sql);
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
        public void DeleteByEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_PhysicalExamination", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
