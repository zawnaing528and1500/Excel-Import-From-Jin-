using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Toyo.Core
{
    /// <summary>
    /// Developer : JinnySaw
    /// Date : 2014-06-19 10:58 AM
    /// </summary>
    public class DBManager
    {
        #region Private Variable

        private static DBManager _dbInstance = null;
        private static readonly string ConnStringName = "ToImportExcelForPTIC.Properties.Settings.ForPTICMDY_ExcelImportConnectionString";
        private static string _conString = string.Empty;
        private readonly SqlConnection conn = new SqlConnection(_conString);
        private static DBManager _builder = null;
        #endregion

        #region Constructors

        private DBManager() { }

        #endregion

        #region Private Connection String

        private static string GetConnectionStringByName(string name)
        {
            string value = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                value = settings.ConnectionString;
            return value;
        }

        private static string GetConnectionStringByProvider(string providerName)
        {
            string value = null;
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == providerName)
                    {
                        value = cs.ConnectionString;
                        break;
                    }
                }
            }
            return value;
        }
        #endregion

        #region GetInstance

        public static DBManager GetInstance()
        {
            if (_dbInstance == null)
            {
                _conString = GetConnectionStringByName(ConnStringName);               
                // initiate db manager
                _dbInstance = new DBManager();
            }
            return _dbInstance;
        }
       
        #endregion

        public SqlConnection GetDbConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
            }
            catch (SqlException sqle)
            {
                //ToastMessageBox4.Show(Resource.errDBorNet + "\r\nError Code : " + sqle.ErrorCode);
            }
            return conn;
        }

        public void CloseDbConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException sqle)
            { }
        }
        public SqlConnectionStringBuilder SqlConnectionStringBuilder()
        {
           
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(DBManager._conString);
           
            return builder;
        }
    }
}
