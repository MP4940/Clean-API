namespace Domain.Models.Users
{
    public class User
    {
        public Guid ID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required bool Authorized { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}