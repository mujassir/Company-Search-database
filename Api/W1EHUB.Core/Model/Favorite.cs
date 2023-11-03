namespace W1EHUB.Core.Model
{
    public class Favorite: BaseModel
    {
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
