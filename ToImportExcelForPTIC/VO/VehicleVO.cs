using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class VehicleVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string vehicleDivision;

        public string VehicleDivision
        {
            get { return vehicleDivision; }
            set { vehicleDivision = value; }
        }
        private string vehiclePrefixNo;

        public string VehiclePrefixNo
        {
            get { return vehiclePrefixNo; }
            set { vehiclePrefixNo = value; }
        }
        private string vehicleNo;

        public string VehicleNo
        {
            get { return vehicleNo; }
            set { vehicleNo = value; }
        }
        
        private string vehicleModel;

        public string VehicleModel
        {
            get { return vehicleModel; }
            set { vehicleModel = value; }
        }
        private bool isBlackColour;

        public bool IsBlackColour
        {
            get { return isBlackColour; }
            set { isBlackColour = value; }
        }
        private bool isRedColour;

        public bool IsRedColour
        {
            get { return isRedColour; }
            set { isRedColour = value; }
        }
        private string vehicleType;

        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }
        private string vehicleBrand;

        public string VehicleBrand
        {
            get { return vehicleBrand; }
            set { vehicleBrand = value; }
        }
        private string vehicleColour;

        public string VehicleColour
        {
            get { return vehicleColour; }
            set { vehicleColour = value; }
        }
        private decimal capacityWgt;

        public decimal CapacityWgt
        {
            get { return capacityWgt; }
            set { capacityWgt = value; }
        }
        private decimal vehicleWgt;

        public decimal VehicleWgt
        {
            get { return vehicleWgt; }
            set { vehicleWgt = value; }
        }
        private string licenseType;

        public string LicenseType
        {
            get { return licenseType; }
            set { licenseType = value; }
        }
        private DateTime purchaseDate;

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
        private decimal purchasePrice;

        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }
        private int seller;

        public int Seller
        {
            get { return seller; }
            set { seller = value; }
        }
        private bool isSticker;

        public bool IsSticker
        {
            get { return isSticker; }
            set { isSticker = value; }
        }
        private DateTime vehicleLicenseExpireDate;

        public DateTime VehicleLicenseExpireDate
        {
            get { return vehicleLicenseExpireDate; }
            set { vehicleLicenseExpireDate = value; }
        }
        private bool isLicenseExpireDate;

        public bool IsLicenseExpireDate
        {
            get { return isLicenseExpireDate; }
            set { isLicenseExpireDate = value; }
        }

        
        private DateTime licenseExpireDate;

        public DateTime LicenseExpireDate
        {
            get { return licenseExpireDate; }
            set { licenseExpireDate = value; }
        }
        private string enginePower;

        public string EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }
        private string fuelType;

        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }
        private string vehicleSizeLength;

        public string VehicleSizeLength
        {
            get { return vehicleSizeLength; }
            set { vehicleSizeLength = value; }
        }
        private string vehicleSizeWidth;

        public string VehicleSizeWidth
        {
            get { return vehicleSizeWidth; }
            set { vehicleSizeWidth = value; }
        }
        private string vehicleSizeHeight;

        public string VehicleSizeHeight
        {
            get { return vehicleSizeHeight; }
            set { vehicleSizeHeight = value; }
        }
        private int noOfWheels;

        public int NoOfWheels
        {
            get { return noOfWheels; }
            set { noOfWheels = value; }
        }
        private string wheelSize;

        public string WheelSize
        {
            get { return wheelSize; }
            set { wheelSize = value; }
        }
        private string vehicleBodyType;

        public string VehicleBodyType
        {
            get { return vehicleBodyType; }
            set { vehicleBodyType = value; }
        }
        private string gearType;

        public string GearType
        {
            get { return gearType; }
            set { gearType = value; }
        }
        private string otherTools;

        public string OtherTools
        {
            get { return otherTools; }
            set { otherTools = value; }
        }       

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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

        private DateTime municipalExpireDate;

        public DateTime MunicipalExpireDate
        {
            get { return municipalExpireDate; }
            set { municipalExpireDate = value; }
        }
        private DateTime premiumExpireDate;

        public DateTime PremiumExpireDate
        {
            get { return premiumExpireDate; }
            set { premiumExpireDate = value; }
        }
        private int fuelLimit;

        public int FuelLimit
        {
            get { return fuelLimit; }
            set { fuelLimit = value; }
        }
    }
}
