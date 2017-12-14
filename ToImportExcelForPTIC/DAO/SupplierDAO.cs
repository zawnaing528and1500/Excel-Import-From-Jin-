using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class SupplierDAO
    {
        Base b = new Base();
        public int Insert(SupplierVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Supplier", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(SupplierVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Supplier", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Supplier", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Supplier");
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

        public DataTable SelectAllSupplierView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Supplier");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public SupplierVO GetByID(int id)
        {
            SupplierVO vo = new SupplierVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new SupplierVO()) as SupplierVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Supplier", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectBySupName(string value)
        {
            Base b = new Base();
            List<string> col = new List<string>();
            col.Add("SupplierName");
            List<object> val = new List<object>();
            val.Add(value);

            return b.SelectByCondition("Supplier", col, val, "SupplierName=@SupplierName");
        }

        public bool isExistBySupName(string value)
        {
            bool exist = false;
            Base b = new Base();
            DataTable dt = new DataTable();

            //List<string> col = new List<string>();
            //col.Add("SupplierName");
            //List<object> val = new List<object>();
            //val.Add(value);
            //DataTable dt = b.SelectByCondition("Supplier", col, val, "SupplierName=@SupplierName");
            try
            {
                dt = b.SelectByQuery("select * from Supplier where SupplierName=N'" + value + "'");
            }
            catch (Exception e)
            {
                throw e;
            }

            if (dt.Rows.Count > 0)
                exist = true;
            return exist;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Supplier", start, end);
            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }


        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Supplier", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
