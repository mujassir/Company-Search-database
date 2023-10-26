namespace W1EHUB.Core.Model
{
    public class Project: BaseModel
    {
        public string Title { get; set; }
        public string? Nature { get; set; }
        public string? Type { get; set; }
        public string? Level { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }

        // Foreign key to link to the associated company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }


}
