using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FP_DutyDateVO
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
        private DateTime dutyDate;

        public DateTime DutyDate
        {
            get { return dutyDate; }
            set { dutyDate = value; }
        }
    }
}
