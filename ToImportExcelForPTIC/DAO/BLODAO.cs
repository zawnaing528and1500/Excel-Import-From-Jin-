using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class BLODAO
    {
        Base b = new Base();
        public int Insert(BLOVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("BLO", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(BLOVO vo)
        {
            int fineTypeID = 0;
            try
            {
                b.Update("BLO", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                fineTypeID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fineTypeID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("BLO", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("BLO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public BLOVO GetByID(int id)
        {
            BLOVO vo = new BLOVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new BLOVO()) as BLOVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("BLO", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByBLO(string value)
        {
            Base b = new Base();
            List<string> col = new List<string>();
            col.Add("Description");
            List<object> val = new List<object>();
            val.Add(value);

            return b.SelectByCondition("BLO", col, val, "Description=@Description");
        }
        public DataTable SelectByBLOandID(string Description, string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("Description");
                val.Add(Description);
                col.Add("ID");
                val.Add(ID);
                dt = b.SelectByCondition("BLO", col, val, "Description=@Description AND ID<>@ID");
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("BLO", " ISACTIVE=1 ", end-start+1, start);
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
                string condition2 = (condition == string.Empty)?" ISACTIVE=1 " :" ISACTIVE=1  and " + condition;
                dt = b.SelectTopRowByCondition("BLO", condition2 , count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
