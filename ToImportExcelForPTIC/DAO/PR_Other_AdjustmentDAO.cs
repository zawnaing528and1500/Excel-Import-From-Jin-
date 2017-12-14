// -----------------------------------------------------------------------
// <copyright file="PR_Other_Adjustment.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Toyo.Core
{
    using System;
    using System.Collections.Generic;
    
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    using System.Windows.Forms;
    //using Toyo.Core;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PR_Other_AdjustmentDAO
    {
        Base b = new Base();

        public int Insert(PR_Other_AdjustmentVO vo)
        {
            int lastInsertedId = 0;
            try
            {
                lastInsertedId = b.Insert("PR_Other_Adjustment", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertedId;
        }

        //public int Update(PR_Other_AdjustmentVO vo)
        //{
        //    int AssetID = 0;
        //    try
        //    {
        //        b.Update("PR_Other_Adjustment", vo.ID.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
        //        AssetID = vo.ID;
        //    }
        //    catch(SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    return AssetID;
        //}

        public bool isExit(string key)
        {
            return b.CheckRec("PR_Other_Adjustment", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_Other_Adjustment");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DeleteByCondition(String id)
        {
            int effectedRow = 1;
            try
            {
                b.DeleteByCondition("PR_Other_Adjustment", "EmpID=" + id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Error:" + e.ToString());
                effectedRow = -1;
            }
            return effectedRow;
        }

        public int Delete(string id)
        {
            int effectedRow = 1;
            try
            {
                b.Delete("PR_Other_Adjustment", id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete error:" + e.ToString());
                effectedRow = -1;
                throw e;
            }
            return effectedRow;
        }

        public PR_Other_AdjustmentVO GetByID(int id)
        {
            PR_Other_AdjustmentVO vo = new PR_Other_AdjustmentVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_Other_AdjustmentVO()) as PR_Other_AdjustmentVO;
            return vo;
        }

        public DataTable Select(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_Other_Adjustment", condition);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        //vw_PR_Other_Adjustment
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_PR_Other_Adjustment");
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_PR_Other_Adjustment", condition);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_PR_Other_Adjustment", start, end);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_PR_Other_Adjustment", condition, count, start);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

    }
}
