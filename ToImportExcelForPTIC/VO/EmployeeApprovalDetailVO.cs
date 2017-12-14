using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeApprovalDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int approvalInfoID;

        public int ApprovalInfoID
        {
            get { return approvalInfoID; }
            set { approvalInfoID = value; }
        }
        private int descriptionID;

        public int DescriptionID
        {
            get { return descriptionID; }
            set { descriptionID = value; }
        }
        private int payMarks;

        public int PayMarks
        {
            get { return payMarks; }
            set { payMarks = value; }
        }
        private int gainMarks;

        public int GainMarks
        {
            get { return gainMarks; }
            set { gainMarks = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
