using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class StateDivisionDAO
    {
        Base b = new Base();
        public int Insert(StateDivisionVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("StateDivision", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(StateDivisionVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("StateDivision", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("StateDivision", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("StateDivision");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public StateDivisionVO GetByID(int id)
        {
            StateDivisionVO vo = new StateDivisionVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new StateDivisionVO()) as StateDivisionVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("StateDivision", sql);
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

        public StateDivisionVO GetStateDivisionIDByName(string stateDivisionName)
        {
            StateDivisionVO vo = new StateDivisionVO();

            DataTable dt = SelectByDivisionName("StateDivisionName=N'" + stateDivisionName + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new StateDivisionVO()) as StateDivisionVO;
            return vo;
        }
        public DataTable SelectByDivisionName(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("StateDivisionName");
                val.Add(value);

                dt = b.SelectByCondition("StateDivision", col, val, "StateDivisionName=@StateDivisionName");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
