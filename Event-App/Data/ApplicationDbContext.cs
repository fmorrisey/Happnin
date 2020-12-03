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
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Person",
                NormalizedName = "PERSON"
            },
            new IdentityRole
            {
                Name = "Group",
                NormalizedName = "GROUP"
            },
            new IdentityRole
            {
                Name = "Venue",
                NormalizedName = "VENUE"
            }
            ) ;
        }

    }
}
