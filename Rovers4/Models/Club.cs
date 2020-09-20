using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Club Number"), StringLength(20, MinimumLength = 1, ErrorMessage = "Contact Number cannot be longer than 20 characters or null.")]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        public string ClubImage1 { get; set; }

        [NotMapped]
        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Club Image 1")]
        public IFormFile ClubImageFile1 { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        public string ClubImage2 { get; set; }

        [NotMapped]
        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Club Image 2")]
        public IFormFile ClubImageFile2 { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        public string ClubImage3 { get; set; }

        [NotMapped]
        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Club Image 3")]
        public IFormFile ClubImageFile3 { get; set; }

    }
}
