using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FuelInventoryDAO
    {
        Base b = new Base();
        public int Insert(FuelInventoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Fuel_Inventory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FuelInventoryVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Fuel_Inventory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Fuel_Inventory", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Fuel_Inventory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public FuelInventoryVO GetByID(int id)
        {
            DataTable dt = Select("ID=" + id + "");
            FuelInventoryVO vo = b.ConvertObj(dt.Rows[0], new FuelInventoryVO()) as FuelInventoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Fuel_Inventory", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public FuelInventoryVO SelectByFuelStationID(string FuelStationID)
        {

            FuelInventoryVO vo = new FuelInventoryVO();
            DataTable dt = Select("FuelStationID=" + FuelStationID + "");
            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObj(dt.Rows[0], new FuelInventoryVO()) as FuelInventoryVO;
            }
            return vo;
        }

        public DataTable SelectAmountByFuelStationID(int id)
        {
            DataTable dt;
            try
            {
                //dt = b.SelectByQuery("SELECT SUM(BalanceAmount) BalanceAmt FROM Fuel_Inventory WHERE FuelStationID = " + id);
                //DataRow dr = dt.Rows[0];
                //balanceAmount = decimal.Parse(dr["BalanceAmt"].ToString());
                dt = b.SelectByQuery("SELECT * FROM Fuel_Inventory WHERE FuelStationID=" + id);
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

        public void UpdateQuery(string query)
        {
            try
            {
                b.UpdateQuery("Fuel_Inventory", query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
