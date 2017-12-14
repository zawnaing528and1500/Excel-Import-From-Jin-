using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_AllLog_DeleteDAO
    {
        Base b = new Base();
        public int Insert(FP_AllLog_DeleteVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_AllLog_Delete", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FP_AllLog_DeleteVO vo)
        {
            int deviceID = 0;
            try
            {
                b.Update("FP_AllLog_Delete", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                deviceID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deviceID;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("FP_AllLog_Delete", key);
        }
        public FP_AllLog_DeleteVO GetByID(int id)
        {
            FP_AllLog_DeleteVO vo = new FP_AllLog_DeleteVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FP_AllLog_DeleteVO()) as FP_AllLog_DeleteVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_AllLog_Delete", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_AllLog_Delete");
            }
            catch (Exception ex)
            {
                throw ex;
                //ex.
            }
            return dt;
        }
        public void Delete(string key)
        {
            try
            {
                b.Delete("FP_AllLog_Delete", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
