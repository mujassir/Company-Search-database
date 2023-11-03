namespace W1EHUB.Core.Model
{
    public class FavoriteCompany: BaseModel
    {
        public int FavoriteId { get; set; }
        public Favorite Favorite { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
