namespace Domain.Models.Animals.Cats
{
    public class Cat : Animal
    {
        public bool LikesToPlay { get; set; }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}