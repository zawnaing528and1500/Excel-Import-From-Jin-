using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class Approve_Employee_OrderVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string officeOrderNo;

        public string OfficeOrderNo
        {
            get { return officeOrderNo; }
            set { officeOrderNo = value; }
        }
        private string letterNo;

        public string LetterNo
        {
            get { return letterNo; }
            set { letterNo = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        
        private int jobPositionID;

        public int JobPositionID
        {
            get { return jobPositionID; }
            set { jobPositionID = value; }
        }
        private string nrc;

        public string Nrc
        {
            get { return nrc; }
            set { nrc = value; }
        }
        private DateTime employDate;

        public DateTime EmployDate
        {
            get { return employDate; }
            set { employDate = value; }
        }
        private DateTime approveDate;

        public DateTime ApproveDate
        {
            get { return approveDate; }
            set { approveDate = value; }
        }
        private decimal approveSalary;

        public decimal ApproveSalary
        {
            get { return approveSalary; }
            set { approveSalary = value; }
        }
        private int assignDepartmentID;

        public int AssignDepartmentID
        {
            get { return assignDepartmentID; }
            set { assignDepartmentID = value; }
        }
        private int approvalPersonID;

        public int ApprovalPersonID
        {
            get { return approvalPersonID; }
            set { approvalPersonID = value; }
        }
        private int approvalPersonPostID;

        public int ApprovalPersonPostID
        {
            get { return approvalPersonPostID; }
            set { approvalPersonPostID = value; }
        }
            
    }
}
