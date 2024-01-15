namespace Domain.Models.Animals.Birds
{
    public class Bird
    {
        public Guid BirdID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool CanFly { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}