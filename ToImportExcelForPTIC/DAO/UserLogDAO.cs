// -----------------------------------------------------------------------
// <copyright file="UserLogDAO.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Toyo.Core
{
    using System;
    using System.Collections.Generic;
    
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UserLogDAO
    {
        Base b = new Base();
        public int Insert(UserLogVO vo)
        {
            int lastInserted = 0;
            try
            {
                lastInserted = b.Insert("UserLog", b.ConvertColName(vo), b.ConvertValueList(vo));

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInserted;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("select * from UserLog ORDER BY LogDate DESC");
            }
            catch (SqlException e)
            {
                throw e;
            }
            return dt;
        }

        public int Delete(string id)
        {
            int effectedRow = 1;
            try
            {
                b.Delete("UserLog", id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return effectedRow;
        }

        public DataTable Select(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("UserLog", condition);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByFormName(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery("select * from UserLog where Id=" + id );
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable SelectByName(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery("select * from UserLog where UserName=N'" + name + "'");
            }
            catch (SqlException e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return dt;
        }
    }
}
