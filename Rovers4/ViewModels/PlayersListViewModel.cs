using Rovers4.Models;
using System.Collections.Generic;

namespace Rovers4.ViewModels
{
    public class PlayersListViewModel
    {
        public IEnumerable<Person> Staff { get; set; }

        public IEnumerable<Person> Mgmt { get; set; }

        public IEnumerable<Person> Goalkeepers { get; set; }
        public IEnumerable<Person> Defenders { get; set; }
        public IEnumerable<Person> Midfielders { get; set; }
        public IEnumerable<Person> Forwards { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public string CurrentTeam { get; set; }

        public int TeamID { get; set; }
    }
}
