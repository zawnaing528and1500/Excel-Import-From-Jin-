using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AddressVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }     

        private int conPersonID;
        public int ConPersonID
        {
            get { return conPersonID; }
            set { conPersonID = value; }
        }

        private int applicantID;

        public int ApplicantID
        {
            get { return applicantID; }
            set { applicantID = value; }
        }

        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        private string homeNo;

        public string HomeNo
        {
            get { return homeNo; }
            set { homeNo = value; }
        }

        private string street;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        private string quarter;

        public string Quarter
        {
            get { return quarter; }
            set { quarter = value; }
        }
        private int townshipID;

        public int TownshipID
        {
            get { return townshipID; }
            set { townshipID = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private int stateDivisionID;

        public int StateDivisionID
        {
            get { return stateDivisionID; }
            set { stateDivisionID = value; }
        }
        private bool isPermanent;

        public bool IsPermanent
        {
            get { return isPermanent; }
            set { isPermanent = value; }
        }
        
    }
}
