using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PR_Additional_AllowanceVO
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
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private DateTime regDate;

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }      
        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
