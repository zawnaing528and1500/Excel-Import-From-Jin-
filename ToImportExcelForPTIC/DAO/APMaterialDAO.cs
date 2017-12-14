using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class APMaterialDAO
    {
        Base b = new Base();
        public int Insert(APMaterialVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("AP_Material", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APMaterialVO vo)
        {
            int apMaterialID = 0;
            try
            {
                b.Update("AP_Material", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                apMaterialID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return apMaterialID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AP_Material", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_Material");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //AP_Material_Join_APSubCategory_View
        public DataTable SelectAllByView()
        {
            DataTable dt = new DataTable("APSUBMaterial");
            try
            {
                dt = b.SelectAll("AP_Material_Join_APSubCategory_View");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APMaterialVO GetByID(int id)
        {
            APMaterialVO vo = new APMaterialVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new APMaterialVO()) as APMaterialVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_Material", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByAPMaterialName(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                //col.Add("APMaterialName");
                //val.Add(value);
                //return b.SelectByCondition("AP_Material", col, val, "APMaterialName=@APMaterialName");
                dt = b.SelectByQuery("select * from AP_Material where APMaterialName=N'" + value + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByAPMaterialNameView(string value)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                //col.Add("APMaterialName");
                //val.Add(value);
                //return b.SelectByCondition("APMaterial_Join_APSubCategory_View", col, val, "APMaterialName=@APMaterialName");
                dt = b.SelectByQuery("select * from APMaterial_Join_APSubCategory_View where APMaterialName=N'" + value + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
