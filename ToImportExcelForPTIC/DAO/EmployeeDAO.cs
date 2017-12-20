
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ToImportExcelForPTIC;
using System;

namespace Toyo.Core
{
    public class EmployeeDAO
    {
        Base b = new Base();
        public int Insert(EmployeeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertWithImage("Employee", b.ConvertColName(vo), b.ConvertValueList(vo), vo.EmpPhoto);
                if (lastInsertId > 0)
                {
                    //MessageBox.Show("Success");
                }
                //b.Insert("Employee", b.ConvertColName(vo), b.ConvertValueListNullable(vo));
            }
            catch (SqlException Sql)
            {
                MessageBox.Show("Insert Error");
                throw Sql;
            }
            return lastInsertId;
        }

        //public int Update(EmployeeVO vo)
        //{
        //    int empID = 0;
        //    try
        //    {
        //        b.UpdateWithImage("Employee", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo), vo.EmpPhoto);
        //        empID = vo.Id;

        //        string syncDataToOtherDB = @"UPDATE [{0}].[dbo].[Employee] SET [ApplicantID]=" + vo.ApplicantID + ",[EmpName]=N'" + vo.EmpName + "',[PostID]=" + vo.PostID + ",[DeptID]=" + vo.DeptID + ",[FingerID]=" + vo.FingerID
        //                                   + ",[EmployDate]='" + vo.EmployDate + "',[SalaryLvlID]='" + vo.SalaryLvlID + "',[FatherName]=N'" + vo.FatherName + "',[NRCNo]=N'" + vo.NRCNo + "',[DOB]='" + vo.DOB + "',[PassportNo]=N'" + vo.PassportNo
        //                                   + "',[Race]=N'" + vo.Race + "',[Religion]=" + vo.Religion + ",[Gender]='" + vo.Gender + "',[MaritalStatus]='" + vo.MaritalStatus + "',[SSCode]=N'" + vo.SSCode + "',[DriverLicence]=N'" + vo.DriverLicence
        //                                   + "',[IncaseOfDeathNameOfBeneficiary]=N'" + vo.IncaseOfDeathNameOfBeneficiary + "',[Criminal]='" + vo.Criminal + "',[CriminalRecord]=N'" + vo.Criminalrecord + "',[ReferencesName1]=N'" + vo.ReferencesName1
        //                                   + "',[ReferencesName2]=N'" + vo.ReferencesName2 + "',[ReferencesPh1]=N'" + vo.ReferencesPh1 + "',[ReferencesPh2]=N'" + vo.ReferencesPh2 + "',[isPermanent]='" + vo.IsPermanent + "',[ApprovalDate]='" + vo.ApprovalDate
        //                                   + "',[IsActive]='" + vo.IsActive + "' WHERE [ID]={1} ";
        //        if (Program.Branch == "HO")
        //        {
        //            string salesDataBaseName = Properties.Settings.Default.PTIC_Sales_DbName;

        //            string cmdSql = string.Format(syncDataToOtherDB, salesDataBaseName, vo.Id);
        //            int effectedCount = b.ExecuteNonQuery(cmdSql);
        //        }
        //        else if (Program.Branch == "Factory")
        //        {
        //            string FactoryDatabaseName = Properties.Settings.Default.Proven_Factory_DbName;
        //            string cmdSql = string.Format(syncDataToOtherDB, FactoryDatabaseName, vo.Id);
        //            int effectedCount = b.ExecuteNonQuery(cmdSql);
        //        }
        //    }
        //    catch (SqlException Sql)
        //    {
        //        throw Sql;
        //    }
        //    return empID;
        //}

        public void UpdateQuery(string query)
        {
            try
            {
                b.UpdateQuery("Employee", query);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee", key);
        }

        public byte[] GetImageById(string id)
        {
            byte[] image = null;
            try
            {
                image = b.getImageById("Employee", "EmpPhoto", id);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return image;
        }

        public DataTable SelectByAllEmpName(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("EmpName");
                val.Add(value);
                dt = b.SelectByQuery("Select * from Employee where EmpName = N'" + value + "'");
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee","isActive=1");
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return dt;
        }

        public DataTable SelectAllView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_EmployeeList");
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt;
            try
            {
                if (condition == "")
                {
                    dt = b.SelectAll("vw_EmployeeList");
                }
                else { dt = b.Select("vw_EmployeeList", condition); }
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        //Su Wut Yee Naing(16.7.2015)
        #region For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_EmployeeList", start, end);
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
                dt = b.SelectTopRows("vw_EmployeeList", count, start);
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
                if (condition == "")
                    condition = "IsActive=1";
                dt = b.SelectTopRowByCondition("vw_EmployeeList", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

        public DataTable SelectByEmpName(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("EmpName");
                val.Add(value);
                //dt = b.SelectByCondition("Employee", col, val, "EmpName=@EmpName AND IsDeleted=0");
                dt = b.SelectByQuery("Select * from Employee where EmpName=N'" + value + "' AND IsActive=1");
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public DataTable SelectByEmpNameAndNotEmpId(string EmpName, string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery("select * from Employee where EmpName=N'" + EmpName + "' AND ID <>" + ID + " AND IsActive=1");
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public DataTable SelectByEmpNameAndFingerID(string EmpName, string FingerID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                string condition = "ISACTIVE=1";
                if (EmpName != "")
                { 
                    condition += " AND EmpName=N'" + EmpName + "'";
                }
                if (FingerID != "")
                { 
                    condition += " AND FingerID=" + FingerID;
                } 
                dt = b.SelectByQuery("select * from Employee where " + condition);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public EmployeeVO GetByID(int id)
        {
            EmployeeVO vo = new EmployeeVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObjWithImage(dt.Rows[0], new EmployeeVO()) as EmployeeVO;
            return vo;
        }

        public EmployeeVO GetByFingerID(int FingerId)
        {
            EmployeeVO vo = new EmployeeVO();
            DataTable dt = Select("FingerID=" + FingerId + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObjWithImage(dt.Rows[0], new EmployeeVO()) as EmployeeVO;
            return vo;
        }
        public EmployeeVO GetByFingerIDAndActive(int FingerId)
        {
            EmployeeVO vo = new EmployeeVO();
            DataTable dt = Select("FingerID=" + FingerId + " AND IsActive=1");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObjWithImage(dt.Rows[0], new EmployeeVO()) as EmployeeVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee", sql);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public DataTable SelectByCondition(string value)
        {
            DataTable dt = new DataTable();
            try
            { 
                if (value != "")
                { 
                    dt = b.SelectByQuery("select * from Employee where EmpName=N'" + value + "'");
                }
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public bool IsExist(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (SqlException Sql)
            { throw Sql; }
        }

        public bool IsDeleted(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (SqlException Sql)
            { throw Sql; }
        }

        public DataTable SelectByDeptIDandEmpNameAndFingerID(string DeptID, string EmpName, string FingerID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                string condition = "ISACTIVE=1";

                if (DeptID != "")
                { 
                    condition += " AND DeptID=" + DeptID;
                }
                if (EmpName != "")
                { 
                    condition += " AND EmpName=N'" + EmpName + "'";
                }
                if (FingerID != "")
                { 
                    condition += " AND FingerID=" + FingerID;
                } 
                dt = b.SelectByQuery("select * from Employee where " + condition);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public DataTable SelectByView(string DeptID, string EmpName, string FingerID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                string condition = "ISACTIVE=1";

                if (DeptID != "")
                { 
                    condition += " AND DeptID=" + DeptID;
                }
                if (EmpName != "")
                { 
                    condition += " AND EmpName=N'" + EmpName + "'";
                }
                if (FingerID != "")
                { 
                    condition += " AND FingerID=" + FingerID;
                } 
                dt = b.SelectByQuery("select * from vw_Employee_Info where " + condition);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;
        }

        public void Delete(string key)
        {
            try
            {
                b.Delete("Employee", key);
            }
            catch (SqlException Sql)
            { throw Sql; }
        }

        public void DeleteByCondition(string condition)
        {
            try
            {
                b.DeleteByCondition("Employee", condition);
            }
            catch (SqlException Sql)
            { throw Sql; }
        }

        public EmployeeVO GetByApplicantID(int id)
        {
            EmployeeVO vo = new EmployeeVO();
            DataTable dt = Select("ApplicantID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObjWithImage(dt.Rows[0], new EmployeeVO()) as EmployeeVO;
            return vo;
        }

        // Get Employee Name
        public DataTable SelectEmpName()
        {
            return b.SelectByQuery("select EmpName from Employee");
        }

        // Get Employee Name By Department ID
        public DataTable SelectByDeptId(int deptId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery("select * from Employee where DeptID=" + deptId + " and IsActive=1");
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return dt;

        }

        //public DataTable GetEmpIDFromFingerID(int fingerID)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        if (fingerID > 0)
        //        {
        //            dt = b.SelectByQuery("select * from Employee where FingerID="+fingerID);
        //        }
        //    }
        //    catch (SqlException Sql)
        //    {
        //        throw Sql;
        //    }
        //    return dt;
        //}


        public DataTable GetEmpIDFromFingerID(int fingerID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("FingerID");
                val.Add(fingerID);

                dt = b.SelectByCondition("Employee", col, val, "FingerID=@FingerID");

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }

        //To get PositionID when Employee Data is going to insert into dbo.Employee
        public int SelectIDByPositionName(string value)
        {
            int ID = 0;
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("PostName");
                val.Add(value);

                dt = b.SelectByCondition("Job_Position", col, val, "PostName=@PostName");
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ID"] != System.DBNull.Value)
                    {
                        string Id = dt.Rows[0][0].ToString();
                        ID = Convert.ToInt32(Id);
                    }
                }
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }


        public int SelectIDByDeptName(string value)
        {
            int ID = 0;
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("DeptName");
                val.Add(value);

                dt = b.SelectByCondition("Department", col, val, "DeptName=@DeptName");
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ID"] != System.DBNull.Value)
                    {
                        string Id = dt.Rows[0][0].ToString();
                        ID = Convert.ToInt32(Id);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

    }
}
