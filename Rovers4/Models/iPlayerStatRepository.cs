using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public interface iPlayerStatRepository
    {
        IEnumerable<PlayerStat> Stats { get; }
       
        PlayerStat GetStatsById(int personId);
    }
}
