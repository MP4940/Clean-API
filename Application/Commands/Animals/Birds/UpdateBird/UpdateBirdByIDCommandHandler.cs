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
            Bird BirdToUpdate = _mockDatabase.allBirds.FirstOrDefault(Bird => Bird.AnimalID == request.ID)!;

            BirdToUpdate.Name = request.UpdatedBird.Name;
            BirdToUpdate.CanFly = request.UpdatedBird.CanFly;

            return Task.FromResult(BirdToUpdate);
        }
    }
}