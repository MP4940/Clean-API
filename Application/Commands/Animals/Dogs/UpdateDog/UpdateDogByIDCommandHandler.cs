using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIDCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(UpdateDogByIDCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = _mockDatabase.allDogs.FirstOrDefault(dog => dog.AnimalID == request.ID)!;

            dogToUpdate.Name = request.UpdatedDog.Name;

            return Task.FromResult(dogToUpdate);
        }
    }
}
