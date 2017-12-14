using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelUsageVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
                
        private int fuelStationID;
        public int FuelStationID
        {
            get { return fuelStationID; }
            set { fuelStationID = value; }
        }

        private int vehicleID;
        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }

        private int fuelType;
        public int FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }

        private decimal fuelGallons;
        public decimal FuelGallons
        {
            get { return fuelGallons; }
            set { fuelGallons = value; }
        }

        private decimal fuelPrice;
        public decimal FuelPrice
        {
            get { return fuelPrice; }
            set { fuelPrice = value; }
        }

        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
                
        private string startKilo;
        public string StartKilo
        {
            get { return startKilo; }
            set { startKilo = value; }
        }

        private string endKilo;
        public string EndKilo
        {
            get { return endKilo; }
            set { endKilo = value; }
        }

        private int issuePersonID;
        public int IssuePersonID
        {
            get { return issuePersonID; }
            set { issuePersonID = value; }
        }

        private int inchargeID;
        public int InchargeID
        {
            get { return inchargeID; }
            set { inchargeID = value; }
        }
        
        private int checkPersonID;
        public int CheckPersonID
        {
            get { return checkPersonID; }
            set { checkPersonID = value; }
        }

        private int permitPersonID;
        public int PermitPersonID
        {
            get { return permitPersonID; }
            set { permitPersonID = value; }
        }
    }
}
