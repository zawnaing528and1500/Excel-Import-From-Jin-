using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeActivityVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string activityName;

        public string ActivityName
        {
            get { return activityName; }
            set { activityName = value; }
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
    }
}
