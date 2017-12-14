using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class OfficeAccessoriesDAO
    {
        Base b = new Base();
        public int Insert(OfficeAccessoriesVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OfficeAccessories", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(OfficeAccessoriesVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("OfficeAccessories", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("OfficeAccessories", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OfficeAccessories");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public OfficeAccessoriesVO GetByID(int id)
        {
            OfficeAccessoriesVO vo = new OfficeAccessoriesVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OfficeAccessoriesVO()) as OfficeAccessoriesVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OfficeAccessories", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByOfficeAccName(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("Name");
                val.Add(value);
                return b.SelectByCondition("vw_OfficeAccessories", col, val, "Name=@Name");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByCondition(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("Name");
                val.Add(value);
                return b.SelectByCondition("OfficeAccessories", col, val, "Name=@Name");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetName(string query)
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

        public void Delete(string id)
        {
            try
            {
                b.Delete("OfficeAccessories", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_OfficeAccessories");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_OfficeAccessories", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("OfficeAccessories", "OfficeAccessories_Inventory", vo, detalVoList, queryList, deleteList);
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
                lastInsertId = b.UpdateInfo_Detail("OfficeAccessories", "", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public void QueryList(List<String> queryList)
        {
            try
            {
                b.Transaction_QueryList(queryList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectStockInHandViewByCondition(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_OfficeAccessoriesStockInHand_Final", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllStockInHandView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_OfficeAccessoriesStockInHand_Final");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_OfficeAccessories", start, end);
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
                dt = b.SelectTopRowByCondition("vw_OfficeAccessories", condition, count, start);

            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
