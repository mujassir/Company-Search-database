using W1EHUB.Core.Model;

namespace W1EHUB.Core.Dtos
{
    public class CompanyProjectDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Certificate { get; set; } = string.Empty;
        public string RunTime { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Votes { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
