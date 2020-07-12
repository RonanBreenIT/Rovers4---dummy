using Rovers4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.ViewModels
{
    public class PlayerStatsViewModel
    {
        public Person Person { get; set; }

        public IEnumerable<Person> Staff { get; set; }
        public IEnumerable<PlayerStat> Stats { get; set; }

        public string CurrentPlayer { get; set; }
    }
}
