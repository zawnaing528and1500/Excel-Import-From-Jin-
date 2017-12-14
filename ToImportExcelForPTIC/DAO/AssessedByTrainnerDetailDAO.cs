using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
namespace Toyo.Core
{
    public class AssessedByTrainnerDetailDAO
    {

        Base b = new Base();
        public int Insert(AssessedByTrainerDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AssessedBy_Trainner_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssessedByTrainerDetailVO vo)
        {
            int detailID = 0;
            try
            {
                b.Update("AssessedBy_Trainner_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                detailID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detailID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AssessedBy_Trainner_Detail", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AssessedBy_Trainner_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AssessedBy_Trainner_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //to get detail info with attendee name
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_AssessebBy_Trainner_Detail_Attendee", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
