using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetCatsByWeightBreed
{
    public class GetCatsByWeightBreedQueryHandler : IRequestHandler<GetCatsByWeightBreedQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;
        public GetCatsByWeightBreedQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> Handle(GetCatsByWeightBreedQuery request, CancellationToken cancellationToken)
        {
            List<Cat> catsByWeightBreed = await _catRepository.GetCatsByWeightBreed(request.Breed, request.Weight);
            return catsByWeightBreed;
        }
    }
}