using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class OfficeAccessoriesStockInVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime entryDate;

        public DateTime EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }
     
        private int entryPersonID;

        public int EntryPersonID
        {
            get { return entryPersonID; }
            set { entryPersonID = value; }
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
