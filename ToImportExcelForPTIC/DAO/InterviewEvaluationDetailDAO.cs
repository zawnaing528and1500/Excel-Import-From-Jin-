using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class InterviewEvaluationDetailDAO
    {
        Base b = new Base();
        public int Insert(InterviewEvaluationDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Interview_Evaluation_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(InterviewEvaluationDetailVO vo)
        {
            int interviewDetailID = 0;
            try
            {
                b.Update("Interview_Evaluation_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                interviewDetailID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return interviewDetailID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Interview_Evaluation_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Interview_Evaluation_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public InterviewEvaluationDetailVO GetByID(int id)
        {
            InterviewEvaluationDetailVO vo = new InterviewEvaluationDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new InterviewEvaluationDetailVO()) as InterviewEvaluationDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Interview_Evaluation_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
