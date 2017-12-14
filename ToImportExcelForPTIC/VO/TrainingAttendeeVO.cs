using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class TrainingAttendeeVO
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
        
        private int empID;
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private int postID;

        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }
        private int deptID;

        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
