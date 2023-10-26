
using W1EHUB.Core.Model;

namespace W1EHUB.Core.Dtos
{
    public class CompanyDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string TypeOfCompany { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        // Navigation property to represent the staff members associated with the company
        public List<CompanyStaffMemberDto> StaffMembers { get; set; } = new List<CompanyStaffMemberDto>();
    }
}
