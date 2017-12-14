using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    public class AssessedByTraineeDAO
    {
        Base b = new Base();
        public int Insert(AssessedByTraineeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AssessedBy_Trainee", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssessedByTraineeVO vo)
        {
            int accessByTraineeID = 0;
            try
            {
                b.Update("AssessedBy_Trainee", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                accessByTraineeID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return accessByTraineeID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AssessedBy_Trainee", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AssessedBy_Trainee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Training_Attendee_Report", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public AssessedByTraineeVO GetByID(int id)
        {
            AssessedByTraineeVO vo = new AssessedByTraineeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AssessedByTraineeVO()) as AssessedByTraineeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AssessedBy_Trainee", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public int GetByTrainingIdNAttendeeID(int id , int attendeeID)
        {
            int assessedID = 0;
            DataTable dt = Select("TrainingPlanDetailID=" + id + " and AttendeeID="+ attendeeID);
            if (dt.Rows.Count != 0)
            {
                AssessedByTraineeVO vo = b.ConvertObj(dt.Rows[0], new AssessedByTraineeVO()) as AssessedByTraineeVO;
                assessedID = vo.Id;
            }
            return assessedID;
        }
    }
}
