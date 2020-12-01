using Microsoft.AspNetCore.Identity;
using System;

namespace Rovers4.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Birthdate { get; set; }
    }
}
