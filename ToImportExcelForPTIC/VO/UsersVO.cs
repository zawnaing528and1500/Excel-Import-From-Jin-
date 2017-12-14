using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class UsersVO
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int accesslevelID;

        public int AccesslevelID
        {
            get { return accesslevelID; }
            set { accesslevelID = value; }
        }
        private int assignUserID;

        public int AssignUserID
        {
            get { return assignUserID; }
            set { assignUserID = value; }
        }
        private string assignPassword;

        public string AssignPassword
        {
            get { return assignPassword; }
            set { assignPassword = value; }
        }
        private bool isAssign;

        public bool IsAssign
        {
            get { return isAssign; }
            set { isAssign = value; }
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
