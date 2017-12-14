using System;
using System.Collections.Generic;

using System.Text;
using Toyo.Core;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class TripAssignDAO
    {
        Base b = new Base();
        public int Insert(TripAssignVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Trip_Assign", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(TripAssignVO vo)
        {
            int categoryID = 0;
            try
            {
                b.Update("Trip_Assign", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                categoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Trip_Assign", key);
        }

        public bool isExistEmp(string key)
        {
            return b.isExist("Trip_Assign", key);
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("Trip_Assign", id);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Trip_Assign");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public TripAssignVO GetByID(int id)
        {
            TripAssignVO vo = new TripAssignVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TripAssignVO()) as TripAssignVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Trip_Assign", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Trip_Assign",condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectAllByView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Trip_Assign");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_Trip_Assign", condition);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectByTripName(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                //col.Add("TripName");
                //val.Add(value);
                //dt = b.SelectByCondition("Trip_Assign", col, val, "TripName=@TripName");
                dt = b.SelectByQuery("select * from Trip_Assign where TripName=N'" + value + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllActivity()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_TripAssign_ForActivity");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelecActivityByCondition(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_TripAssign_ForActivity", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //Ywet Nu Wai Tin
        #region For Paging
        
        // For Trip_Assign
        public DataTable SelectTripAssignTopRows(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Trip_Assign", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        // For Trip_Assign_Activity
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_TripAssign_ForActivity", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRows(double count, int start)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRows("vw_TripAssign_ForActivity", count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        // Search Trip_Assign_Activity by Condition
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_TripAssign_ForActivity", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        // Search Trip_Assign by Condition
        public DataTable SelectTripAssignByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Trip_Assign", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

       
        //public DataTable SelectByCondition(string value, int ID)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        List<string> col = new List<string>();
        //        List<object> val = new List<object>();
        //        if (value == "" && ID == 0)
        //        {
        //            return b.SelectAll("vw_TripAssign");
        //        }
        //        else if (value != "" && ID == 0)
        //        {
        //            col.Add("EmpName");
        //            val.Add(value);
        //            return b.SelectByCondition("vw_TripAssign", col, val, "EmpName=@EmpName");
        //        }
        //        else if (value == "" && ID != 0)
        //        {
        //            col.Add("EmpName");
        //            val.Add(value);
        //            return b.SelectByCondition("vw_TripAssign", col, val, "DeptID='"+ ID +"'");
        //        }
        //        else if (value != "" && ID != 0) 
        //        {
        //            col.Add("EmpName");
        //            val.Add(value);
        //            return b.SelectByCondition("vw_TripAssign", col, val, "EmpName=@EmpName AND DeptID='" + ID + "'");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
    }
}
