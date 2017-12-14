using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int officeAccessoriesCategoryID;

        public int OfficeAccessoriesCategoryID
        {
            get { return officeAccessoriesCategoryID; }
            set { officeAccessoriesCategoryID = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private int _UOMID;

        public int UOMID
        {
            get { return _UOMID; }
            set { _UOMID = value; }
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
