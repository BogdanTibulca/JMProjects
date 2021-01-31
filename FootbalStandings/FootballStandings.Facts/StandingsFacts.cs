using System;
using Xunit;

namespace FootballStandings.Facts
{
    public class StandingsFacts
    {
        readonly Team[] dummyTeams =
        {
            new Team("Team Two", 20),
            new Team("Team One", 33),
            new Team("Team Three", 29),
            new Team("Team Four", 33)
        };

        [Fact]
        public void SortTeamsByPointsStandingsWithOneTeamShouldNotChangeTheStandings()
        {
            Team[] teams = { new Team("Team One", 33) };
            Standings standings = new Standings(teams);

            Team teamToFind = new Team("Team One", 33);

            Assert.Equal(1, standings.GetTeamRanking(teamToFind));
        }

        [Fact]
        public void SortTeamsByPointsStandingsWithTwoTeamsAlreadySortedShouldNotChangeTheStandings()
        {
            Team[] teams =
            {
                new Team("Team One", 33),
                new Team("Team Two", 20)
            };
            Standings standings = new Standings(teams);

            Team teamOne = new Team("Team One", 33);
            Team teamTwo = new Team("Team Two", 20);

            Assert.Equal(1, standings.GetTeamRanking(teamOne));
            Assert.Equal(2, standings.GetTeamRanking(teamTwo));
        }

        [Fact]
        public void SortTeamsByPointsStandingsWithTwoTeamsNotSortedShouldUpdateTheStandings()
        {
            Team[] teams = { new Team("Team Two", 20),
                            new Team("Team One", 33) };
            Standings standings = new Standings(teams);

            Team teamOne = new Team("Team One", 33);
            Team teamTwo = new Team("Team Two", 20);

            Assert.Equal(1, standings.GetTeamRanking(teamOne));
            Assert.Equal(2, standings.GetTeamRanking(teamTwo));
        }

        [Fact]
        public void SortTeamsByPointsStandingsWithMultipleTeamsShouldUpdateTheStandings()
        {
            Standings standings = new Standings(dummyTeams);

            Team teamOne = new Team("Team One", 33);
            Team teamFour = new Team("Team Four", 33);
            Team teamThree = new Team("Team Three", 29);
            Team teamTwo = new Team("Team Two", 20);

            Assert.Equal(1, standings.GetTeamRanking(teamOne));
            Assert.Equal(2, standings.GetTeamRanking(teamFour));
            Assert.Equal(3, standings.GetTeamRanking(teamThree));
            Assert.Equal(4, standings.GetTeamRanking(teamTwo));
        }

        [Fact]
        public void GetTeamByRankingInvalidRankingShouldReturnNull()
        {
            Standings standings = new Standings(dummyTeams);

            Assert.Null(standings.GetTeamByRanking(0));
        }

        [Fact]
        public void GetTeamByRankingValiddRankingShouldReturnTheCorrectTeam()
        {
            Standings standings = new Standings(dummyTeams);
            Team expected = new Team("Team One", 33);

            Team result = standings.GetTeamByRanking(1);

            Assert.True(expected.IsTheSameTeam(result));
        }

        [Fact]
        public void AddTeamAddingANewTeamShouldReturnUpdatedStandings()
        {
            Team[] teams = { new Team("Test", 22) };
            Standings standings = new Standings(teams);

            Team teamToAdd = new Team("Team Extra", 35);
            standings.AddTeam(teamToAdd);

            Assert.Equal(1, standings.GetTeamRanking(teamToAdd));
        }

        [Fact]
        public void AddTeamAddingTwoNewTeamShouldReturnUpdatedStandings()
        {
            Team[] teams = { new Team("Test", 22) };
            Standings standings = new Standings(teams);

            Team teamOneToAdd = new Team("Team Extra", 35);
            Team teamTwoToAdd = new Team("Another One");

            standings.AddTeam(teamOneToAdd);
            standings.AddTeam(teamTwoToAdd);

            Assert.Equal(1, standings.GetTeamRanking(teamOneToAdd));
            Assert.Equal(3, standings.GetTeamRanking(teamTwoToAdd));
        }

        [Fact]
        public void GetTeamRankingTeamDoesNotExistInStandingsShouldReturnInvalidMessage()
        {
            Standings standings = new Standings(dummyTeams);

            Team teamToFind = new Team("Not here");

            Assert.Equal(-1, standings.GetTeamRanking(teamToFind));
        }

        [Fact]
        public void GetTeamRankingTeamExistsInStandingsShouldReturnTheCorrectPosition()
        {
            Standings standings = new Standings(dummyTeams);

            Team teamToFind = new Team("Team One", 33);

            Assert.Equal(1, standings.GetTeamRanking(teamToFind));
        }
    }
}
