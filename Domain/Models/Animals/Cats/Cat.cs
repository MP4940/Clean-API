namespace Domain.Models.Animals.Cats
{
    public class Cat
    {
        public Guid CatID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool LikesToPlay { get; set; }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}