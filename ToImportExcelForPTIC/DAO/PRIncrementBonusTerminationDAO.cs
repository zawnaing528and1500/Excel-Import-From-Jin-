using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class PRIncrementBonusTerminationDAO
    {
        Base b = new Base();
        public int Insert(PRIncrementBonusTerminationVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_IncrementBonus_Termination", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PRIncrementBonusTerminationVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_IncrementBonus_Termination", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_IncrementBonus_Termination", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_IncrementBonus_Termination");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public PRIncrementBonusTerminationVO GetByID(int id)
        {
            PRIncrementBonusTerminationVO vo = new PRIncrementBonusTerminationVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PRIncrementBonusTerminationVO()) as PRIncrementBonusTerminationVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_IncrementBonus_Termination", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
