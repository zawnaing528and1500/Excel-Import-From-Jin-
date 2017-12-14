using System;
using System.Data;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class ScheduleDAO
    {
        Base b = new Base();
        public int Insert(ScheduleVO vo)
        {
            int lastInsertId = 0;

            try
            {
                lastInsertId = b.Insert("FP_Scheduling", b.ConvertColName(vo), b.ConvertValueList(vo));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("FP_Scheduling", key);
        }

        public int Update(ScheduleVO vo)
        {
            int vehiclePartID = 0;
            try
            {
                b.Update("FP_Scheduling", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                vehiclePartID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vehiclePartID;
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("FP_Scheduling", id);
            }
            catch (Exception ex) { throw ex; }
        }

        public ScheduleVO GetByID(int id)
        {
            ScheduleVO vo = new ScheduleVO();
            DataTable dt = Select(String.Format("ID={0}", id));
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new ScheduleVO()) as ScheduleVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_Scheduling", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByView(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("VW_Scheduling", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectScheduleByEmpIDandDate(string EmpId, DateTime date)
        {
            //vw_Scheduling_Combine_Shift
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_FP_Emp_Sch_Shift", "EmpId=" + EmpId + " AND '" + date.Date + "' BETWEEN FROMDATE AND TODATE");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByScheduleRelationShift(string ScheduleId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Scheduling_Relation_Shift", "ScheduleId=" + ScheduleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("FP_Scheduling");
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
                dt = b.SelectAll("VW_Scheduling");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectViewForShowAll()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("VW_Scheduling_For_Search_ToDate");
            }
            catch (Exception err)
            {

                throw err;
            }
            return dt;
        }
        //For Paging(29.7.2015)
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM (SELECT ROW_NUMBER() OVER ( ORDER BY FromDate,TODATE,Empid desc) AS RowNum, ID,ShiftID,EmpId,FromDate ,(CASE WHEN ToDate = CAST('9998-12-31' AS DATE)  THEN 'No End Date' ELSE CONVERT(varchar,ToDate, 103) END) AS TDate,Name,EmpName,DeptID,DeptName,FingerID FROM VW_Scheduling) AS RowConstrainedResult where  RowNum >=" + start + "  AND RowNum <= " + end + " ORDER BY RowNum ";
                dt = b.SelectByQuery(query);
            }
            catch (SqlException Sql)
            { throw Sql; }
            return dt;
        }

        public DataTable SelectTopRows(int size, int start)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRows("VW_Scheduling", size, start);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectTopRowsByCondition(int size, int start, string condition, DateTime? _FromDate, DateTime? _ToDate, int? _DeptId, int? _fingerId, int? _shiftId)
        {
            DataTable dt = new DataTable();
            try
            {
                if (_FromDate.HasValue)
                {
                    string condi = null;
                    // SELECT TOP {0} (ROW_NUMBER() OVER ( ORDER BY Id desc)+{2}) AS RowNum,* FROM {1} WHERE ID NOT IN (SELECT TOP {2} ID FROM {1} WHERE {3}  order by ID desc) and {3} ", count, tblName, start, condition);
                    string query = "SElECT Top " + size + " (ROW_NUMBER() OVER ( ORDER BY Id desc)+" + start + ") AS RowNum, ID,ShiftID,EmpId, (case when '" + _FromDate.Value.ToString("yyyy-MM-dd") + "' > FromDate Then '" + _FromDate.Value.ToString("yyyy-MM-dd") + "' Else FromDate End) AS FromDate ,";
                    query += "  (Case When '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' < ToDate Then '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' Else ToDate End) AS TDate,Name,EmpName,DeptID,DeptName,FingerID ";
                    query += " FROM VW_Scheduling_For_Search_ToDate WHERE ID NOT IN (SELECT TOP " + start + " ID FROM VW_Scheduling_For_Search_ToDate ";
                    query += " WHERE FromDate <= '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' and ToDate >= '" + _FromDate.Value.ToString("yyyy-MM-dd") + "'";
                    condi = " FromDate <= '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' and ToDate >= '" + _FromDate.Value.ToString("yyyy-MM-dd") + "'";
                    if (_DeptId != null)
                    {
                        query += " AND DeptId=" + _DeptId;
                        condi += " AND DeptId=" + _DeptId;
                    }
                    if (_fingerId != null)
                    {
                        query += " AND FingerId=" + _fingerId;
                        condi += " AND FingerId=" + _fingerId;
                    }
                    if (_shiftId != null)
                    {
                        query += " AND ShiftId=" + _shiftId;
                        condi += " AND ShiftId=" + _shiftId;
                    }
                    query += " order by ID desc) and " + condi;
                    dt = b.SelectByQuery(query);
                }
                else
                {
                    dt = b.SelectTopRowByCondition("VW_Scheduling", condition, size, start);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllViewByID(string condition)
        {
            DataTable dt;
            try
            {
                dt = b.Select("VW_Scheduling", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable getColumnByView(string condition, DateTime? _FromDate, DateTime? _ToDate, int? _deptId, int? _fingerId, int? _shiftId)
        {
            DataTable dt = new DataTable();
            try
            {
                if (_FromDate != null)
                {
                    string query = "Select ID,ShiftID,EmpId, (case when '" + _FromDate.Value.ToString("yyyy-MM-dd") + "' > FromDate Then '" + _FromDate.Value.ToString("yyyy-MM-dd") + "' Else FromDate End) AS FromDate ,";
                    query += "  (Case When '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' < ToDate Then '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' Else ToDate End) AS ToDate,Name,EmpName,DeptID,DeptName,FingerID from VW_Scheduling_For_Search_ToDate ";
                    query += "where FromDate <= '" + _ToDate.Value.ToString("yyyy-MM-dd") + "' and ToDate >= '" + _FromDate.Value.ToString("yyyy-MM-dd") + "'";
                    if (_deptId != null)
                    {
                        query += " AND DeptId=" + _deptId;
                    }
                    if (_fingerId != null)
                    {
                        query += " AND FingerId=" + _fingerId;
                    }
                    if (_shiftId != null)
                    {
                        query += " AND ShiftId=" + _shiftId;
                    }
                    dt = b.SelectByQuery(query);
                }
                else
                {
                    dt = b.getColumn("VW_Scheduling_For_Search_ToDate", "ID,ShiftID,EmpId,FromDate, (CASE WHEN ToDate = CAST('9998-12-31' AS DATE)  THEN 'No End Date' ELSE CONVERT(varchar,ToDate, 103) END) AS TDate,Name,EmpName,DeptID,DeptName,FingerID", condition);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public bool isExistSchedule(string condition)
        {
            try
            {
                return b.isExist("FP_Scheduling", condition);
            }
            catch (Exception ex) { throw ex; }
        }

        public void DeleteSchedule(string condition)
        {
            try
            {
                b.DeleteByCondition("FP_Scheduling", condition);
            }
            catch (Exception ex) { throw ex; }
        }

        //FP_EmployeeWithSchedule_View
        public DataTable SelectEmpWithScheduleViewByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_FP_Emp_Sch_Shift", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //vw_FP_Emp_Sch_Shift
        public DataTable SelectEmpSchShift(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_FP_Emp_Sch_Shift", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
