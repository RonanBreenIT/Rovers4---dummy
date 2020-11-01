using Rovers4.Data;
using System.Collections.Generic;
using System.Linq;

namespace Rovers4.Models
{
    public class PlayerStatRepository : IPlayerStatRepository
    {
        private readonly ClubContext _appDbContext;

        public PlayerStatRepository(ClubContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<PlayerStat> AllStats => _appDbContext.PlayerStats;

        public PlayerStat GetStatsById(int personId)
        {
            return _appDbContext.PlayerStats.FirstOrDefault(p => p.PersonID == personId);
        }

        public void AddPlayerStats(int PersonID)
        {
            PlayerStat newPlayer = new PlayerStat
            {
                PersonID = PersonID,
                GamesPlayed = 0,
                Assists = 0,
                Goals = 0,
                CleanSheet = 0,
                RedCards = 0,
                MotmAward = 0
            };

            _appDbContext.PlayerStats.Add(newPlayer);
            _appDbContext.SaveChanges();
        }

        public void UpdatePlayerStats(int personID, bool played, int assists, int goals, bool cleansheet, bool redcard, bool motm)
        {
            // Amended Create player to always create a new PlayerStat with same PersonID
            var player = _appDbContext.PlayerStats.FirstOrDefault(i => i.PersonID == personID);

            if (player != null)
            {
                player.PersonID = personID;
                player.Assists += assists;
                player.Goals += goals;
                if (played)
                {
                    player.GamesPlayed += 1;
                }
                if (cleansheet)
                {
                    player.CleanSheet += 1;
                }
                if (redcard)
                {
                    player.RedCards += 1;
                }
                if (motm)
                {
                    player.MotmAward += 1;
                }

                _appDbContext.PlayerStats.Update(player);
                _appDbContext.SaveChanges();
            }
        }
    }
}
