
using W1EHUB.Core.Model;

namespace W1EHUB.Core.Dtos
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Website { get; set; }
        public string? Type { get; set; }
        public string OldDetail { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        // Navigation property to represent the staff members associated with the company
        public List<CompanyStaffMemberDto> StaffMembers { get; set; } = new List<CompanyStaffMemberDto>();
    }
}
