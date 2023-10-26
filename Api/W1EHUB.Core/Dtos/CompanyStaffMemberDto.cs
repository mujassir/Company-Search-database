
namespace W1EHUB.Core.Dtos
{
    public class CompanyStaffMemberDto
    {
        public string Name { get; set; }
        public string Role { get; set; }

        // Foreign key to link to the associated company
        public int CompanyId { get; set; }
    }
}
