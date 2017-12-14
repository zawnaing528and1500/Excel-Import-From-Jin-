using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class UOMVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string _UOMName;

        public string UOMName
        {
            get { return _UOMName; }
            set { _UOMName = value; }
        }
        private string shortTerm;

        public string ShortTerm
        {
            get { return shortTerm; }
            set { shortTerm = value; }
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
