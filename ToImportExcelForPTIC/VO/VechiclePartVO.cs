using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class VehiclePartVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string vehiclePartName;

        public string VehiclePartName
        {
            get { return vehiclePartName; }
            set { vehiclePartName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
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
