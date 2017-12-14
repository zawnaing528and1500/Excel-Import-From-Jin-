using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeRewardVO
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
        private DateTime rewardDate;

        public DateTime RewardDate
        {
            get { return rewardDate; }
            set { rewardDate = value; }
        }
        private string rewardType;

        public string RewardType
        {
            get { return rewardType; }
            set { rewardType = value; }
        }
        private string rewardCertificate;

        public string RewardCertificate
        {
            get { return rewardCertificate; }
            set { rewardCertificate = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
