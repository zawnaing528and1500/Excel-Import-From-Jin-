using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class RegularMotorCarCheckInfoDAO
    {
        Base b = new Base();
        public int Insert(RegularMotorCarCheckInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Regular_Motor_Car_Check_Info", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(RegularMotorCarCheckInfoVO vo)
        {
            int deviceID = 0;
            try
            {
                b.Update("Regular_Motor_Car_Check_Info", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Regular_Motor_Car_Check_Info", key);
        }
        public RegularMotorCarCheckInfoVO GetByID(int id)
        {
            RegularMotorCarCheckInfoVO vo = new RegularMotorCarCheckInfoVO();
            DataTable dt = Select(String.Format("ID={0}", id));
            if(dt.Rows.Count >0)
                vo = b.ConvertObj(dt.Rows[0], new RegularMotorCarCheckInfoVO()) as RegularMotorCarCheckInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Regular_Motor_Car_Check_Info", sql);
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
                dt = b.SelectAll("Regular_Motor_Car_Check_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //vw_Regular_Motor_Car_Check_Info
        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Regular_Motor_Car_Check_Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Regular_Motor_Car_Check_Info", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.CreateInfo_Detail("Regular_Motor_Car_Check_Info", "Regular_Motor_Car_Check_Detail", vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public int UpdateInfo_Detail(int infoId, object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.UpdateInfo_Detail("Regular_Motor_Car_Check_Info", "Regular_Motor_Car_Check_Detail", infoId, vo, detalVoList, queryList, deleteList);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        //Ywet Nu Wai Tin
        #region For Paging
        public DataTable SelectTopRows(double count, int start)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRows("vw_Regular_Motor_Car_Check_Info", count, start);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }


        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Regular_Motor_Car_Check_Info", start, end);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }


        public DataTable SelectTopRowByCondition(double count,int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Regular_Motor_Car_Check_Info", condition, count,start);
              
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }
        #endregion
    }
}
