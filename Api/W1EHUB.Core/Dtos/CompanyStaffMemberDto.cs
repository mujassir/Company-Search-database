
namespace W1EHUB.Core.Dtos
{
    public class CompanyStaffMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public CompanyDto? Company { get; set; }

        // Foreign key to link to the associated company
        public int CompanyId { get; set; }
    }
}
