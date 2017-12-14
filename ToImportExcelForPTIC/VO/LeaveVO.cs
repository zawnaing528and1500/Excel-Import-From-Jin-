using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class LeaveVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string leavename;
        public string Leavename
        {
            get { return leavename; }
            set { leavename = value; }
        }

        private int leaveDay;
        public int LeaveDay
        {
            get { return leaveDay; }
            set { leaveDay = value; }
        }

        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        private DateTime updatedDate;

        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }
    }
}
