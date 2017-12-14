using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class VehicleCheckDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int vehicleCheckID;

        public int VehicleCheckID
        {
            get { return vehicleCheckID; }
            set { vehicleCheckID = value; }
        }
        private int carSubPartID;

        public int CarSubPartID
        {
            get { return carSubPartID; }
            set { carSubPartID = value; }
        }
        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
