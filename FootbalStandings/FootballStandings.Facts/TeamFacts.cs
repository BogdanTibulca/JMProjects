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

            Assert.True(dummy.HasTheSameNumberOfPoints(teamOne));
        }

        [Fact]
        public void HasMorePointsThanFirstTeamHasMorePointsThanTheSecondOneShouldReturnFalse()
        {
            Team dummy = new Team("Dummy", 20);

            Assert.False(dummy.HasMorePointsThan(teamOne));
        }

        [Fact]
        public void HasMorePointsThanSecondTeamHasMorePointsThanTheFirstOneShouldReturnTrue()
        {
            Team dummy = new Team("Dummy", 26);

            Assert.True(dummy.HasMorePointsThan(teamOne));
        }

        [Fact]
        public void HasTheSameNameComparedWithATeamWithTheSameNameShouldReturnTrue()
        {
            Team teamToCompare = new Team("T1", 26);

            Assert.True(teamOne.HasTheSameName(teamToCompare));
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

            Assert.True(dummy.HasTheSameNumberOfPoints(teamOne));
        }

        [Fact]
        public void AddPointsValidPointsPassedShouldUpdateThePoints()
        {
            Team team = new Team("T", 26);
            Team dummy = new Team("Dummy", 26);

            team.AddPoints(3);

            Assert.True(team.HasMorePointsThan(dummy));
        }
    }
}
