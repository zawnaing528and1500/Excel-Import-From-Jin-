using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class Approve_Employee_OrderDAO
    {
        Base b = new Base();
        public int Insert(Approve_Employee_OrderVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Approve_Employee_Order", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(Approve_Employee_OrderVO vo)
        {
            int categoryID = 0;
            try
            {
                b.Update("Approve_Employee_Order", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Approve_Employee_Order", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Approve_Employee_Order");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_Approve_Employee_Order
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Approve_Employee_Order");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Approve_Employee_Order", condition);
            }
            catch (Exception ex)
            { throw ex; }
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
        public Approve_Employee_OrderVO GetByID(int id)
        {
            Approve_Employee_OrderVO vo = new Approve_Employee_OrderVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new Approve_Employee_OrderVO()) as Approve_Employee_OrderVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Approve_Employee_Order", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public bool IsExist(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            { throw ex; }
        }

        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Approve_Employee_Order", start, end);
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
                dt = b.SelectTopRowByCondition("vw_Approve_Employee_Order", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
