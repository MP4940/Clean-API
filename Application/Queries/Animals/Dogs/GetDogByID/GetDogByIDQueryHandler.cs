using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Queries.Animals.Dogs.GetDogByID
{
    public class GetDogByIDQueryHandler : IRequestHandler<GetDogByIDQuery, Dog>
    {
        private readonly IDogRepository _dogRepository;

        public GetDogByIDQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<Dog> Handle(GetDogByIDQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = await _dogRepository.GetDogByID(request.ID);
            return wantedDog;
        }
    }
}