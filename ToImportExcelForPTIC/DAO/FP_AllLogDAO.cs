using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FP_AllLogDAO
    {
        Base b = new Base();
        public int Insert(FP_AllLogVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_AllLog", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FP_AllLogVO vo)
        {
            int deviceID = 0;
            try
            {
                b.Update("FP_AllLog", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                deviceID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deviceID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("FP_AllLog", key);
        }

        public bool isExistByCondition(string conditon)
        {
            return b.isExist("FP_AllLog", conditon);
        }

        public FP_AllLogVO GetByID(int id)
        {
            FP_AllLogVO vo = new FP_AllLogVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FP_AllLogVO()) as FP_AllLogVO;
            return vo;
        }

        public DataTable Select(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_AllLog", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByQuery(String query)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch(Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_AllLog");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetDistinctDate(DateTime fromdate,DateTime todate)
        {
            DataTable dt=new DataTable();
            try
            {
                dt = b.getColumn("FP_AllLOG", "DISTINCT ATTENDANCEDATE", "ATTENDANCEDATE BETWEEN'" + fromdate.ToShortDateString() + "' AND '" + todate.ToShortDateString() + "' order by AttendanceDate");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Get Date Error:"+ ex.ToString());
            }
            return dt;
        
        }

        public void Delete(string Key)
        {
            try
            {
                b.Delete("FP_AllLOG", Key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("FP_AllLog", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
