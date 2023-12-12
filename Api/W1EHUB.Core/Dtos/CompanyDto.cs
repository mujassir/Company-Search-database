
namespace W1EHUB.Core.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CompanyType { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Website { get; set; }
        public string? Type { get; set; }
        public string OldDetail { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? FavoriteIds { get; set; }

        // Navigation property to represent the staff members associated with the company
        public List<CompanyStaffMemberDto> StaffMembers { get; set; } = new List<CompanyStaffMemberDto>();
        public List<CompanyProjectDto> Projects { get; set; } = new List<CompanyProjectDto>();
        public List<CompanyProgramDto> Programs { get; set; } = new List<CompanyProgramDto>();
    }
}
