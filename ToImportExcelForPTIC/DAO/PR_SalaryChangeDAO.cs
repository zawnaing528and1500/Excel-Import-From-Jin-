using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class PR_SalaryChangeDAO
    {
        Base b = new Base();
        public int Insert(PR_SalaryChangeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_Salary_Change", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PR_SalaryChangeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_Salary_Change", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_Salary_Change", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_Salary_Change");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public PR_SalaryChangeVO GetByID(int id)
        {
            PR_SalaryChangeVO vo = new PR_SalaryChangeVO();
            DataTable dt = Select("ID=" + id + "");
            if(dt.Rows.Count >0)
                vo = b.ConvertObj(dt.Rows[0], new PR_SalaryChangeVO()) as PR_SalaryChangeVO;
            return vo;
        }

        public void updateEndDate(int changeID,DateTime endDate)
        {
            try
            {
                b.UpdateQuery("PR_Salary_Change", "ENDDATE='" + endDate + "' WHERE ID=" + changeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int getMaxIDBySalaryID(int salaryID,int branchID)
        {
            int value = 0;
            try
            {
                DataTable dt = b.SelectByQuery("SELECT MAX(ID) AS ID FROM PR_Salary_Change WHERE SalaryID=" + salaryID + " AND BranchID="+ branchID);
                if (dt.Rows.Count > 0)
                {
                    value = (dt.Rows[0][0].ToString() == "" ? 0 : int.Parse(dt.Rows[0][0].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetMaxID Error:" + ex.ToString());
            }
            return value;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_Salary_Change", sql);
                
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectView()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = b.SelectAll("vw_PR_Salary_Change_with_Rank");
            }
            catch (Exception ex)
            { throw ex; }

            return dt;
        }
        public DataTable SelectRankView(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = b.Select("vw_PR_Salary_Change_with_Rank", sql);
            }
            catch (Exception ex)
            { throw ex; }

            return dt;
        }
        public PR_SalaryChangeVO GetMaxDateByRankID(int RankId)
        {
            PR_SalaryChangeVO vo = new PR_SalaryChangeVO();
            DataTable dt = b.SelectByQuery("SELECT Max(StartDate) From PR_Salary_Change Where RankID="+RankId+"");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_SalaryChangeVO()) as PR_SalaryChangeVO;
            return vo;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_PR_Salary_Change_with_Rank", start, end);
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
                dt = b.SelectTopRowByCondition("vw_PR_Salary_Change_with_Rank", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
