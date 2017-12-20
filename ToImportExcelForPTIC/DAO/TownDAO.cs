using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class TownDAO
    {
        Base b = new Base();
        public int Insert(TownVO vo)
        {
            int lastInsertId = 0;
            try 
            {
                lastInsertId = b.Insert("Town", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex) 
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(TownVO vo)
        {
            int townID = 0;
            try 
            {
                b.Update("Town", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                townID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return townID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Town", key);
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("Town", id);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Town");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public TownVO GetByID(int id)
        {
            TownVO vo = new TownVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TownVO()) as TownVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Town", sql);
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

        public DataTable SelectByCondition(string value1, string value2)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                if (value1 != "" && value2 != "")
                {
                    //col.Add("Town");
                    //col.Add("StateDivisionName");
                    //val.Add(value1);
                    //val.Add(value2);
                    //return b.SelectByCondition("vw_Town_StateDiv", col, val, "Town=@Town AND StateDivisionName=@StateDivisionName");
                    dt = b.SelectByQuery("select * from vw_Town_StateDiv where Town=N'" + value1 + "' AND StateDivisionName=N'" + value2 + "'");
                }
                else if (value1 != "" && value2 == "")
                {
                    //col.Add("Town");
                    //val.Add(value1);
                    ////return b.SelectByCondition("vw_Town_StateDiv", col, val, "Town=@Town AND StateDivisionName=@StateDivisionName");
                    //return b.SelectByCondition("vw_Town_StateDiv", col, val, "Town=@Town");
                    dt = b.SelectByQuery("select * from vw_Town_StateDiv where Town=N'" + value1 + "'");
                }
                else if (value1 == "" && value2 != "")
                {
                    //col.Add("StateDivisionName");
                    //val.Add(value2);
                    //return b.SelectByCondition("vw_Town_StateDiv", col, val, "StateDivisionName=@StateDivisionName");
                    dt = b.SelectByQuery("select * from vw_Town_StateDiv where StateDivisionName=N'" + value2 + "'");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByConditions(string townName, int id, int Sid)
        {
            DataTable dt = new DataTable();
            try
            {
                if (id != 0)
                {
                    dt = b.SelectByQuery("Select * from Town where ID != " + id + " And Town = N'" + townName + "' And StateDivisionID = " + Sid);
                }
                else
                {
                    dt = b.SelectByQuery("select * from Town where Town = N'" + townName + "' And StateDivisionID =  " + Sid + "");
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            return dt;
        }


        public TownVO GetIDByName(string Name)
        {
            TownVO vo = new TownVO();

            DataTable dt = Select("Town='" + Name + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TownVO()) as TownVO;
            return vo;
        }
    }
}
