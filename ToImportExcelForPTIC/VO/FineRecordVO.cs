using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FineRecordVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int fineTypeID;

        public int FineTypeID
        {
            get { return fineTypeID; }
            set { fineTypeID = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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
