using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    //public enum Grade
    //{
    //    [Display(Name = "First Team")]
    //    FirstTeam,
    //    [Display(Name = "Under 21s")]
    //    U21,
    //    [Display(Name = "Under 19s")]
    //    U19,
    //    [Display(Name = "Under 17s")]
    //    U17,
    //    [Display(Name = "Under 15s")]
    //    U15,
    //    [Display(Name = "Under 13s")]
    //    U13,
    //    [Display(Name = "Under 11s")]
    //    U11
    //}
    public class Team
    {
        //[Key]
        //public int Name { get; set; }

        //[Display(Name = "Team")]
        //public Grade Grade { get; set; }

        [Key]
        public string Name { get; set; }

     
        [ForeignKey("ClubID")]
        public int ClubID  { get; set; } // Do I need to add the ID also - good to find out

        public virtual Club Club { get; set; }

        public List<Person> Staff { get; set; }

        //[ForeignKey("PersonID")]
        //public int PersonID { get; set; }

        //public virtual ICollection<Person> Person { get; set; }

        //private List<Person> persons = null;

        //List<Person> Persons
        //{
        //    get
        //    {
        //        if (persons == null)
        //        {
        //            return persons = new List<Person>();
        //        }
        //        return persons;
        //    }
        //}



        //[ForeignKey("FixtureID")]
        //public int fixtureID { get; set; }

        public List<Fixture> fixtures { get; set; }

        //private List<Fixture> fixtures = null;

        //List<Fixture> Fixtures
        //{
        //    get
        //    {
        //        if (fixtures == null)
        //        {
        //            return fixtures = new List<Fixture>();
        //        }
        //        return fixtures;
        //    }
        //}

    }
}
