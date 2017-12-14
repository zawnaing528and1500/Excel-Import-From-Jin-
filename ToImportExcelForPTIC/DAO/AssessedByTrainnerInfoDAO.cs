using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class AssessedByTrainnerInfoDAO
    {
        Base b = new Base();
        public int Insert(AssessedByTrainerInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AssessedBy_Trainner_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AssessedByTrainerInfoVO vo)
        {
            int infoID = 0;
            try
            {
                b.Update("AssessedBy_Trainner_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                infoID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return infoID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AssessedBy_Trainner_Info", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AssessedBy_Trainner_Info");
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
                dt = b.Select("AssessedBy_Trainner_Info", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public AssessedByTrainerInfoVO GetByID(int id)
        {
            AssessedByTrainerInfoVO vo = new AssessedByTrainerInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AssessedByTrainerInfoVO()) as AssessedByTrainerInfoVO;
            return vo;
        }

    }
}
