using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animals.Birds
{
    public class Bird : Animal
    {
        public bool CanFly { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}