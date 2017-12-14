using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeVO
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

        private string empName;
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
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
        
        private int fingerID;
        public int FingerID
        {
            get { return fingerID; }
            set { fingerID = value; }
        }             
        
        private DateTime employDate;
        public DateTime EmployDate
        {
            get { return employDate; }
            set { employDate = value; }
        }
        
        private int salaryLvlID;
        public int SalaryLvlID
        {
            get { return salaryLvlID; }
            set { salaryLvlID = value; }
        }
        
        private string fatherName;
        public string FatherName
        {
            get { return fatherName; }
            set { fatherName = value; }
        }
        
        private string nRCNo;
        public string NRCNo
        {
            get { return nRCNo; }
            set { nRCNo = value; }
        }
        
        private DateTime dOB;
        public DateTime DOB
        {
            get { return dOB; }
            set { dOB = value; }
        }
        private string passportNo;
        public string PassportNo
        {
            get { return passportNo; }
            set { passportNo = value; }
        }
        
        private string race;
        public string Race
        {
            get { return race; }
            set { race = value; }
        }
        
        private int religion;
        public int Religion
        {
            get { return religion; }
            set { religion = value; }
        }

        private bool gender;
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private bool maritalStatus;

        public bool MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }      
        
        private string sSCode;
        public string SSCode
        {
            get { return sSCode; }
            set { sSCode = value; }
        }       
        
        private string driverLicence;
        public string DriverLicence
        {
            get { return driverLicence; }
            set { driverLicence = value; }
        }
        private string incaseOfDeathNameOfBeneficiary;

        public string IncaseOfDeathNameOfBeneficiary
        {
            get { return incaseOfDeathNameOfBeneficiary; }
            set { incaseOfDeathNameOfBeneficiary = value; }
        }
        private bool criminal;

        public bool Criminal
        {
            get { return criminal; }
            set { criminal = value; }
        }
        private string criminalrecord;

        public string Criminalrecord
        {
            get { return criminalrecord; }
            set { criminalrecord = value; }
        }
        private string referencesName1;

        public string ReferencesName1
        {
            get { return referencesName1; }
            set { referencesName1 = value; }
        }
        private string referencesName2;

        public string ReferencesName2
        {
            get { return referencesName2; }
            set { referencesName2 = value; }
        }
        private string referencesPh1;

        public string ReferencesPh1
        {
            get { return referencesPh1; }
            set { referencesPh1 = value; }
        }
        private string referencesPh2;

        public string ReferencesPh2
        {
            get { return referencesPh2; }
            set { referencesPh2 = value; }
        }

        private bool isPermanent;

        public bool IsPermanent
        {
            get { return isPermanent; }
            set { isPermanent = value; }
        }

        private DateTime approvalDate;

        public DateTime ApprovalDate
        {
            get { return approvalDate; }
            set { approvalDate = value; }
        }
        //added
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        private DateTime lastModified;

        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }
        
        
        private bool? isBLO;
        public bool? IsBLO
        {
            get { return isBLO; }
            set { isBLO = value; }
        }



        private byte[] empPhoto;
        public byte[] EmpPhoto
        {
            get { return empPhoto; }
            set { empPhoto = value; }
        }

       
    }
}
