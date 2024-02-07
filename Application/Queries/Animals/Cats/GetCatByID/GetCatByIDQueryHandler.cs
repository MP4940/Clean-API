using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetCatByID
{
    public class GetCatByIDQueryHandler : IRequestHandler<GetCatByIDQuery, Cat>
    {
        private readonly ICatRepository _catRepository;

        public GetCatByIDQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(GetCatByIDQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = await _catRepository.GetCatByID(request.ID);
            return wantedCat;
        }
    }
}