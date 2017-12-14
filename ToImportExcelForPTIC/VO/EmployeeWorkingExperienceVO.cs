using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeWorkingExperienceVO
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
        private string period;

        public string Period
        {
            get { return period; }
            set { period = value; }
        }
        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        private string company;

        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string refName;

        public string RefName
        {
            get { return refName; }
            set { refName = value; }
        }
    }
}
