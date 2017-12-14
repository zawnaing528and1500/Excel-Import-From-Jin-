using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesIssueDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int issueInfoID;

        public int IssueInfoID
        {
            get { return issueInfoID; }
            set { issueInfoID = value; }
        }
        private int officeAccessoriesID;

        public int OfficeAccessoriesID
        {
            get { return officeAccessoriesID; }
            set { officeAccessoriesID = value; }
        }
               
        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private int uomID;

        public int UomID
        {
            get { return uomID; }
            set { uomID = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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
