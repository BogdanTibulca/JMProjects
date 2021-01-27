using System;
using Xunit;

namespace FootballStandings.Facts
{
    public class GameFacts
    {
        Team t1 = new Team("Team One", 24);
        Team t2 = new Team("Team Two", 18);
        [Fact]
        public void GetWinnerGameEndedWithDrawShouldReturnCorrectResult()
        {
            string result = "0 - 0";
            Game game = new Game(t1, t2, result);

            Assert.Equal(0, game.GetWinner());
        }

        [Fact]
        public void GetWinnerFirstTeamWinsShouldReturnCorrectResult()
        {
            string result = "2 - 0";
            Game game = new Game(t1, t2, result);

            Assert.Equal(1, game.GetWinner());
        }

        [Fact]
        public void GetWinnerSecondTeamWinsShouldReturnCorrectResult()
        {
            string result = "2 - 5";
            Game game = new Game(t1, t2, result);

            Assert.Equal(2, game.GetWinner());
        }

        [Fact]
        public void UpdatePointsDrawResultShouldReturnPointsUpdatedByOne()
        {
            string result = "1 - 1";
            Game game = new Game(t1, t2, result);

            Team expectedT1 = new Team("Team One", 25);
            Team expectedT2 = new Team("Team One", 19);

            game.UpdatePoints();

            Assert.True(expectedT1.HasTheSameNumberOfPoints(t1));
            Assert.True(expectedT2.HasTheSameNumberOfPoints(t2));
        }

        [Fact]
        public void UpdatePointsFirstTeamWinsShouldReturnPointsCorrectlyUpdated()
        {
            string result = "2 - 1";
            Game game = new Game(t1, t2, result);

            Team expectedT1 = new Team("Team One", 27);
            Team expectedT2 = new Team("Team One", 18);

            game.UpdatePoints();

            Assert.True(expectedT1.HasTheSameNumberOfPoints(t1));
            Assert.True(expectedT2.HasTheSameNumberOfPoints(t2));
        }

        [Fact]
        public void UpdatePointsSecondTeamWinsShouldReturnPointsCorrectlyUpdated()
        {
            string result = "1 - 2";
            Game game = new Game(t1, t2, result);

            Team expectedT1 = new Team("Team One", 24);
            Team expectedT2 = new Team("Team One", 21);

            game.UpdatePoints();

            Assert.True(expectedT1.HasTheSameNumberOfPoints(t1));
            Assert.True(expectedT2.HasTheSameNumberOfPoints(t2));
        }

        [Fact]
        public void IsValidResultResultIsNotSeparatedByMinusShouldReturnFalse()
        {
            string result = "1 1";
            Game game = new Game(t1, t2, result);

            Assert.False(game.IsValidResult(result));
        }

        [Fact]
        public void IsValidResultResultStartsWithMinusShouldReturnFalse()
        {
            string result = "-1 1";
            Game game = new Game(t1, t2, result);

            Assert.False(game.IsValidResult(result));
        }

        [Fact]
        public void IsValidResultResultHasMoreThanOneMinusShouldReturnFalse()
        {
            string result = "1 -- 1";
            Game game = new Game(t1, t2, result);

            Assert.False(game.IsValidResult(result));
        }

        [Fact]
        public void IsValidResultResultDoesNotAllowsCharactersShouldReturnFalse()
        {
            string result = "a - 1";
            Game game = new Game(t1, t2, result);

            Assert.False(game.IsValidResult(result));
        }
    }
}
