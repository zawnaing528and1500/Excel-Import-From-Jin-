using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FPManualSettingDAO
    {
        Base b = new Base();
        public int Insert(FPManualSettingVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_ManualSetting", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FPManualSettingVO vo)
        {
            int stockInInfoID = 0;
            try
            {
                b.Update("FP_ManualSetting", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                stockInInfoID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stockInInfoID;
        }
        public int UpdateByAtt(FPManualSettingVO vo)
        {
            int ID = 0;
            try
            {
                b.UpdateByConditon("FP_ManualSetting", "AttendanceID=" + vo.AttendanceID + " AND EMPID='" + vo.EmpID + "'", b.ConvertColName(vo), b.ConvertValueList(vo));
               
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
            return b.CheckRec("FP_ManualSetting", key);
        }
        public FPManualSettingVO GetByID(int id)
        {
            FPManualSettingVO vo = new FPManualSettingVO();
            DataTable dt = Select("ID=" + id + "");
            if(dt.Rows.Count >0)
             vo = b.ConvertObj(dt.Rows[0], new FPManualSettingVO()) as FPManualSettingVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_ManualSetting", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        //Select Top Row From View(Su Wut Yee 29.7.2015)
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_FP_Manual_Setting", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectTopRows(int size,int start)
        {
            DataTable dt = new DataTable();
            try
            {
                if (start < 0)
                    start = 0;
                dt = b.SelectTopRows("vw_FP_Manual_Setting", size,start);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        //Select Top Row From View By Condition(Su Wut Yee 29.7.2015)
        public DataTable SelectTopRowsByCondition(int size, int start,string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectTopRowByCondition("vw_FP_Manual_Setting", condition, size, start);
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
                dt = b.SelectAll("FP_ManualSetting");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_FP_Manual_Setting");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllViewByCondition(string condition)
        {
            DataTable dt=new DataTable();
            try
            {
               dt= b.Select("vw_FP_Manual_Setting", condition);
            }
            catch (Exception ex)
            { 
                
            }
            return dt;
        }
         
        public bool isExistDateNid(string Condition)
        {
            return b.isExist("FP_ManualSetting", Condition);
        }
        public int Delete(string id)
        {
            int effectedId = 0;
            try
            {
                effectedId = b.Delete("FP_ManualSetting", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return effectedId;
        }
       
    }
}
