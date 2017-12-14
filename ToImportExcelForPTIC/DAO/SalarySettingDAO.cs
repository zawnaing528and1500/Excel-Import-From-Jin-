using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class SalarySettingDAO
    {
        Base b = new Base();
        public int Insert(SalarySettingVO vo)
        {
            int lastInsertId = 0;
            string item = null;
            try
            {
                lastInsertId = b.Insert("PR_SalarySetting", b.ConvertColName(vo), b.ConvertValueList(vo));
                DataTable dt = b.SelectByQuery("SELECT Max(LINKER) AS LINKER FROM PR_SalarySetting");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Linker"] == null || dr["Linker"] == "")
                        item = "item_0000";
                    else item = dr["Linker"].ToString();
                    string latestLinker = item;
                    int num = int.Parse(latestLinker.Split('_')[1]);
                    num++;
                    if (num < 10)
                        latestLinker = "item_000" + num;
                    else if (num < 100)
                        latestLinker = "item_00" + num;
                    else if (num < 1000)
                        latestLinker = "item_0" + num;
                    else latestLinker = "item_" + num;

                    b.SelectByQuery("UPDATE PR_SalarySetting SET LINKER='" + latestLinker + "' WHERE ID=" + lastInsertId + " AND FixedRulesID=" + vo.FixedRulesID + "");

                    break;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(SalarySettingVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_SalarySetting", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_SalarySetting", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_SalarySetting");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public SalarySettingVO GetByID(int id)
        {
            SalarySettingVO vo = new SalarySettingVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new SalarySettingVO()) as SalarySettingVO;
            return vo;
        }
        public SalarySettingVO GetByFixedRulesIdAndSalaryItem(string query)
        {
            SalarySettingVO vo = new SalarySettingVO();
            DataTable dt = b.SelectByQuery(query);
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new SalarySettingVO()) as SalarySettingVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_SalarySetting", sql);
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
                b.Delete("PR_SalarySetting", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteByFixedRulesID(string FixedRulesId)
        {
            try
            {
                b.DeleteByCondition("PR_SalarySetting","FixedRulesId="+ FixedRulesId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
