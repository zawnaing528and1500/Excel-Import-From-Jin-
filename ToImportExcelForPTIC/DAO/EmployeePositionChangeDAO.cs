using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class EmployeePositionChangeDAO
    {
        Base b = new Base();
        public int Insert(EmployeePositionChangeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Position_Change", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeePositionChangeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Employee_Position_Change", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Position_Change", key);
        }

        public bool isExistByEmpID(string key)
        {
            return b.isExist("Employee_Position_Change", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Position_Change");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAll_vw_EmpPostChange_Info()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_EmpPostChange_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAll_vw_EmpPostChange_InfoByCondition(string Condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_EmpPostChange_Info", Condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public EmployeePositionChangeVO GetByID(int id)
        {
            EmployeePositionChangeVO vo = new EmployeePositionChangeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeePositionChangeVO()) as EmployeePositionChangeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Position_Change", sql);
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

        public void DeletebyEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Position_Change", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(string Id)
        {
            try
            {
                b.Delete("Employee_Position_Change",  Id);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public int getMaxID(string empId)
        {
            int id = 0;
            try
            {
               
              string value= b.SelectMaxIDByCondition("Employee_Position_Change","EmpID=" + empId);
              if (value != "")
              {
                  id = int.Parse(value);
              }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        //vw_EmpPostingChange_For_Increment_Employee

        public DataTable SelectAllViewForIncrement()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_EmpPostingChange_For_Increment_Employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllViewWithIncrementYear(DateTime payDate)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("Select *,DATEDIFF(Year,ChangeDate,'"+payDate.ToString("yyyy/M/dd")+"') AS IncrementYear From vw_EmpPostingChange_For_Increment_Employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Employee_Position_Change", "", vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public int UpdateInfo_Detail(int infoId, object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.UpdateInfo_Detail("Employee_Position_Change", "", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        #region For Paging
        public DataTable SelectTopRows(double count, int start)
        {
            DataTable dt = new DataTable();
            try
            {
              //  dt = b.SelectTopRows("vw_EmpPostChange_Info", count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_EmpPostChange_Info", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_EmpPostChange_Info", condition, count,start );
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_EmpPostChange_Info", condition);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        #endregion
    }
}
