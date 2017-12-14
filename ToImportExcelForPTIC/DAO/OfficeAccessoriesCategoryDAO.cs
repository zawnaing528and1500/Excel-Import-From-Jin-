using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class OfficeAccessoriesCategoryDAO
    {
        Base b = new Base();
        public int Insert(OfficeAccessoriesCategoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("OfficeAccessories_Category", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(OfficeAccessoriesCategoryVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("OfficeAccessories_Category", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("OfficeAccessories_Category", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OfficeAccessories_Category");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public OfficeAccessoriesCategoryVO GetByID(int id)
        {
            OfficeAccessoriesCategoryVO vo = new OfficeAccessoriesCategoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObj(dt.Rows[0], new OfficeAccessoriesCategoryVO()) as OfficeAccessoriesCategoryVO;

            }
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OfficeAccessories_Category", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
