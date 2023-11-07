namespace W1EHUB.Core.Model
{
    public class Country: BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
