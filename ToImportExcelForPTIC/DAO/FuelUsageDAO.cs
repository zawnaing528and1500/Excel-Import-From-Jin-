using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FuelUsageDAO
    {
        Base b = new Base();
        public int Insert(FuelUsageVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Fuel_Usage_Entry", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FuelUsageVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Fuel_Usage_Entry", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Fuel_Usage_Entry", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Fuel_Usage_Entry");
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
                dt = b.SelectAll("vw_Fuel_Usage_Entry");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllGenerator()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Generator");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public FuelUsageVO GetByID(int id)
        {
            FuelUsageVO vo = new FuelUsageVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FuelUsageVO()) as FuelUsageVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Fuel_Usage_Entry", sql);
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
        //to select last issued fuel gallons
        public FuelUsageVO SelectByVehicleID(string query)
        {
            FuelUsageVO vo = new FuelUsageVO();
            DataTable dt = SelectByQuery(query);
            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObj(dt.Rows[0], new FuelUsageVO()) as FuelUsageVO;
                return vo;
            }
            return vo;
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Fuel_Usage_Entry", "", vo, detalVoList, queryList, deleteList);
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
                lastInsertId = b.UpdateInfo_Detail("Fuel_Usage_Entry", "", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(string tableName, int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal(tableName, start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRowByCondition(string tableName, double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition(tableName, condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }



}
