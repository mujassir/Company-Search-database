namespace W1EHUB.Core.Dtos
{
    public class StaffWithCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCountry { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? CompanyType { get; set; }
        public string CompanyOldDetail { get; set; }
        public string? CompanyCategoryId { get; set; }
        public string? CompanyCategory { get; set; }
    }
}
