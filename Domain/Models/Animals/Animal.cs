using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animals
{
    public class Animal
    {
        [Key]
        public Guid AnimalID { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public List<User>? Users { get; set; }
    }
}