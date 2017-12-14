using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class YearlyTrainingPlanDetailVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int yearlyTrainingPlanInfoID;

        public int YearlyTrainingPlanInfoID
        {
            get { return yearlyTrainingPlanInfoID; }
            set { yearlyTrainingPlanInfoID = value; }
        }
        private int trainingTypeID;

        public int TrainingTypeID
        {
            get { return trainingTypeID; }
            set { trainingTypeID = value; }
        }
        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private bool january;

        public bool January
        {
            get { return january; }
            set { january = value; }
        }
        private bool february;

        public bool February
        {
            get { return february; }
            set { february = value; }
        }
        private bool march;

        public bool March
        {
            get { return march; }
            set { march = value; }
        }
        private bool april;

        public bool April
        {
            get { return april; }
            set { april = value; }
        }
        private bool may;

        public bool May
        {
            get { return may; }
            set { may = value; }
        }
        private bool june;

        public bool June
        {
            get { return june; }
            set { june = value; }
        }
        private bool july;

        public bool July
        {
            get { return july; }
            set { july = value; }
        }
        private bool august;

        public bool August
        {
            get { return august; }
            set { august = value; }
        }
        private bool september;

        public bool September
        {
            get { return september; }
            set { september = value; }
        }
        private bool october;

        public bool October
        {
            get { return october; }
            set { october = value; }
        }
        private bool november;

        public bool November
        {
            get { return november; }
            set { november = value; }
        }
        private bool december;

        public bool December
        {
            get { return december; }
            set { december = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool approved;

        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        } 
    }
}
