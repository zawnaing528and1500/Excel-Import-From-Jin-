using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class PR_SalaryComputingResultVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int month;

        private int prMonth;

        public int PrMonth
        {
            get { return prMonth; }
            set { prMonth = value; }
        }
        private int prYear;

        public int PrYear
        {
            get { return prYear; }
            set { prYear = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private int postId;

        public int PostId
        {
            get { return postId; }
            set { postId = value; }
        }
        
        private int fingerId;

        public int FingerId
        {
            get { return fingerId; }
            set { fingerId = value; }
        }       
       
        private decimal basicSalary;

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }
        private DateTime joinedDate;

        public DateTime JoinedDate
        {
            get { return joinedDate; }
            set { joinedDate = value; }
        }
        private DateTime permanentDate;

        public DateTime PermanentDate
        {
            get { return permanentDate; }
            set { permanentDate = value; }
        }       
        private int wDay;

        public int WDay
        {
            get { return wDay; }
            set { wDay = value; }
        }
        private int cL;

        public int CL
        {
            get { return cL; }
            set { cL = value; }
        }
        private int eL;

        public int EL
        {
            get { return eL; }
            set { eL = value; }
        }
        private int wL;

        public int WL
        {
            get { return wL; }
            set { wL = value; }
        }
        private int medicalLeave;

        public int MedicalLeave
        {
            get { return medicalLeave; }
            set { medicalLeave = value; }
        }

        private int maternalLeave;

        public int MaternalLeave
        {
            get { return maternalLeave; }
            set { maternalLeave = value; }
        }               

        private decimal totalAmount;

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
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
        private decimal otherAllowance;

        public decimal OtherAllowance
        {
            get { return otherAllowance; }
            set { otherAllowance = value; }
        }
       
        private decimal additionalAllowance;

        public decimal AdditionalAllowance
        {
            get { return additionalAllowance; }
            set { additionalAllowance = value; }
        }
        private decimal additionalAllowedPayment;

        public decimal AdditionalAllowedPayment
        {
            get { return additionalAllowedPayment; }
            set { additionalAllowedPayment = value; }
        }
        private decimal backPay;

        public decimal BackPay
        {
            get { return backPay; }
            set { backPay = value; }
        }
       
        private decimal timeFing;

        public decimal TimeFing
        {
            get { return timeFing; }
            set { timeFing = value; }
        }
        private decimal late;

        public decimal Late
        {
            get { return late; }
            set { late = value; }
        }
        private decimal others;

        public decimal Others
        {
            get { return others; }
            set { others = value; }
        }
        private decimal adv;

        public decimal Adv
        {
            get { return adv; }
            set { adv = value; }
        }
        private decimal tax;

        public decimal Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        private decimal ssb;

        public decimal Ssb
        {
            get { return ssb; }
            set { ssb = value; }
        }
        private decimal loan;

        public decimal Loan
        {
            get { return loan; }
            set { loan = value; }
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
        private decimal fine;

        public decimal Fine
        {
            get { return fine; }
            set { fine = value; }
        }
        private decimal otherDeduction;

        public decimal OtherDeduction
        {
            get { return otherDeduction; }
            set { otherDeduction = value; }
        }

        private decimal battery;

        public decimal Battery
        {
            get { return battery; }
            set { battery = value; }
        }
        private decimal adjustmentPlus;

        public decimal AdjustmentPlus
        {
            get { return adjustmentPlus; }
            set { adjustmentPlus = value; }
        }
        private decimal adjustmentMinus;

        public decimal AdjustmentMinus
        {
            get { return adjustmentMinus; }
            set { adjustmentMinus = value; }
        }
        private decimal otherAdjustment;

        public decimal OtherAdjustment
        {
            get { return otherAdjustment; }
            set { otherAdjustment = value; }
        }
        private decimal netAmount;

        public decimal NetAmount
        {
            get { return netAmount; }
            set { netAmount = value; }
        }
        private bool isEdit;

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        private string remark;
        private bool isResign;

        public bool IsResign
        {
            get { return isResign; }
            set { isResign = value; }
        }
 
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
