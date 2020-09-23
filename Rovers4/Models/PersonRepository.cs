using Rovers4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class PersonRepository: IPersonRepository
    {
        private readonly ClubContext _appDbContext;

        public PersonRepository(ClubContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Person> AllStaff
        {
            get
            {
                return _appDbContext.Persons;
            }
        }

        public IEnumerable<Person> Players
        {
            get
            {
                return _appDbContext.Persons.Where(p => p.PersonType == PersonType.Player);
            }
        }

        public IEnumerable<Person> Mgmt
        {
            get
            {
                return _appDbContext.Persons.Where(p => p.PersonType == PersonType.Manager);
            }
        }

        public IEnumerable<Person> AllGoalkeepers
        {
            get
            {
                return _appDbContext.Persons.Where(p => p.PersonType == PersonType.Player).Where(s => s.PlayerPosition == PlayerPosition.Goalkeeper);
            }

        }

        public IEnumerable<Person> AllDefenders
        {
            get
            {
                return _appDbContext.Persons.Where(p => p.PersonType == PersonType.Player).Where(s => s.PlayerPosition == PlayerPosition.Defender);
            }

        }

        public IEnumerable<Person> AllMidfielders
        {
            get
            {
                return _appDbContext.Persons.Where(p => p.PersonType == PersonType.Player).Where(s => s.PlayerPosition == PlayerPosition.Midfielder);
            }

        }

        public IEnumerable<Person> AllForwards
        {
            get
            {
                return _appDbContext.Persons.Where(p => p.PersonType == PersonType.Player).Where(s => s.PlayerPosition == PlayerPosition.Forward);
            }

        }

        public Person GetPersonById(int personId)
        {
            return _appDbContext.Persons.FirstOrDefault(p => p.PersonID == personId);
        }

        //Unit Testing
        public ICollection<Person> GetPeople()
        {
            return _appDbContext.Persons.ToList();
        }

        public Person CreatePerson(Person person)
        {
            _appDbContext.Persons.Add(person);
            _appDbContext.SaveChanges();
            return person;
        }

        public Person UpdatePerson(Person person)
        {
            var foundPerson = _appDbContext.Persons.FirstOrDefault(i => i.PersonID == person.PersonID);
            foundPerson.FirstName = person.FirstName;
            foundPerson.Surname = person.Surname;
            _appDbContext.Persons.Update(foundPerson);
            _appDbContext.SaveChanges();
            return foundPerson;
        }

        public Person DeletePerson(Person person)
        {
            var foundPerson = _appDbContext.Persons.FirstOrDefault(i => i.PersonID == person.PersonID);
            _appDbContext.Persons.Remove(foundPerson);
            _appDbContext.SaveChanges();
            return foundPerson;
        }  
    }
}
