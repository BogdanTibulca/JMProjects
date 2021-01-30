using System;

namespace FootballStandings.Facts
{
    class Standings
    {
        Team[] teams;

        public Standings(Team[] teams)
        {
            this.teams = teams;
            UpdateStandings();
        }

        public Team GetTeamByRanking(int rank)
        {
            return (rank < 1 || rank >= this.teams.Length) ? null : teams[rank - 1];
        }

        public string GetTeamRanking(Team teamToFind)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].HasTheSameName(teamToFind))
                {
                    return (i + 1).ToString();
                }
            }

            return string.Format("The team {0} is not in the standings", teamToFind);
        }

        public Team[] AddTeamInStandings(Team[] teamsToAdd)
        {
            if (teamsToAdd.Length == 0)
            {
                return teams;
            }

            int lastElement = this.teams.Length;

            Array.Resize(ref this.teams, this.teams.Length + teamsToAdd.Length);
            Array.Copy(teamsToAdd, 0, this.teams, lastElement, teamsToAdd.Length);

            UpdateStandings();

            return teams;
        }

        public void SortTeamsByPoints(Team[] teams)
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

        public void UpdateStandings()
        {
            SortTeamsByPoints(this.teams);
        }
    }
}
