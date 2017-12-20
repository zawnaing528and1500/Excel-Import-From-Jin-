using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class AddressDAO
    {
        Base b = new Base();
        public int Insert(AddressVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Employee_Address", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(AddressVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Employee_Address", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Employee_Address", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Employee_Address");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public AddressVO GetByID(int id)
        {
            AddressVO vo = new AddressVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AddressVO()) as AddressVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Employee_Address", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable SelectByQuery(string query)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void DeleteByEmpID(string EmpID)
        {
            try
            {
                b.DeleteByCondition("Employee_Address", "EmpID=" + EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //12_12_2017 (Zaw Naing)

        #region get TownshipId from Township Name
        public AddressVO GetIDByName(string townshipName)
        {
            AddressVO vo = new AddressVO();

            DataTable dt = SelectTownshipID("Township=N'" + townshipName + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AddressVO()) as AddressVO;
            return vo;
        }
        public DataTable SelectTownshipID(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Township", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region get StateDivisionID from StateDIvision Name
        public AddressVO GetStateDivisionIDByName(string stateDivisionName)
        {
            AddressVO vo = new AddressVO();

            DataTable dt = SelectStateDivisionID("StateDivisionName=N'" + stateDivisionName + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new AddressVO()) as AddressVO;
            return vo;
        }

        public DataTable SelectStateDivisionID(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("StateDivision", sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #endregion

    }
}
