using System;
using Xunit;

namespace FootballStandings.Facts
{
    public class TeamFacts
    {
        readonly Team teamOne = new Team("T1", 23);

        [Fact]
        public void CompareByPoints_CompareTwoTeamsWithTheSameNumberOfPoints_ShouldReturnTrue()
        {      
            Team dummy = new Team("Dummy", 23);

            Assert.True(dummy.CompareByPoints(teamOne));
        }

        [Fact]
        public void CompareByPoints_FirstTeamHasMorePointsThanTheSecondOne_ShouldReturnFalse()
        {
            Team dummy = new Team("Dummy", 20);

            Assert.False(dummy.CompareByPoints(teamOne));
        }

        [Fact]
        public void CompareByPoints_SecondTeamHasMorePointsThanTheFirstOne_ShouldReturnTrue()
        {
            Team dummy = new Team("Dummy", 26);

            Assert.True(dummy.CompareByPoints(teamOne));
        }

        [Fact]
        public void AddPoints_InvalidPointsPassed_ShouldNotChangeThePoints()
        {
            Team dummy = new Team("Dummy", 23);

            teamOne.AddPoints(-1);

            Assert.True(dummy.CompareByPoints(teamOne));
        }

        [Fact]
        public void AddPoints_ValidPointsPassed_ShouldUpdateThePoints()
        {
            Team dummy = new Team("Dummy", 26);

            teamOne.AddPoints(3);

            Assert.True(dummy.CompareByPoints(teamOne));
        }
    }
}
