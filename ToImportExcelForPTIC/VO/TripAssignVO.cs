using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TripAssignVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
      
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private string tripName;

        public string TripName
        {
            get { return tripName; }
            set { tripName = value; }
        }
        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        private DateTime toDate;

        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool isTrip;

        public bool IsTrip
        {
            get { return isTrip; }
            set { isTrip = value; }
        }
    }
}
