using W1EHUB.Core.Model;

namespace W1EHUB.Repo
{
    public class SampleData
    {
        public static SampleDataDto SampleDataJson()
        {
            var companies = new List<Company>();
            var categories = new List<Category>();
            var staffMembers = new List<StaffMember>();
            var users = new List<User>()
            {
                new User {Id = 1, Email = "a@abc.com", Password = "aaa", CreateAt = DateTime.Now},
                new User {Id = 2, Email = "b@abc.com", Password = "bbb", CreateAt = DateTime.Now},
                new User {Id = 3, Email = "c@abc.com", Password = "ccc", CreateAt = DateTime.Now},
                new User {Id = 4, Email = "d@abc.com", Password = "ddd", CreateAt = DateTime.Now},
            };

            for (int i = 1; i <= 10; i++)
            {
                var company = new Company
                {
                    Id = companies.Count() + 1,
                    Country = $"Country {i}",
                    Name = $"Company {i}",
                    Website = $"www.company{i}.com",
                };

                for (int j = 1; j <= 2; j++)
                {
                    var staffMember = new StaffMember
                    {
                        Id = staffMembers.Count() + 1,
                        Name = $"Staff Member {j}",
                        Role = $"Role {j}",
                        CompanyId = company.Id
                    };
                    staffMembers.Add(staffMember);
                }

                companies.Add(company);

                for (int k = 1; k <= 3; k++)
                {
                    var project = new Category
                    {
                        Id = categories.Count() + 1,
                        Name = $"Project {k} for Company {i}",
                    };
                    categories.Add(project);
                }
            }



            return new SampleDataDto()
            {
                Companies = companies,
                Categories = categories,
                StaffMembers = staffMembers,
                Users = users,
            };
        }
    }
    public class SampleDataDto
    {
        public List<Company> Companies { get; set; }
        public List<Category> Categories { get; set; }
        public List<StaffMember> StaffMembers { get; set; }
        public List<User> Users { get; set; }
    }
}
