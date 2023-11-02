using W1EHUB.Core.Model;

namespace W1EHUB.Core.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Company>? Companies { get; set; }
    }
}
