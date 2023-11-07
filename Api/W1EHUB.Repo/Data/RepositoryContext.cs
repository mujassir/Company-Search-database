using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using W1EHUB.Core.Model;

namespace W1EHUB.Repo.Data
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new[]
            {
                new User { Id = 1, Email = "abc@email.com", Password = "abc", CreateAt = DateTime.Now }
            });

            modelBuilder.Entity<Region>().HasData(new[]
            {
                // Dont Update any Id's becuase its used in Countries
                new Region { Id = 1, Name= "England", CreateAt = DateTime.Now },
                new Region { Id = 2, Name= "Scotland", CreateAt = DateTime.Now },
                new Region { Id = 3, Name= "Wales", CreateAt = DateTime.Now },
                new Region { Id = 4, Name= "Northern Ireland", CreateAt = DateTime.Now },
            });

            var countryCounter = 1;
            modelBuilder.Entity<Country>().HasData(new[]
            {
                new Country { Id = countryCounter++, RegionId = 1, Name = "North East England", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "North West England", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "Yorkshire and the Humber", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "West Midlands", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "East Midlands", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "East of England", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "South West England", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "London", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 1, Name = "South East England", CreateAt = DateTime.Now },

                new Country { Id = countryCounter++, RegionId = 2, Name = "Highlands and Islands", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 2, Name = "North East Scotland", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 2, Name = "Central Scotland", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 2, Name = "South of Scotland", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 2, Name = "Glasgow", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 2, Name = "Edinburgh and the Lothians", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 2, Name = "West of Scotland", CreateAt = DateTime.Now },

                new Country { Id = countryCounter++, RegionId = 3, Name = "North Wales", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 3, Name = "Mid Wales", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 3, Name = "South Wales", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 3, Name = "Cardiff", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 3, Name = "Swansea", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 3, Name = "Newport", CreateAt = DateTime.Now },

                new Country { Id = countryCounter++, RegionId = 4, Name = "Antrim and Newtownabbey", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Armagh, Banbridge, and Craigavon", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Belfast", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Causeway Coast and Glens", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Derry and Strabane", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Fermanagh and Omagh", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Lisburn and Castlereagh", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Mid and East Antrim", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Mid Ulster", CreateAt = DateTime.Now },
                new Country { Id = countryCounter++, RegionId = 4, Name = "Newry, Mourne, and Down", CreateAt = DateTime.Now },
            });
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<FavoriteCompany> FavoriteCompany { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
