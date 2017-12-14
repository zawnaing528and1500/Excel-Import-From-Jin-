using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class DepartmentVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int mainDeptID;

        public int MainDeptID
        {
            get { return mainDeptID; }
            set { mainDeptID = value; }
        }
        private string deptName;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
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
