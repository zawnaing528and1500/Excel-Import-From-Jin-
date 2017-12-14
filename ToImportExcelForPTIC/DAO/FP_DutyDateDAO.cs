using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_DutyDateDAO
    {
        Base b = new Base();
        public int Insert(FP_DutyDateVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_DutyDate", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FP_DutyDateVO vo)
        {
            int deviceID = 0;
            try
            {
                b.Update("FP_DutyDate", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                deviceID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deviceID;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("FP_DutyDate", key);
        }
        public FP_DutyDateVO GetByID(int id)
        {
            FP_DutyDateVO vo = new FP_DutyDateVO();
            DataTable dt = Select(String.Format("ID={0}", id));
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FP_DutyDateVO()) as FP_DutyDateVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_DutyDate", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_DutyDate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //FP_EMP_Duty_Define_View
        public DataTable SelectAllBy_DutyDefine_View()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_EMP_Duty_Define_View");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllBy_DutyDefine_ViewByID(string empId)
        {
            DataTable dt;
            try
            {
                dt = b.Select("FP_EMP_Duty_Define_View", empId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //FP_EMP_DUTY_UNDEFINED_VIEW
        public DataTable SelectAllBy_DutyUNdefine_View()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_EMP_DUTY_UNDEFINED_VIEW");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllBy_DutyUNdefine_ViewByID(string empId)
        {
            DataTable dt;
            try
            {
                dt = b.Select("FP_EMP_DUTY_UNDEFINED_VIEW", empId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void Delete(string id)
        {
            try
            {
                b.Delete("FP_DutyDate", id);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void DeleteByCondition(string condition)
        {
            try
            {
                b.DeleteByCondition("FP_DutyDate", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
