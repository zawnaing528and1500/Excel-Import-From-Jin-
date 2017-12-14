using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
   public class ApplicantInformationDAO
    {
        Base b = new Base();
        public int Insert(ApplicantInformationVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertWithImage("Applicant_Information", b.ConvertColName(vo), b.ConvertValueList(vo),vo.ApplicantPhoto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(ApplicantInformationVO vo)
        {
            int applicantID = 0;
            try
            {
                b.UpdateWithImage("Applicant_Information", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo),vo.ApplicantPhoto);
                applicantID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return applicantID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Applicant_Information", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Applicant_Information");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
     
        public ApplicantInformationVO GetByID(int id)
        {
            ApplicantInformationVO vo = new ApplicantInformationVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
            {
                vo = b.ConvertObjWithImage(dt.Rows[0], new ApplicantInformationVO()) as ApplicantInformationVO;
            }
            return vo;

        }
        //vw_ApplicantInformation
        public DataTable SelectAllView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_ApplicantInformation");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_ApplicantInformation", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Applicant_Information", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByCondition(string ApplicantName)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                
                //if (ApplicantName != "")
                //{
                //    col.Add("ApplicantName");
                //    val.Add(ApplicantName);
                //    dt = b.SelectByCondition("Applicant_Information", col, val, "ApplicantName = @ApplicantName");
                //}
                dt = b.SelectByQuery("select * from Applicant_Information where ApplicantName=N'" + ApplicantName + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByNameAndCodeNo(string ApplicantName,string CodeNo)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                 
                col.Add("ApplicantName");
                val.Add(ApplicantName);

                col.Add("CodeNo");
                val.Add(CodeNo);
                dt = b.SelectByCondition("Applicant_Information", col, val, "ApplicantName = @ApplicantName AND CodENo=@CodeNo");
              // dt = b.SelectByQuery("select * from Applicant_Information where ApplicantName=N'" + ApplicantName + "' AND CodENo=" + CodeNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void UpdateQuery(string query)
        {
            try
            {
                b.UpdateQuery("Applicant_Information", query);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Update Applicant Information Error!");
                throw ex;
            }
        }

        public DataTable SelectByTwoCondition(string ApplicantName, string codeNo)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();


                //col.Add("ApplicantName");
                //val.Add(ApplicantName);

                //col.Add("CodeNo");
                //val.Add(codeNo);
                //dt = b.SelectByCondition("Applicant_Information", col, val, "ApplicantName = @ApplicantName AND CodeNo=@CodeNo AND Hire=0");
                dt = b.SelectByQuery("select * from Applicant_Information where ApplicantName=N'" + ApplicantName + "' AND CodeNo='" + codeNo + "' AND Hire=0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public byte[] GetImageById(string id)
        {
            byte[] image = null;
            try
            {
                image = b.getImageById("Applicant_Information", "ApplicantPhoto", id);
            }
            catch (SqlException Sql)
            {
                throw Sql;
            }
            return image;
        }

       // Su Wut Yee Naing (18.02.2016) 
       // For Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_ApplicantInformation", start, end);
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
                dt = b.SelectTopRowByCondition("vw_ApplicantInformation", condition, count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
    }
}
