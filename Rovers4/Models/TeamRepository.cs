using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rovers4.Data;

namespace Rovers4.Models
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ClubContext _appDbContext;

        public TeamRepository(ClubContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Team> Teams => _appDbContext.Teams;
    }
}
