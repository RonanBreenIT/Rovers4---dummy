using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class PersonStats : Person
    {
        [NotMapped]
        [Display(Name = "Games Played")]
        public bool Played { get; set; }

        [NotMapped]
        public int Assists { get; set; }

        [NotMapped]
        public int Goals { get; set; }

        [NotMapped]
        [Display(Name = "Cleansheets")]
        public bool CleanSheet { get; set; }

        [NotMapped]
        [Display(Name = "Red Cards")]
        public bool RedCards { get; set; }

        [NotMapped]
        [Display(Name = "Man of the Match")]
        public bool MotmAward { get; set; }
    }
}
