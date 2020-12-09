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
        public DbSet<Person> Person { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Interest> Interest { get; set; }

        public DbSet<Address> Address { get; set; }



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
          new Interest { InterestId = 15, InterestType = "Party" },
          new Interest { InterestId = 16, InterestType = "Movie Night" },
          new Interest { InterestId = 17, InterestType = "Pub Crawl" },
          new Interest { InterestId = 18, InterestType = "Tour" }
           );

            builder.Entity<Address>()
           .HasData(
           new Address { AddressId = 101, Venue = "Harley Davidson Museum", Street = "400 W Canal", City = "Milwuakee", State = "WI", ZipCode = 53201, Latitude = 43.03244221967385, Longitude = -87.91667126136444 },
           new Address { AddressId = 102, Venue = "Lake Shore State Park", Street = "500 N Harbor Dr", City = "Milwuakee", State = "WI", ZipCode = 53202, Latitude = 43.03382873576791, Longitude = -87.89557134607516 }
          );
        }

            //builder.Entity<Event>().HasData(
            //    new Event
            //    {
            //        EventId = 133,
            //        PersonId = 1,
            //        EventName = "Tour Harley-Davidson",
            //        AddressId = 101,
            //        InterestId = 18,
            //        EventDate = DateTime.Parse("2020-12-08 7:00:00.000"),
            //        EventDescription = "Be there, loser!",
            //        IsPrivate = false,
            //        IsVirtual = false,
            //    }, new Event
            //    {
            //        EventId = 134,
            //        PersonId = 1,
            //        AddressId = 101,
            //        EventName = "Beer Crawl",
            //        InterestId = 17,
            //        EventDate = DateTime.Parse("2020-12-08 19:00:00.000"),
            //        EventDescription = "Come Drink BEER!!!",
            //        IsPrivate = false,
            //        IsVirtual = false,
            //    });


           

            //builder.Entity<Event>().HasData(
            //    new Event
            //    {
            //        EventId = 135,
            //        PersonId = 1,
            //        AddressId = 102,
            //        EventName = "Movies at the Park",
            //        InterestId = 16,
            //        EventDate = DateTime.Parse("2020-12-12 17:00:00.000"),
            //        EventDescription = "We will be showing 'Back to the Future' parts 1, 2, and 3",
            //        IsPrivate = false,
            //        IsVirtual = false,
            //    }
            //    );


        

       

    }
}
