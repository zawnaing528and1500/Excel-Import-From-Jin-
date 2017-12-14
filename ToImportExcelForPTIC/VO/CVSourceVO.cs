using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class CVSourceVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cVSource;

        public string CVSource
        {
            get { return cVSource; }
            set { cVSource = value; }
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
    }
}
