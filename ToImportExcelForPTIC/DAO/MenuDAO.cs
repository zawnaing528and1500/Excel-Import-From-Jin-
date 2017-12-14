using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class MenuDAO
    {
         Base b = new Base();
        public int Insert(MenuVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Menu", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(MenuVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("Menu", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("Menu", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Menu");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public MenuVO GetByID(int id)
        {
            MenuVO vo = new MenuVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new MenuVO()) as MenuVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Menu", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
