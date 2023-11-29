using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIDCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(UpdateBirdByIDCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _mockDatabase.AllBirds.FirstOrDefault(bird => bird.AnimalID == request.ID)!;

            birdToUpdate.Name = request.UpdatedBird.Name;
            birdToUpdate.CanFly = request.UpdatedBird.CanFly;

            return Task.FromResult(birdToUpdate);
        }
    }
}