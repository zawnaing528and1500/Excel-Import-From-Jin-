using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class SalarySettingVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string salaryItem;

        public string SalaryItem
        {
            get { return salaryItem; }
            set { salaryItem = value; }
        }
        private string initialValue;

        public string InitialValue
        {
            get { return initialValue; }
            set { initialValue = value; }
        }
        private string formula;

        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }
        private int fixedRulesID;

        public int FixedRulesID
        {
            get { return fixedRulesID; }
            set { fixedRulesID = value; }
        }
        private string linker;

        public string Linker
        {
            get { return linker; }
            set { linker = value; }
        }
    }
}
