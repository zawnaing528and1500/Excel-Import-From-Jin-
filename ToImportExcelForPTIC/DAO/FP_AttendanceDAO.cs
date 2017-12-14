using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Toyo.Core
{
    public class FP_AttendanceDAO
    {
        Base b = new Base();
        public int Insert(FP_AttendanceVO vo)
        {
            //if (vo.InTime == TimeSpan.Parse("00:00:00"))
            //{
            //    if (vo.Late > TimeSpan.Parse("23:59:59"))
            //        vo.Late = TimeSpan.Parse("00:00:00");
            //}
            //if (vo.OutTime == TimeSpan.Parse("00:00:00"))
            //{
            //    if (vo.EarlyOut > TimeSpan.Parse("23:59:59"))
            //        vo.EarlyOut = TimeSpan.Parse("00:00:00");
            //}






            int lastInsertId = 0;
            try
            {
                string condition = "ShiftDateIn='" + vo.ShiftDateIn + "' AND ShiftDateOut='" + vo.ShiftDateOut + "' AND  InDate='" + vo.InDate + "' AND OutDate='" + vo.OutDate + "' AND EMPID='" + vo.EmpID + "' and ShiftID=" + vo.ShiftID;
                DataTable dt = b.Select("FP_Attendance", condition);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool flg = (bool)dr["isOtherActivity"];
                        if (!flg)
                        {
                            FP_AttendanceDAO dao = new FP_AttendanceDAO();
                            lastInsertId = dao.Update(vo);
                        }
                    }
                }
                else
                {
                    // id = dao.Insert(vo);
                    lastInsertId = b.Insert("FP_Attendance", b.ConvertColName(vo), b.ConvertValueListNullable(vo));
                }
                //lastInsertId = b.Insert("FP_Attendance", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public int UpdateByAttendanceID(FP_AttendanceVO vo)
        {
            int ID = 0;
            try
            {
                b.Update("FP_Attendance", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueListNullable(vo));
                ID = vo.Id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ID;
        }
        public int Update(FP_AttendanceVO vo)
        {
            int ID = 0;
            try
            {
                b.UpdateByConditon("FP_Attendance", "ShiftDateIn='" + vo.ShiftDateIn + "' AND ShiftDateOut='" + vo.ShiftDateOut + "' AND InDate='" + vo.InDate + "' AND OutDate='" + vo.OutDate + "' AND EMPID='" + vo.EmpID + "' AND ShiftID='" + vo.ShiftID + "'", b.ConvertColName(vo), b.ConvertValueList(vo));
                ID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }
        public bool isExist(string conditon)
        {
            return b.isExist("FP_Attendance", conditon);
        }
        public FP_AttendanceVO GetByID(int id)
        {
            FP_AttendanceVO vo = new FP_AttendanceVO();
            DataTable dt = Select(String.Format("ID={0}", id));
            if (dt.Rows.Count > 0)
                vo = b.ConvertObjWithImage(dt.Rows[0], new FP_AttendanceVO()) as FP_AttendanceVO;
            return vo;
        }
        public void Delete(string id)
        {
            try
            {
                b.Delete("FP_Attendance", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("FP_Attendance", sql);
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
                dt = b.SelectAll("FP_Attendance");
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
                dt = b.SelectAll("vw_FP_Attendance");
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
                dt = b.Select("vw_FP_Attendance", condition);
            }
            catch (Exception ex)
            { throw ex; }
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
        public int DeleteByCondition(string condition)
        {
            int effectedId = 0;
            try
            {
                effectedId = b.DeleteByCondition("FP_Attendance", condition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return effectedId;
        }
        #region Payroll Calculation
        public int getLateCount(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                DataTable dt = b.SelectByQuery("SELECT COUNT(LATE) AS LATECOUNT from FP_Attendance where InDate >= '" + fromdate.ToShortDateString() + "' and InDate <= '" + todate.ToShortDateString() + "' AND EMPID='" + empId + "' AND LATE <> '00:00:00'");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["LATECOUNT"] != "")
                        count = int.Parse(dr["LATECOUNT"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
        public int getLateMinutes(string empId, DateTime fromdate, DateTime todate)
        {
            int totalMinutes = 0;
            try
            {
                string query = "SELECT (SUM(DATEPART(hh, CAST(dbo.FP_Attendance.Late AS DATETIME))) + SUM(DATEPART(MINUTE, CAST(dbo.FP_Attendance.Late AS DATETIME))) / 60) + (SUM(DATEPART(MINUTE, ";
                query += "CAST(dbo.FP_Attendance.Late AS DATETIME))) % 60 + SUM(DATEPART(SECOND, CAST(dbo.FP_Attendance.Late AS DATETIME))) / 60) / 60 AS LateHours, ";
                query += "(SUM(DATEPART(MINUTE, CAST(dbo.FP_Attendance.Late AS DATETIME))) % 60 + SUM(DATEPART(SECOND, CAST(dbo.FP_Attendance.Late AS DATETIME))) / 60) ";
                query += "% 60 AS LateMinutes, SUM(DATEPART(SECOND, CAST(dbo.FP_Attendance.Late AS DATETIME))) % 60 AS LateSeconds, ";
                query += "SUM(CASE WHEN Late <> '00:00:00' THEN 1 ELSE 0 END) AS LateCount FROM FP_Attendance ";
                query += " WHERE InDate >= '" + fromdate.ToShortDateString() + "' AND InDate <= '" + todate.ToShortDateString() + "' AND EmpID= '" + empId + "' AND Late <> '00:00:00' ";

                DataTable dt = b.SelectByQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    int hr = int.Parse(dr["LATEHOURS"].ToString());
                    int min = int.Parse(dr["LATEMINUTES"].ToString());
                    int sec = int.Parse(dr["LATESECONDS"].ToString());
                    totalMinutes = hr * 60 + min + sec / 60;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalMinutes;
        }
        public int getEarlyLeaveTime(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                DataTable dt = b.SelectByQuery("SELECT COUNT(EarlyOut) AS EarlyOutCount from FP_Attendance where InDate >= '" + fromdate.ToShortDateString() + "' and InDate <= '" + todate.ToShortDateString() + "' AND EMPID='" + empId + "' AND EarlyOut <> '00:00:00'");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["EarlyOutCount"].ToString() != "")
                        count = int.Parse(dr["EarlyOutCount"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }

        public int getEarlyLeaveMinutes(string empId, DateTime fromdate, DateTime todate)
        {
            int totalMinutes = 0;
            try
            {
                string query = "SELECT (SUM(DATEPART(hh,CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) + SUM(DATEPART(MINUTE, CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) / 60) + (SUM(DATEPART(MINUTE, ";
                query += "CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) % 60 + SUM(DATEPART(SECOND, CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) / 60) / 60 AS EarlyOutHours, ";
                query += "(SUM(DATEPART(MINUTE, CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) % 60 + SUM(DATEPART(SECOND, CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) ";
                query += "/ 60) % 60 AS EarlyOutMinutes, SUM(DATEPART(SECOND, CAST(dbo.FP_Attendance.EarlyOut AS DATETIME))) % 60 AS EarlyOutSeconds, ";
                query += "SUM(CASE WHEN EarlyOut <> '00:00:00' THEN 1 ELSE 0 END) AS EarlyOutCount FROM FP_Attendance ";
                query += "  WHERE InDate >= '" + fromdate.ToShortDateString() + "' AND InDate <= '" + todate.ToShortDateString() + "' AND EmpID= '" + empId + "' AND EarlyOut <> '00:00:00'";
                // DataTable dt = b.SelectByQuery("SELECT EarlyOutHOURS,EarlyOutMINUTES,EarlyOutSECONDS FROM vw_Monthly_EarlyOut WHERE EmpID=" + empId + " AND Month=" + month + " AND Year=" + year + "");
                DataTable dt = b.SelectByQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    int hr = int.Parse(dr["EarlyOutHOURS"].ToString());
                    int min = int.Parse(dr["EarlyOutMINUTES"].ToString());
                    int sec = int.Parse(dr["EarlyOutSECONDS"].ToString());
                    totalMinutes = hr * 60 + min + sec / 60;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalMinutes;
        }

        #region Get Actual Working Days
        public int getActualWorkingDays(string empId, DateTime fromDate, DateTime toDate)
        {
            int actualworkingdays = 0;
            try
            {
                DataTable dt = b.SelectByQuery("SELECT COUNT(*) AS ActualWorkingDays from FP_Attendance WHERE EmpID='" + empId + "'  and  FP_Attendance.InDate >='" + fromDate.ToShortDateString() + "' AND  FP_Attendance.InDate <= '" + toDate.ToShortDateString() + "'");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ActualWorkingDays"].ToString() != "")
                        actualworkingdays = int.Parse(dr["ActualWorkingDays"].ToString());
                }
                //actualworkingdays = actualworkingdays + 1;

            }
            catch (Exception e)
            { throw e; }
            return actualworkingdays;
        }
        #endregion


        public int getAbsenteeismTimes(string empId, DateTime fromdate, DateTime todate)
        {
            int AbsentTimes = 0;
            try
            {
                DataTable dt = b.SelectByQuery("SELECT COUNT(*) AS AbsentTimes FROM Absence_Entry WHERE EMPID=" + empId + "  AND  Absence_Entry.AbsenceDate >= '" + fromdate.ToShortDateString() + "' AND Absence_Entry.AbsenceDate <='" + todate.ToShortDateString() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["AbsentTimes"].ToString() != "")
                        AbsentTimes = int.Parse(dr["AbsentTimes"].ToString());
                }

            }
            catch (Exception ex)
            { throw ex; }
            return AbsentTimes;
        }

        public int getCasualLeave(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Casual Leave");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }
        public int getAnnualLeave(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Annual Leave");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }

        //Medical Leave
        public int getMedicalLeave(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Medical Leave");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }

        //Maternal Leave
        public int getMaternalLeave(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                //DataTable dt = b.SelectByQuery("SELECT UsedLeave FROM vw_UsedLeave WHERE FromDate >='" + fromdate.ToShortDateString() + "' AND TODATE <='" + todate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Maternal Leave'");
                // DataTable dt = b.SelectByQuery("SELECT SUM(UsedLeave) AS UsedLeave FROM vw_UsedLeave WHERE FromDate <='" + todate.ToShortDateString() + "' AND TODATE >='" + fromdate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Maternal Leave'");

                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Maternal Leave");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);


                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }

        // PL
        public int getParentalLeave(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                // DataTable dt = b.SelectByQuery("SELECT SUM(USEDLEAVE) AS UsedLeave FROM vw_UsedLeave WHERE FromDate <='" + todate.ToShortDateString() + "' AND TODATE >='" + fromdate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Parental Leave'");
                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Parental Leave");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }

        //Leave Without Pay
        public int getLeaveWithoutPay(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                //DataTable dt = b.SelectByQuery("SELECT UsedLeave FROM vw_UsedLeave WHERE FromDate >='" + fromdate.ToShortDateString() + "' AND TODATE <='" + todate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Leave Without Pay'");
                //  DataTable dt = b.SelectByQuery("SELECT SUM(UsedLeave) AS UsedLeave FROM vw_UsedLeave WHERE FromDate <='" + todate.ToShortDateString() + "' AND TODATE >='" + fromdate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Leave Without Pay'");
                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Leave Without Pay");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }
        //Medical Leave Without Pay
        public int getMedicalLeaveWithoutPay(string empId, DateTime fromdate, DateTime todate)
        {
            int count = 0;
            try
            {
                //DataTable dt = b.SelectByQuery("SELECT UsedLeave FROM vw_UsedLeave WHERE FromDate >='" + fromdate.ToShortDateString() + "' AND TODATE <='" + todate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Medical Leave Without Pay'");
                //  DataTable dt = b.SelectByQuery("SELECT SUM(UsedLeave) AS UsedLeave FROM vw_UsedLeave WHERE FromDate <='" + todate.ToShortDateString() + "' AND TODATE >='" + fromdate.ToShortDateString() + "' AND EMPID=" + empId + " AND LeaveName='Medical Leave Without Pay'");
                LeaveVO LeaveVo = new LeaveDAO().GetByLeaveName("Medical Leave Without Pay");
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpIDAndLeaveID] '" + fromdate.Date + "','" + todate.Date + "'," + empId + "," + LeaveVo.Id);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        count = int.Parse(dr["UsedLeave"].ToString());
                }
            }
            catch (Exception ex)
            { throw ex; }
            return count;
        }

        public int getTotalLeaveDays(string empId, DateTime fromdate, DateTime todate)
        {
            int days = 0;
            try
            {
                //string query = "SELECT SUM(UsedLeave) as USEDLEAVE from Used_Leave where FromDate >= '"+ fromdate.ToShortDateString() + "' AND TODATE <='" + todate.ToShortDateString() + "' AND EMPID=" + empId + "";
                // string query = "SELECT SUM(UsedLeave) as USEDLEAVE from Used_Leave where FromDate <= '" + todate.ToShortDateString() + "' AND TODATE >='" + fromdate.ToShortDateString() + "' AND EMPID=" + empId + "";
                // DataTable dt = b.SelectByQuery(query);
                DataTable dt = b.SelectByQuery("execute [LeaveDateRangeByEmpID] '" + fromdate.Date + "','" + todate.Date + "'," + empId);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UsedLeave"].ToString() != "")
                        days = int.Parse(dr["UsedLeave"].ToString());
                }

            }
            catch (Exception ex)
            { throw ex; }
            return days;
        }
        #endregion

        #region Basic Salary Items

        //public PR_Basic_Salary_Items_View_VO getBasicSalaryItems(string empId, DateTime todate)
        //{
        //    PR_Basic_Salary_Items_View_VO vo = new PR_Basic_Salary_Items_View_VO();

        //    try
        //    {
        //        // check Salary Date
        //        DateTime fromDate = new DateTime(todate.Year, todate.Month, 1);
        //        DateTime toDate = new DateTime(todate.Year, todate.Month, DateTime.DaysInMonth(todate.Year, todate.Month));

        //        int EmpId = int.Parse(empId);
        //        List<Entity_Framework.vw_PR_Employee_Position_Change> objList = (from A in DAO.PTIC_Logger.em.vw_PR_Employee_Position_Change
        //                                                                         where A.EmpID == (int)(EmpId)
        //                                                                         select A).ToList();

        //        // Check change history exist or not by search date
        //        IEnumerable<Entity_Framework.vw_PR_Employee_Position_Change> positionChangeList = objList.Where(x => x.TentativeDate <= fromDate).ToList();
        //        //IEnumerable<Entity_Framework.vw_PR_Employee_Position_Change> positionChangeList = objList.Where(x => x.ChangeDate >= fromDate).Where(x => x.ChangeDate <= todate).ToList();
        //        Entity_Framework.vw_PR_Employee_Position_Change obj = new Entity_Framework.vw_PR_Employee_Position_Change();
        //        Entity_Framework.PR_Salary_Change salaryObj = new Entity_Framework.PR_Salary_Change();
        //        if (positionChangeList.Count() == 0) // if change history not exist by search date
        //        {
        //            var mindate = objList.Where(x => x.TentativeDate >= toDate).Min(x => x.TentativeDate); // get min date
        //            obj = objList.Where(x => x.TentativeDate == mindate).FirstOrDefault();
        //            // search by max date to get current rankId
        //            if (obj == null)
        //            {
        //                DataTable dtEmpPosition = new Base().SelectByQuery("Select E.ID,E.DeptId,P.Rank AS RankId,P.PostName From Employee E inner join Job_Position P on E.PostId= P.ID Where E.ID=" + EmpId);
        //                foreach (DataRow dremppos in dtEmpPosition.Rows)
        //                {
        //                    int rankid = int.Parse(dremppos["RankId"].ToString());
        //                    int depid = int.Parse(dremppos["DeptId"].ToString());
        //                    IEnumerable<Entity_Framework.PR_Salary_Change> changeObj = (from A in DAO.PTIC_Logger.em.PR_Salary_Change
        //                                                                                join dep in DAO.PTIC_Logger.em.Departments
        //                                                                                    on A.BranchID equals dep.MainDeptID
        //                                                                                where A.RankID == (int)rankid && dep.ID == (int)depid
        //                                                                                select A).Where(x => fromDate >= x.StartDate).Where(x => fromDate <= x.EndDate);
        //                    if (changeObj.Count() == 0)
        //                    {

        //                        // date between not exist
        //                        salaryObj = (from A in DAO.PTIC_Logger.em.PR_Salary_Change
        //                                     join dep in DAO.PTIC_Logger.em.Departments
        //                                         on A.BranchID equals dep.MainDeptID
        //                                     where A.RankID == (int)rankid && dep.ID == (int)depid
        //                                     select A).Where(x => x.StartDate == x.EndDate).FirstOrDefault();

        //                        ///  no rank and no salary define
        //                        if (salaryObj == null)
        //                        {
        //                            return vo;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // between date exist
        //                        salaryObj = changeObj.FirstOrDefault();
        //                    }
        //                    vo.Id = int.Parse(dremppos["ID"].ToString());
        //                    vo.EmpId = int.Parse(dremppos["ID"].ToString());
        //                    vo.Rank = int.Parse(dremppos["RankId"].ToString());
        //                    vo.PositionName = dremppos["PostName"].ToString();
        //                }


        //            }
        //            else
        //            {
        //                IEnumerable<Entity_Framework.PR_Salary_Change> changeObj = (from A in DAO.PTIC_Logger.em.PR_Salary_Change
        //                                                                            join dep in DAO.PTIC_Logger.em.Departments
        //                                                                                on A.BranchID equals dep.MainDeptID
        //                                                                            where A.RankID == obj.CurrentRank && dep.ID == obj.CurrentDeptID
        //                                                                            select A).Where(x => fromDate >= x.StartDate).Where(x => fromDate <= x.EndDate);

        //                if (changeObj.Count() == 0)
        //                {

        //                    // date between not exist
        //                    salaryObj = (from A in DAO.PTIC_Logger.em.PR_Salary_Change
        //                                 join dep in DAO.PTIC_Logger.em.Departments
        //                                     on A.BranchID equals dep.MainDeptID
        //                                 where A.RankID == obj.CurrentRank && dep.ID == obj.CurrentDeptID
        //                                 select A).Where(x => x.StartDate == x.EndDate).FirstOrDefault();
        //                }
        //                else
        //                {
        //                    // between date exist
        //                    salaryObj = changeObj.FirstOrDefault();
        //                }
        //                vo.Id = (int)obj.ID;
        //                vo.EmpId = (int)obj.EmpID;
        //                vo.Rank = (int)obj.CurrentRank;
        //                vo.PositionName = obj.CurrentPostName;
        //            }


        //        }
        //        else
        //        {
        //            var maxdate = objList.Where(x => x.TentativeDate <= toDate).Max(x => x.TentativeDate); // get max date
        //            obj = objList.Where(x => x.TentativeDate == maxdate).FirstOrDefault();

        //            IEnumerable<Entity_Framework.PR_Salary_Change> changeObj = (from A in DAO.PTIC_Logger.em.PR_Salary_Change
        //                                                                        join dep in DAO.PTIC_Logger.em.Departments
        //                                                                            on A.BranchID equals dep.MainDeptID
        //                                                                        where A.RankID == obj.NewRank && dep.ID == obj.NewDeptID
        //                                                                        select A).Where(x => fromDate >= x.StartDate).Where(x => fromDate <= x.EndDate);
        //            if (changeObj.Count() == 0)
        //            {
        //                //changeobj.count ==0 
        //                // date between not exist
        //                salaryObj = (from A in DAO.PTIC_Logger.em.PR_Salary_Change
        //                             join dep in DAO.PTIC_Logger.em.Departments
        //                                 on A.BranchID equals dep.MainDeptID
        //                             where A.RankID == obj.NewRank && dep.ID == obj.NewDeptID
        //                             select A).Where(x => x.StartDate == x.EndDate).FirstOrDefault();
        //                if (salaryObj == null)
        //                {
        //                    // so salary define for rank
        //                    return vo;
        //                }
        //            }
        //            else
        //            {
        //                // between date exist
        //                salaryObj = changeObj.FirstOrDefault();
        //            }
        //            vo.Id = (int)obj.ID;
        //            vo.EmpId = (int)obj.EmpID;
        //            vo.Rank = (int)obj.NewRank;
        //            vo.PositionName = obj.NewPostName;
        //        }

        //        vo.BasicSalary = (salaryObj.BasicSalary == null ? 0 : (decimal)salaryObj.BasicSalary);
        //        vo.AttendanceBonus = (salaryObj.AttendanceBonus == null ? 0 : (decimal)salaryObj.AttendanceBonus);
        //        vo.BasicAllowance = (salaryObj.BasicAllowance == null ? 0 : (decimal)salaryObj.BasicAllowance);
        //        vo.ServiceBonus = (salaryObj.ServiceBonus == null ? 0 : (decimal)salaryObj.ServiceBonus);
        //        vo.SSB = (salaryObj.SSB == null ? 0 : (decimal)salaryObj.SSB);
        //        vo.EmployeeBenefits = (salaryObj.EmployeeBenefits ==null? 0: (decimal)salaryObj.EmployeeBenefits);
        //        vo.Blo = (salaryObj.BLO == null ? 0 : (decimal)salaryObj.BLO);

        //        //DataTable dt = b.SelectByQuery("Select ID,Rank,BasicSalary,AttendanceBonus,BasicAllowance,ServiceBonus,EmpID from vw_Salary_Change2 where EmpID=" + empId + "  AND ((StartDate=EndDate) OR ('" + toDate.ToShortDateString() + "' BETWEEN StartDate AND EndDate ))");

        //        ////DataTable dt = b.SelectByQuery("SELECT * FROM vw_PR_Basic_Salary_Items_View WHERE EMPID='"+ empId +"'");

        //        //if (dt.Rows.Count > 0)
        //        //{
        //        //    vo = b.ConvertObj(dt.Rows[0], new PR_Basic_Salary_Items_View_VO()) as PR_Basic_Salary_Items_View_VO;
        //        //}


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return vo;
        //}

        #endregion

        public int Create_Create(object vo, int infoId, object detailVo, int manualId, object mhistoryVo)
        {
            int insertedId = 0;
            try
            {
                insertedId = b.Create_Attendance_Manual_History("FP_Attendance", infoId, b.ConvertColName(vo), b.ConvertValueListNullable(vo), "FP_ManualSetting", b.ConvertColName(detailVo), b.ConvertValueListNullable(detailVo), manualId, b.ConvertColName(mhistoryVo), b.ConvertValueListNullable(mhistoryVo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertedId;
        }

        public decimal GetFineAmount(string empId, DateTime fromdate, DateTime todate)
        {
            decimal FineAmount = 0;
            try
            {
                string query = "Select SUM(Fine_Type.FineAmount) AS FineAmount from Fine_Record ";
                query += "  inner join Fine_Type on ";
                query += "  Fine_Record.FineTypeID = Fine_Type.ID ";
                query += "  Where EmployeeID = " + empId + " and Date Between '" + fromdate.Date + "' and '" + todate.Date + "' ";
                query += "   group by FineTypeID ";

                DataTable dt = b.SelectByQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["FineAmount"].ToString() != "")
                        FineAmount += decimal.Parse(dr["FineAmount"].ToString());
                }
                return FineAmount;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public decimal GetOtherDeduction(string empId, DateTime fromdate, DateTime todate)
        {
            decimal deductionAmount = 0;
            try
            {
                string query = "Select SUM(Amount) AS OtherDeduction from Employee_Warefare_Info ";
                query += "  INNER JOIN ";
                query += "   Employee_Warefare_Details ";
                query += "   ON Employee_Warefare_Info.ID = Employee_Warefare_Details.Employee_Warefare_Info_Id ";
                query += "  Where Date Between '" + fromdate + "' AND '" + todate + "' AND EmployeeID=" + empId + " AND Employee_Warefare_Info.IsDeleted=0";
                query += "  group by EmployeeID";

                DataTable dt = b.SelectByQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["OtherDeduction"].ToString() != "")
                        deductionAmount = decimal.Parse(dr["OtherDeduction"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return deductionAmount;
        }

    }
}
