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
            DateTime endDate = startDate;

            if (weekEnds == null)
                endDate = endDate.AddDays(dayCount - 1);
            else
            {
                foreach (var day in weekEnds)
                {
                    if (day.StartDate.CompareTo(endDate) > 0)             
                    {
                        System.TimeSpan diff2 = day.StartDate - endDate; 
                        if (dayCount - diff2.Days > 0)
                        {
                            dayCount -= diff2.Days;
                            endDate = endDate.AddDays(diff2.Days);
                        }
                        else
                        {
                            endDate = endDate.AddDays(dayCount);
                            dayCount = 0;
                        }
                    }

                    if (day.StartDate.CompareTo(endDate) == 0 && dayCount > 0)                 
                    {
                        System.TimeSpan diff2 = day.EndDate - day.StartDate;

                        if (diff2.Days == 0)
                            endDate = endDate.AddDays(1);
                        else
                            endDate = endDate.AddDays(diff2.Days);
                    }
                    else if (day.EndDate.CompareTo(endDate) >= 0 && dayCount > 0)  
                    {
                        System.TimeSpan diff2 = day.EndDate - endDate;
                        endDate = endDate.AddDays(diff2.Days);
                    }

                    if (dayCount == 0)
                        break;
                }

                if (dayCount > 0)
                    endDate = endDate.AddDays(dayCount);
            }

            return endDate;
        }

    }
}