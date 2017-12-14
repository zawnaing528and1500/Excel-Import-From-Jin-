using System;
using System.Data;

namespace Toyo.Core
{
    public class PR_SalaryComputingDAO
    {
        //public double GetValueForItem(string item, string empID, DateTime fromdate, DateTime todate)
        //{
        //    double value = 0;

        //    switch (item)
        //    {
        //        // Attendance Items
        //        case "{Late(Times)}": value = LateTimes(empID, fromdate, todate); break;
        //        case "{Late(Minutes)}": value = LateMinutes(empID, fromdate, todate); break;
        //        case "{Leave Early(Times)}": value = EarlyLeaveTimes(empID, fromdate, todate); break;
        //        case "{Leave Early(Minutes)}": value = EarlyLeaveMinutes(empID, fromdate, todate); break;
        //        case "{Actual Working Days}": value = ActualWorkingDays(empID, fromdate, todate); break;
        //        case "{Absent}": value = AbsenteeismTimes(empID, fromdate, todate); break;
        //        case "{Leave(Days)}": value = TotalLeaveDays(empID, fromdate, todate); break;
        //        case "{Days of Month}": value = DateTime.DaysInMonth(todate.Year, todate.Month); break;// TotalDays(fromdate, todate); break;//                
        //        case "{CL}": value = CasualLeave(empID, fromdate, todate); break;
        //        case "{EL}": value = EarnLeave(empID, fromdate, todate); break;
        //        case "{WL}": value = WithoutPayLeave(empID, fromdate, todate); break;
        //        case "{PL}": value = ParentalLeave(empID, fromdate, todate); break;
        //        case "{Medical Leave}": value = MedicalLeave(empID, fromdate, todate); break;
        //        case "{Maternal Leave}": value = MaternalLeave(empID, fromdate, todate); break;
        //        // Basic Salary Items
        //        case "{Basic Salary}": value = BasicSalary(empID, todate); break;
        //        case "{Attendance Bonus}": value = AttendanceBonus(empID, fromdate, todate); break;
        //        case "{Allowance}": value = BasicAllowance(empID, todate); break;
        //        // case "{Basic Service Bonus}": value = BasicServiceBonus(empID, fromdate, todate); break;
        //        case "{Service Year}": value = ServiceYear(empID, todate); break;
        //        //case "{Increment Basic}": value = IncrementBasic(empID, fromdate, todate); break;
        //        case "{Additional Allowance}": value = AdditionalAllowance(empID,todate.Year,todate.Month); break;
        //        case "{TotalWorkingDays}": value = GetTotalWorkingDays(empID, fromdate, todate); break;
        //        case "{TotalWorkingDaysResign}": value = GetTotalWorkingDaysResign(empID, fromdate, todate); break; 
        //        default:
        //            break;
        //    }
        //    return value;
        //}
        //#region Attendance Items
        //public double TotalDays(DateTime fromdate, DateTime todate)
        //{
        //    TimeSpan ts = new TimeSpan();
        //    ts = todate.Date - fromdate.Date;
        //    return ts.TotalDays + 1;
        //}
        //public double LateTimes(string empID, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    int Late = dao.getLateCount(empID, fromdate, todate);
        //    return Late;
        //}
        //public double LateMinutes(string empID, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    int Late = dao.getLateMinutes(empID, fromdate, todate);
        //    return Late;
        //}
        //public double EarlyLeaveTimes(string empID, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    int earlyTimes = dao.getEarlyLeaveTime(empID, fromdate, todate);
        //    return earlyTimes;
        //}
        //public double EarlyLeaveMinutes(string empID, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    int earlyMinutes = dao.getEarlyLeaveMinutes(empID, fromdate, todate);
        //    return earlyMinutes;
        //}
        //public double ActualWorkingDays(string empID, DateTime fromDate, DateTime toDate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    int days = dao.getActualWorkingDays(empID, fromDate, toDate);
        //    return days;
        //}
        //public double GetTotalWorkingDays(string empID, DateTime fromDate, DateTime toDate)
        //{
        //    int days = 0;
        //    Base dao = new Base();
        //    DataTable dt = dao.SelectByQuery("Select DATEDIFF(day,EmployDate,'" + toDate + "') AS Days from Employee where ID =" + empID);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        days = int.Parse(dr["Days"].ToString());
        //    }
        //    days = days + 1;
        //    return days;
        //}
        //public double GetTotalWorkingDaysResign(string empID, DateTime fromDate, DateTime toDate)
        //{
        //    int days = 0;
        //    Base dao = new Base();
        //    DataTable dt = dao.SelectByQuery("select DATEDIFF(day,'" + fromDate + "',ResignDate) AS Days from Employee_Resign where EmpID =" + empID);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        days = int.Parse(dr["Days"].ToString());
        //    }

        //    return days;
        //}
        //public double AbsenteeismTimes(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    int AbsentTimes = dao.getAbsenteeismTimes(empId, fromdate, todate);
        //    return AbsentTimes;
        //}
        //// CL
        //public double CasualLeave(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getCasualLeave(empId, fromdate, todate);
        //}
        //// EL or Annual Leave
        //public double EarnLeave(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getAnnualLeave(empId, fromdate, todate);
        //}
        //// WL
        //public double WithoutPayLeave(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getLeaveWithoutPay(empId, fromdate, todate);
        //}
        //// ML
        //public double MedicalLeave(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getMedicalLeave(empId, fromdate, todate);
        //}
        //// Maternal L
        //public double MaternalLeave(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getMaternalLeave(empId, fromdate, todate);
        //}
        //// Parental L
        //public double ParentalLeave(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getParentalLeave(empId, fromdate, todate);
        //}

        //// Total Leave Days
        //public double TotalLeaveDays(string empId, DateTime fromdate, DateTime todate)
        //{
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    return dao.getTotalLeaveDays(empId, fromdate, todate);
        //}
        //#endregion

        //#region Basic Salary Items

        ////public double BasicSalary(string empId, DateTime todate)
        ////{
        ////    double amount = 0;
        ////    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        ////    //PR_Basic_Salary_Items_View_VO vo = dao.getBasicSalaryItems(empId, todate);
        ////    amount = (double)vo.BasicSalary;
        ////    return amount;
        ////}

        //public double AttendanceBonus(string empId, DateTime fromdate, DateTime todate)
        //{
        //    decimal amount = 0;
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    //PR_Basic_Salary_Items_View_VO vo = dao.getBasicSalaryItems(empId, todate);
        //    int cl = (int)CasualLeave(empId, fromdate, todate);
        //    int wl = (int)WithoutPayLeave(empId, fromdate, todate);
        //    int el = (int)EarnLeave(empId, fromdate, todate);
        //    int ml = (int)MedicalLeave(empId, fromdate, todate);
        //    int maternalLeave = (int)MaternalLeave(empId, fromdate, todate);
        //    int pl = (int)ParentalLeave(empId, fromdate, todate);
        //    amount = (decimal)vo.AttendanceBonus;
        //    // Casual Leave
        //    if (cl == 2)
        //    {
        //        amount = (decimal)((vo.AttendanceBonus * 50) / 100);
        //    }
        //    else if (cl >= 3)
        //    {
        //        amount = 0;
        //    }

        //    if ((cl == 1 && el == 1) || (cl == 1 && ml == 1))
        //    {
        //        amount = (decimal)((vo.AttendanceBonus * 50) / 100);
        //    }

        //    // Earn Leave
        //    if (el >= 1)
        //    {
        //        amount = 0;
        //    }

        //    if (wl >= 1 && cl >= 2)
        //    {
        //        amount = 0;
        //    }
        //    // Medical L
        //    if (ml == 1)
        //    {
        //        amount = (decimal)((vo.AttendanceBonus * 50) / 100);
        //    }
        //    if (ml > 1)
        //    {
        //        amount = 0;
        //    }

        //    // Without Leave
        //    if (wl == 1)
        //    {

        //        amount = (decimal)((vo.AttendanceBonus * 50) / 100);
        //    }
        //    if (wl >= 2)
        //    {
        //        amount = 0;
        //    }
        //    if (maternalLeave >= 1)
        //    {
        //        amount = 0;
        //    }
        //    if (pl >= 2)
        //    {
        //        amount = 0;
        //    }
        //    else if (pl == 1)
        //    {
        //        amount = (decimal)((vo.AttendanceBonus * 50) / 100);
        //    }

        //    return (double)(amount);
        //}

        //public double BasicAllowance(string empId, DateTime todate)
        //{
        //    double amount = 0;
        //    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //    //PR_Basic_Salary_Items_View_VO vo = dao.getBasicSalaryItems(empId, todate);
        //    amount = (double)vo.BasicAllowance;
        //    return amount;
        //}
        //#region Basic Service
        ////public double BasicServiceBonus(string empId, DateTime fromdate, DateTime todate)
        ////{
        ////    double amount = 0;

        ////    // Get Calculate Service Year
        ////    double years = ServiceYear(empId, todate);
        ////    FP_AttendanceDAO dao = new FP_AttendanceDAO();
        ////    PR_Basic_Salary_Items_View_VO vo = dao.getBasicSalaryItems(empId,todate);
        ////    double serviceBonus = (double)vo.ServiceBonus;

        ////    // Get Approval Date From Employee Table
        ////    EmployeeVO empVo = new EmployeeDAO().GetByID(int.Parse(empId));
        ////    TimeSpan ts = new TimeSpan();
        ////    if (empVo.IsPermanent)
        ////    {
        ////       // ts = DateTime.Today - empVo.ApprovalDate;
        ////        ts = todate - empVo.ApprovalDate;
        ////    }

        ////    double ApprovalYears = Math.Floor(ts.TotalDays / 365.25);
        ////    if (years >= 2 && years < 3)
        ////    {
        ////        amount = serviceBonus;
        ////    }
        ////    else if (years >= 3 && years < 4)
        ////    {
        ////        amount = serviceBonus * 2;
        ////    }
        ////    else if (years >= 4 && years < 5)
        ////    {
        ////        amount = serviceBonus * 3;
        ////    }
        ////    else if (years >= 5)
        ////    {
        ////        amount = serviceBonus * 4;
        ////    }
        ////    DataTable dtTerminate = dao.SelectByQuery("select * from PR_ServiceBonus_Termination where fromdate <='" + todate.ToShortDateString() + "' and todate >= '" + fromdate.ToShortDateString() + "' and EmpId=" + empId + "");
        ////    if (dtTerminate.Rows.Count > 0)
        ////    {
        ////        amount = 0;
        ////    }
        ////    else
        ////    {
        ////        // For Employee with Service year greather than 2 and has position change
        ////        // Set service bonus as new position service 2 year
        ////        if (years >= 0 && years < 2)
        ////        {
        ////            if (ApprovalYears > years)
        ////                amount = serviceBonus;
        ////        }
        ////    }
        ////    return amount;
        ////}
        //#endregion
        //// Service Year
        //public double ServiceYear(string empId, DateTime todate)
        //{
        //    double years = 0;
        //    TimeSpan ts = new TimeSpan();
        //    DataTable dtPostChange = new EmployeePositionChangeDAO().SelectByQuery("SELECT top 1 * FROM Employee_Position_Change WHERE EmpID=" + empId + " AND ((Year(ChangeDate)=" + todate.Year + " AND MONTH(ChangeDate)<=" + todate.Month + ")or Year(ChangeDate)<" + todate.Year + ") order by ChangeDate desc");
        //    foreach (DataRow dr in dtPostChange.Rows)
        //    {
        //        // ts = DateTime.Today - DateTime.Parse(dr["ChangeDate"].ToString());
        //        ts = todate - DateTime.Parse(dr["ChangeDate"].ToString());

        //    }

        //    //DataTable dt = new EmployeeDAO().SelectByQuery("SELECT ID,PostID,ApprovalDate FROM Employee WHERE  ID=" + empId + " AND IsActive=1 AND isPermanent=1 AND YEAR(ApprovalDate)<="
        //    //       + todate.Year + " AND ID NOT IN(SELECT PC.EmpID FROM Employee_Position_Change PC,Employee E WHERE PC.EmpID=E.ID AND PC.NewPostID=E.PostID AND E.IsActive=1)");

        //    DataTable dt = new EmployeeDAO().SelectByQuery("SELECT ID,PostID,ApprovalDate FROM Employee WHERE  ID=" + empId + " AND IsActive=1 AND isPermanent=1 AND ((MONTH(ApprovalDate) <=" + todate.Month + " AND Year(ApprovalDate)=" + todate.Year + ") OR( YEAR(ApprovalDate) < " + todate.Year + ")) AND ID NOT IN(SELECT EmpID FROM Employee_Position_Change WHERE EmpID = " + empId + " AND ((Year(ChangeDate)=" + todate.Year + " AND MONTH(ChangeDate)<=" + todate.Month + ")or Year(ChangeDate)<" + todate.Year + "))");

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        // ts = DateTime.Today - DateTime.Parse(dr["ApprovalDate"].ToString());
        //        ts = todate - DateTime.Parse(dr["ApprovalDate"].ToString());
        //    }
        //    years = Math.Floor(ts.TotalDays / 365.25);

        //    return years;
        //}

        //public double IncrementBasic(string empId, DateTime fromdate, DateTime todate)
        //{
        //    //double amount = 0;
        //    ////DataTable dt = new Base().SelectByQuery("SELECT IncrementAmount FROM Increment_Employee WHERE YEAR(INCREMENTDATE)='" + todate.Year + "' AND MONTH(INCREMENTDATE)='" + todate.Month + "' AND EMPID='" + empId + "'");
        //    ////if (dt.Rows.Count > 0)
        //    ////{
        //    ////    if (dt.Rows[0]["IncrementAmount"] != "")
        //    ////        amount = double.Parse(dt.Rows[0]["IncrementAmount"].ToString());
        //    ////}

        //    //DataTable dtInc=new Base().SelectByQuery("execute IncrementEmployee '"+todate.ToString("yyyy-MM-dd")+"'");
        //    //DataTable dtSearch=new DataTable();
        //    //if (dtInc.Rows.Count > 0)
        //    //{
        //    //    dtSearch = dtInc.Copy();
        //    //}

        //    //DataRow[] dr = dtSearch.Select("EmpId="+ empId);
        //    //if (dr.Length > 0)
        //    //{
        //    //    dtSearch = dr.CopyToDataTable();
        //    //    if (dtSearch.Rows[0]["IncrementAmount"] != "")
        //    //        amount = double.Parse(dtSearch.Rows[0]["IncrementAmount"].ToString());
        //    //}
        //    //else dtSearch = new DataTable();           


        //    //DataTable dtTermi = new Base().SelectByQuery("SELECT * FROM PR_IncrementBonus_Termination WHERE FROMDATE ='" + fromdate.ToShortDateString() + "' AND TODATE='" + todate.ToShortDateString() + "' AND EMPID='" + empId + "'");
        //    //if (dtTermi.Rows.Count > 0)
        //    //{
        //    //    amount = 0;
        //    //}
        //    // return amount;
        //    return 0;
        //}
        //public double AdditionalAllowance(string empId,int Year,int Month)
        //{
        //    double amount = 0;

        //    DataTable dt = new Base().SelectByQuery("SELECT MonthlyAddtionalAllowanceSettingDetails.Employee_ID,MonthlyAddtionalAllowanceSettingDetails.Amount FROM MonthlyAddtionalAllowanceSettings INNER JOIN MonthlyAddtionalAllowanceSettingDetails ON MonthlyAddtionalAllowanceSettings.ID = MonthlyAddtionalAllowanceSettingDetails.MonthlyAddtionalAllowanceSettingID WHERE MonthlyAddtionalAllowanceSettingDetails.Employee_ID=" + empId + "AND MonthlyAddtionalAllowanceSettings.Year=" + Year + "AND MonthlyAddtionalAllowanceSettings.Month=" + Month + " AND MonthlyAddtionalAllowanceSettings.IsDeleted=0");
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["AMOUNT"] != "")
        //            amount = double.Parse(dt.Rows[0]["AMOUNT"].ToString());
        //    }
        //    return amount;
        //}
        //#endregion
    }
}
