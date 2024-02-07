using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Queries.Animals.Dogs.GetDogsByWeightBreed
{
    public class GetDogsByWeightBreedQueryHandler : IRequestHandler<GetDogsByWeightBreedQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;
        public GetDogsByWeightBreedQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<List<Dog>> Handle(GetDogsByWeightBreedQuery request, CancellationToken cancellationToken)
        {
            List<Dog> dogsByWeightBreed = await _dogRepository.GetDogsByWeightBreed(request.Breed, request.Weight);
            return dogsByWeightBreed;
        }
    }
}