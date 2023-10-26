namespace W1EHUB.Core.Dtos
{
    public class LogInUser_Response
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public int AccessTokenExpiry { get; set; }

    }
}
