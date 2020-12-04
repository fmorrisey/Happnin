using Event_App.Models.Calendar;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
            builder.Entity<Day>()
              .HasData(
              new Day
              {
                  Id = 0,
                  WeekDay = "Sunday"
              },
              new Day
              {
                  Id = 1,
                  WeekDay = "Monday"
              }, new Day
              {
                  Id = 2,
                  WeekDay = "Tuesday"
              }, new Day
              {
                  Id = 3,
                  WeekDay = "Wednesday"
              }, new Day
              {
                  Id = 4,
                  WeekDay = "Thursday"
              }, new Day
              {
                  Id = 5,
                  WeekDay = "Friday"
              },
              new Day
              {
                  Id = 6,
                  WeekDay = "Saturday"
              });

        }

    }
}
