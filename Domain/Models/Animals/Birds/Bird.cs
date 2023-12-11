namespace Domain.Models.Animals.Birds
{
    public class Bird
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool CanFly { get; set; }
    }
}