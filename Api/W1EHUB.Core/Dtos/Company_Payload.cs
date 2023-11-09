namespace W1EHUB.Core.Dtos
{
    public class Company_Payload
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CompanyType { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Website { get; set; }
        public string? Type { get; set; }
        public string OldDetail { get; set; }
        public int CategoryId { get; set; }
    }
}
