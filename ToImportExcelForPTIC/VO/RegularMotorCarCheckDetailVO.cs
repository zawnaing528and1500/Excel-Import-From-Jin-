using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class RegularMotorCarCheckDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int regularMotorCarCheckID;

        public int RegularMotorCarCheckID
        {
            get { return regularMotorCarCheckID; }
            set { regularMotorCarCheckID = value; }
        }
        private int vSecondPartID;

        public int VSecondPartID
        {
            get { return vSecondPartID; }
            set { vSecondPartID = value; }
        }
        private bool available;

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
        private bool nonAvailable;

        public bool NonAvailable
        {
            get { return nonAvailable; }
            set { nonAvailable = value; }
        }
        private bool good;

        public bool Good
        {
            get { return good; }
            set { good = value; }
        }
        private bool noGood;

        public bool NoGood
        {
            get { return noGood; }
            set { noGood = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
