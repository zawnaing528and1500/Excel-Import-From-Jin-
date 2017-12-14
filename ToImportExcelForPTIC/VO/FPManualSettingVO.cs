using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FPManualSettingVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int attendanceID;

        public int AttendanceID
        {
            get { return attendanceID; }
            set { attendanceID = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
       
        private DateTime manualInDate;

        public DateTime ManualInDate
        {
            get { return manualInDate; }
            set { manualInDate = value; }
        }

        private DateTime manualOutDate;

        public DateTime ManualOutDate
        {
            get { return manualOutDate; }
            set { manualOutDate = value; }
        }
        private DateTime inTime;

        public DateTime InTime
        {
            get { return inTime; }
            set { inTime = value; }
        }
        private DateTime outTime;

        public DateTime OutTime
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
        private string workHours;

        public string WorkHours
        {
            get { return workHours; }
            set { workHours = value; }
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
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
