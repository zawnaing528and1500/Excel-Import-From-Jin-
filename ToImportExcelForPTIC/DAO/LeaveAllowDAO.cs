using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class LeaveAllowDAO
    {
        Base b = new Base();
        public int Insert(LeaveAllowVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Leave_Allow", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(LeaveAllowVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Leave_Allow", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Leave_Allow", key);
        }

        public bool isEntitled(string condition)
        {
            return b.isExist("Leave_Allow", condition);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Leave_Allow");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public LeaveAllowVO GetByID(int id)
        {
            LeaveAllowVO vo = new LeaveAllowVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new LeaveAllowVO()) as LeaveAllowVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Leave_Allow", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt = new DataTable();
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

        public void Delete(string id)
        {
            try
            {
                b.Delete("Leave_Allow", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Truncate()
        {
            try
            {
                b.Truncate("Leave_Allow");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
