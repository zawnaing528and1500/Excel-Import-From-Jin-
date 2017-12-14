using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelPurchaseEntryVO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string cashRequestNo;
        public string CashRequestNo
        {
            get { return cashRequestNo; }
            set { cashRequestNo = value; }
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

        private int issuerID;
        public int IssuerID
        {
            get { return issuerID; }
            set { issuerID = value; }
        }
        private int cashReceiptPersonID;

        public int CashReceiptPersonID
        {
            get { return cashReceiptPersonID; }
            set { cashReceiptPersonID = value; }
        }

        private decimal expectedPrice;
        public decimal ExpectedPrice
        {
            get { return expectedPrice; }
            set { expectedPrice = value; }
        }

        private decimal expectedGalon;
        public decimal ExpectedGalon
        {
            get { return expectedGalon; }
            set { expectedGalon = value; }
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
