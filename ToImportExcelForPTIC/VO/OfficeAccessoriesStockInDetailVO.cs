using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesStockInDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int stockInInfoID;

        public int StockInInfoID
        {
            get { return stockInInfoID; }
            set { stockInInfoID = value; }
        }
        private int officeAccessoriesID;

        public int OfficeAccessoriesID
        {
            get { return officeAccessoriesID; }
            set { officeAccessoriesID = value; }
        }
        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private int uomID;

        public int UomID
        {
            get { return uomID; }
            set { uomID = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private int supplierID;

        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
    }
}
