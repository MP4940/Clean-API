using Domain.Models.Animals;
using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.UserAnimal
{
    public class UserAnimalModel
    {
        [Key]
        public Guid Key { get; set; }
        public Guid UserID { get; set; }
        public User? User { get; set; }
        public Guid AnimalID { get; set; }
        public AnimalModel? Animal { get; set; }
    }
}