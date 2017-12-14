using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class VehicleRepairRequestVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime requestDate;

        public DateTime RequestDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }
        
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private int driverID;

        public int DriverID
        {
            get { return driverID; }
            set { driverID = value; }
        }
        private int inChargeID;

        public int InChargeID
        {
            get { return inChargeID; }
            set { inChargeID = value; }
        }
        private int repairPartID;

        public int RepairPartID
        {
            get { return repairPartID; }
            set { repairPartID = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private decimal expectedCost;

        public decimal ExpectedCost
        {
            get { return expectedCost; }
            set { expectedCost = value; }
        }
        private bool isLastRepair;

        public bool IsLastRepair
        {
            get { return isLastRepair; }
            set { isLastRepair = value; }
        }
        private DateTime lastRepairDate;

        public DateTime LastRepairDate
        {
            get { return lastRepairDate; }
            set { lastRepairDate = value; }
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
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        private int maintenanceEmpID;

        public int MaintenanceEmpID
        {
            get { return maintenanceEmpID; }
            set { maintenanceEmpID = value; }
        }
    }
}
