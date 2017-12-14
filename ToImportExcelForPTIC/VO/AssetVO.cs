using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssetVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private string assetName;

        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }
        private int uomID;

        public int UomID
        {
            get { return uomID; }
            set { uomID = value; }
        }
        private int assetCatID;

        public int AssetCatID
        {
            get { return assetCatID; }
            set { assetCatID = value; }
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
