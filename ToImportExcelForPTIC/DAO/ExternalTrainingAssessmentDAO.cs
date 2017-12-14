using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    public class ExternalTrainingAssessmentDAO
    {
        Base b = new Base();
        public int Insert(ExternalTrainingAssessmentVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("External_Training_Assessment", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(ExternalTrainingAssessmentVO vo)
        {
            int updateID = 0;
            try
            {
                b.Update("External_Training_Assessment", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                updateID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updateID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("External_Training_Assessment", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("External_Training_Assessment");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("External_Training_Assessment", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public int GetByTrainingIdNAttendeeID(int id, int attendeeID)
        {
            int assessedID = 0;
            DataTable dt = Select("TrainingPlanDetailID=" + id + " and AttendeeID=" + attendeeID);
            if (dt.Rows.Count != 0)
            {
                ExternalTrainingAssessmentVO vo = b.ConvertObj(dt.Rows[0], new ExternalTrainingAssessmentVO()) as ExternalTrainingAssessmentVO;
                assessedID = vo.Id;
            }
            return assessedID;


        }

        public ExternalTrainingAssessmentVO GetByID(int id)
        {
            ExternalTrainingAssessmentVO vo = new ExternalTrainingAssessmentVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new ExternalTrainingAssessmentVO()) as ExternalTrainingAssessmentVO;
            return vo;
        }
    }
}
