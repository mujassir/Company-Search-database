namespace W1EHUB.Core.Model
{
    public class Company: BaseModel
    {
        public string Name { get; set; }
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? Type { get; set; }
        public string OldDetail { get; set; }

        // Foreign key to link to the associated company
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Navigation property to represent the staff members associated with the company
        public List<StaffMember> StaffMembers { get; set; } = new List<StaffMember>();
    }


}
