using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_Manual_HistoryDAO
    {
        Base b = new Base();
        public int Insert(FP_Manual_HistoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_Manual_History", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FP_Manual_HistoryVO vo)
        {
            int FP_Manual_HistoryID = 0;
            try
            {
                b.Update("FP_Manual_History", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                FP_Manual_HistoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return FP_Manual_HistoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("FP_Manual_History", key);
        }
        public bool isExistByCondition(string condition)
        {
            return b.isExist("FP_Manual_History", condition);
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_Manual_History");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public FP_Manual_HistoryVO GetByID(int id)
        {
            FP_Manual_HistoryVO vo = new FP_Manual_HistoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FP_Manual_HistoryVO()) as FP_Manual_HistoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_Manual_History", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
