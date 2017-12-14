using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class PR_SalaryComputingResultDAO
    {

        Base b = new Base();
        public int Insert(PR_SalaryComputingResultVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_SalaryComputingResult", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PR_SalaryComputingResultVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_SalaryComputingResult", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }
        public void UpdateByCondition(PR_SalaryComputingResultVO vo)
        {
            try
            {
                b.UpdateByConditon("PR_SalaryComputingResult", " EmpID=" + vo.EmpId.ToString() + " AND Month='" + vo.PrMonth + "' AND Year='" + vo.PrMonth + "'", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool isExist(string key)
        {
            return b.CheckRec("PR_SalaryComputingResult", key);
        }

        public bool isExistEmployeeByMonth(string empId, int month, int year)
        {
            bool flg = false;
            try
            {
                flg = b.isExist("PR_SalaryComputingResult", " EmpID=" + empId + " AND PRMonth='" + month + "' AND PRYear='" + year + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_SalaryComputingResult");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllView()
        {
            //vw_PR_Salary_Computing_Result
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_PR_Salary_Computing_Result");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllViewByCondition(string condition)
        {
            //vw_PR_Salary_Computing_Result
            DataTable dt;
            try
            {
                dt = b.Select("vw_PR_Salary_Computing_Result", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllPaySlip(string condition)
        {
            //vw_PR_Salary_Computing_Result
            DataTable dt;
            try
            {
                dt = b.Select("vw_PR_PaySlip_Final", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public PR_SalaryComputingResultVO GetByID(int id)
        {
            PR_SalaryComputingResultVO vo = new PR_SalaryComputingResultVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_SalaryComputingResultVO()) as PR_SalaryComputingResultVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_SalaryComputingResult", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt = new DataTable();
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

        public int Delete(string id)
        {
            int effectedRow = 1;
            try
            {
                b.Delete("PR_SalaryComputingResult", id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error:" + ex.ToString());
                effectedRow = -1;

            }
            return effectedRow;
        }

        #region Paging
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_PR_Salary_Computing_Result", condition, count, start);

            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
