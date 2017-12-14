using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class LeaveRequestVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime requestDate;

        public DateTime RequestDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        
        private string leaveReason;

        public string LeaveReason
        {
            get { return leaveReason; }
            set { leaveReason = value; }
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

        private int requireDays;

        public int RequireDays
        {
            get { return requireDays; }
            set { requireDays = value; }
        }
        private int replaceEmpID;

        public int ReplaceEmpID
        {
            get { return replaceEmpID; }
            set { replaceEmpID = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private int mgrID;

        public int MgrID
        {
            get { return mgrID; }
            set { mgrID = value; }
        }
        private string mgrRemark;

        public string MgrRemark
        {
            get { return mgrRemark; }
            set { mgrRemark = value; }
        }
    }
}
