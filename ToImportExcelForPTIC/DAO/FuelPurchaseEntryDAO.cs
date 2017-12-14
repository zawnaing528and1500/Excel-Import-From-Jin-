using System;
using System.Collections.Generic;

using System.Text;
using Toyo.Core;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FuelPurchaseEntryDAO
    {
        Base b = new Base();
        public int Insert(FuelPurchaseEntryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Fuel_Purchase_Entry", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FuelPurchaseEntryVO vo)
        {
            int fuelPurchaseID = 0;
            try
            {
                b.Update("Fuel_Purchase_Entry", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                fuelPurchaseID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fuelPurchaseID;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("Fuel_Purchase_Entry", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Fuel_Purchase_Entry");
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
                dt = b.SelectAll("vw_Fuel_Purchase_Entry");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllViewByID(int id)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_Fuel_Purchase_Entry" ,"ID="+ id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllViewByCondition(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_Fuel_Purchase_Entry", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public FuelPurchaseEntryVO GetByID(int id)
        {
            FuelPurchaseEntryVO vo = new FuelPurchaseEntryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FuelPurchaseEntryVO()) as FuelPurchaseEntryVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Fuel_Purchase_Entry", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public decimal SelectAmountByFuelStationID(int id)
        {
            decimal balanceAmount = 0;
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT SUM(BalanceAmount) BalanceAmt FROM Fuel_Purchase_Entry WHERE BalanceAmount > 0 AND FuelStationID = "+ id);
                DataRow dr = dt.Rows[0];
                balanceAmount = decimal.Parse(dr["BalanceAmt"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return balanceAmount;
        }

        public int SelectMinID(string query)
        {
            int MinID = 0;
            try
            {
                DataTable dt = b.getColumn("Fuel_Purchase_Entry", "Min(ID)ID", query);
                DataRow dr = dt.Rows[0];
                MinID = int.Parse(dr["ID"].ToString());
            }
            catch (Exception ex)
            { throw ex; }
            return MinID;
        }

        public void UpdateQuery(string query)
        {
            try
            {
                b.UpdateQuery("Fuel_Purchase_Entry", query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Fuel_Purchase_Entry", "", vo, detalVoList, queryList, deleteList);
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
                lastInsertId = b.UpdateInfo_Detail("Fuel_Purchase_Entry", "", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Fuel_Purchase_Entry", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Fuel_Purchase_Entry", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
