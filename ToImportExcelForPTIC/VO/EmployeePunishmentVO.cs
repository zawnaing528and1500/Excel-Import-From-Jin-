using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeePunishmentVO
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
        private DateTime punishDate;

        public DateTime PunishDate
        {
            get { return punishDate; }
            set { punishDate = value; }
        }
        private string disobidient;

        public string Disobidient
        {
            get { return disobidient; }
            set { disobidient = value; }
        }
        private string punishmentType;

        public string PunishmentType
        {
            get { return punishmentType; }
            set { punishmentType = value; }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        private decimal money;

        public decimal Money
        {
            get { return money; }
            set { money = value; }
        }
                
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
