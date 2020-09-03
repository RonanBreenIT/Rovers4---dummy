using Rovers4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.ViewModels
{
    public class FixtureListViewModel
    {
        public IEnumerable<Fixture> Fixtures { get; set; }
        public IEnumerable<Person> Staff { get; set; }
        public IEnumerable<PlayerStat> Stats { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public string CurrentTeam { get; set; }
        public IEnumerable<Fixture> JanuaryFixtures { get; set; }
        public IEnumerable<Fixture> FebruaryFixtures { get; set; }
        public IEnumerable<Fixture> MarchFixtures { get; set; }
        public IEnumerable<Fixture> AprilFixtures { get; set; }
        public IEnumerable<Fixture> MayFixtures { get; set; }
        public IEnumerable<Fixture> JuneFixtures { get; set; }
        public IEnumerable<Fixture> JulyFixtures { get; set; }
        public IEnumerable<Fixture> AugustFixtures { get; set; }
        public IEnumerable<Fixture> SeptemberFixtures { get; set; }
        public IEnumerable<Fixture> OctoberFixtures { get; set; }
        public IEnumerable<Fixture> NovemberFixtures { get; set; }
        public IEnumerable<Fixture> DecemberFixtures { get; set; }

        public int TotalWins { get; set; }

        public int TotalDraws { get; set; }

        public int TotalLosses { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int GamesPlayed { get; set; }
    }
}
