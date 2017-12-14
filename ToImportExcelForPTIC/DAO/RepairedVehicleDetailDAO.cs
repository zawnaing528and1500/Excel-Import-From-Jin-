using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class RepairedVehicleDetailDAO
    {
        Base b = new Base();
        public int Insert(RepairedVehicleDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Repaired_Vehicle_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(RepairedVehicleDetailVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Repaired_Vehicle_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Repaired_Vehicle_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Repaired_Vehicle_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public RepairedVehicleDetailVO GetByID(int id)
        {
            RepairedVehicleDetailVO vo = new RepairedVehicleDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new RepairedVehicleDetailVO()) as RepairedVehicleDetailVO;
            return vo;
        }

        public DataTable GetByRepairedVehicleID(int id)
        {
            DataTable dt;
            try 
            {
                dt = Select("RepairedVehicleID=" + id + "");
            }
            catch (SqlException ex)
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
                dt = b.Select("Repaired_Vehicle_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
