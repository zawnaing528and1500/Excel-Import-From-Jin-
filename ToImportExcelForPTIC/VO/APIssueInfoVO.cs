using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APIssueInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime issueDate;

        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }
        private int issueDeptID;

        public int IssueDeptID
        {
            get { return issueDeptID; }
            set { issueDeptID = value; }
        }
        private int issueEmpID;

        public int IssueEmpID
        {
            get { return issueEmpID; }
            set { issueEmpID = value; }
        }
        private string requestNo;

        public string RequestNo
        {
            get { return requestNo; }
            set { requestNo = value; }
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
