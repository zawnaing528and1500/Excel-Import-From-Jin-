using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class JobPositionVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string postName;

        public string PostName
        {
            get { return postName; }
            set { postName = value; }
        }

        private int departmentID;

        public int DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }
        private string reportTo;

        public string ReportTo
        {
            get { return reportTo; }
            set { reportTo = value; }
        }
        private string jobSpecification;

        public string JobSpecification
        {
            get { return jobSpecification; }
            set { jobSpecification = value; }
        }
        private string jobDescription;

        public string JobDescription
        {
            get { return jobDescription; }
            set { jobDescription = value; }
        }

        private int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
     
    }
}
