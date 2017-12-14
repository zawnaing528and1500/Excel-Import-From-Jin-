using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class LoginDAO
    {
        public Base b = new Base();
        #region isValidUserName

        public string isValidUserName(string usrName)
        {
            DataTable dt = new DataTable();
            string name = null;
            try
            {
                dt = b.SelectByQuery("Select UserName From Users Where UserName='" + b.ReplaceQueryValue(usrName) + "'");
                if (dt.Rows.Count > 0)
                {
                    name = dt.Rows[0]["UserName"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return name;
        }

        #endregion

        #region isValidUser

        public int isValidUser(string username, string password)
        {
            int Id = 0;
            DataTable dt = new DataTable();
            try
            {
                string cmdStr = "Select AccessLevelID From Users Where [Password]='" + b.ReplaceQueryValue(password) + "' AND UserName='" + b.ReplaceQueryValue(username) + "'";
                dt = b.SelectByQuery(cmdStr);
                if (dt.Rows.Count > 0)
                {
                    Id = int.Parse(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username and Password do not match!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Id;
        }

        #endregion
        #region isValidUser

        public string getUserId(string username, string password)
        {
            string empId = null;
            DataTable dt = new DataTable();
            try
            {
                string cmdStr = "Select ID From Users Where UserName='" + b.ReplaceQueryValue(username) + "' AND [Password]='" + b.ReplaceQueryValue(password) + "'";
                dt = b.SelectByQuery(cmdStr);
                if (dt.Rows.Count > 0)
                {
                    empId = dt.Rows[0][0].ToString();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username and Password do not match!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return empId;
        }
        public string getEmployeeId(string username, string password)
        {
            string empId = null;
            DataTable dt = new DataTable();
            try
            {
                string cmdStr = "Select EmpID From Users Where UserName='" + b.ReplaceQueryValue(username) + "' AND [Password]='" + b.ReplaceQueryValue(password) + "'";
                dt = b.SelectByQuery(cmdStr);
                if (dt.Rows.Count > 0)
                {
                    empId = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username and Password do not match!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return empId;
        }

        #endregion

        #region OpenSQL

        public bool OpenSQL()
        {
            Base db = new Base();
            bool status = true;
            
            try
            {
                db.OpenConnection();
            }
            catch (SqlException)
            {
                status = false;
            }
            return status;
        }

        #endregion
    }
}
