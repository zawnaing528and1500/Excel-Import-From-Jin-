using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class ProbationOfficeOrderVO
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
        private int applicantID;

        public int ApplicantID
        {
            get { return applicantID; }
            set { applicantID = value; }
        }
        private int jobPositionID;

        public int JobPositionID
        {
            get { return jobPositionID; }
            set { jobPositionID = value; }
        }

        private string nrcno;

        public string Nrcno
        {
            get { return nrcno; }
            set { nrcno = value; }
        }
        private int salary;

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private DateTime employDate;

        public DateTime EmployDate
        {
            get { return employDate; }
            set { employDate = value; }
        }
        private int employDeptID;

        public int EmployDeptID
        {
            get { return employDeptID; }
            set { employDeptID = value; }
        }

        private int approveDirectorID;

        public int ApproveDirectorID
        {
            get { return approveDirectorID; }
            set { approveDirectorID = value; }
        }
    }
}
