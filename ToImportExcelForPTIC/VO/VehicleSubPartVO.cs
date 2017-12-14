using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class VehicleSubPartVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int vehiclePartID;

        public int VehiclePartID
        {
            get { return vehiclePartID; }
            set { vehiclePartID = value; }
        }
        private string vehicleSubPartName;

        public string VehicleSubPartName
        {
            get { return vehicleSubPartName; }
            set { vehicleSubPartName = value; }
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
