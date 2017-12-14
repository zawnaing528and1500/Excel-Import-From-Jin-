using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class LeaveDAO
    {
        Base b = new Base();
        public int Insert(LeaveVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Leave", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(LeaveVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Leave", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Leave", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Leave");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public LeaveVO GetByID(int id)
        {
            LeaveVO vo = new LeaveVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new LeaveVO()) as LeaveVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Leave", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByLeaveName(string value)
        {
            Base b = new Base();
            List<string> col = new List<string>();
            col.Add("LeaveName");
            List<object> val = new List<object>();
            val.Add(value);

            return b.SelectByCondition("Leave", col, val, "LeaveName=@LeaveName");
        }
        public LeaveVO GetByLeaveName(string value)
        {
            LeaveVO vo = new LeaveVO();
            DataTable dt = b.SelectByQuery("Select * From Leave Where LeaveName=N'" + value + "'");
            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObj(dt.Rows[0], new LeaveVO()) as LeaveVO;
            }
            return vo;
        }
    }
}
