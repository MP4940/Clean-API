namespace Domain.Models.Animals.Cats
{
    public class Cat
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool LikesToPlay { get; set; }
    }
}
