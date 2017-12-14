using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Toyo.Core
{
    public class ExitInterviewDAO
    {
        Base b = new Base();
        public int Insert(ExitInterviewVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Exit_Interview", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(ExitInterviewVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Exit_Interview", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Exit_Interview", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Exit_Interview");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public ExitInterviewVO GetByID(int id)
        {
            ExitInterviewVO vo = new ExitInterviewVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new ExitInterviewVO()) as ExitInterviewVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Exit_Interview", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public ExitInterviewVO GetByResignID(int id)
        {
            DataTable dt = Select("ResignID=" + id + "");
            ExitInterviewVO vo = b.ConvertObj(dt.Rows[0], new ExitInterviewVO()) as ExitInterviewVO;
            return vo;
        }



    }
}
