using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FP_Shift_Management_SettingVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        private TimeSpan onDutyTime;

        public TimeSpan OnDutyTime
        {
            get { return onDutyTime; }
            set { onDutyTime = value; }
        }
        private string offDutyType;

        public string OffDutyType
        {
            get { return offDutyType; }
            set { offDutyType = value; }
        }
        private TimeSpan offDutyTime;

        public TimeSpan OffDutyTime
        {
            get { return offDutyTime; }
            set { offDutyTime = value; }
        }
        private string earlyInType;

        public string EarlyInType
        {
            get { return earlyInType; }
            set { earlyInType = value; }
        }
        private TimeSpan earlyInTime;

        public TimeSpan EarlyInTime
        {
            get { return earlyInTime; }
            set { earlyInTime = value; }
        }
        
        private bool isLateAllow;

        public bool IsLateAllow
        {
            get { return isLateAllow; }
            set { isLateAllow = value; }
        }
        private bool isEarlyOutAllow;

        public bool IsEarlyOutAllow
        {
            get { return isEarlyOutAllow; }
            set { isEarlyOutAllow = value; }
        }
        private int lateAllow;

        public int LateAllow
        {
            get { return lateAllow; }
            set { lateAllow = value; }
        }
        private int earlyOutAllow;

        public int EarlyOutAllow
        {
            get { return earlyOutAllow; }
            set { earlyOutAllow = value; }
        }
        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
