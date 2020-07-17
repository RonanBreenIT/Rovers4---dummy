using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public interface IFixtureRepository
    {
        IEnumerable<Fixture> AllFixtures { get; }
        IEnumerable<Fixture> JanuaryFixtures { get; }
        IEnumerable<Fixture> FebruaryFixtures { get; }
        IEnumerable<Fixture> MarchFixtures { get; }
        IEnumerable<Fixture> AprilFixtures { get; }
        IEnumerable<Fixture> MayFixtures { get; }
        IEnumerable<Fixture> JuneFixtures { get; }
        IEnumerable<Fixture> JulyFixtures { get; }
        IEnumerable<Fixture> AugustFixtures { get; }
        IEnumerable<Fixture> SeptemberFixtures { get; }
        IEnumerable<Fixture> OctoberFixtures { get; }
        IEnumerable<Fixture> NovemberFixtures { get; }
        IEnumerable<Fixture> DecemberFixtures { get; }

    }
}
