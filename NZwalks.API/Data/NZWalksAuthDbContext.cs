using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {

        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleID = "8db6b252-8cfe-4edf-ab06-97758cb0ef50";
            var writeRoleID = "7a1177a7-adfb-4cf7-8a24-ba2b8a61a575";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleID,
                    ConcurrencyStamp = readerRoleID,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                 new IdentityRole
                 {
                     Id = writeRoleID,
                     ConcurrencyStamp = writeRoleID,
                     Name = "Writer",
                     NormalizedName = "Writer".ToUpper()
                 },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
