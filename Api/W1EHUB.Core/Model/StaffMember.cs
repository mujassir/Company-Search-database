namespace W1EHUB.Core.Model
{
    public class StaffMember : BaseModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Foreign key to link to the associated company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }


}
