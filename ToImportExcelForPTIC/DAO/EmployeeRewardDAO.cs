using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeRewardDAO
    {
        Base b = new Base();
        public int Insert(EmployeeRewardVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Reward", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeRewardVO vo)
        {
            int empMedicalHisID = 0;
            try
            {
                b.Update("Employee_Reward", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Employee_Reward", key);
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_Reward", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Reward");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeRewardVO GetByID(int id)
        {
            EmployeeRewardVO vo = new EmployeeRewardVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeRewardVO()) as EmployeeRewardVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Reward", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Reward", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
