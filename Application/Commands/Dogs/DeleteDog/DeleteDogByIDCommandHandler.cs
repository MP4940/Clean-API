using Application.Commands.Dogs.DeleteDog;
using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    internal class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIDCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(DeleteDogByIDCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _mockDatabase.allDogs.FirstOrDefault(dog => dog.AnimalID == request.ID)!;            
            _mockDatabase.allDogs.Remove(dogToDelete);

            // Kanske fel return
            return Task.FromResult(dogToDelete);
        }
    }
}