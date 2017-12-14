using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class AssessedByTrainerInfoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int trainingPlanID;

        public int TrainingPlanID
        {
            get { return trainingPlanID; }
            set { trainingPlanID = value; }
        }
        private string trainerName;

        public string TrainerName
        {
            get { return trainerName; }
            set { trainerName = value; }
        }
        private DateTime assessmentDate;

        public DateTime AssessmentDate
        {
            get { return assessmentDate; }
            set { assessmentDate = value; }
        }

        

    }
}
