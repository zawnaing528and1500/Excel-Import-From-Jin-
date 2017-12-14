using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeApprovalInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime approveDate;

        public DateTime ApproveDate
        {
            get { return approveDate; }
            set { approveDate = value; }
        }
        private int applicantID;

        public int ApplicantID
        {
            get { return applicantID; }
            set { applicantID = value; }
        }
        private int approvePersonID;

        public int ApprovePersonID
        {
            get { return approvePersonID; }
            set { approvePersonID = value; }
        }
        
        private int totalMarks;

        public int TotalMarks
        {
            get { return totalMarks; }
            set { totalMarks = value; }
        }
        private decimal percentage;

        public decimal Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }
    }
}
