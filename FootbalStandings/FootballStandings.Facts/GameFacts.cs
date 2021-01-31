using System;
using Xunit;

namespace FootballStandings.Facts
{
    public class GameFacts
    {
        Team t1 = new Team("Team One", 24);
        Team t2 = new Team("Team Two", 18);

        [Fact]
        public void UpdatePointsDrawResultShouldReturnPointsUpdatedByOne()
        {
            Game game = new Game(t1, t2, 1, 1);

            game.UpdatePoints();

            Assert.Equal(0, t1.CompareTo(new Team("Team One", 25)));
            Assert.Equal(0, t2.CompareTo(new Team("Team Two", 19)));
        }

        [Fact]
        public void UpdatePointsFirstTeamWinsShouldReturnPointsCorrectlyUpdated()
        {
            Game game = new Game(t1, t2, 2, 1);

            game.UpdatePoints();

            Assert.Equal(0, t1.CompareTo(new Team("Team One", 27)));
            Assert.Equal(0, t2.CompareTo(new Team("Team Two", 18)));
        }

        [Fact]
        public void UpdatePointsSecondTeamWinsShouldReturnPointsCorrectlyUpdated()
        {
            Game game = new Game(t1, t2, 1, 2);

            game.UpdatePoints();

            Assert.Equal(0, t1.CompareTo(new Team("Team One", 24)));
            Assert.Equal(0, t2.CompareTo(new Team("Team Two", 21)));
        }
    }
}
