using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssetCategoryVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private string codeNo;

        public string CodeNo
        {
            get { return codeNo; }
            set { codeNo = value; }
        }
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
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
