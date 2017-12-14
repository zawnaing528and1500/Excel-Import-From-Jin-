using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class PRLateFineDAO
    {
        Base b = new Base();
        public int Insert(PRLateFineVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_Late_Fine", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PRLateFineVO vo)
        {
            int categoryID = 0;
            try
            {
                b.Update("PR_Late_Fine", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                categoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("PR_Late_Fine", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_Late_Fine");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public PRLateFineVO GetByID(int id)
        {
            PRLateFineVO vo = new PRLateFineVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PRLateFineVO()) as PRLateFineVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_Late_Fine", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }


        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("PR_Late_Fine", start, end);
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
                dt = b.SelectTopRowByCondition("PR_Late_Fine", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
