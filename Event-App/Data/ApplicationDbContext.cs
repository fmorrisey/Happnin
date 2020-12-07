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

        //public DbSet<Interest>Interests { get; set; }
        //public DbSet<Event> Events { get; set; }
        //public DbSet<Person>People { get; set; }

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
                new Interest {InterestId =1,InterestType ="Music" },
                new Interest { InterestId = 2, InterestType = "Sports" },
                new Interest { InterestId = 3, InterestType = "Food" },
                 new Interest { InterestId = 4, InterestType = "Party" }
                );
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
