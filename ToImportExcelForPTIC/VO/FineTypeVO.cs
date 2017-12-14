using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FineTypeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string fineType;

        public string FineType
        {
            get { return fineType; }
            set { fineType = value; }
        }
        private decimal fineAmount;

        public decimal FineAmount
        {
            get { return fineAmount; }
            set { fineAmount = value; }
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
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
