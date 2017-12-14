using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class UOMDAO
    {
        Base b = new Base();
        public int Insert(UOMVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("UOM", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(UOMVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("UOM", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("UOM", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("UOM");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public UOMVO GetByID(int id)
        {
            UOMVO vo = new UOMVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObj(dt.Rows[0], new UOMVO()) as UOMVO;
            }
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("UOM", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByUOMName(string value)
        {
            DataTable dt = new DataTable();
            Base b = new Base();
            //List<string> col = new List<string>();
            //col.Add("UOMName");
            //List<object> val = new List<object>();
            //val.Add(value);
            //return b.SelectByCondition("UOM", col, val, "UOMName=@UOMName");
            try
            {
                dt = b.SelectByQuery("select * from UOM where UOMName=N'" + value + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
    }
}
