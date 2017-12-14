using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class YearlyTrainingPlanInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private bool isInternal;

        public bool IsInternal
        {
            get { return isInternal; }
            set { isInternal = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
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
    }
}
