using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class RepairedVehicleVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime repairDate;

        public DateTime RepairDate
        {
            get { return repairDate; }
            set { repairDate = value; }
        }
        private int repairRequestID;

        public int RepairRequestID
        {
            get { return repairRequestID; }
            set { repairRequestID = value; }
        }
        
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        private decimal actualCost;

        public decimal ActualCost
        {
            get { return actualCost; }
            set { actualCost = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
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

        private bool isEmergency;

        public bool IsEmergency
        {
            get { return isEmergency; }
            set { isEmergency = value; }
        }
    }
}
