using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rovers4.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        [Display(Name = "Team Name"), StringLength(80, MinimumLength = 1, ErrorMessage = "Team Name cannot be longer than 80 characters or null.")]
        public string Name { get; set; }

        [Display(Name = "Team Biography"), StringLength(2000, MinimumLength = 0, ErrorMessage = "Team Bio cannot be longer than 2000 characters")]
        public string TeamBio { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        public string TeamImage { get; set; }

        [NotMapped]
        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Team Image")]
        public IFormFile TeamImageFile { get; set; }


        [ForeignKey("ClubID")]
        public int ClubID { get; set; }

        public virtual Club Club { get; set; }

        public List<Person> Staff { get; set; }

        public List<Fixture> fixtures { get; set; }

    }
}
