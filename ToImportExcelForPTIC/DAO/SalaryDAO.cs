using System;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class SalaryDAO
    {
        Base b = new Base();
        public int Insert(SalaryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Salary", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(SalaryVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Salary", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public int UpdateByRank(SalaryVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Salary", vo.Rank.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Salary", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Salary");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectbyCondition(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM Salary" + condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public SalaryVO GetByID(int id)
        {
            SalaryVO vo = new SalaryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new SalaryVO()) as SalaryVO;
            return vo;
        }
        public SalaryVO GetByIDAndBranchID(int id, int branchId)
        {
            SalaryVO vo = new SalaryVO();
            DataTable dt = Select("ID=" + id + " AND BranchID=" + branchId);
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new SalaryVO()) as SalaryVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Salary", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //public DataTable SelectBySSB(string sql)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = b.Select("vw_PayrollSSB", sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
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

        public void Delete(string id)
        {
            try
            {
                b.Delete("Salary", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
