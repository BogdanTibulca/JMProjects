namespace FootballStandings.Facts
{
    class Team
    {
        private readonly string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public Team(string name)
        {
            this.name = name;
            this.points = 0;
        }

        public bool HasMorePointsThan(Team anotherTeam)
        {
            return this.points > anotherTeam.points;
        }

        public bool HasTheSameNumberOfPoints(Team anotherTeam)
        {
            return this.points == anotherTeam.points;
        }

        public bool HasTheSameName(Team anotherTeam)
        {
            return this.name.Equals(anotherTeam.name);
        }

        public bool IsTheSameTeam(Team anotherTeam)
        {
            return this.name.Equals(anotherTeam.name) &&
                   this.points == anotherTeam.points;
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
