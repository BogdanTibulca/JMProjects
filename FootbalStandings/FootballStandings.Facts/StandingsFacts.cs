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

            Team[] expected = { new Team("Team One", 33) };

            standings.SortTeamsByPoints(teams);

            Assert.True(teams[0].IsTheSameTeam(expected[0]));
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

            Team[] expected = { new Team("Team One", 33),
                                new Team("Team Two", 20) };

            standings.SortTeamsByPoints(teams);

            Assert.True(teams[0].IsTheSameTeam(expected[0]));
            Assert.True(teams[1].IsTheSameTeam(expected[1]));
        }

        [Fact]
        public void SortTeamsByPointsStandingsWithTwoTeamsNotSortedShouldUpdateTheStandings()
        {
            Team[] teams = { new Team("Team Two", 20),
                            new Team("Team One", 33) };
            Standings standings = new Standings(teams);

            Team[] expected = { new Team("Team One", 33),
                                new Team("Team Two", 20) };

            standings.SortTeamsByPoints(teams);

            Assert.True(teams[0].IsTheSameTeam(expected[0]));
            Assert.True(teams[1].IsTheSameTeam(expected[1]));
        }

        [Fact]
        public void SortTeamsByPointsStandingsWithMultipleTeamsShouldUpdateTheStandings()
        {
            Standings standings = new Standings(dummyTeams);

            Team[] expected = { new Team("Team One", 33),
                                new Team("Team Four", 33),
                                new Team("Team Three", 29),
                                new Team("Team Two", 20) };

            standings.SortTeamsByPoints(dummyTeams);

            Assert.True(dummyTeams[0].IsTheSameTeam(expected[0]));
            Assert.True(dummyTeams[1].IsTheSameTeam(expected[1]));
            Assert.True(dummyTeams[2].IsTheSameTeam(expected[2]));
            Assert.True(dummyTeams[3].IsTheSameTeam(expected[3]));
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
