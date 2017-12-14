using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class MainMenuDAO
    {

        Base b = new Base();
        public int Insert(MainMenuVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("MainMenu", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(MainMenuVO vo)
        {
            int AssetID = 0;
            try
            {
                b.Update("MainMenu", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                AssetID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return AssetID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("MainMenu", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("MainMenu");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public MainMenuVO GetByID(int id)
        {
            MainMenuVO vo = new MainMenuVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new MainMenuVO()) as MainMenuVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("MainMenu", sql);
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
    }
}
