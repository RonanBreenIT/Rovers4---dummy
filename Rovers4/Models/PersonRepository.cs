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

        public Person GetPersonById(int personId)
        {
            return _appDbContext.Persons.FirstOrDefault(p => p.PersonID == personId);
        }
    }
}
