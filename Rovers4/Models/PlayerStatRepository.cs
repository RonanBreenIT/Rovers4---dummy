using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class PlayerStatRepository: IPlayerStatRepository
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
    }
}
