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

        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<FavoriteCompany> FavoriteCompanies { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new[]
            {
                new User { Id = 1, Email = "abc@email.com", Password = "abc", CreateAt = DateTime.Now }
            });
        }
    }
}
