using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Queries.Animals.Dogs.GetDogsByWeightBreed
{
    public class GetDogsByWeightBreedQuery : IRequest<List<Dog>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}