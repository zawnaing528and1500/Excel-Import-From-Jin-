using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class APSubCategoryDAO
    {
        Base b = new Base();
        public int Insert(APSubCategoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_SubCategory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APSubCategoryVO vo)
        {
            int subCategoryID = 0;
            try
            {
                b.Update("AP_SubCategory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                subCategoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subCategoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AP_SubCategory", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_SubCategory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllByColumns()
        {
            DataTable dt;
            try
            {
                dt = b.getColumn("AP_SubCategory","ID AS APSubCategoryID,APSubCategoryName","");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APSubCategoryVO GetByID(int id)
        {
            APSubCategoryVO vo = new APSubCategoryVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APSubCategoryVO()) as APSubCategoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_SubCategory", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectBySubCatName(string value, int catID)
        {
            Base b = new Base();
            DataTable dt = new DataTable();
            //List<string> col = new List<string>();
            //col.Add("APSubCategoryName");
            //List<object> val = new List<object>();
            //val.Add(value);
            //return b.SelectByCondition("AP_SubCategory", col, val, "APSubCategoryName=@APSubCategoryName and APCategoryID="+ catID);
            try
            {
                dt = b.SelectByQuery("select * from AP_SubCategory where APSubCategoryName=N'" + value + "' AND APCategoryID=" + catID);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
    }
}
