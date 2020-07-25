using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rovers4.Data;
using Rovers4.Models;

namespace Rovers4.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> AllStaff { get; }
        IEnumerable<Person> Players { get; }
        IEnumerable<Person> Mgmt { get; }

        IEnumerable<Person> AllGoalkeepers { get; }

        IEnumerable<Person> AllDefenders { get; }

        IEnumerable<Person> AllMidfielders { get; }

        IEnumerable<Person> AllForwards{ get; }

        Person GetPersonById(int personId);

    }
}

