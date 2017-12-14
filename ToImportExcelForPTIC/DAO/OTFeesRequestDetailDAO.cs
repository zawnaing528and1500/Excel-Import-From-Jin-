using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OTFeesRequestDetailDAO
    {
        Base b = new Base();
        public int Insert(OTFeesRequestDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OT_Fees_Request_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(OTFeesRequestDetailVO vo)
        {
            int detailID = 0;
            try
            {
                b.Update("OT_Fees_Request_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                detailID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detailID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("OT_Fees_Request_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OT_Fees_Request_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OT_Fees_Request_Detail", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_OTFeesRequest_Detail
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OTFeesRequest_Detail", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void updateIsDelete(string otRequestDetailID)
        {
            b.UpdateQuery("OT_Fees_Request_Detail", "isDeleted='True' WHERE OTRequestDetailID =" + otRequestDetailID);
        }
    }
}
