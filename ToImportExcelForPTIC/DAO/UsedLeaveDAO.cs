using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class UsedLeaveDAO
    {
        Base b = new Base();
        public int Insert(UsedLeaveVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Used_Leave", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(UsedLeaveVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Used_Leave", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public int DeleteByCondition(string Id)
        {
            int effectedRow = 1;
            try
            {
                b.DeleteByCondition("Used_Leave", "LeaveRequestID="+ Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error:" + ex.ToString());
                effectedRow = -1;
            }
            return effectedRow;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Used_Leave", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Used_Leave");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public UsedLeaveVO GetByID(int id)
        {
            UsedLeaveVO vo = new UsedLeaveVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new UsedLeaveVO()) as UsedLeaveVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Used_Leave", sql);
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
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_UsedLeave", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_UsedLeave");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_UsedLeave", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_Leave_For_Montly_Attendance
        public DataTable SelectByViewForMonthlyAtt(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Leave_For_Montly_Attendance", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
