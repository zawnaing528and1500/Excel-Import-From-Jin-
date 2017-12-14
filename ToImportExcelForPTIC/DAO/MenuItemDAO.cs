using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class MenuItemDAO
    {
        Base b = new Base();
        public int Insert(MenuItemVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("MenuItem", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(MenuItemVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("MenuItem", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
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
            return b.CheckRec("MenuItem", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("MenuItem");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public MenuItemVO GetByID(int id)
        {
            MenuItemVO vo = new MenuItemVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new MenuItemVO()) as MenuItemVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("MenuItem", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
