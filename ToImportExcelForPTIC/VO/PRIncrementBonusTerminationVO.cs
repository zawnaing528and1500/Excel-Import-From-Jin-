using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PRIncrementBonusTerminationVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
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
        private string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
}
