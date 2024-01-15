using Domain.Models.Animals.Birds;
using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Dogs;
using Domain.Models.AnimalUsers;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animals
{
    public class Animal
    {
        [Key]
        public Guid AnimalID { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public virtual ICollection<AnimalUser>? AnimalUsers { get; set; }
        public List<Dog>? Dogs { get; set; }
        public List<Cat>? Cats { get; set; }
        public List<Bird>? Birds { get; set; }
    }
}