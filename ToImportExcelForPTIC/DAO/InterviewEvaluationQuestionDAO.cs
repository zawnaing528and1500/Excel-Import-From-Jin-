using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    class InterviewEvaluationQuestionDAO
    {
        Base b = new Base();
        public int Insert(InterviewEvaluationQuestionVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Interview_Evalution_Question", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(InterviewEvaluationQuestionVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Interview_Evalution_Question", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Interview_Evalution_Question", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Interview_Evalution_Question");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public InterviewEvaluationQuestionVO GetByID(int id)
        {
            InterviewEvaluationQuestionVO vo = new InterviewEvaluationQuestionVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new InterviewEvaluationQuestionVO()) as InterviewEvaluationQuestionVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Interview_Evalution_Question", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByName(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("EvaluationQuestions");
                val.Add(value);
                return b.SelectByCondition("Interview_Evalution_Question", col, val, "EvaluationQuestions=@EvaluationQuestions");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
