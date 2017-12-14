using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Toyo.Core
{
    public class ProbationOfficeOrderDAO
    {
        Base b = new Base();
        public int Insert(ProbationOfficeOrderVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Probation_Office_Order", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(ProbationOfficeOrderVO vo)
        {
            int probationOrderID = 0;
            try
            {
                b.Update("Probation_Office_Order", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                probationOrderID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return probationOrderID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Probation_Office_Order", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Probation_Office_Order");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Probation_Office_Order", sql);
            }
            catch (Exception ex)
            { throw ex; }
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

        public ProbationOfficeOrderVO GetByID(int id)
        {
            ProbationOfficeOrderVO vo = new ProbationOfficeOrderVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new ProbationOfficeOrderVO()) as ProbationOfficeOrderVO;
            return vo;
        }

        public ProbationOfficeOrderVO GetByApplicantID(int id)
        {
            ProbationOfficeOrderVO vo = new ProbationOfficeOrderVO();
            DataTable dt = Select("ApplicantID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new ProbationOfficeOrderVO()) as ProbationOfficeOrderVO;
            return vo;
        }

        public bool IsExist(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            { throw ex; }
        }

        //vw_Probation_Office_Order
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Probation_Office_Order");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Probation_Office_Order", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        // Su Wut Yee Naing (19.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Probation_Office_Order", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Probation_Office_Order", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
