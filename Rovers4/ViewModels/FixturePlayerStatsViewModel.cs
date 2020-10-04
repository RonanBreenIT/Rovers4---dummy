using Rovers4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.ViewModels
{
    public class FixturePlayerStatsViewModel
    {
        public int TeamID { get; set; }
        public Team Team { get; set; }
        public int FixtureID { get; set; }
        public Fixture Fixture { get; set; }
        public int PersonID { get; set; }
        public List<PersonStats> Players { get; set; }
    }
}
