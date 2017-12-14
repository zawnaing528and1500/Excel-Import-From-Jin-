using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class PR_Additional_AllowanceDAO
    {
         Base b = new Base();
         public int Insert(PR_Additional_AllowanceVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_Additional_Allowance", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

         public int Update(PR_Additional_AllowanceVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("PR_Additional_Allowance", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                AssetID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return AssetID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("PR_Additional_Allowance", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_Additional_Allowance");
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
                b.Delete("PR_Additional_Allowance", id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete error:" + e.ToString());
                effectedRow = -1;
                throw e;
            }
            return effectedRow;
        }

        public int DeleteByCondition(String id)
        {
            int effectedRow = 1;
            try
            {
                b.DeleteByCondition("PR_Additional_Allowance", "EmpID=" + id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Error:" + e.ToString());
                effectedRow = -1;
            }
            return effectedRow;
        }

        public PR_Additional_AllowanceVO GetByID(int id)
        {
            PR_Additional_AllowanceVO vo = new PR_Additional_AllowanceVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_Additional_AllowanceVO()) as PR_Additional_AllowanceVO;
            return vo;
        }

        public DataTable Select(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_Additional_Allowance", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_PR_Additional_Allowance
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_PR_Additional_Allowance");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_PR_Additional_Allowance", condition);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_PR_Additional_Allowance", start, end);
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
                dt = b.SelectTopRowByCondition("vw_PR_Additional_Allowance", condition, count, start);

            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
