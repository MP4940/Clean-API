using Domain.Models.Animals;
using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.AnimalUsers
{
    public class AnimalUser
    {
        [Key]
        public Guid Key { get; set; }
        public required Guid UserID { get; set; }
        public User? User { get; set; }
        public required Guid AnimalID { get; set; }
        public Animal? Animal { get; set; }
    }
}