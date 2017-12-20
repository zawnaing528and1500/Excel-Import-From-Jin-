using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class DepartmentDAO
    {
        Base b = new Base();
        public int Insert(DepartmentVO vo)
        {
            int lastInsertId = 0;

            try
            {
                lastInsertId = b.Insert("Department", b.ConvertColName(vo), b.ConvertValueList(vo));

            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return lastInsertId;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Department", key);
        }

        public int Update(DepartmentVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Department", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return ID;
        }

        public DepartmentVO GetByID(int id)
        {
            DepartmentVO vo = new DepartmentVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new DepartmentVO()) as DepartmentVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Department", sql);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Department");
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return dt;
        }
        
        public DataTable SelectByDeptName(string value)
        {
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();
                col.Add("Name");
                val.Add(value);
                return b.SelectByCondition("Department", col, val, "DeptName=@Name");
            }
            catch (SqlException sql)
            {
                throw sql;
            }
        }

        public DataTable SelectByQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectByQuery(query);
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            return dt;
        }

        public DepartmentVO GetIDByName(string deptName)
        {
            DepartmentVO vo = new DepartmentVO();

            DataTable dt = Select("DeptName='" + deptName + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new DepartmentVO()) as DepartmentVO;
            return vo;
        }

        //To get PositionID when Employee Data is going to insert into dbo.Employee
        public int SelectIDByDeptName(string value)
        {
            int ID = 0;
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("DeptName");
                val.Add(value);

                dt = b.SelectByCondition("Department", col, val, "DeptName=@DeptName");
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ID"] != System.DBNull.Value)
                    {
                        string Id = dt.Rows[0][0].ToString();
                        ID = Convert.ToInt32(Id);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }

    }
}
