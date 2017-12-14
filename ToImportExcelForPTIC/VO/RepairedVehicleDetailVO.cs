using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class RepairedVehicleDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int repairedVehicleID;

        public int RepairedVehicleID
        {
            get { return repairedVehicleID; }
            set { repairedVehicleID = value; }
        }
        private int vehicleSubPartID;

        public int VehicleSubPartID
        {
            get { return vehicleSubPartID; }
            set { vehicleSubPartID = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string workshop;

        public string Workshop
        {
            get { return workshop; }
            set { workshop = value; }
        }
    }
}
