using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
   public class InterviewEvaluationInfoDAO
    {
        Base b = new Base();
        public int Insert(InterviewEvaluationInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Interview_Evaluation_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(InterviewEvaluationInfoVO vo)
        {
            int interviewInfoID = 0;
            try
            {
                b.Update("Interview_Evaluation_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                interviewInfoID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return interviewInfoID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Interview_Evaluation_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Interview_Evaluation_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public InterviewEvaluationInfoVO GetByID(int id)
        {
            InterviewEvaluationInfoVO vo = new InterviewEvaluationInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new InterviewEvaluationInfoVO()) as InterviewEvaluationInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Interview_Evaluation_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public bool IsExist(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            { throw ex; }
        }
        //vw_GetInterviewer
        public DataTable GetInterviewerByApplicantID(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_GetInterviewer", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public InterviewEvaluationInfoVO GetByCondition(string Condition)
        {
            InterviewEvaluationInfoVO vo = new InterviewEvaluationInfoVO();
            DataTable dt = Select(Condition);
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new InterviewEvaluationInfoVO()) as InterviewEvaluationInfoVO;
            return vo;
        }
        //vw_Interview_Evaluation_Info
        public DataTable SelectAllView(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Interview_Evaluation_Info", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        // Su Wut Yee Naing (18.02.2016) 
        // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Interview_Evaluation_Info", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Interview_Evaluation_Info", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
