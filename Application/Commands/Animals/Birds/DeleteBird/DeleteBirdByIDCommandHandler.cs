using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Birds.DeleteBird
{
    //public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIDCommand, Bird>
    //{
    //    private readonly MockDatabase _mockDatabase;

    //    public DeleteBirdByIdCommandHandler(MockDatabase mockDatabase)
    //    {
    //        _mockDatabase = mockDatabase;
    //    }
    //    public Task<Bird> Handle(DeleteBirdByIDCommand request, CancellationToken cancellationToken)
    //    {
    //        Bird birdToDelete = _mockDatabase.AllBirds.FirstOrDefault(bird => bird.DogID == request.ID)!;
    //        _mockDatabase.AllBirds.Remove(birdToDelete);

    //        // Lite orelevant information som returneras
    //        return Task.FromResult(birdToDelete);
    //    }
    //}
}