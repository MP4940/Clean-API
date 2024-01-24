using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Queries.Animals.Birds.GetBirdByID
{
    public class GetBirdByIDQueryHandler : IRequestHandler<GetBirdByIDQuery, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public GetBirdByIDQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(GetBirdByIDQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = await _birdRepository.GetBirdByID(request.ID);
            return wantedBird;
        }
    }
}