using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rovers4.Models
{
    public enum MgmtRole
    {
        Manager,
        Coach,
        [Display(Name = "Goalkeeping Coach")]
        GoalKeeperCoach,
        [Display(Name = "Strength & Conditioning Coach")]
        SandC,
        Physio,
        Kitman
    }

    public enum PlayerPosition
    {
        Goalkeeper, Defender, Midfielder, Forward
    }

    public enum PersonType
    {
        Player, Manager
    }


    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Display(Name = "Type")]
        public PersonType PersonType { get; set; }

        [Display(Name = "Management Role")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public MgmtRole? MgmtRole { get; set; }

        [Display(Name = "Player Position")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public PlayerPosition? PlayerPosition { get; set; }

        [Required]
        [Display(Name = "First Name"), StringLength(40, MinimumLength = 1, ErrorMessage = "First Name cannot be longer than 40 characters or null.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname"), StringLength(40, MinimumLength = 1, ErrorMessage = "Surname cannot be longer than 40 characters or null.")]
        public string Surname { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + Surname;
            }
        }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [DisplayFormat(NullDisplayText = "Null")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Thumbnail Image")]
        public string ThumbnailImage { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Thumbhnail Image")]
        public IFormFile ProfileThumbnailImage { get; set; }

        [NotMapped]
        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Profile Image")]
        public IFormFile ProfileImage { get; set; }

        [Display(Name = "Biography"), StringLength(1280, MinimumLength = 0, ErrorMessage = "Team Bio cannot be longer than 1280 characters")]
        public string PersonBio { get; set; }

        [ForeignKey("TeamID")]
        [Display(Name = "Team")]
        public int TeamID { get; set; }

        public Team Team { get; set; }

        [ForeignKey("PlayerStatID")]
        public int PlayerStatID { get; set; }

        public virtual PlayerStat PlayerStat { get; set; }
    }

}
