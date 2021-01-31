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

        public int GetWinner()
        {
            if (!IsValidResult(result))
            {
                return -1;
            }

            string[] goalsScored = result.Split('-');
            int firstTeamGoals = Convert.ToInt32(goalsScored[0]);
            int secondTeamGoals = Convert.ToInt32(goalsScored[1]);

            if (firstTeamGoals != secondTeamGoals)
            {
                return firstTeamGoals > secondTeamGoals ? 1 : 2;
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

        public bool IsValidResult(string result)
        {
            if (result.IndexOf('-') <= 0 ||
               (result.IndexOf('-') != result.LastIndexOf('-')))
            {
                return false;
            }

            string[] goalsScored = result.Split('-');

            return IsValidGoalNumber(goalsScored[0]) && IsValidGoalNumber(goalsScored[1]);
        }

        public bool IsValidGoalNumber(string goal)
        {
            foreach (char ch in goal.Trim())
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
