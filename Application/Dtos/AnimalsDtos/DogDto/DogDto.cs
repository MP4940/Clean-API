namespace Application.Dtos.AnimalsDtos.DogDto
{
    public class DogDto : AnimalDto 
    {
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}