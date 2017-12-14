using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeResignVO
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
        private DateTime resignDate;

        public DateTime ResignDate
        {
            get { return resignDate; }
            set { resignDate = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int approvedBy;

        public int ApprovedBy
        {
            get { return approvedBy; }
            set { approvedBy = value; }
        }
        private string orderNo;

        public string OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
    }
}
