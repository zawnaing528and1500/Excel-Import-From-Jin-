using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class ScheduleVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int shiftID;

        public int ShiftID
        {
            get { return shiftID; }
            set { shiftID = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        private DateTime toDate;

        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        private bool isEndDate;

        public bool IsEndDate
        {
            get { return isEndDate; }
            set { isEndDate = value; }
        }
    }
}
