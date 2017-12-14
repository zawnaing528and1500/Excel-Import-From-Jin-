using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class VehicleImageVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private string imageName;

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        private byte[] image;

        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
