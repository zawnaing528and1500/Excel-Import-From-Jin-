using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class TrainingAttendeeDAO
    {
        Base b = new Base();
        public int Insert(TrainingAttendeeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Training_Attendee", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(TrainingAttendeeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Training_Attendee", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Training_Attendee", key);
        }
        
        public bool isExistEmp(string key)
        {
            return b.isExist("Training_Attendee", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Training_Attendee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public TrainingAttendeeVO GetByID(int id)
        {
            TrainingAttendeeVO vo = new TrainingAttendeeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TrainingAttendeeVO()) as TrainingAttendeeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Training_Attendee", sql);
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
                b.Delete("Training_Attendee", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByCondition(string value, string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                if (value != "")
                {
                    col.Add("EmpName");
                    val.Add(value);

                    return b.SelectByCondition("vw_Training_Attendee_Report", col, val, "EmpName=@EmpName AND " + condition + "");
                }
                else
                {
                   // return b.SelectByQuery("SELECT * FROM vw_Training_Attendee_Report WHERE " + condition);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //to get attendee name from employee table 
        public DataTable SelectViewByCondition(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_TrainingAttendee_Name", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //to get attendee name from employee table 
        public DataTable SelectAttendeeByCondition(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Training_Attendee_Report", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int Create_Object_List(List<object> voList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
                id = b.Create_Object_List("Training_Attendee",voList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
     
    }
}
