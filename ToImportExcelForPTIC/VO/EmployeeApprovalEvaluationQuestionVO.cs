using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeApprovalEvaluationQuestionVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string approvalEvaluationQuestion;

        public string ApprovalEvaluationQuestion
        {
            get { return approvalEvaluationQuestion; }
            set { approvalEvaluationQuestion = value; }
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
