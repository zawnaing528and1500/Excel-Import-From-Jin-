using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_Payroll_PeriodDAO
    {
        Base b = new Base();
        public int Insert(PR_Payroll_PeriodVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_Payroll_Period", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PR_Payroll_PeriodVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_Payroll_Period", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_Payroll_Period", key);
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_Payroll_Period");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public PR_Payroll_PeriodVO SelectPeriod()
        {
            PR_Payroll_PeriodVO vo = new PR_Payroll_PeriodVO();

            try
            {
                DataTable dt = b.SelectAll("PR_Payroll_Period");
                if (dt.Rows.Count > 0)
                    vo = b.ConvertObj(dt.Rows[0], new PR_Payroll_PeriodVO()) as PR_Payroll_PeriodVO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vo;
        }

        public PR_Payroll_PeriodVO GetByID(int id)
        {
            PR_Payroll_PeriodVO vo = new PR_Payroll_PeriodVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_Payroll_PeriodVO()) as PR_Payroll_PeriodVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_Payroll_Period", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public void DeleteByAll()
        {
            try
            {
                b.DeleteByAll("PR_Payroll_Period");
            }
            catch (Exception ex)
            { throw ex; }


        }
    }
}
