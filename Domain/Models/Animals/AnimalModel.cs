using Domain.Models.UserAnimal;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animals
{
    public class AnimalModel
    {
        [Key]
        public Guid AnimalID { get; set; }
        public required string Name { get; set; }
        public ICollection<UserAnimalModel> UserAnimals { get; set; }

    }
}