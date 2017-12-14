using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssetInDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int assetInInfoID;

        public int AssetInInfoID
        {
            get { return assetInInfoID; }
            set { assetInInfoID = value; }
        }
        private string prefixPlace;

        public string PrefixPlace
        {
            get { return prefixPlace; }
            set { prefixPlace = value; }
        }
        private string no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }
        private string codeNo;

        public string CodeNo
        {
            get { return codeNo; }
            set { codeNo = value; }
        }
        private int assetID;

        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
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
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
