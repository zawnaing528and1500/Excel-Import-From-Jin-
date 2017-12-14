using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AbsenceEntryVO
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
        private DateTime absenceDate;

        public DateTime AbsenceDate
        {
            get { return absenceDate; }
            set { absenceDate = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
