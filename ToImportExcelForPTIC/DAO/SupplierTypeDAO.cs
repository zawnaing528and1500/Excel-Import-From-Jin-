using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class SupplierTypeDAO
    {
        Base b = new Base();
        public int Insert(SupplierTypeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Supplier_Type", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(SupplierTypeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Supplier_Type", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Supplier_Type", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Supplier_Type");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public SupplierTypeVO GetByID(int id)
        {
            SupplierTypeVO vo = new SupplierTypeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new SupplierTypeVO()) as SupplierTypeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Supplier_Type", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
