using System;
using Xunit;

namespace FootballStandings.Facts
{
    public class TeamFacts
    {
        readonly Team teamOne = new Team("T1", 23);

        [Fact]
        public void HasTheSameNumberOfPointsCompareTwoTeamsWithTheSameNumberOfPointsShouldReturnTrue()
        {      
            Team dummy = new Team("Dummy", 23);

            Assert.Equal(0 ,dummy.CompareTo(teamOne));
        }

        [Fact]
        public void HasMorePointsThanFirstTeamHasMorePointsThanTheSecondOneShouldReturnFalse()
        {
            Team dummy = new Team("Dummy", 20);

            Assert.Equal(-1, dummy.CompareTo(teamOne));
        }

        [Fact]
        public void HasMorePointsThanSecondTeamHasMorePointsThanTheFirstOneShouldReturnTrue()
        {
            Team dummy = new Team("Dummy", 26);

            Assert.Equal(1, dummy.CompareTo(teamOne));
        }

        [Fact]
        public void IsTheSameTeamComparedWithATeamWithTheSameDetailsShouldReturnTrue()
        {
            Team teamToCompare = new Team("T1", 23);

            Assert.True(teamOne.IsTheSameTeam(teamToCompare));
        }

        [Fact]
        public void AddPointsInvalidPointsPassedShouldNotChangeThePoints()
        {
            Team dummy = new Team("Dummy", 23);

            teamOne.AddPoints(-1);

            Assert.Equal(0, dummy.CompareTo(teamOne));
        }

        [Fact]
        public void AddPointsValidPointsPassedShouldUpdateThePoints()
        {
            Team team = new Team("T", 26);
            Team dummy = new Team("Dummy", 26);

            team.AddPoints(3);

            Assert.Equal(1, team.CompareTo(dummy));
        }
    }
}
