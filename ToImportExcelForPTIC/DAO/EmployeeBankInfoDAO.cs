using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeBankInfoDAO
    {
        Base b = new Base();
        public int Insert(EmployeeBankInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Bank_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeBankInfoVO vo)
        {
            int empBankInfoID = 0;
            try
            {
                b.Update("Employee_Bank_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empBankInfoID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empBankInfoID;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_Bank_Info", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Bank_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Bank_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeBankInfoVO GetByID(int id)
        {
            EmployeeBankInfoVO vo = new EmployeeBankInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeBankInfoVO()) as EmployeeBankInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Bank_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeleteByEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Bank_Info", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
