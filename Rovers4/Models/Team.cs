using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        
        public string Name { get; set; }

        [Display(Name = "Team Biography")]
        public string TeamBio { get; set; }


        [ForeignKey("ClubID")]
        public int ClubID  { get; set; } 

        public virtual Club Club { get; set; }

        public List<Person> Staff { get; set; }

        public List<Fixture> fixtures { get; set; }

    }
}
