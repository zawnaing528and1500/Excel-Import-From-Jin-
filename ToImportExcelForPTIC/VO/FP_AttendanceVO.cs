using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FP_AttendanceVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private int fingerID;

        public int FingerID
        {
            get { return fingerID; }
            set { fingerID = value; }
        }
        private DateTime inDate;

        public DateTime InDate
        {
            get { return inDate; }
            set { inDate = value; }
        }
        private DateTime outDate;

        public DateTime OutDate
        {
            get { return outDate; }
            set { outDate = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private string empName;

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private TimeSpan? inTime;

        public TimeSpan? InTime
        {
            get { return inTime; }
            set { inTime = value; }
        }
        private TimeSpan? outTime;

        public TimeSpan? OutTime
        {
            get { return outTime; }
            set { outTime = value; }
        }
        private TimeSpan? late;

        public TimeSpan? Late
        {
            get { return late; }
            set { late = value; }
        }
        private TimeSpan? earlyOut;

        public TimeSpan? EarlyOut
        {
            get { return earlyOut; }
            set { earlyOut = value; }
        }
        private TimeSpan? overTime;

        public TimeSpan? OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }
        private String workHours;

        public String WorkHours
        {
            get { return workHours; }
            set { workHours = value; }
        }
        private TimeSpan? inTime2;

        public TimeSpan? InTime2
        {
            get { return inTime2; }
            set { inTime2 = value; }
        }
        private TimeSpan? outTime2;

        public TimeSpan? OutTime2
        {
            get { return outTime2; }
            set { outTime2 = value; }
        }
        private TimeSpan? inTime3;

        public TimeSpan? InTime3
        {
            get { return inTime3; }
            set { inTime3 = value; }
        }
        private TimeSpan? outTime3;

        public TimeSpan? OutTime3
        {
            get { return outTime3; }
            set { outTime3 = value; }
        }
        private TimeSpan? inTime4;

        public TimeSpan? InTime4
        {
            get { return inTime4; }
            set { inTime4 = value; }
        }
        private TimeSpan? outTime4;

        public TimeSpan? OutTime4
        {
            get { return outTime4; }
            set { outTime4 = value; }
        }
        private TimeSpan? inTime5;

        public TimeSpan? InTime5
        {
            get { return inTime5; }
            set { inTime5 = value; }
        }
        private TimeSpan? outTime5;

        public TimeSpan? OutTime5
        {
            get { return outTime5; }
            set { outTime5 = value; }
        }
        private TimeSpan? inTime6;

        public TimeSpan? InTime6
        {
            get { return inTime6; }
            set { inTime6 = value; }
        }
        private TimeSpan? outTime6;
        public TimeSpan? OutTime6
        {
            get { return outTime6; }
            set { outTime6 = value; }
        }
        private TimeSpan? inTime7;

        public TimeSpan? InTime7
        {
            get { return inTime7; }
            set { inTime7 = value; }
        }
        private TimeSpan? outTime7;

        public TimeSpan? OutTime7
        {
            get { return outTime7; }
            set { outTime7 = value; }
        }
        private TimeSpan? inTime8;

        public TimeSpan? InTime8
        {
            get { return inTime8; }
            set { inTime8 = value; }
        }
        private TimeSpan? outTime8;

        public TimeSpan? OutTime8
        {
            get { return outTime8; }
            set { outTime8 = value; }
        }
        private TimeSpan? inTime9;
        public TimeSpan? InTime9
        {
            get { return inTime9; }
            set { inTime9 = value; }
        }
        private TimeSpan? outTime9;
        public TimeSpan? OutTime9
        {
            get { return outTime9; }
            set { outTime9 = value; }
        }

        private TimeSpan? inTime10;
        public TimeSpan? InTime10
        {
            get { return inTime10; }
            set { inTime10 = value; }
        }

        private TimeSpan? outTime10;
        public TimeSpan? OutTime10
        {
            get { return outTime10; }
            set { outTime10 = value; }
        }

        private TimeSpan? latestOutTime;
        public TimeSpan? LatestOutTime
        {
            get { return latestOutTime; }
            set { latestOutTime = value; }
        }
        private int shiftID;

        public int ShiftID
        {
            get { return shiftID; }
            set { shiftID = value; }
        }
        private DateTime shiftDateIn;

        public DateTime ShiftDateIn
        {
            get { return shiftDateIn; }
            set { shiftDateIn = value; }
        }
        private DateTime shiftDateOut;

        public DateTime ShiftDateOut
        {
            get { return shiftDateOut; }
            set { shiftDateOut = value; }
        }
        private bool isOtherActivity;

        public bool IsOtherActivity
        {
            get { return isOtherActivity; }
            set { isOtherActivity = value; }
        }
        private string otherActivity;

        public string OtherActivity
        {
            get { return otherActivity; }
            set { otherActivity = value; }
        }
    }
}
