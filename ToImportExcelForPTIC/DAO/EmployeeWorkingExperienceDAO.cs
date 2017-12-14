using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class EmployeeWorkingExperienceDAO
    {
        Base b = new Base();
        public int Insert(EmployeeWorkingExperienceVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_WorkingExperience", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeWorkingExperienceVO vo)
        {
            int empWorkExpID = 0;
            try
            {
                b.Update("Employee_WorkingExperience", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empWorkExpID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empWorkExpID;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_WorkingExperience", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool isExist(string key)
        {
            return b.CheckRec("Employee_WorkingExperience", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_WorkingExperience");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeWorkingExperienceVO GetByID(int id)
        {
            EmployeeWorkingExperienceVO vo = new EmployeeWorkingExperienceVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeWorkingExperienceVO()) as EmployeeWorkingExperienceVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_WorkingExperience", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_WorkingExperience", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
