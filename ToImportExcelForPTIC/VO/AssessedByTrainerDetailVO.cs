using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssessedByTrainerDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int assessedByTrainerInfoID;

        public int AssessedByTrainerInfoID
        {
            get { return assessedByTrainerInfoID; }
            set { assessedByTrainerInfoID = value; }
        }
        private int trainingAttendeeID;

        public int TrainingAttendeeID
        {
            get { return trainingAttendeeID; }
            set { trainingAttendeeID = value; }
        }
        private int interest;

        public int Interest
        {
            get { return interest; }
            set { interest = value; }
        }
        private int participation;

        public int Participation
        {
            get { return participation; }
            set { participation = value; }
        }
        private int understanding;

        public int Understanding
        {
            get { return understanding; }
            set { understanding = value; }
        }
        private int punctuality;

        public int Punctuality
        {
            get { return punctuality; }
            set { punctuality = value; }
        }
        private int totalmarks;

        public int Totalmarks
        {
            get { return totalmarks; }
            set { totalmarks = value; }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
    }
}
