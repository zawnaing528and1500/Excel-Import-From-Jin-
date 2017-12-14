using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class AbsenceEntryDAO
    {
        Base b = new Base();
        public int Insert(AbsenceEntryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Absence_Entry", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AbsenceEntryVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Absence_Entry", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Absence_Entry", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Absence_Entry");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public AbsenceEntryVO GetByID(int id)
        {
            AbsenceEntryVO vo = new AbsenceEntryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AbsenceEntryVO()) as AbsenceEntryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Absence_Entry", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public bool isExistEmployee(int empId,DateTime date)
        {
            bool flg= false;
            try
            {
               DataTable dt = b.Select("Absence_Entry", "EmpId=" + empId + " AND AbsenceDate='" + date + "'");
               if (dt.Rows.Count > 0)
                   flg = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;
        }
        public bool isExistEmployeeByID(int empId, DateTime date, int id)
        {
            bool flg = false;
            try
            {
                DataTable dt = b.Select("Absence_Entry", "EmpId=" + empId + " AND AbsenceDate='" + date + "' AND ID <> " + id);
                if (dt.Rows.Count > 0)
                    flg = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;
        }
    }
}
