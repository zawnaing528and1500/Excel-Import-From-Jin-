using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PR_SalaryChangeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int salaryID;

        public int SalaryID
        {
            get { return salaryID; }
            set { salaryID = value; }
        }
        private int branchID;

        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        private int rankID;

        public int RankID
        {
            get { return rankID; }
            set { rankID = value; }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }             
        
        private decimal basicSalary;

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }
        private decimal minIncrement;

        public decimal MinIncrement
        {
            get { return minIncrement; }
            set { minIncrement = value; }
        }
        private decimal maxIncrement;

        public decimal MaxIncrement
        {
            get { return maxIncrement; }
            set { maxIncrement = value; }
        }
        private decimal attendanceBonus;

        public decimal AttendanceBonus
        {
            get { return attendanceBonus; }
            set { attendanceBonus = value; }
        }
        private decimal basicAllowance;

        public decimal BasicAllowance
        {
            get { return basicAllowance; }
            set { basicAllowance = value; }
        }
        private decimal serviceBonus;

        public decimal ServiceBonus
        {
            get { return serviceBonus; }
            set { serviceBonus = value; }
        }
        private decimal ssb;

        public decimal Ssb
        {
            get { return ssb; }
            set { ssb = value; }
        }
        private decimal employeeBenefits;

        public decimal EmployeeBenefits
        {
            get { return employeeBenefits; }
            set { employeeBenefits = value; }
        }
        private decimal blo;

        public decimal Blo
        {
            get { return blo; }
            set { blo = value; }
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
        private int changedUserID;

        public int ChangedUserID
        {
            get { return changedUserID; }
            set { changedUserID = value; }
        }
    }
}
