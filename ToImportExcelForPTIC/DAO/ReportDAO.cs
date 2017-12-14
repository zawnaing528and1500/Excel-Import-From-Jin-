using System;
using System.Data;

namespace Toyo.Core
{
    public class ReportDAO
    {
        Base b = new Base();
        //public void LogOn(ReportDocument rpt)
        //{
        //    TableLogOnInfo crtableLogoninfos = new TableLogOnInfo();
        //    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        //    ConnectionInfo crConnectionInfo = new ConnectionInfo();
        //    Tables CrTables; 

        //    SqlConnectionStringBuilder builder = DBManager.GetInstance().SqlConnectionStringBuilder();           

        //    crConnectionInfo.ServerName =builder["Data Source"] as string;
        //    crConnectionInfo.DatabaseName = builder["Initial Catalog"] as string;
        //    crConnectionInfo.UserID = builder["User ID"] as string;
        //    crConnectionInfo.Password = builder["Password"] as string;

        //    CrTables = rpt.Database.Tables;
        //    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        //    {
        //        crtableLogoninfo = CrTable.LogOnInfo;
        //        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
        //        CrTable.ApplyLogOnInfo(crtableLogoninfo);
        //    }
        //}

        public DataTable SelectByQuery(string query)
        {
            Base b = new Base();
            return b.SelectByQuery(query);
        }

        public void Execute_SP(string tblName, string condition)
        {
            try
            {
                Base b = new Base();
                b.Execute_SP(tblName, condition);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Execute_SP Error :" + ex.ToString());
            }
        }

        public void Insert(string query)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Select(string viewName, string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select(viewName, condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Late_Count_By_Minutes");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //public DataTable Execute_SP(string tblName, string condition)
        //{
        //    try
        //    {
        //        Base b = new Base();
        //       DataTable dt= b.Execute_SP(tblName, condition);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Execute_SP Error :" + ex.ToString());
        //    }
        //}

    }
}
