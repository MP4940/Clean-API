using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public AddBirdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToCreate = new()
            {
                AnimalID = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly
            };

            _mockDatabase.allBirds.Add(birdToCreate);

            return Task.FromResult(birdToCreate);
        }
    }
}