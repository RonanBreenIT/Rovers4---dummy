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
        int TotalWins(int? teamID);

        int TotalDraws(int? teamID);

        int TotalLosses(int? teamID);

        int GoalsFor(int? teamID);

        int GoalsAgainst(int? teamID);

        //Unit Testing
        Fixture CreateFixture(Fixture fixture);

        Fixture UpdateFixture(Fixture fixture);

        Fixture DeleteFixture(Fixture fixture);

    }
}
