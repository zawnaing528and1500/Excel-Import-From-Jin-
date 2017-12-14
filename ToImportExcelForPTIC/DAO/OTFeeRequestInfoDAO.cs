using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OTFeeRequestInfoDAO
    {
        Base b = new Base();
        public int Insert(OTFeesRequestInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OT_Fees_Request_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(OTFeesRequestInfoVO vo)
        {
            int infoID = 0;
            try
            {
                b.Update("OT_Fees_Request_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("OT_Fees_Request_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OT_Fees_Request_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public OTFeesRequestInfoVO GetByID(int id)
        {
            OTFeesRequestInfoVO vo = new OTFeesRequestInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OTFeesRequestInfoVO()) as OTFeesRequestInfoVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OT_Fees_Request_Info", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //vw_OT_Fees_Request_Info
        public DataTable SelectByViewInfo(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OT_Fees_Request_Info", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllInfoView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_OT_Fees_Request_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectInfoView(string date)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OT_Fees_Request_Info",date);
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
                dt = b.SelectTopRowsFinal("vw_OT_Fees_Request_Info", start, end);
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
                dt = b.SelectTopRowByCondition("vw_OT_Fees_Request_Info", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
