using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeRelativeVO
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
        private string relativeName;

        public string RelativeName
        {
            get { return relativeName; }
            set { relativeName = value; }
        }
        private string relation;

        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }
        
        private string nameOfCompany;

        public string NameOfCompany
        {
            get { return nameOfCompany; }
            set { nameOfCompany = value; }
        }
        private string occupation;

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
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
       
    }
}
