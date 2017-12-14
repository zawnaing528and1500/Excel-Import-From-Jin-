using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class RepairedVehicleDAO
    {
        Base b = new Base();
        public int Insert(RepairedVehicleVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Repaired_Vehicle", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(RepairedVehicleVO vo)
        {
            int repairedVehicleID = 0;
            try
            {
                b.Update("Repaired_Vehicle", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                repairedVehicleID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return repairedVehicleID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Repaired_Vehicle", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Repaired_Vehicle");
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
                dt = b.SelectAll("vw_Repaired_Vehicle_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //Paging (29.7.2015)
        public DataTable SelectTopRows(int size, int start)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRows("vw_Repaired_Vehicle_Info", size, start);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Repaired_Vehicle_Info", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectTopRowsByCondition(int size, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Repaired_Vehicle_Info", condition, size, start);
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
                dt = b.Select("vw_Repaired_Vehicle_Info", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public RepairedVehicleVO GetByID(int id)
        {
            RepairedVehicleVO vo = new RepairedVehicleVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new RepairedVehicleVO()) as RepairedVehicleVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Repaired_Vehicle", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByQuery(string query)
        {
            Base b = new Base();
            return b.SelectByQuery(query);
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Repaired_Vehicle", "Repaired_Vehicle_Detail", vo, detalVoList, queryList, deleteList);
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
                lastInsertId = b.UpdateInfo_Detail("Repaired_Vehicle", "Repaired_Vehicle_Detail", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public void DeleteByRepairedVehicleId(string RepairedVehicleId)
        {
            try
            {
                List<String> queryList = new List<string>();
                string detail = "Delete From Repaired_Vehicle_Detail Where RepairedVehicleID=" + RepairedVehicleId;
                queryList.Add(detail);

                string master = "Delete From Repaired_Vehicle Where ID=" + RepairedVehicleId;
                queryList.Add(master);
                
                Base b = new Base();
                b.Transaction_QueryList(queryList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
