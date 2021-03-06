﻿using System.Collections.Generic;

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

        IEnumerable<Person> AllForwards { get; }

        Person GetPersonById(int personId);

        // For Unit Testing
        ICollection<Person> GetPeople();

        Person CreatePerson(Person person);

        Person UpdatePerson(Person person);

        Person DeletePerson(Person person);

    }
}

