﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public string Mobile { get; set; }

        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        [Display(Name = "Thumbnail Image")]
        public string ThumbnailImage { get; set; }

        [DisplayFormat(NullDisplayText = "No Image")]
        public string Image { get; set; }

        [Display(Name = "Biography")]
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
