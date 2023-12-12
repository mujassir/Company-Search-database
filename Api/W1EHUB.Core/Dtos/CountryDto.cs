namespace W1EHUB.Core.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NumberOfCompanies { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
