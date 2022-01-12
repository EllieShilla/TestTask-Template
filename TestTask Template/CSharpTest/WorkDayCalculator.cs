using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = new DateTime();
            if (weekEnds == null)
                endDate = startDate.AddDays(dayCount - 1);
            else
            {
                foreach (var date in weekEnds)
                {
                    System.TimeSpan diff2 = date.EndDate - date.StartDate;
                    dayCount+= diff2.Days;
                }

                endDate = startDate.AddDays(dayCount);
            }

            return endDate;
        }
    }
}
