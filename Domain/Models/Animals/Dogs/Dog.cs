namespace Domain.Models.Animals.Dogs
{
    public class Dog : Animal
    {
        public string Bark()
        {
            return "Bark";
        }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}