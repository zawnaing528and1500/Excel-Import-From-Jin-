using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FineRecordDAO
    {
        Base b = new Base();
        public int Insert(FineRecordVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Fine_Record", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FineRecordVO vo)
        {
            int fineRecordID = 0;
            try
            {
                b.Update("Fine_Record", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                fineRecordID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fineRecordID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Fine_Record", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Fine_Record");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public FineRecordVO GetByID(int id)
        {
            FineRecordVO vo = new FineRecordVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FineRecordVO()) as FineRecordVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Fine_Record", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByCondition(string value, string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                if (value != "")
                {
                    //col.Add("EmpName");
                    //val.Add(value);
                    //return b.SelectByCondition("vw_FineRecord", col, val, "EmpName=@EmpName AND " + condition + "");
                    dt = b.SelectByQuery("select * from vw_FineRecord where EmpName=N'" + value + "' AND "+ condition );
                }
                else
                {
                    //return b.SelectByQuery("SELECT * FROM vw_FineRecord WHERE "+ condition);
                    dt = b.SelectByQuery("select * from vw_FineRecord where " + condition);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectFindRecordView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_FineRecord");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByView(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("vw_FineRecord", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectFineCountView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Fine_Count");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectFineCountByCondition(string value, string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                if (value != "")
                {
                    //col.Add("EmpName");
                    //val.Add(value);
                    //return b.SelectByCondition("vw_Fine_Count", col, val, "EmpName=@EmpName AND " + condition + "");
                    dt = b.SelectByQuery("select * from vw_Fine_Count where EmpName=N'" + value + "' AND " + condition);
                }
                else
                {
                    //return b.SelectByQuery("SELECT * FROM vw_Fine_Count WHERE " + condition);
                    dt = b.SelectByQuery("select * from vw_Fine_Count where " + condition);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByQuery(string query)
        {
            Base b = new Base();
            return b.SelectByQuery(query);
        }

        public void DeleteById(int ID)
        {
            try
            {
                b.DeleteByCondition("Fine_Record", "ID=" + ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_FineRecord", start, end);
            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_FineRecord", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
