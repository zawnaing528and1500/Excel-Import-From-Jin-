using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FP_Manual_HistoryVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int manualID;

        public int ManualID
        {
            get { return manualID; }
            set { manualID = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private DateTime? inDate;

        public DateTime? InDate
        {
            get { return inDate; }
            set { inDate = value; }
        }
        private DateTime? outDate;

        public DateTime? OutDate
        {
            get { return outDate; }
            set { outDate = value; }
        }
        private TimeSpan? inTime;

        public TimeSpan? InTime
        {
            get { return inTime; }
            set { inTime = value; }
        }
        private TimeSpan? outTime;

        public TimeSpan? OutTime
        {
            get { return outTime; }
            set { outTime = value; }
        }
        private int createdBy;

        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
    }
}