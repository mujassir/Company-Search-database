namespace W1EHUB.Core.Model
{
    public class Region: BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
