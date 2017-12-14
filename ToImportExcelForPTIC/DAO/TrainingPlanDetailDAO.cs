using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class TrainingPlanDetailDAO
    {
        Base b = new Base();
        public int Insert(TrainingPlanDetailVO vo)
        {
            int lastInsertId = 0;

            try
            {
                lastInsertId = b.Insert("Training_Plan_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Training_Plan_Detail", key);
        }

        public bool checkExist(string condition)
        {
            return b.isExist("Training_Plan_Detail", condition); ;
        }

        public int Update(TrainingPlanDetailVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Training_Plan_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }

        public TrainingPlanDetailVO GetByID(int id)
        {
            TrainingPlanDetailVO vo = new TrainingPlanDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TrainingPlanDetailVO()) as TrainingPlanDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Training_Plan_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Training_Plan_Detail");
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
                dt = b.Select("vw_Training_Plan_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAllByView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Training_Plan_Detail");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAllByViewList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Training_Plan_Detail_List");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectListViewBycondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Training_Plan_Detail_List", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        //public TrainingPlanDetailVO GetViewByYearTrainingType(string year, int typeID)
        //{
        //    TrainingPlanDetailVO vo = new TrainingPlanDetailVO();
        //    DataTable dt = SelectByView("Year=" + year + "and TrainingTypeID=" + typeID);
        //    if (dt.Rows.Count > 0)
        //        vo = b.ConvertObjWithImage(dt.Rows[0], new TrainingPlanDetailVO()) as TrainingPlanDetailVO;
        //    return vo;
        //}
        public DataTable GetViewByYearTrainingType(string year, int typeID,int isInternal)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SelectByView("Year=" + year + " and TrainingTypeID=" + typeID+ " and isInternalTraining="+ isInternal );
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable GetByYearTrainingType(string year, int typeID)
        {
            DataTable dt = new DataTable();
            try
            {
                string condition = "YEAR(StartDate)=" + year + " and TrainingTypeID=" + typeID;
                dt = b.SelectByQuery("select MONTH(StartDate) As ActualMonth from Training_Plan_Detail where " + condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //to get employee training record
        public DataTable SelectEmpTrainingByCondition(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Employee_Training_Record", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Training_Plan_Detail_List", start, end);
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
                dt = b.SelectTopRowByCondition("vw_Training_Plan_Detail_List", condition, count, start);

            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
