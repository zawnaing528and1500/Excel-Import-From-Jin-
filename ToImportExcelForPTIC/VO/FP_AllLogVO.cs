using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class FP_AllLogVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int fingerID;

        public int FingerID
        {
            get { return fingerID; }
            set { fingerID = value; }
        }
        private int verifyMode;

        public int VerifyMode
        {
            get { return verifyMode; }
            set { verifyMode = value; }
        }
        private int inOut;

        public int InOut
        {
            get { return inOut; }
            set { inOut = value; }
        }
        private DateTime attendanceDate;

        public DateTime AttendanceDate
        {
            get { return attendanceDate; }
            set { attendanceDate = value; }
        }
        private DateTime attendanceDateTime;

        public DateTime AttendanceDateTime
        {
            get { return attendanceDateTime; }
            set { attendanceDateTime = value; }
        }
    }
}
