using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeePositionChangeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        private int currentPostID;

        public int CurrentPostID
        {
            get { return currentPostID; }
            set { currentPostID = value; }
        }

        private bool isSameCompany;

        public bool IsSameCompany
        {
            get { return isSameCompany; }
            set { isSameCompany = value; }
        }
        private int newDeptID;

        public int NewDeptID
        {
            get { return newDeptID; }
            set { newDeptID = value; }
        }
        private string otherPostDescription;

        public string OtherPostDescription
        {
            get { return otherPostDescription; }
            set { otherPostDescription = value; }
        }
        private int newPostID;

        public int NewPostID
        {
            get { return newPostID; }
            set { newPostID = value; }
        }
        private int deptId;

        public int DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }
        private string tentativeOrderNo;

        public string TentativeOrderNo
        {
            get { return tentativeOrderNo; }
            set { tentativeOrderNo = value; }
        }
        private DateTime tentativeDate;

        public DateTime TentativeDate
        {
            get { return tentativeDate; }
            set { tentativeDate = value; }
        }
        private DateTime changeDate;

        public DateTime ChangeDate
        {
            get { return changeDate; }
            set { changeDate = value; }
        }

        private bool isPromotion;

        public bool IsPromotion
        {
            get { return isPromotion; }
            set { isPromotion = value; }
        }

        private int recommender;

        public int Recommender
        {
            get { return recommender; }
            set { recommender = value; }
        }

        private int approveEmp1;

        public int ApproveEmp1
        {
            get { return approveEmp1; }
            set { approveEmp1 = value; }
        }

        private int approveEmp2;

        public int ApproveEmp2
        {
            get { return approveEmp2; }
            set { approveEmp2 = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private DateTime previousDate;

        public DateTime PreviousDate
        {
            get { return previousDate; }
            set { previousDate = value; }
        }
        private string orderNo;

        public string OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
    }
}
