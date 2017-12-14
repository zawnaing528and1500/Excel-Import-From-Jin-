using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class FP_Shift_Management_SettingDAO
    {
        Base b = new Base();
        public int Insert(FP_Shift_Management_SettingVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("FP_Shift_Management_Setting", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(FP_Shift_Management_SettingVO vo)
        {
            int shiftID = 0;
            try
            {
                b.Update("FP_Shift_Management_Setting", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                shiftID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return shiftID;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("FP_Shift_Management_Setting", key);
        }

        public bool isExistShiftName(string Name, int shiftID)
        {
            bool exist = false;
            DataTable dt = new DataTable();
            List<string> col = new List<string>();
            List<object> val = new List<object>();

            col.Add("Name");
            val.Add(Name);
            if (shiftID == 0)
            {
                dt = b.SelectByCondition("FP_Shift_Management_Setting", col, val, "Name=@Name and IsDeleted=0");
            }
            else dt = b.SelectByCondition("FP_Shift_Management_Setting", col, val, "Name=@Name and IsDeleted=0 AND ID <> " + shiftID);
            
            if (dt.Rows.Count > 0)
                exist = true;
            return exist;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.Select("FP_Shift_Management_Setting","IsDeleted=0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public FP_Shift_Management_SettingVO GetByID(int id)
        {
            FP_Shift_Management_SettingVO vo = new FP_Shift_Management_SettingVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new FP_Shift_Management_SettingVO()) as FP_Shift_Management_SettingVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_Shift_Management_Setting", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
