using Domain.Models.Animals;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required bool Authorized { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public List<Animal>? Animals { get; set; }
    }
}