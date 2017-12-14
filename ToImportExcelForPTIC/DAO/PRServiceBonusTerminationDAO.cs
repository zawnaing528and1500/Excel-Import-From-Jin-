using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PRServiceBonusTerminationDAO
    {
        Base b = new Base();
        public int Insert(PRServiceBonusTerminationVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_ServiceBonus_Termination", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PRServiceBonusTerminationVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_ServiceBonus_Termination", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_ServiceBonus_Termination", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_ServiceBonus_Termination");
                //PR_ServiceBonus_Termination
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public PRServiceBonusTerminationVO GetByID(int id)
        {
            PRServiceBonusTerminationVO vo = new PRServiceBonusTerminationVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PRServiceBonusTerminationVO()) as PRServiceBonusTerminationVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_ServiceBonus_Termination", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        //vw_PR_ServiceBonus_Termination
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_PR_ServiceBonus_Termination", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_PR_ServiceBonus_Termination");
                //PR_ServiceBonus_Termination
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
