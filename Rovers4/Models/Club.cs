using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rovers4.Models
{
    public class Club
    {
        [Key]
        public int ClubID { get; set; }

        [Required]
        [Display(Name = "Club Name"), StringLength(80, MinimumLength = 1, ErrorMessage = "Club Name cannot be longer than 80 characters or null.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Club Address"), StringLength(255, MinimumLength = 1, ErrorMessage = "Club Address cannot be longer than 255 characters or null.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Club Number"), StringLength(20, MinimumLength = 1, ErrorMessage = "Contact Number cannot be longer than 20 characters or null.")]
        public string Number { get; set; }

        //public int TeamID { get; set; }

        private List<Team> teamList = null;

        List<Team> TeamList  // Confirm this
        {
            get
            {
                if (teamList == null)
                {
                    return teamList = new List<Team>();
                }
                return teamList;
            }
        }
            
    }
}
