using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.DAO
{
    public class DeductionSummaryDAO:Toyo.Core.Base
    {

        public System.Data.DataTable GetMonthlyDeductionSummary(DateTime startTime,DateTime endTime) 
        {

            try
            {
                return Execute_SP_DT("sp_DeductionSummary", "'" + startTime.ToString("yyyyMMdd") + "','" + endTime.ToString("yyyyMMdd") + "'");

            }
            catch (Exception err) 
            {
                throw err;
            }
        
        }


    }
}
