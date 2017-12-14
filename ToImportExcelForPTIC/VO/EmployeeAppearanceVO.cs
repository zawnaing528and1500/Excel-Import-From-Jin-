using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeeAppearanceVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private decimal weight;

        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string bloodType;

        public string BloodType
        {
            get { return bloodType; }
            set { bloodType = value; }
        }
        private string eyeColour;

        public string EyeColour
        {
            get { return eyeColour; }
            set { eyeColour = value; }
        }
        private string hairColour;

        public string HairColour
        {
            get { return hairColour; }
            set { hairColour = value; }
        }
        private string skinColour;

        public string SkinColour
        {
            get { return skinColour; }
            set { skinColour = value; }
        }
        private string height;

        public string Height
        {
            get { return height; }
            set { height = value; }
        }
        private string shoulder;

        public string Shoulder
        {
            get { return shoulder; }
            set { shoulder = value; }
        }
        private string breast;

        public string Breast
        {
            get { return breast; }
            set { breast = value; }
        }
        private string waist;

        public string Waist
        {
            get { return waist; }
            set { waist = value; }
        }
        private string hip;

        public string Hip
        {
            get { return hip; }
            set { hip = value; }
        }
        private DateTime checkUpDate;

        public DateTime CheckUpDate
        {
            get { return checkUpDate; }
            set { checkUpDate = value; }
        }
        private DateTime reCheckUpDate;

        public DateTime ReCheckUpDate
        {
            get { return reCheckUpDate; }
            set { reCheckUpDate = value; }
        }
        private string physicianName;

        public string PhysicianName
        {
            get { return physicianName; }
            set { physicianName = value; }
        }
    }
}
