using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OTRequestDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int oTRequestInfoID;

        public int OTRequestInfoID
        {
            get { return oTRequestInfoID; }
            set { oTRequestInfoID = value; }
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
        private Double totalOTHours;

        public Double TotalOTHours
        {
            get { return totalOTHours; }
            set { totalOTHours = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool isUsed;

        public bool IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }
        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
