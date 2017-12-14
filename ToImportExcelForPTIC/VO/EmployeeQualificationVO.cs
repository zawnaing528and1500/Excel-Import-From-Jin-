using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeQualificationVO
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
        private string degree;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        private string university;

        public string University
        {
            get { return university; }
            set { university = value; }
        }
        private string qYear;

        public string QYear
        {
            get { return qYear; }
            set { qYear = value; }
        }
    }
}
