﻿using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class OTRequestInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime oTRequestDate;

        public DateTime OTRequestDate
        {
            get { return oTRequestDate; }
            set { oTRequestDate = value; }
        }
        
       private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private int recommandEmpID;

        public int RecommandEmpID
        {
            get { return recommandEmpID; }
            set { recommandEmpID = value; }
        }
        private int checkedEmpID;

        public int CheckedEmpID
        {
            get { return checkedEmpID; }
            set { checkedEmpID = value; }
        }
        private int plannedEmpID;

        public int PlannedEmpID
        {
            get { return plannedEmpID; }
            set { plannedEmpID = value; }
        }
        private int approveEmpID;

        public int ApproveEmpID
        {
            get { return approveEmpID; }
            set { approveEmpID = value; }
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
