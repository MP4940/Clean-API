using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Dogs.DeleteDog
{
    //public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIDCommand, Dog>
    //{
    //    private readonly MockDatabase _mockDatabase;

    //    public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
    //    {
    //        _mockDatabase = mockDatabase;
    //    }
    //    public Task<Dog> Handle(DeleteDogByIDCommand request, CancellationToken cancellationToken)
    //    {
    //        Dog dogToDelete = _mockDatabase.AllDogs.FirstOrDefault(dog => dog.AnimalID == request.ID)!;
    //        _mockDatabase.AllDogs.Remove(dogToDelete);

    //        // Lite orelevant information som returneras
    //        return Task.FromResult(dogToDelete);
    //    }
    //}
}