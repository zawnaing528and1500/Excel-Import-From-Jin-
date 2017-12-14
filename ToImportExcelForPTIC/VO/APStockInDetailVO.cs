using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class APStockInDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int aPStockInID;

        public int APStockInID
        {
            get { return aPStockInID; }
            set { aPStockInID = value; }
        }
        private int aPMaterialID;

        public int APMaterialID
        {
            get { return aPMaterialID; }
            set { aPMaterialID = value; }
        }
        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }


    }
}
