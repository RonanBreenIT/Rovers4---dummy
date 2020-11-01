using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rovers4.Models
{
    [NotMapped]
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
