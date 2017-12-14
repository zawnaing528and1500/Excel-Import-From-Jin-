using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PRLateFineVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int fromrank;

        public int FromRank
        {
            get { return fromrank; }
            set { fromrank = value; }
        }

        public int torank;
        public int ToRank
        {
            get { return torank; }
            set { torank = value; }
        }

        private string lateType;

        public string LateType
        {
            get { return lateType; }
            set { lateType = value; }
        }
        private int lateCount;

        public int LateCount
        {
            get { return lateCount; }
            set { lateCount = value; }
        }

        private decimal fineKyat;

        public decimal FineKyat
        {
            get { return fineKyat; }
            set { fineKyat = value; }
        }
        private int percentOfAtt;

        public int PercentOfAtt
        {
            get { return percentOfAtt; }
            set { percentOfAtt = value; }
        }
        private int postponeIncrementMonth;

        public int PostponeIncrementMonth
        {
            get { return postponeIncrementMonth; }
            set { postponeIncrementMonth = value; }
        }
        private int percentOfOtherAllowance;

        public int PercentOfOtherAllowance
        {
            get { return percentOfOtherAllowance; }
            set { percentOfOtherAllowance = value; }
        }
        private bool isFineKyat;

        public bool IsFineKyat
        {
            get { return isFineKyat; }
            set { isFineKyat = value; }
        }
        private bool isPercentOfAtt;

        public bool IsPercentOfAtt
        {
            get { return isPercentOfAtt; }
            set { isPercentOfAtt = value; }
        }
        private bool isPostponeIncrement;

        public bool IsPostponeIncrement
        {
            get { return isPostponeIncrement; }
            set { isPostponeIncrement = value; }
        }
        private bool isPercentOfOtherAllowance;

        public bool IsPercentOfOtherAllowance
        {
            get { return isPercentOfOtherAllowance; }
            set { isPercentOfOtherAllowance = value; }
        }
    }
}
