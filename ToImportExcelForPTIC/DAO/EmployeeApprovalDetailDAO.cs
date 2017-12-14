using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
   public class EmployeeApprovalDetailDAO
   {

       Base b = new Base();
       public int Insert(EmployeeApprovalDetailVO vo)
       {
           int lastInsertId = 0;
           try
           {
               lastInsertId = b.Insert("Employee_Approval_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return lastInsertId;
       }

       public int Update(EmployeeApprovalDetailVO vo)
       {
           int detailID = 0;
           try
           {
               b.Update("Employee_Approval_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
               detailID = vo.Id;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return detailID;
       }

       public bool isExist(string key)
       {
           return b.CheckRec("Employee_Approval_Detail", key);
       }

       public DataTable SelectAll()
       {
           DataTable dt;
           try
           {
               dt = b.SelectAll("Employee_Approval_Detail");
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }

       public EmployeeApprovalDetailVO GetByID(int id)
       {
           EmployeeApprovalDetailVO vo = new EmployeeApprovalDetailVO();
           DataTable dt = Select("ID=" + id + "");
           if (dt.Rows.Count > 0)
               vo = b.ConvertObj(dt.Rows[0], new EmployeeApprovalDetailVO()) as EmployeeApprovalDetailVO;
           return vo;
       }

       public DataTable Select(string sql)
       {
           DataTable dt = new DataTable();
           try
           {
               dt = b.Select("Employee_Approval_Detail", sql);
           }
           catch (Exception ex)
           { throw ex; }
           return dt;
       }
    
   }
}
