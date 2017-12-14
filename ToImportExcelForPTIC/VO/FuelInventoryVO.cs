using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelInventoryVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int fuelStationID;

        public int FuelStationID
        {
            get { return fuelStationID; }
            set { fuelStationID = value; }
        }
        private decimal payAmount;

        public decimal PayAmount
        {
            get { return payAmount; }
            set { payAmount = value; }
        }
        private decimal usedAmount;

        public decimal UsedAmount
        {
            get { return usedAmount; }
            set { usedAmount = value; }
        }
        private decimal balanceAmount;

        public decimal BalanceAmount
        {
            get { return balanceAmount; }
            set { balanceAmount = value; }
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
