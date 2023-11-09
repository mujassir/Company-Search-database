using W1EHUB.Core.Model;

namespace W1EHUB.Core.Dtos
{
    public class CompanyProgramDto
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public string Activity { get; set; }
        public string? ProjectTypes { get; set; }
        public string? Nature { get; set; }

        // Foreign key to link to the associated company
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
