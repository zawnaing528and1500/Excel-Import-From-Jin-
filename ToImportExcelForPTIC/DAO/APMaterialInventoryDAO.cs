using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    public class APMaterialInventoryDAO
    {
       
        Base b = new Base();
        public int Insert(APMaterialInventoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("APMaterial_Inventory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APMaterialInventoryVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("APMaterial_Inventory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("APMaterial_Inventory", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("APMaterial_Inventory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APMaterialInventoryVO GetByID(int id)
        {
            APMaterialInventoryVO vo = new APMaterialInventoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APMaterialInventoryVO()) as APMaterialInventoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("APMaterial_Inventory", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void updateInventoryQty(string query)
        {
            try
            {
                b.UpdateQuery("APMaterial_Inventory", query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
