using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Cats.DeleteCat
{
    //public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIDCommand, Cat>
    //{
    //    private readonly MockDatabase _mockDatabase;

    //    public DeleteCatByIdCommandHandler(MockDatabase mockDatabase)
    //    {
    //        _mockDatabase = mockDatabase;
    //    }
    //    public Task<Cat> Handle(DeleteCatByIDCommand request, CancellationToken cancellationToken)
    //    {
    //        Cat catToDelete = _mockDatabase.AllCats.FirstOrDefault(cat => cat.DogID == request.ID)!;
    //        _mockDatabase.AllCats.Remove(catToDelete);

    //        // Lite orelevant information som returneras
    //        return Task.FromResult(catToDelete);
    //    }
    //}
}