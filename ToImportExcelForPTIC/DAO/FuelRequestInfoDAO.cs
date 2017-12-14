using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FuelRequestInfoDAO
    {
        Base b = new Base();
        public int Insert(FuelRequestInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Fuel_Request_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FuelRequestInfoVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Fuel_Request_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Fuel_Request_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Fuel_Request_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public FuelRequestInfoVO GetByID(int id)
        {
            FuelRequestInfoVO vo = new FuelRequestInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FuelRequestInfoVO()) as FuelRequestInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Fuel_Request_Info", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByRequestNo(string requestNo)
        {
            DataTable dt = new DataTable();
            try 
            {
                dt = b.SelectByQuery("SELECT * FROM Fuel_Request_Info WHERE RequestNo='" + requestNo + "'");
            }
            catch (SqlException ex)
            { 
                throw ex; 
            }
            return dt;
        }

        public DataTable SelectRequestNo()
        {
            DataTable dt = new DataTable();
            try 
            {
                dt = b.SelectByQuery("SELECT * FROM Fuel_Request_Info WHERE ID NOT IN(SELECT FuelRequestID FROM Fuel_Usage_Entry)");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
