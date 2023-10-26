namespace W1EHUB.Core.Model
{
    public class Company: BaseModel
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
        public List<StaffMember> StaffMembers { get; set; } = new List<StaffMember>();
    }


}
