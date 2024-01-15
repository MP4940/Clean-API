namespace Domain.Models.Animals.Dogs
{
    public class Dog
    {
        public Guid DogID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bark()
        {
            return "Bark";
        }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}