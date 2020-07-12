using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class FixtureRepository: IFixtureRepository
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
                return _appDbContext.Fixtures;
            }
        }

        public Fixture GetFixtureById(int fixtureId)
        {
            return _appDbContext.Fixtures.FirstOrDefault(p => p.FixtureID == fixtureId);
        }
    }
}
