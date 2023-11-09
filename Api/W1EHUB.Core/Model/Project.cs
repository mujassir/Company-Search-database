namespace W1EHUB.Core.Model
{
    public class Project: BaseModel
    {
        public string Title { get; set; } = string.Empty;
        public string? Genre { get; set; } = string.Empty;
        public string? Year { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;
        public string? Certificate { get; set; } = string.Empty;
        public string? RunTime { get; set; } = string.Empty;
        public string? Rating { get; set; } = string.Empty;
        public string? Votes { get; set; } = string.Empty;

        // Foreign key to link to the associated company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
