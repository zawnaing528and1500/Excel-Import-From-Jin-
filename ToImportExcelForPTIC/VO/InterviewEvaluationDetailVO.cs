using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class InterviewEvaluationDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int interviewEvaluationInfoID;

        public int InterviewEvaluationInfoID
        {
            get { return interviewEvaluationInfoID; }
            set { interviewEvaluationInfoID = value; }
        }
        private int evaluationQuestionID;

        public int EvaluationQuestionID
        {
            get { return evaluationQuestionID; }
            set { evaluationQuestionID = value; }
        }
        private bool twentyMarks;

        public bool TwentyMarks
        {
            get { return twentyMarks; }
            set { twentyMarks = value; }
        }
        private bool fifteenMarks;

        public bool FifteenMarks
        {
            get { return fifteenMarks; }
            set { fifteenMarks = value; }
        }
        private bool tenMarks;

        public bool TenMarks
        {
            get { return tenMarks; }
            set { tenMarks = value; }
        }
        private bool fiveMarks;

        public bool FiveMarks
        {
            get { return fiveMarks; }
            set { fiveMarks = value; }
        }
        private bool zeroMarks;

        public bool ZeroMarks
        {
            get { return zeroMarks; }
            set { zeroMarks = value; }
        }
        private string detailTotalMark;

        public string DetailTotalMark
        {
            get { return detailTotalMark; }
            set { detailTotalMark = value; }
        }
    }
}
