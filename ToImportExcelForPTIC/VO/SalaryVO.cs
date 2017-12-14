using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SalaryVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int branchID;

        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        private int rank;
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
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
        private DateTime? updatedDate;

        public DateTime? UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }       
    }
}
