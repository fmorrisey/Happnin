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
            builder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 133,
                    IdentityUserId = "1",
                    EventName = "Tour Harley-Davidson",
                    InterestId = 2,
                    EventDate = DateTime.Parse("2020-12-08 7:00:00.000"),
                    EventDescription = "Be there, loser!",
                    IsPrivate = false,
                    IsVirtual = false,
                },
                new Event
                {
                    EventId = 134,
                    IdentityUserId = "1",
                    EventName = "Beer Crawl",
                    InterestId = 2,
                    EventDate = DateTime.Parse("2020-12-08 19:00:00.000"),
                    EventDescription = "Come Drink BEER!!!",
                    IsPrivate = false,
                    IsVirtual = false,
                },
                new Event
                {
                    EventId = 135,
                    IdentityUserId = "1",
                    EventName = "Movies at the Park",
                    InterestId = 1,
                    EventDate = DateTime.Parse("2020-12-12 17:00:00.000"),
                    EventDescription = "We will be showing 'Back to the Future' parts 1, 2, and 3",
                    IsPrivate = false,
                    IsVirtual = false,
                },
                new Event
                {
                    EventId = 136,
                    IdentityUserId = "1",
                    EventName = "Bowling with the Oldies",
                    InterestId = 3,
                    EventDate = DateTime.Parse("2020-12-11 21:00:00.000"),
                    EventDescription = "Come bowling with us while we listen to all the best tunes of the 80s",
                    IsPrivate = false,
                    IsVirtual = false,
                });

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
           new Interest { InterestId = 14, InterestType = "Sky Diving" }
            );
        }



        public DbSet<Event_App.Models.Person> Person { get; set; }

        public DbSet<Event_App.Models.Event> Event { get; set; }

        public DbSet<Event_App.Models.Interest> Interest { get; set; }

    }
}
