using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class PR_FixedRulesAssignVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int fixedRulesID;

        public int FixedRulesID
        {
            get { return fixedRulesID; }
            set { fixedRulesID = value; }
        }
        private int rankID;

        public int RankID
        {
            get { return rankID; }
            set { rankID = value; }
        }
    }
}
