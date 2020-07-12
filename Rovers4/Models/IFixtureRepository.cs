using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public interface IFixtureRepository
    {
        IEnumerable<Fixture> AllFixtures { get; }
        Fixture GetFixtureById(int fixtureId);
    }
}
