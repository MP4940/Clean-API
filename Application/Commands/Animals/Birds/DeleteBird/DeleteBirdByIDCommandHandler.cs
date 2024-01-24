using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.DeleteBird
{
    public class DeleteBirdByIDCommandHandler : IRequestHandler<DeleteBirdByIDCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;
        public DeleteBirdByIDCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(DeleteBirdByIDCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _birdRepository.GetBirdByID(request.ID).Result;

            var deletedBird = await _birdRepository.DeleteBird(birdToDelete);

            return deletedBird;
        }
    }
}