using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class OfficeAccessoriesInventoryVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int officeAccessoriesID;

        public int OfficeAccessoriesID
        {
            get { return officeAccessoriesID; }
            set { officeAccessoriesID = value; }
        }
        private int openingBalance;

        public int OpeningBalance
        {
            get { return openingBalance; }
            set { openingBalance = value; }
        }
        private int stockInQty;

        public int StockInQty
        {
            get { return stockInQty; }
            set { stockInQty = value; }
        }
        private int issueQty;

        public int IssueQty
        {
            get { return issueQty; }
            set { issueQty = value; }
        }
    }
}
