using System.Collections.Generic;

namespace Rovers4.Models
{
    public interface IPlayerStatRepository
    {
        IEnumerable<PlayerStat> AllStats { get; }

        PlayerStat GetStatsById(int personId);

        public void AddPlayerStats(int personID)
        {
        }

        public void UpdatePlayerStats(int personID, bool played, int assists, int goals, bool cleansheet, bool redcard, bool motm)
        {
        }
    }
}
