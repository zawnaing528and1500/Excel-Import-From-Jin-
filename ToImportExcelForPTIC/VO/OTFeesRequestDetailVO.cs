using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OTFeesRequestDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int oTFeesRequestInfoID;

        public int OTFeesRequestInfoID
        {
            get { return oTFeesRequestInfoID; }
            set { oTFeesRequestInfoID = value; }
        }
        private int oTRequestDetailID;

        public int OTRequestDetailID
        {
            get { return oTRequestDetailID; }
            set { oTRequestDetailID = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
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
        private string typeOfTask;

        public string TypeOfTask
        {
            get { return typeOfTask; }
            set { typeOfTask = value; }
        }
        private bool isRewardTypeOT;

        public bool IsRewardTypeOT
        {
            get { return isRewardTypeOT; }
            set { isRewardTypeOT = value; }
        }
        private bool isRewardTypeReplace;

        public bool IsRewardTypeReplace
        {
            get { return isRewardTypeReplace; }
            set { isRewardTypeReplace = value; }
        }
        private DateTime oTFromDate;

        public DateTime OTFromDate
        {
            get { return oTFromDate; }
            set { oTFromDate = value; }
        }
        private TimeSpan oTStartTime;

        public TimeSpan OTStartTime
        {
            get { return oTStartTime; }
            set { oTStartTime = value; }
 
        } 
        private DateTime oTToDate;

        public DateTime OTToDate
        {
            get { return oTToDate; }
            set { oTToDate = value; }
        }
        private TimeSpan oTEndTime;

        public TimeSpan OTEndTime
        {
            get { return oTEndTime; }
            set { oTEndTime = value; }
        }
        private double totalOTHours;

        public double TotalOTHours
        {
            get { return totalOTHours; }
            set { totalOTHours = value; }
        }
        private decimal oTFeesPerHour;

        public decimal OTFeesPerHour
        {
            get { return oTFeesPerHour; }
            set { oTFeesPerHour = value; }
        }
        private decimal totalOTFees;

        public decimal TotalOTFees
        {
            get { return totalOTFees; }
            set { totalOTFees = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
