using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using Toyo.Core;

namespace Toyo.Core
{
   public class OfficeAccessoriesStockInDAO
   {
       Base b = new Base();
       public int Insert(OfficeAccessoriesStockInVO vo)
       {
           int lastInsertId = 0 ;
           try
           {
              lastInsertId = b.Insert("OfficeAccessories_StockIn", b.ConvertColName(vo), b.ConvertValueList(vo));
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return lastInsertId;
       }

       public int Update(OfficeAccessoriesStockInVO vo)
       {
           int stockInInfoID = 0;
           try
           {
               b.Update("OfficeAccessories_StockIn", vo.Id.ToString(),b.ConvertColName(vo),b.ConvertValueList(vo));
               stockInInfoID = vo.Id;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return stockInInfoID;
       }
       public bool isExist(string key)
       {
           return b.CheckRec("OfficeAccessories_StockIn", key);
       }
       public OfficeAccessoriesStockInVO GetByID(int id)
       {
           OfficeAccessoriesStockInVO vo = new OfficeAccessoriesStockInVO();
           DataTable dt = Select("ID=" + id + "");
           if (dt.Rows.Count > 0)
               vo = b.ConvertObj(dt.Rows[0], new OfficeAccessoriesStockInVO()) as OfficeAccessoriesStockInVO;
           return vo;
       }

       public DataTable Select(string sql)
       {
           DataTable dt = new DataTable();
           try
           {
               dt = b.Select("OfficeAccessories_StockIn", sql);
           }
           catch (Exception ex)
           { throw ex; }
           return dt;
       }
       public DataTable SelectAll()
       {
           DataTable dt;
           try
           {
               dt = b.SelectAll("OfficeAccessories_StockIn");
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }
       public DataTable SelectAllView()
       {
           DataTable dt;
           try
           {
               dt = b.SelectAll("vw_OfficeAccessories_StockIn");
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }

       public DataTable SelectAllCategory()
       {
           DataTable dt = new DataTable();
           try
           {               
               dt = b.SelectAll("vw_OfficeAccessoriesStockIn_XML_Path");
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }
       public DataTable SelectViewByCondition(string condition)
       {
           DataTable dt;
           try
           {
               dt = b.Select("vw_OfficeAccessoriesStockIn_XML_Path", condition);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }
       //vw_OfficeAccessories_StockIn_Info_Detail
       public DataTable SelectStockIn_Info_Detail(string condition)
       {
           DataTable dt;
           try
           {
               dt = b.Select("vw_OfficeAccessories_StockIn_Info_Detail", condition);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }

       public int CreateInfo_Detail(object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
       {
           int lastInsertId = 0;
           try
           {
               lastInsertId = b.CreateInfo_Detail("OfficeAccessories_StockIn", "OfficeAccessories_StockIn_Detail", vo, detalVoList, queryList, deleteList);
           }
           catch (SqlException ex)
           {
               throw ex;
           }
           return lastInsertId;
       }
       public int UpdateInfo_Detail(int infoId, object vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
       {
           int lastInsertId = 0;
           try
           {
               lastInsertId = b.UpdateInfo_Detail("OfficeAccessories_StockIn", "OfficeAccessories_StockIn_Detail", infoId, vo, detalVoList, queryList, deleteList);
           }
           catch (SqlException ex)
           {
               throw ex;
           }
           return lastInsertId;
       }

       // Su Wut Yee Naing (18.02.2016) 
       // For Paging
       public DataTable SelectTopRowsFinal(int start, int end)
       {
           DataTable dt;
           try
           {
               dt = b.SelectTopRowsFinal("vw_OfficeAccessoriesStockIn_XML_Path", start, end);
           }
           catch (SqlException Sql)
           { throw Sql; }
           return dt;
       }
       public DataTable SelectTopRowByCondition(double count, int start, string condition)
       {
           DataTable dt;
           try
           {
               dt = b.SelectTopRowByCondition("vw_OfficeAccessoriesStockIn_XML_Path", condition, count, start);
           }
           catch (SqlException Sql)
           { throw Sql; }
           return dt;
       }
    }
}
