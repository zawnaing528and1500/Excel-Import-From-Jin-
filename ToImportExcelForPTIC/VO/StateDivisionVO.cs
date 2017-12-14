using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class StateDivisionVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string stateDivisionName;

        public string StateDivisionName
        {
            get { return stateDivisionName; }
            set { stateDivisionName = value; }
        }
    }
}
