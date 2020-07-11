using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class PlayerStatRepository
    {
        private readonly ClubContext _appDbContext;

        public PlayerStatRepository(ClubContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<PlayerStat> Stats
        {
            get
            {
                return _appDbContext.PlayerStats;
            }
        }

    }
}
