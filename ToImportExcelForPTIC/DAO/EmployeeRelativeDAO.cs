using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeRelativeDAO
    {
        Base b = new Base();

        public void InsertWithNoObject(string queryString)
        {
            b.InsertWtithNoObject(queryString);
        }

        public int Insert(EmployeeRelativeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Relative", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeRelativeVO vo)
        {
            int empSpouseID = 0;
            try
            {
                b.Update("Employee_Relative", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                empSpouseID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empSpouseID;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee_Relative", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Relative", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Relative");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeRelativeVO GetByID(int id)
        {
            EmployeeRelativeVO vo = new EmployeeRelativeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeRelativeVO()) as EmployeeRelativeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Relative", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Relative", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
