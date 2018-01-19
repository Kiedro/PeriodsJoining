using System.Collections.Generic;
using System.Linq;

namespace PeriodsJoining
{
    public class TimePeriodUtility
    {
        public IEnumerable<TimePeriod> JoinAdjacent(List<TimePeriod> periods)
        {
            var result = periods.Select(x=>new TimePeriod(x.Start,x.End)).ToList();

            for (int j = 0; j < result.Count -1 ; j++)
            {
                if (result[j].End == result[j+1].Start)
                {
                    result[j].End = result[j + 1].End;
                    result.RemoveAt(j+1);
                }
            }

            return result;
        }
    }
}