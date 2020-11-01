using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rovers4.Models;

namespace Rovers4.Data
{
    public class ClubContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<PlayerStat> PlayerStats { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }

        public DbSet<Person> Persons { get; set; }

        public ClubContext(DbContextOptions<ClubContext> options)
            : base(options)
        {
        }
    }
}