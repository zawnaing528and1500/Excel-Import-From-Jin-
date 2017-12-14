using System;
using System.Collections.Generic;

using System.Text;
using Toyo.Core;

namespace Toyo.Core
{
    public class WEInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private int jobPositionID;

        public int JobPositionID
        {
            get { return jobPositionID; }
            set { jobPositionID = value; }
        }
        private int wE;

        public int WE
        {
            get { return wE; }
            set { wE = value; }
        }

        
        private int surplus;

        public int Surplus
        {
            get { return surplus; }
            set { surplus = value; }
        }
        private string referenceNo;

        public string ReferenceNo
        {
            get { return referenceNo; }
            set { referenceNo = value; }
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
