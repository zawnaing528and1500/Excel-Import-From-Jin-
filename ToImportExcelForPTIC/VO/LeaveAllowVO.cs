using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class LeaveAllowVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string leaveName;

        public string LeaveName
        {
            get { return leaveName; }
            set { leaveName = value; }
        }

        private int leaveDay;

        public int LeaveDay
        {
            get { return leaveDay; }
            set { leaveDay = value; }
        }
        private int usedLeave;

        public int UsedLeave
        {
            get { return usedLeave; }
            set { usedLeave = value; }
        }
    }
}
