using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetCatsByWeightBreed
{
    public class GetCatsByWeightBreedQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}