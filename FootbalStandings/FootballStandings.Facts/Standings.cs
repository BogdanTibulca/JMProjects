using System;

namespace FootballStandings.Facts
{
    class Standings
    {
        Team[] teams;

        public Standings(Team[] teams)
        {
            this.teams = teams;

            SortTeamsByPoints(this.teams);
        }

        public Team GetTeamByRanking(int rank)
        {
            return (rank < 1 || rank >= this.teams.Length) ? null : teams[rank - 1];
        }

        public int GetTeamRanking(Team teamToFind)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsTheSameTeam(teamToFind))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void AddTeam(Team teamToAdd)
        {
            Team[] newTeams = new Team[this.teams.Length + 1];
            
            Array.Copy(this.teams, newTeams, this.teams.Length);
            newTeams[^1] = teamToAdd;

            SortTeamsByPoints(newTeams);

            this.teams = newTeams;
        }

        private void SortTeamsByPoints(Team[] teams)
        {
            for (int i = 1; i < teams.Length; ++i)
            {
                Team key = teams[i];
                int j = i - 1;

                while (j >= 0 && key.CompareTo(teams[j]) == 1)
                {
                    teams[j + 1] = teams[j];
                    j--;
                }

                teams[j + 1] = key;
            }
        }

        public void Update(Game game)
        {
            game.UpdatePoints();
            SortTeamsByPoints(this.teams);
        }
    }
}
