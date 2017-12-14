using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class UsedLeaveVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private int leaveID;

        public int LeaveID
        {
            get { return leaveID; }
            set { leaveID = value; }
        }
        
        private int usedLeave;

        public int UsedLeave
        {
            get { return usedLeave; }
            set { usedLeave = value; }
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
        private int leaveRequestID;

        public int LeaveRequestID
        {
            get { return leaveRequestID; }
            set { leaveRequestID = value; }
        }
                
    }
}
