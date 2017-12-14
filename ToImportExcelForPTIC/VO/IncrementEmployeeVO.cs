using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class IncrementEmployeeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime incrementDate;

        public DateTime IncrementDate
        {
            get { return incrementDate; }
            set { incrementDate = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private int postID;

        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private decimal incrementAmount;

        public decimal IncrementAmount
        {
            get { return incrementAmount; }
            set { incrementAmount = value; }
        }

    }
}
