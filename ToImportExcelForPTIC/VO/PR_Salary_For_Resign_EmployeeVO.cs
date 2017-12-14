using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PR_Salary_For_Resign_EmployeeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private decimal basicSalary;

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }
        private int attendanceDays;

        public int AttendanceDays
        {
            get { return attendanceDays; }
            set { attendanceDays = value; }
        }
        private decimal additionalPay;

        public decimal AdditionalPay
        {
            get { return additionalPay; }
            set { additionalPay = value; }
        }
        private decimal otherDeduction;

        public decimal OtherDeduction
        {
            get { return otherDeduction; }
            set { otherDeduction = value; }
        }
        private decimal totalAmount;

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        private decimal netAmount;

        public decimal NetAmount
        {
            get { return netAmount; }
            set { netAmount = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
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
