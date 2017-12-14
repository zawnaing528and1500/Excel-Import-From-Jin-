using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeWorkHistoryVO
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

        
        private int branchID;

        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        private int departmentID;

        public int DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }
        private int positionID;

        public int PositionID
        {
            get { return positionID; }
            set { positionID = value; }
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
