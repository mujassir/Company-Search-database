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

            var data = SampleData.SampleDataJson();

            modelBuilder.Entity<Company>().HasData(data.Companies);
            modelBuilder.Entity<Project>().HasData(data.Projects);
            modelBuilder.Entity<StaffMember>().HasData(data.StaffMembers);
            modelBuilder.Entity<User>().HasData(data.Users);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<StaffMember> StaffMember { get; set; }
        public DbSet<User> User { get; set; }
    }
}
