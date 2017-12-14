using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class LeaveRequestDAO
    {
        Base b = new Base();
        public int Insert(LeaveRequestVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Leave_Request", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(LeaveRequestVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Leave_Request", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public int Delete(string Id)
        {
            int effectedRow = 1;
            try
            {
                b.Delete("Leave_Request", Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error:" + ex.ToString());
                effectedRow = -1;
            }
            return effectedRow;
        }

        public void UpdateRequireDays(string query)
        {
            try
            {
                b.UpdateQuery("Leave_Request", query);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Leave_Request", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Leave_Request");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllByView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Leave_Request");
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
                dt = b.Select("vw_Leave_Request", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByLeaveRequestInfoView(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_LeaveRequestInfo", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public LeaveRequestVO GetByID(int id)
        {
            LeaveRequestVO vo = new LeaveRequestVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new LeaveRequestVO()) as LeaveRequestVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Leave_Request", sql);
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

        public int InsertInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Leave_Request", "Used_Leave", vo, detalVoList, queryList, deleteList);
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
                lastInsertId = b.UpdateInfo_Detail("Leave_Request", "Used_Leave", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public DataTable SelectAllPIVOTquery()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_LeaveRequest_With_UsedLeave");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByPIVOTquery(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_LeaveRequest_With_UsedLeave",condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
