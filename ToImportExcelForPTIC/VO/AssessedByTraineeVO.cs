using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class AssessedByTraineeVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int trainingPlanDetailID;

        public int TrainingPlanDetailID
        {
            get { return trainingPlanDetailID; }
            set { trainingPlanDetailID = value; }
        }

       
        private int attendeeID;

        public int AttendeeID
        {
            get { return attendeeID; }
            set { attendeeID = value; }
        }
        private string objective;

        public string Objective
        {
            get { return objective; }
            set { objective = value; }
        }
        private bool isFullyAchieved;

        public bool IsFullyAchieved
        {
            get { return isFullyAchieved; }
            set { isFullyAchieved = value; }
        }
        private bool isLargelyAchieved;

        public bool IsLargelyAchieved
        {
            get { return isLargelyAchieved; }
            set { isLargelyAchieved = value; }
        }
        private bool isPartlyAchieved;

        public bool IsPartlyAchieved
        {
            get { return isPartlyAchieved; }
            set { isPartlyAchieved = value; }
        }
        private bool isNotUnderstand;

        public bool IsNotUnderstand
        {
            get { return isNotUnderstand; }
            set { isNotUnderstand = value; }
        }
        private bool isUsefulContent;

        public bool IsUsefulContent
        {
            get { return isUsefulContent; }
            set { isUsefulContent = value; }
        }
        private bool isTooTheoreticalContent;

        public bool IsTooTheoreticalContent
        {
            get { return isTooTheoreticalContent; }
            set { isTooTheoreticalContent = value; }
        }

        
        private bool isSomewhatUsefulContent;

        public bool IsSomewhatUsefulContent
        {
            get { return isSomewhatUsefulContent; }
            set { isSomewhatUsefulContent = value; }
        }
        private bool isNotAchievedContent;

        public bool IsNotAchievedContent
        {
            get { return isNotAchievedContent; }
            set { isNotAchievedContent = value; }
        }
        private bool isExcellentInstructor;

        public bool IsExcellentInstructor
        {
            get { return isExcellentInstructor; }
            set { isExcellentInstructor = value; }
        }
        private bool isGoodInstructor;

        public bool IsGoodInstructor
        {
            get { return isGoodInstructor; }
            set { isGoodInstructor = value; }
        }
        private bool isAverageInstructor;

        public bool IsAverageInstructor
        {
            get { return isAverageInstructor; }
            set { isAverageInstructor = value; }
        }
        private bool isPoorInstructor;

        public bool IsPoorInstructor
        {
            get { return isPoorInstructor; }
            set { isPoorInstructor = value; }
        }
        private string comments;

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private string suggestions;

        public string Suggestions
        {
            get { return suggestions; }
            set { suggestions = value; }
        }

       

    }
}
