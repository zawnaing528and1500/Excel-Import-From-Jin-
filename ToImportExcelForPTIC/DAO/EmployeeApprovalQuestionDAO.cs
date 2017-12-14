using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class EmployeeApprovalQuestionDAO
    {
        Base b = new Base();
        public int Insert(EmployeeApprovalEvaluationQuestionVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Approval_Evaluation_Question", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(EmployeeApprovalEvaluationQuestionVO vo)
        {
            int detailID = 0;
            try
            {
                b.Update("Employee_Approval_Evaluation_Question", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                detailID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detailID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Approval_Evaluation_Question", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Approval_Evaluation_Question");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public EmployeeApprovalEvaluationQuestionVO GetByID(int id)
        {
            EmployeeApprovalEvaluationQuestionVO vo = new EmployeeApprovalEvaluationQuestionVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new EmployeeApprovalEvaluationQuestionVO()) as EmployeeApprovalEvaluationQuestionVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Approval_Evaluation_Question", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByQuestionName(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("ApprovalEvaluationQuestion");
                val.Add(value);
                return b.SelectByCondition("Employee_Approval_Evaluation_Question", col, val, "ApprovalEvaluationQuestion=@ApprovalEvaluationQuestion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
