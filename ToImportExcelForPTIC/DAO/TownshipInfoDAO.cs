using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class TownshipInfoDAO
    {
        Base b = new Base();
        public int Insert(TownshipInfoVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Township", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(TownshipInfoVO vo)
        {
            int townID = 0;
            try
            {
                b.Update("Township", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Township", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Township");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public TownshipInfoVO GetByID(int id)
        {
            TownshipInfoVO vo = new TownshipInfoVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TownshipInfoVO()) as TownshipInfoVO;
            return vo;
        }

        public DataTable Select(string sql)
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

        public DataTable SelectByCondition(string value1, string value2)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                if (value1 != "" && value2 != "")
                {
                    //col.Add("Township");
                    //col.Add("Town");
                    //val.Add(value1);
                    //val.Add(value2);
                    //return b.SelectByCondition("vw_Township_Town", col, val, "Township=@Township AND Town=@Town");
                    dt = b.SelectByQuery("select * from vw_Township_Town where Township=N'" + value1 + "' AND Town=N'" + value2 + "'");
                }
                else if (value1 != "" && value2 == "")
                {
                    //col.Add("Township");
                    //val.Add(value1);
                    //return b.SelectByCondition("vw_Township_Town", col, val, "Township=@Township");
                    dt = b.SelectByQuery("select * from vw_Township_Town where Township=N'" + value1 + "'");
                }
                else if (value1 == "" && value2 != "")
                {
                    //col.Add("Town");
                    //val.Add(value2);
                    //return b.SelectByCondition("vw_Township_Town", col, val, "Town=@Town");
                    dt = b.SelectByQuery("select * from vw_Township_Town where Town=N'" + value2 + "'");
                }
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

        public DataTable SelectViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Township_Town", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllByView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Township_Town");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectByConditions(string townShip, int id, int Tid)
        {
            DataTable dt = new DataTable();
            try
            {
                if (id != 0)
                {
                    dt = b.SelectByQuery("select * from Township where ID != " + id + " And Township = N'" + townShip + "' And TownID = " + Tid);
                }
                else
                {
                    dt = b.SelectByQuery("select * from Township where Township = N'" + townShip + "' And TownID = " + Tid);

                }
            }
            catch (Exception er)
            {
                throw er;
            }
            return dt;
        }

        public TownshipInfoVO GetIDByName(string Name)
        {
            TownshipInfoVO vo = new TownshipInfoVO();

            DataTable dt = Select("Township=N'" + Name + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new TownshipInfoVO()) as TownshipInfoVO;
            return vo;
        }

        public int SelectIDByTownshipName(string value)
        {
            int ID = 0;
            DataTable dt = new DataTable();
            try
            {
                List<string> col = new List<string>();
                List<object> val = new List<object>();

                col.Add("Township");
                val.Add(value);

                dt = b.SelectByCondition("Township", col, val, "Township=@Township");
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

