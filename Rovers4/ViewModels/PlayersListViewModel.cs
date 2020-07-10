using Rovers4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.ViewModels
{
    public class PlayersListViewModel
    {
        public IEnumerable<Person> Staff { get; set; }

        public IEnumerable<Team> Teams { get; set; }
        public string CurrentTeam { get; set; }
    }
}
