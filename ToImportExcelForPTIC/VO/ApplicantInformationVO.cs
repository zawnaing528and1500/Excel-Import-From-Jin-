using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class ApplicantInformationVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        } 
        private DateTime applyDate;

        public DateTime ApplyDate
        {
            get { return applyDate; }
            set { applyDate = value; }
        }
        private string applicantName;

        public string ApplicantName
        {
            get { return applicantName; }
            set { applicantName = value; }
        }
        private bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private int applyPositionID;

        public int ApplyPositionID
        {
            get { return applyPositionID; }
            set { applyPositionID = value; }
        }
        private int applyDepartmentID;

        public int ApplyDepartmentID
        {
            get { return applyDepartmentID; }
            set { applyDepartmentID = value; }
        }
        private int cVSourceID;

        public int CVSourceID
        {
            get { return cVSourceID; }
            set { cVSourceID = value; }
        }
        private int recommandEmployeeID;

        public int RecommandEmployeeID
        {
            get { return recommandEmployeeID; }
            set { recommandEmployeeID = value; }
        }
        private int agencyID;

        public int AgencyID
        {
            get { return agencyID; }
            set { agencyID = value; }
        }

        private string jobFair;

        public string JobFair
        {
            get { return jobFair; }
            set { jobFair = value; }
        }
        private string journal;

        public string Journal
        {
            get { return journal; }
            set { journal = value; }
        }
        private string otherSource;

        public string OtherSource
        {
            get { return otherSource; }
            set { otherSource = value; }
        }
        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        private bool hire;

        public bool Hire
        {
            get { return hire; }
            set { hire = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool isFirstAppointment;

        public bool IsFirstAppointment
        {
             get { return isFirstAppointment; }
              set { isFirstAppointment = value; }
        } 
 
        private DateTime firstAppointmentDate;

        public DateTime FirstAppointmentDate
        {
            get { return firstAppointmentDate; }
            set { firstAppointmentDate = value; }
        }
        private TimeSpan firstAppointmentTime;

        public TimeSpan FirstAppointmentTime
        {
            get { return firstAppointmentTime; }
            set { firstAppointmentTime = value; }
        }
        private bool isSecondAppointment;

        public bool IsSecondAppointment
        {
            get { return isSecondAppointment; }
            set { isSecondAppointment = value; }
        }

        private DateTime secondAppointmentDate;

        public DateTime SecondAppointmentDate
        {
            get { return secondAppointmentDate; }
            set { secondAppointmentDate = value; }
        }
        private TimeSpan secondAppointmentTime;

        public TimeSpan SecondAppointmentTime
        {
            get { return secondAppointmentTime; }
            set { secondAppointmentTime = value; }
        }
        private bool isThirdAppointment;

        public bool IsThirdAppointment
        {
            get { return isThirdAppointment; }
            set { isThirdAppointment = value; }
        }
        private DateTime thirdAppointmentDate;

        public DateTime ThirdAppointmentDate
        {
            get { return thirdAppointmentDate; }
            set { thirdAppointmentDate = value; }
        }
        private TimeSpan thirdAppointmentTime;

        public TimeSpan ThirdAppointmentTime
        {
            get { return thirdAppointmentTime; }
            set { thirdAppointmentTime = value; }
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
        private byte[] applicantPhoto;

        public byte[] ApplicantPhoto
        {
            get { return applicantPhoto; }
            set { applicantPhoto = value; }
        }
         
    }
}
