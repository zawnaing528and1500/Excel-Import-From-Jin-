using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OfficeAccessoriesInventoryDAO
    {
        Base b = new Base();
        public int Insert(OfficeAccessoriesInventoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OfficeAccessories_Inventory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public int Update(OfficeAccessoriesInventoryVO vo)
        {
            int inventoryID = 0;
            try
            {
                b.Update("OfficeAccessories_Inventory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                inventoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return inventoryID;
        }
        public OfficeAccessoriesInventoryVO GetByID(int id)
        {
            OfficeAccessoriesInventoryVO vo = new OfficeAccessoriesInventoryVO();
            DataTable dt = Select("OfficeAccessoriesID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OfficeAccessoriesInventoryVO()) as OfficeAccessoriesInventoryVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OfficeAccessories_Inventory", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("OfficeAccessories_Inventory", key);
        }
        public void updateInventoryQty(string query)
        {
            try
            {
                b.UpdateQuery("OfficeAccessories_Inventory", query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("OfficeAccessories_Inventory", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
