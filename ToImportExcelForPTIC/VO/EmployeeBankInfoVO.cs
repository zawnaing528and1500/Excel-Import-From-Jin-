using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeBankInfoVO
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
        private int bankID;

        public int BankID
        {
            get { return bankID; }
            set { bankID = value; }
        }
        private string accountNumber;

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        private string accountType;

        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
    }
}
