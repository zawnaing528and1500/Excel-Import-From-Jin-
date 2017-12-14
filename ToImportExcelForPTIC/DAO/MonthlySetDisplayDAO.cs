using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class MonthlySetDisplayDAO
    {
        Base b = new Base();
        public int Insert(MonthlySetDisplayVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_MonthlySetDisplayFormat", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(MonthlySetDisplayVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("FP_MonthlySetDisplayFormat", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("FP_MonthlySetDisplayFormat", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_MonthlySetDisplayFormat");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public MonthlySetDisplayVO GetByID(int id)
        {
            MonthlySetDisplayVO vo = new MonthlySetDisplayVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new MonthlySetDisplayVO()) as MonthlySetDisplayVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_MonthlySetDisplayFormat", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
