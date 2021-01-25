using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStandings.Facts
{
    class Team
    {
        private readonly string name;
        private int points;

        public Team (string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool CompareByPoints(Team anotherTeam)
        {
            return this.points >= anotherTeam.points;
        }

        public void AddPoints(int pointsToAdd)
        {
            if (pointsToAdd < 0)
            {
                return;
            }

            this.points += pointsToAdd;
        }
    }
}
