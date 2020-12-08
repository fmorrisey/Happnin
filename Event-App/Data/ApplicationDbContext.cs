using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Event_App.Models;

namespace Event_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Person",
                NormalizedName = "PERSON"
            }
            );

            builder.Entity<Interest>()
           .HasData(
           new Interest { InterestId = 1, InterestType = "Basketball" },
           new Interest { InterestId = 2, InterestType = "Football" },
           new Interest { InterestId = 3, InterestType = "Soccer" },
           new Interest { InterestId = 4, InterestType = "Cycling" },
           new Interest { InterestId = 5, InterestType = "Rock Climbing" },
           new Interest { InterestId = 6, InterestType = "Baseball" },
           new Interest { InterestId = 7, InterestType = "Yoga" },
           new Interest { InterestId = 8, InterestType = "Baking" },
           new Interest { InterestId = 9, InterestType = "Game Night" },
           new Interest { InterestId = 10, InterestType = "Trivia" },
           new Interest { InterestId = 11, InterestType = "Crochete" },
           new Interest { InterestId = 12, InterestType = "Music" },
           new Interest { InterestId = 13, InterestType = "Networking" },
           new Interest { InterestId = 14, InterestType = "Sky Diving" },
           new Interest { InterestId = 15, InterestType = "Party" }
            );
        }




        public DbSet<Person> Person { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Interest> Interest { get; set; }

        public DbSet<Address> Address { get; set; }

    }
}
