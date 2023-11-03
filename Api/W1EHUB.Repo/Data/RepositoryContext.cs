using Microsoft.EntityFrameworkCore;
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
            //var data = SampleData.SampleDataJson();

            //modelBuilder.Entity<Category>().HasData(data.Projects);
            //modelBuilder.Entity<Company>().HasData(data.Companies);
            //modelBuilder.Entity<StaffMember>().HasData(data.StaffMembers);
            //modelBuilder.Entity<User>().HasData(data.Users);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<FavoriteCompany> FavoriteCompany { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
