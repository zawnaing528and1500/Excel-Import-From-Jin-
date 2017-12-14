using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class DeviceDAO 
    {
        Base b = new Base();
        public int Insert(DeviceVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_Device", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(DeviceVO vo)
        {
            int deviceID = 0;
            try
            {
                b.Update("FP_Device", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("FP_Device", key);
        }
        public DeviceVO GetByID(int id)
        {
            DeviceVO vo = new DeviceVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new DeviceVO()) as DeviceVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_Device", sql);
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
                dt = b.SelectAll("FP_Device");
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
                b.Delete("FP_Device", key);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
