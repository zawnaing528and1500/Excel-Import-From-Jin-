using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class TrainingTypeDAO
    {
        Base b = new Base();
        public int Insert(TrainingTypeVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Training_Type", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(TrainingTypeVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Training_Type", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Training_Type", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Training_Type");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public TrainingTypeVO GetByID(int id)
        {
            TrainingTypeVO vo = new TrainingTypeVO();
            DataTable dt = Select("ID=" + id + "");
            if(dt.Rows.Count>0)
            vo = b.ConvertObj(dt.Rows[0], new TrainingTypeVO()) as TrainingTypeVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Training_Type", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Yearly_Training_Plan_Info_Join_Detail_View", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectByTrainingType(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("TrainingType");
                val.Add(value);
                return b.SelectByCondition("Training_Type", col, val, "TrainingType=@TrainingType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectByTrainingTypeName(string value)
        {
            Base b = new Base();
            List<string> col = new List<string>();
            col.Add("TrainingType");
            List<object> val = new List<object>();
            val.Add(value);

            return b.SelectByCondition("Training_Type", col, val, "TrainingType=@TrainingType");
        }

    }
}
