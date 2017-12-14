using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class PR_FixedRulesDAO
    {
        Base b = new Base();
        public int Insert(PR_FixedRulesVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_FixedRules", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PR_FixedRulesVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("PR_FixedRules", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_FixedRules", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_FixedRules");
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
                b.Delete("PR_FixedRules", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PR_FixedRulesVO GetByID(int id)
        {
            PR_FixedRulesVO vo = new PR_FixedRulesVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_FixedRulesVO()) as PR_FixedRulesVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_FixedRules", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
