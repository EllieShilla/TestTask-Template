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
                endDate = startDate.AddDays(dayCount - 1);

                foreach (var date in weekEnds)
                {
                    if (date.StartDate.CompareTo(endDate) < 0 || date.StartDate.CompareTo(endDate) == 0)
                    {
                        System.TimeSpan diff2 = date.EndDate - date.StartDate;
                        endDate = endDate.AddDays(diff2.Days+1);
                    }
                }
            }

            return endDate;
        }
    }
}


