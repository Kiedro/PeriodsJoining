using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PeriodsJoining.UnitTests
{
    public class TimePeriodUtilityTests
    {
        [Fact]
        public void JoinAdjacent_AdjacentPeriods_SinglePeriod()
        {
            var periods = new List<TimePeriod>
            {
                new TimePeriod(new DateTime(2000, 1, 1, 12, 0, 0), new DateTime(2000,1,1,12,30,0)),
                new TimePeriod(new DateTime(2000, 1, 1, 12, 30, 0), new DateTime(2000,1,1,14,0,0))
            };

            var sut = new TimePeriodUtility();

            var result = sut.JoinAdjacent(periods);

            Assert.Equal(1, result.Count());
            Assert.Equal(new DateTime(2000, 1, 1, 12, 0, 0), result.First().Start);
            Assert.Equal(new DateTime(2000, 1, 1, 14, 0, 0), result.First().End);
        }

        [Fact]
        public void JoinAdjacent_AdjacentPeriodsInTwoGroups_TwoPeriod()
        {
            var periods = new List<TimePeriod>
            {
                new TimePeriod(new DateTime(2000, 1, 1, 12, 0, 0), new DateTime(2000,1,1,12,30,0)),
                new TimePeriod(new DateTime(2000, 1, 1, 12, 30, 0), new DateTime(2000,1,1,14,0,0)),

                new TimePeriod(new DateTime(2000, 1, 1, 15, 0, 0), new DateTime(2000,1,1,16,30,0)),
                new TimePeriod(new DateTime(2000, 1, 1, 16, 30, 0), new DateTime(2000,1,1,17,0,0))
            };

            var sut = new TimePeriodUtility();

            var result = sut.JoinAdjacent(periods);

            Assert.Equal(2, result.Count());

            Assert.Equal(new DateTime(2000, 1, 1, 12, 0, 0), result.First().Start);
            Assert.Equal(new DateTime(2000, 1, 1, 14, 0, 0), result.First().End);

            Assert.Equal(new DateTime(2000, 1, 1, 15, 0, 0), result.Last().Start);
            Assert.Equal(new DateTime(2000, 1, 1, 17, 0, 0), result.Last().End);
        }
    }
}
