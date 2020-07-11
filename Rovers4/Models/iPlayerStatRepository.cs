using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public interface IPlayerStatRepository
    {
        IEnumerable<PlayerStat> AllStats { get; }
       
        PlayerStat GetStatsById(int personId);
    }
}
