using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PR_Payroll_PeriodVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int startDay;

        public int StartDay
        {
            get { return startDay; }
            set { startDay = value; }
        }
        private int endDay;

        public int EndDay
        {
            get { return endDay; }
            set { endDay = value; }
        }
        private bool isNextMonth;

        public bool IsNextMonth
        {
            get { return isNextMonth; }
            set { isNextMonth = value; }
        }
    }
}
