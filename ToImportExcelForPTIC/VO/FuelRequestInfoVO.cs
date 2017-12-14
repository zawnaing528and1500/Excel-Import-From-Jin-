using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FuelRequestInfoVO
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
        private string requestNo;

        public string RequestNo
        {
            get { return requestNo; }
            set { requestNo = value; }
        }
        private string fuelName;

        public string FuelName
        {
            get { return fuelName; }
            set { fuelName = value; }
        }
        private decimal reqGallon;

        public decimal ReqGallon
        {
            get { return reqGallon; }
            set { reqGallon = value; }
        }
        private decimal fuelPrice;

        public decimal FuelPrice
        {
            get { return fuelPrice; }
            set { fuelPrice = value; }
        }
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private DateTime receiveDate;

        public DateTime ReceiveDate
        {
            get { return receiveDate; }
            set { receiveDate = value; }
        }
        private int receiveEmpID;

        public int ReceiveEmpID
        {
            get { return receiveEmpID; }
            set { receiveEmpID = value; }
        }
        private int inChargeID;

        public int InChargeID
        {
            get { return inChargeID; }
            set { inChargeID = value; }
        }
        private int checkEmpID;

        public int CheckEmpID
        {
            get { return checkEmpID; }
            set { checkEmpID = value; }
        }
        private int permitEmpID;

        public int PermitEmpID
        {
            get { return permitEmpID; }
            set { permitEmpID = value; }
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
    }
}
