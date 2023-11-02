namespace W1EHUB.Core.Model
{
    public class Category: BaseModel
    {
        public string Name { get; set; }

        public List<Company> Companies { get; set; }
    }


}
