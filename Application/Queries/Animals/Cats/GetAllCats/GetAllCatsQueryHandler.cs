using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetAllCats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly ICatRepository _CatRepository;

        public GetAllCatsQueryHandler(ICatRepository CatRepository)
        {
            _CatRepository = CatRepository;
        }

        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCats = await _CatRepository.GetAllCats();
            return allCats;
        }
    }
}