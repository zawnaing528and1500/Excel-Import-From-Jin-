using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class AccessLevelDAO
    {
        Base b = new Base();
        public int Insert(AccessLevelVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AccessLevel", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AccessLevelVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("AccessLevel", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            bool flg = false;
            try
            {
                flg = b.CheckRec("AccessLevel", key);
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("isExist Error:" + sqle.ToString());
            }
            return flg;
        }
        public bool isExistCheck(string condition)
        {
            bool flg = false;
            try
            {
                flg = b.isExist("AccessLevel", condition);
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("isExist Error:" + sqle.ToString());
            }
            return flg;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AccessLevel");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public AccessLevelVO GetByID(int id)
        {
            AccessLevelVO vo = new AccessLevelVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AccessLevelVO()) as AccessLevelVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AccessLevel", sql);
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

        public DataTable SelectByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AccessLevel", condition);
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
                dt = b.SelectTopRowsFinal("AccessLevel", start, end);
            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
