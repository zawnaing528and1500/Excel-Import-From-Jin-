using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OTRequestDetailDAO
    {
        Base b = new Base();
        public int Insert(OTRequestDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OT_Request_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId ;
        }

        public int Update(OTRequestDetailVO vo)
        {
            int detailID = 0;
            try
            {
                b.Update("OT_Request_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("OT_Request_Detail", key);
        }
        public OTRequestDetailVO GetByID(int id)
        {
            OTRequestDetailVO vo = new OTRequestDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OTRequestDetailVO()) as OTRequestDetailVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OT_Request_Detail", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByViewDetail(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OTRequestDetail", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OT_Request_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void updateIsDelete(string otRequestDetailID)
        {
            b.UpdateQuery("OT_Request_Detail", "isDeleted='True' WHERE ID =" + otRequestDetailID);
        }
        public void updateIsUsed(string isused, int otRequestDetailID)
        {
            b.UpdateQuery("OT_Request_Detail", "isUsed='"+ isused +"' WHERE ID =" + otRequestDetailID);
        }
    }
}
