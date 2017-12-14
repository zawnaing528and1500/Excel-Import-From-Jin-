using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TrainingPlanDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string training;

        public string Training
        {
            get { return training; }
            set { training = value; }
        }
        private int trainingTypeID;

        public int TrainingTypeID
        {
            get { return trainingTypeID; }
            set { trainingTypeID = value; }
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
        private string trainer;

        public string Trainer
        {
            get { return trainer; }
            set { trainer = value; }
        }
        private int noOfParticipants;

        public int NoOfParticipants
        {
            get { return noOfParticipants; }
            set { noOfParticipants = value; }
        }

        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        private string trainingCentre;

        public string TrainingCentre
        {
            get { return trainingCentre; }
            set { trainingCentre = value; }
        }
        private bool certificate;

        public bool Certificate
        {
            get { return certificate; }
            set { certificate = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private bool isInternalTraining;

        public bool IsInternalTraining
        {
            get { return isInternalTraining; }
            set { isInternalTraining = value; }
        }
        private bool isInternalTrainer;

        public bool IsInternalTrainer
        {
            get { return isInternalTrainer; }
            set { isInternalTrainer = value; }
        }
    }
}
