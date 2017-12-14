using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class RegularMotorCarCheckDetailDAO
    {
        Base b = new Base();
        public int Insert(RegularMotorCarCheckDetailVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Regular_Motor_Car_Check_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(RegularMotorCarCheckDetailVO vo)
        {
            int deviceID = 0;
            try
            {
                b.Update("Regular_Motor_Car_Check_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Regular_Motor_Car_Check_Detail", key);
        }
        public RegularMotorCarCheckDetailVO GetByID(int id)
        {
            RegularMotorCarCheckDetailVO vo = new RegularMotorCarCheckDetailVO();
            DataTable dt = Select(String.Format("ID={0}", id));
            if(dt.Rows.Count>0)
             vo = b.ConvertObj(dt.Rows[0], new RegularMotorCarCheckDetailVO()) as RegularMotorCarCheckDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Regular_Motor_Car_Check_Detail", sql);
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
                dt = b.SelectAll("Regular_Motor_Car_Check_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_RegularMotorCheck_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
