using System;

namespace FootballStandings.Facts
{
    class Game
    {
        private const int WinnerPoints = 3;
        private const int DrawPoints = 1;
        private const int LoserPoints = 0;

        readonly Team homeTeam;
        readonly Team visitorTeam;

        readonly int homeTeamGoals;
        readonly int visitorTeamGoals;

        public Game(Team homeTeam, Team visitorTeam, int homeTeamGoals, int visitorTeamGoals)
        {
            this.homeTeam = homeTeam;
            this.visitorTeam = visitorTeam;
            this.homeTeamGoals = homeTeamGoals;
            this.visitorTeamGoals = visitorTeamGoals;
        }

        private int GetWinner()
        {
            if (this.homeTeamGoals != this.visitorTeamGoals)
            {
                return this.homeTeamGoals > this.visitorTeamGoals ? 1 : 2;
            }

            return 0;
        }

        public void UpdatePoints()
        {
            switch (GetWinner())
            {
                case 0:
                    homeTeam.AddPoints(DrawPoints);
                    visitorTeam.AddPoints(DrawPoints);
                    break;
                case 1:
                    homeTeam.AddPoints(WinnerPoints);
                    visitorTeam.AddPoints(LoserPoints);
                    break;
                case 2:
                    homeTeam.AddPoints(LoserPoints);
                    visitorTeam.AddPoints(WinnerPoints);
                    return;
            }
        }
    }
}
