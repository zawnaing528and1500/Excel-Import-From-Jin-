using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class UtilizedAssetVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int assetInDetailID;

        public int AssetInDetailID
        {
            get { return assetInDetailID; }
            set { assetInDetailID = value; }
        }

        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private int _UOMID;

        public int UOMID
        {
            get { return _UOMID; }
            set { _UOMID = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }

    }
}
