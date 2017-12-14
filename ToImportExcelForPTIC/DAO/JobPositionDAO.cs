using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class JobPositionDAO
    {
        Base b = new Base();
        public int Insert(JobPositionVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Job_Position", b.ConvertColName(vo), b.ConvertValueList(vo));
                string syncDataToOtherDB = @"SET IDENTITY_INSERT [{0}].[dbo].[JOB_POSITION] ON
                                           INSERT INTO [{0}].[dbo].[JOB_POSITION]([ID],[PostName],[DepartmentID],[ReportTo],[JobSpecification],[JobDescription],[Rank])            
                                           SELECT [ID],[PostName],[DepartmentID],[ReportTo],[JobSpecification],[JobDescription],[Rank]
                                           FROM [dbo].[JOB_POSITION]
                                           WHERE [ID]={1}
                                           SET IDENTITY_INSERT [{0}].[dbo].[Employee] OFF ";

                //if (Program.Branch == "HO")
                //{
                //    string salesDataBaseName = Properties.Settings.Default.PTIC_Sales_DbName;

                //    string cmdSql = string.Format(syncDataToOtherDB, salesDataBaseName, lastInsertId);
                //    int effectedCount = b.ExecuteNonQuery(cmdSql);
                //}
                //else if (Program.Branch == "Factory")
                //{
                //    try
                //    {
                //        string FactoryDatabaseName = Properties.Settings.Default.Proven_Factory_DbName;
                //        string cmdSql = string.Format(syncDataToOtherDB, FactoryDatabaseName, lastInsertId);
                //        int effectedCount = b.ExecuteNonQuery(cmdSql);
                //    }
                //    catch (SqlException ex)
                //    { }
                //}
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(JobPositionVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Job_Position", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("Job_Position", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Job_Position", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Job_Position");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public JobPositionVO GetByID(int id)
        {
            JobPositionVO vo = new JobPositionVO();
            DataTable dt = Select("ID=" + id + "");

            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObj(dt.Rows[0], new JobPositionVO()) as JobPositionVO;
            }
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Job_Position", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Job_Position");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Job_Position", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByPositionName(string value)
        {
            Base b = new Base();
            List<string> col = new List<string>();
            col.Add("PostName");
            List<object> val = new List<object>();
            val.Add(value);

            return b.SelectByCondition("Job_Position", col, val, "PostName=@PostName");
        }

        public DataTable SelectByPositionNameAndID(string value, string ID)
        {
            Base b = new Base();
            //List<string> col = new List<string>();
            //col.Add("PostName");
            //List<object> val = new List<object>();
            //val.Add(value);
            //List<string> col = new List<string>();
            //col.Add("ID");

            return b.SelectByQuery("Select * From Job_Position where PostName=N'" + value + "' AND ID <>" + ID);

            // return b.SelectByCondition("Job_Position", col, val, "PostName=@PostName AND ID <>");
        }

        public JobPositionVO GetIDByName(string postName)
        {
            JobPositionVO vo = new JobPositionVO();

            DataTable dt = Select("PostName='" + postName + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new JobPositionVO()) as JobPositionVO;
            return vo;
        }
    }
}

    /*
        //Ywet Nu Wai Tin
        #region For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Job_Position", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectTopRows(double count, int start)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRows("vw_Job_Position", count, start);
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
                dt = b.SelectTopRowByCondition("vw_Job_Position", condition,count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }

    */