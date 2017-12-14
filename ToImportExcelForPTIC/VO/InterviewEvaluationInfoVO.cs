using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class InterviewEvaluationInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int applicantID;

        public int ApplicantID
        {
            get { return applicantID; }
            set { applicantID = value; }
        }
        private int interviewerID;

        public int InterviewerID
        {
            get { return interviewerID; }
            set { interviewerID = value; }
        }
        private int interviewerPostID;

        public int InterviewerPostID
        {
            get { return interviewerPostID; }
            set { interviewerPostID = value; }
        }
        private DateTime interviewDate;

        public DateTime InterviewDate
        {
            get { return interviewDate; }
            set { interviewDate = value; }
        }
        private TimeSpan interviewTime;

        public TimeSpan InterviewTime
        {
            get { return interviewTime; }
            set { interviewTime = value; }
        }
       
        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        private decimal expectedSalary;

        public decimal ExpectedSalary
        {
            get { return expectedSalary; }
            set { expectedSalary = value; }
        }
        private decimal totalMarks;

        public decimal TotalMarks
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
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        private bool isFirstInterview;

        public bool IsFirstInterview
        {
            get { return isFirstInterview; }
            set { isFirstInterview = value; }
        }
        private bool isSecondInterview;

        public bool IsSecondInterview
        {
            get { return isSecondInterview; }
            set { isSecondInterview = value; }
        }
        
        private bool isThirdInterview;

        public bool IsThirdInterview
        {
            get { return isThirdInterview; }
            set { isThirdInterview = value; }
        }
        private bool isQualifySecondInterview;

        public bool IsQualifySecondInterview
        {
            get { return isQualifySecondInterview; }
            set { isQualifySecondInterview = value; }
        }
        private bool isQualifyThirdInterview;

        public bool IsQualifyThirdInterview
        {
            get { return isQualifyThirdInterview; }
            set { isQualifyThirdInterview = value; }
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
