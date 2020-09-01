using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class FixtureRepository : IFixtureRepository
    {
        private readonly ClubContext _appDbContext;

        public FixtureRepository(ClubContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Fixture> AllFixtures
        {
            get
            {
              return _appDbContext.Fixtures.Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> JanuaryFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 1).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> FebruaryFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 2).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> MarchFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 3).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> AprilFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 4).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> MayFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 5).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> JuneFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 6).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> JulyFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 7).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> AugustFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 8).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> SeptemberFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 9).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> OctoberFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 10).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> NovemberFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 11).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        public IEnumerable<Fixture> DecemberFixtures
        {
            get
            {
                return _appDbContext.Fixtures.Where(f => f.FixtureDate.Month == 12).Where(s => s.FixtureType != FixtureType.Training);
            }
        }

        

        public int TotalWins(int? teamID)
        {
            int wins = 0;
            foreach (var item in _appDbContext.Fixtures.Where(t => t.TeamID == teamID).Where(s => s.ResultDescription == ResultDescription.Win))
            {
                wins += 1;
            }
            return wins;
        }

        public int TotalDraws(int? teamID)
        {
            int draws = 0;
            foreach (var item in _appDbContext.Fixtures.Where(t => t.TeamID == teamID).Where(s => s.ResultDescription == ResultDescription.Draw))
            {
                draws += 1;
            }
            return draws;
        }

        public int TotalLosses(int? teamID)
        {
            int losses = 0;
            foreach (var item in _appDbContext.Fixtures.Where(t => t.TeamID == teamID).Where(s => s.ResultDescription == ResultDescription.Loss))
            {
                losses += 1;
            }
            return losses;
        }

        public int GoalsAgainst(int? teamID)
        {
            int against = 0;
            foreach (var item in _appDbContext.Fixtures.Where(t => t.TeamID == teamID))
            {
                against += item.OpponentScore.GetValueOrDefault();
            }
            return against;
        }

        public int GoalsFor(int? teamID)
        {
            int goalsfor = 0;
            foreach (var item in _appDbContext.Fixtures.Where(t => t.TeamID == teamID))
            {
                goalsfor += item.OurScore.GetValueOrDefault();
            }
            return goalsfor;
        }

        

    }
}
