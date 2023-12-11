using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animals.Dogs
{
    public class Dog
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bark()
        {
            return "Bark";
        }
    }
}