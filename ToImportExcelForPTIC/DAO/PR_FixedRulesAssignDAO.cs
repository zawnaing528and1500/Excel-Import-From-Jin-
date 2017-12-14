using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Toyo.Core
{
    public class PR_FixedRulesAssignDAO
    {
        Base b = new Base();
        public int Insert(PR_FixedRulesAssignVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("PR_FixedRulesAssign", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(PR_FixedRulesAssignVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("PR_FixedRulesAssign", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("PR_FixedRulesAssign", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("PR_FixedRulesAssign");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_PR_FixedRulesAssign_View
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_PR_FixedRulesAssign_View");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public PR_FixedRulesAssignVO GetByID(int id)
        {
            PR_FixedRulesAssignVO vo = new PR_FixedRulesAssignVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new PR_FixedRulesAssignVO()) as PR_FixedRulesAssignVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("PR_FixedRulesAssign", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void DeleteByCondition(string condition)
        {
            try
            {
                b.DeleteByCondition("PR_FixedRulesAssign", condition);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public PR_FixedRulesAssignVO SelectByQuery(string query)
        //{
        //    PR_FixedRulesAssignVO vo = new PR_FixedRulesAssignVO();

        //    try
        //    {
        //        DataTable dt = b.SelectByQuery(query);
        //        if (dt.Rows.Count > 0)
        //            vo = b.ConvertObj(dt.Rows[0], new PR_FixedRulesAssignVO()) as PR_FixedRulesAssignVO;
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //    return vo;
        //}
        public DataTable SelectByQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery(query);

            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable GetFormulaView(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
               dt= b.Select("vw_GetFormula_View", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        //vw_GetFormula_For_New_Employee
        public DataTable GetFormulaForNewEmployeeView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_GetFormula_For_New_Employee");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //vw_GetFormula_For_Resign_Employee
        public DataTable GetFormula_For_Resign_Employee()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_GetFormula_For_Resign_Employee");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        #region FindPair
        int findPair(string str)
        {
            int pair = 1;
            int index = -1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '(') pair++;
                else if (str[i] == ')') pair--;
                if (pair == 0)
                {
                    // found pair
                    index = i;
                    break;
                }
            }
            return index;
        }
        #endregion
       
      
        
       
        //public string formulaExtractor(string formulaItem, string Formula)
        //{
            
        //    string text = "";

        //    int endIndex;
        //    string innerStr;
        //    string[] str = Formula.Split('[');
        //    string ss = null;
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        if (str[i] != "")
        //        {
        //            ss = str[i].Split(']')[0];
                    
        //            DataTable dt = b.SelectByQuery("Select initialValue, formula, linker From PR_SalarySetting Where FixedRulesID=" + formulaItem + " AND (SalaryItem = '" + ss + "')");

        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                if (dr["INITIALVALUE"] != null && dr["INITIALVALUE"].ToString() != "" && dr["INITIALVALUE"].ToString() != "0")
        //                {
        //                    str[i] = str[i].Remove(str[i].IndexOf(']'), 1);
        //                    str[i] = str[i].Replace(ss, dr["INITIALVALUE"].ToString());
        //                }
        //                else
        //                {
        //                    str[i] = str[i].Remove(str[i].IndexOf(']'), 1);
        //                    str[i] = str[i].Replace(ss, dr["formula"].ToString());
        //                }

        //            }
        //            if (dt.Rows.Count == 0)
        //            {
        //                str[i] = ss;
        //                text += ss;
        //            }
        //        }
        //    }

        //    for (int i = 1; i < str.Length; i++)
        //    {
        //        text += str[i];
        //    }
        //    if (text.Contains('[')) text = formulaExtractor(formulaItem, text);
        //    else
        //    {
        //        if(text=="")
        //            text = ss;
        //    }
          
        //    return text;
        //}
    }
}
