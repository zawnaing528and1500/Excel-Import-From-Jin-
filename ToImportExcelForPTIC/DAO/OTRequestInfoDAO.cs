using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OTRequestInfoDAO
    {
        Base b = new Base();
        public int Insert(OTRequestInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OT_Request_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(OTRequestInfoVO vo)
        {
            int infoID = 0;
            try
            {
                b.Update("OT_Request_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                infoID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return infoID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("OT_Request_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OT_Request_Info");
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
                dt = b.SelectAll("vw_OT_Request_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectView(string date)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_OT_Request_Info", date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public OTRequestInfoVO GetByID(int id)
        {
            OTRequestInfoVO vo = new OTRequestInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OTRequestInfoVO()) as OTRequestInfoVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OT_Request_Info", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_OTRequest_Info_Detail_view
        public DataTable SelectInfoDetail(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OTRequest_Info_Detail_view", condition);
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
                dt = b.Select("vw_OT_Request_Info", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_OT_Request_Info", start, end);
            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }


        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_OT_Request_Info", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
