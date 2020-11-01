using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{  
    public class PlayerStat
    {
        [Key]
        public int PlayerStatID { get; set; }

        [Display(Name = "Games Played")]
        public int GamesPlayed { get; set; }

        public int Assists { get; set; }
        public int Goals { get; set; }

        [Display(Name = "Cleansheets")]
        public int CleanSheet { get; set; }

        [Display(Name = "Red Cards")]
        public int RedCards { get; set; }


        [Display(Name = "Man of the Match")]
        public int MotmAward { get; set; }

        [ForeignKey("PersonID")]
        public int PersonID { get; set; }


    }
}
