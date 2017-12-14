// -----------------------------------------------------------------------
// <copyright file="OtherAdjustmentVO.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Toyo.Core
{
    using System;
    using System.Collections.Generic;
    
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PR_Other_AdjustmentVO
    {
        private int ID;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }
        private int EmpID;

        public int EmpID1
        {
            get { return EmpID; }
            set { EmpID = value; }
        }
        private int DeptID;

        public int DeptID1
        {
            get { return DeptID; }
            set { DeptID = value; }
        }
        private DateTime RegDate;

        public DateTime RegDate1
        {
            get { return RegDate; }
            set { RegDate = value; }
        }
        private Decimal Amount;

        public Decimal Amount1
        {
            get { return Amount; }
            set { Amount = value; }
        }
        private String Remark;

        public String Remark1
        {
            get { return Remark; }
            set { Remark = value; }
        }

    }
}
