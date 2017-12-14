using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeePunishmentDAO
    {
        Base b = new Base();
        public int Insert(EmployeePunishmentVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Punishment", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeePunishmentVO vo)
        {
            int empMedicalHisID = 0;
            try
            {
                b.Update("Employee_Punishment", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empMedicalHisID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empMedicalHisID;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_Punishment", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Punishment", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Punishment");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeePunishmentVO GetByID(int id)
        {
            EmployeePunishmentVO vo = new EmployeePunishmentVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeePunishmentVO()) as EmployeePunishmentVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Punishment", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Punishment", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
